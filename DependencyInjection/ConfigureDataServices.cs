using GS1US.Framework.Common.Configuration.Apim;
using GS1US.Framework.DAL.Services.Implementations;
using GS1US.Framework.DAL.Services.Interfaces;
using GS1US.Framework.DAL.Services.MockRepositories;
using GS1US.Framework.DAL.Services.MockRepositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GS1US.Framework.API.DependencyInjection
{
    public static class ConfigureDataServices
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductsDataStore, ProductsDataStore>();
            services.AddSingleton<IValuesDataStore, ValuesDataStore>();
            services.AddSingleton<IReferenceDataStore, ReferenceDataStore>();
            services.AddSingleton<IReferenceDataAccessService, ReferenceDataAccessService>();
            services.AddSingleton<IMessageCenterDataStore, MessageCenterDataStore>();
            services.AddSingleton<IApimConfigService, ApimConfigService>();
            return services;
        }
    }
}
