using GS1US.Framework.Common.Configuration.Apim;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GS1US.Framework.API.Configuration
{
    public class ApimSettingsConfiguration
    { 
        public static ApimSettings Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApimSettings>(configuration.GetSection("ApimSettings"));

            var apimSettings = new ApimSettings();
            configuration.Bind("ApimSettings", apimSettings);

            return apimSettings;
        }
    }
}
