using GS1US.Framework.Common.Logging;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.DependencyInjection;

namespace GS1US.Framework.API.Configuration
{
    /// <summary>
    /// Use to configure the Application Insights logger with the App Instrumentation Key
    /// and flush setting
    /// </summary>
    public class AppInsightsLoggerConfiguration
    { 
        public static void Configure(AppSettings configuration, IGS1USAppInsightsLogger logger)
        {
            if (null != logger)
            {   
                var config = TelemetryConfiguration.CreateDefault();
                config.InstrumentationKey = configuration.IdentityApiInstrumentationKey;

                logger.SetLoggingConfiguration(configuration.IdentityApiInstrumentationKey, configuration.AutoFlushToAppInsight);
                logger.InitializeTelemetryClient(new TelemetryClient(config));
            }

        }
    }
}
