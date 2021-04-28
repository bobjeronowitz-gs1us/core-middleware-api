using GS1US.Framework.API.Authentication;
using GS1US.Framework.API.Caching;
using GS1US.Framework.API.Logging;
using GS1US.Framework.Common.Authentication;
using GS1US.Framework.Common.Caching;
using GS1US.Framework.Common.DataSerializer;
using GS1US.Framework.Common.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GS1US.Framework.API.DependencyInjection
{
    public static class ConfigureCommonServices
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IGS1USAppInsightsLogger, GS1AILogger>();
            services.TryAddSingleton<ILoggingContextService, LoggingContextService>();
            services.TryAddSingleton<IClaimsPrincipalService, ClaimsPrincipalService>();
            services.TryAddSingleton<IAppCacheService, AppCacheService>();
            services.TryAddSingleton<IMemoryCache, MemoryCache>();
            services.TryAddSingleton<IDataSerializer, DataSerializer>();

            return services;
        }
    }
}