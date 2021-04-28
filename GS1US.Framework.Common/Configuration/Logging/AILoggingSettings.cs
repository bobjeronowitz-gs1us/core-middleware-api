using System.Collections.Generic;

namespace GS1US.Framework.Common.Configuration.Logging
{
    public class AILoggingSettings
    {
        public List<AppInsightsConnection> AppInsightsConnections { get; set; }
    }

    public class AppInsightsConnection
    {
        public string ConnectionName { get; set; }
        public string InstrumentationKey { get; set; }
    }
}
