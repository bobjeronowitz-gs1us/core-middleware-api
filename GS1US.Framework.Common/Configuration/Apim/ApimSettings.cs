using System.Collections.Generic;

namespace GS1US.Framework.Common.Configuration.Apim
{
    public class ApimSettings
    {
        public bool UseHttpMessageHandler { get; set; }
        public List<ApimConnection> ApimConnections { get; set; }
    }

    public class ApimConnection
    {
        public string ConnectionName { get; set; }
        public string SubscriptionKey { get; set; }
        public string ApimRootUri { get; set; }
    }
    
}
