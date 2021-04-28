using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS1US.Framework.Common.Configuration.Apim
{
    
     public class ApimConfigService : IApimConfigService
    {
        private readonly ApimSettings _apimSettings;

        public ApimConfigService(IOptions<ApimSettings> apimSettings)
        {
            _apimSettings = apimSettings?.Value;
        }
        
        public void AddApimSettings(ApimConnection apimConnection)
        {
            _apimSettings.ApimConnections.Add(apimConnection);
        }


        public string GetApimSubscriptionKey(string connectionName)
        {

            var connection = _apimSettings?.ApimConnections?.Find(c => c.ConnectionName == connectionName);
            return connection?.SubscriptionKey;
        }

        public string GetApimRoot(string connectionName)
        {
            var connection = _apimSettings?.ApimConnections?.Find(c => c.ConnectionName == connectionName);
            return connection?.ApimRootUri;
        }
    }
}
