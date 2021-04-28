using GS1US.Framework.Common.Configuration.Apim;
using GS1US.Framework.Common.HttpMessageHandlers;
using GS1US.Framework.Common.HttpNamedClients;
using GS1US.Framework.Common.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace GS1US.Framework.API.Configuration
{
    public class HttpNamedClientConfiguration
    {
        public static void Configure(IServiceCollection services, ApimSettings apimSettings)
        {
            var apimConnections = new Dictionary<string, ApimConnection>();

            // HttpClient for ProductCreateManage APIM
            apimConnections.Add(NamedHttpClients.ApimContentProxy, apimSettings?.ApimConnections.Find(c => c.ConnectionName == ApimConnectionNames.productCreateManage));

            // HttpClient for First Party APIM
            apimConnections.Add(NamedHttpClients.ApimFirstParty, apimSettings?.ApimConnections.Find(c => c.ConnectionName == ApimConnectionNames.firstParty));

            // HttpClient for Ref Data w/o APIM
            apimConnections.Add(NamedHttpClients.NonApimRefData, apimSettings?.ApimConnections.Find(c => c.ConnectionName == ApimConnectionNames.NonApimRefData));

            foreach (var cnt in apimConnections)
            {
                if (apimSettings.UseHttpMessageHandler)
                {
                    // this swallows certificate errors
                    services.AddHttpClient(cnt.Key, c =>
                            {
                                c.BaseAddress = new Uri(cnt.Value.ApimRootUri);
                                c.DefaultRequestHeaders.Add("Accept", "application/json");
                                c.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", cnt.Value.SubscriptionKey);
                                c.DefaultRequestHeaders.Add("Ocp-Apim-Connection-Name", cnt.Value.ConnectionName);
                            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                            {
                                ClientCertificateOptions = ClientCertificateOption.Manual,
                                ServerCertificateCustomValidationCallback =
                                                (httpRequestMessage, cert, certChain, policyErrors) =>
                                                {
                                                    return true;
                                                }
                            });
                } else {
                    services.AddHttpClient(cnt.Key, c =>
                    {   
                        c.BaseAddress = new Uri(cnt.Value.ApimRootUri);
                        c.DefaultRequestHeaders.Add("Accept", "application/json");
                        c.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", cnt.Value.SubscriptionKey);
                        c.DefaultRequestHeaders.Add("Ocp-Apim-Connection-Name", cnt.Value.ConnectionName);
                    }).AddHttpMessageHandler(provider =>
                         {
                             var aiLogger = provider.GetRequiredService<IGS1USAppInsightsLogger>();
                             return new ApimHttpMessageHandler(aiLogger);
                         });

                }
            }
        }
       
    }
}
