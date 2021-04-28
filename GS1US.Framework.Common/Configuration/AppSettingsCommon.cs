using System;
using System.Collections.Generic;
using System.Text;

namespace GS1US.Framework.Common.Configuration
{
    public class AppSettingsCommon
    {
        public class Environments
        {
            public const string Dev = "dev";
            public const string Prod = "prod";
            public const string QA = "qa";
            public const string Staging = "staging";
        }

        public string AppInstanceId { get; set; }

        public string EnvironmentId { get; set; }

        public bool UseCors { get; set; }

        public string CorsOrigins { get; set; }
        public string[] CorsOriginUrls { get; set; }
        public string CorsPolicy { get; set; }

        public string IdentityApiInstrumentationKey { get; set; }
        
        public bool AutoFlushToAppInsight { get; set; }
    }
}
