using GS1US.Framework.Common.Logging;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace GS1US.Framework.Common.HttpMessageHandlers
{
    public class ApimHttpMessageHandler : DelegatingHandler
    {
    
            private readonly IGS1USAppInsightsLogger _logger;
            private const string HEADER_APIM_CONNECTION_NAME = "Ocp-Apim-Connection-Name";

            public ApimHttpMessageHandler(IGS1USAppInsightsLogger logger)
            {
                _logger = logger;
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                            CancellationToken cancellationToken)
            {

                var apimConnection = GetHeaderValue(request, HEADER_APIM_CONNECTION_NAME, "NO_CONNECTION_NAME");

                var operationGuid = "APIMCall" + new Guid().ToString(); ;
                //using (var operation = _logger.BeginScope<HttpRequestMessage>(request, operationGuid))
                //{

                var response = await base.SendAsync(request, cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var error = JObject.Parse(jsonContent);
                    string errorId = null, errorTitle = null, errorDetail = null;
                    if (error != null)
                    {
                        errorId = error["Id"]?.ToString();
                        errorTitle = error["Title"]?.ToString();
                        errorDetail = error["Detail"]?.ToString();
                    }

                    // Set properties of containing telemetry item--for example:
                    // operation.Telemetry.ResponseCode = ((int)response.StatusCode).ToString();

                    var ex = new Exception("APIM Failure");

                    ex.Data.Add("API Route", $"GET {request.RequestUri}");
                    ex.Data.Add("API Status", (int)response.StatusCode);
                    ex.Data.Add("API ErrorId", errorId);
                    ex.Data.Add("API Title", errorTitle);
                    ex.Data.Add("API Detail", errorDetail);

                    //_logger.LogWarning("API Error when calling {APIRoute}: {APIStatus},", $"GET {request.RequestUri}",
                    //    (int)response.StatusCode);
                    _logger.Warn("API Error when calling {0}: {1}," +
                        " {2} - {3} - {4}",
                        $"GET {request.RequestUri}", (int)response.StatusCode,
                        errorId, errorTitle, errorDetail);
                    throw ex;
                }

                _logger.Info("API called {0}: {1}," +
                       " {2} - {3}",
                       $"GET {request.RequestUri}", (int)response.StatusCode,
                       operationGuid, apimConnection);
                return response;
                // }

            }

            private string GetHeaderValue(HttpRequestMessage request, string headerKey, string defaultValue)
            {
                var headerValue = defaultValue;
                try 
                {
                    headerValue = request.Headers.GetValues(headerKey).ToArray()[0];
                }
                catch { }
                return headerValue;
            }
        }
    }
