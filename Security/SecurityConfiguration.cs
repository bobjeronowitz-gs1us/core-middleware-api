using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GS1US.Framework.API.Security
{
    public class SecurityConfiguration
    { 
        public static AzureB2CSettings Configure(IServiceCollection services, IConfiguration configuration, IB2CSecurityTasks b2CSecurityTasks)
        {
            var b2cSettings = GetAppSettings(services, configuration);
            ConfigureB2CSecurity(services, configuration, b2cSettings, b2CSecurityTasks);

            return b2cSettings;
        }

        private static void ConfigureB2CSecurity(IServiceCollection services, IConfiguration configuration, 
                                                    AzureB2CSettings b2CSettings, IB2CSecurityTasks b2CSecurityTasks) 
        {
            services.AddAuthentication(AzureADDefaults.JwtBearerAuthenticationScheme)
                .AddAzureADBearer(options => configuration.Bind("AzureAd", options))
                .AddJwtBearer(jwtOptions =>
                {
                    jwtOptions.Authority = b2CSettings.AuthorityUri; // authorityUri;
                jwtOptions.RequireHttpsMetadata = false;
                    jwtOptions.Audience = b2CSettings.ClientId; // Configuration["AzureAdB2C:ClientId"];
                jwtOptions.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = b2CSecurityTasks.AuthenticationFailed,
                        OnChallenge = b2CSecurityTasks.OnChallenge,
                        OnMessageReceived = b2CSecurityTasks.OnMessageReceived,
                        OnTokenValidated = b2CSecurityTasks.OnTokenValidated
                    };
                });
        }

        private static AzureB2CSettings GetAppSettings(IServiceCollection services, IConfiguration configuration) 
        {
            services.Configure<AzureB2CSettings>(configuration.GetSection("AzureAdB2C"));

            var b2cSettings = new AzureB2CSettings();
            configuration.Bind("AzureAdB2C", b2cSettings);

            b2cSettings.TenantUri = $"{b2cSettings.Tenant}.onmicrosoft.com";
            b2cSettings.AuthorityUri = $"https://{b2cSettings.Tenant}.b2clogin.com/tfp/{b2cSettings.TenantUri}/{b2cSettings.Policy}/v2.0/";

            return b2cSettings;
        }
    }
}
