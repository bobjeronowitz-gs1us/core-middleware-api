using GS1US.Framework.Common.HttpNamedClients;
using GS1US.Framework.Common.Logging;
using GS1US.Framework.DAL.Services.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GS1US.Framework.DAL.Services.Implementations
{
    public class ReferenceDataAccessService : DalApiServiceBase, IReferenceDataAccessService
    {
        private IGS1USAppInsightsLogger Logger { get; }
        private IHttpClientFactory HttpClientFactory { get; }
        private const string REF_ENDPOINT = "reference";
        private const string NAMED_HTTP_CLIENT = NamedHttpClients.NonApimRefData;

        public ReferenceDataAccessService(IHttpClientFactory httpClientFactory, IGS1USAppInsightsLogger logger)
        {   
            this.HttpClientFactory = httpClientFactory;
            this.Logger = logger;
        }

        public async Task<string> GetAllReferenceData() 
        {  
            return await GetJsonFromEndPoint(REF_ENDPOINT);
        }

        /// <summary>
        /// Uses the APIM settings to get the external endpoint
        /// </summary>
        /// <param name="verticalCategory"></param>
        /// <returns></returns>
        public async Task<string> GetReferenceDataByVertical(string verticalCategory) 
        {
            return await GetJsonFromEndPoint($"{REF_ENDPOINT}?verticalCategory={verticalCategory}");
        }

        /// <summary>
        /// Consolidated call using HttpNamedClient
        /// </summary>
        /// <param name="endPoint"></param>
        /// <returns></returns>
        private async Task<string> GetJsonFromEndPoint(string endPoint) 
        {
            try
            {
                var namedClient = this.HttpClientFactory.CreateClient(NAMED_HTTP_CLIENT);
                var request = new HttpRequestMessage(HttpMethod.Get, namedClient.BaseAddress + endPoint);
                var response = await namedClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    var phrase = response.ReasonPhrase;
                    var code = (int)response.StatusCode;
                    var msg = $"Error Retrieving data from APIM: Code: {phrase} {code}";
                    this.Logger.Error(new Exception(message: msg), $"Error Retrieving data from APIM: {endPoint}");
                    throw new Exception(msg);
                }

                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                this.Logger.Error(ex, $"Error Retrieving data from APIM: {endPoint}");
                throw ex;
            }
        }

    }
}
