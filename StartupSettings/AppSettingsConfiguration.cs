using GS1US.Framework.API.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace GS1US.Framework.API.StartupSettings
{
    public class AppSettingsConfiguration
    {
        public static readonly string CORS_POLICY = "AccessControlCors";

        public static AppSettings Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

            var appSettings = new AppSettings();
            configuration.Bind("AppSettings", appSettings);
            appSettings.CorsOriginUrls = appSettings.CorsOrigins.Split(',');
            appSettings.CorsOriginUrls = appSettings.CorsOriginUrls.Select(x => x == null ? null : x.Trim()).ToArray();
            appSettings.UseCors = appSettings.CorsOriginUrls.Any() && appSettings.CorsOriginUrls[0] != "";
            appSettings.CorsPolicy = CORS_POLICY;

            return appSettings;
        }
    }
}
