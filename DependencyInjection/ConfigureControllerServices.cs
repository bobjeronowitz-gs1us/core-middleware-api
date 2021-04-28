using GS1US.Framework.API.ControllerServices;
using GS1US.Framework.API.ControllerServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GS1US.Framework.API.DependencyInjection
{
    public static class ConfigureControllerServices
    {
        public static IServiceCollection AddControllerServices(this IServiceCollection services)
        {
            services.TryAddSingleton<IProductControllerService, ProductControllerService>();
            services.AddSingleton<IValuesControllerService, ValuesControllerService>();
            services.AddSingleton<IReferenceDataControllerService, ReferenceDataControllerService>();
            services.AddSingleton<IMessageCenterControllerService, MessageCenterControllerService>();
            services.AddSingleton<ILoggerControllerService, LoggerControllerService > ();
            return services;
        }
    }
}
