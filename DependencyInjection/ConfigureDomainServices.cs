using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GS1US.Framework.Domain.Services.Interfaces;
using GS1US.Framework.Domain.Services.Implementations;

namespace GS1US.Framework.API.DependencyInjection
{
    public static class ConfigureDomainServices
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.TryAddSingleton<IProductDomainService, ProductDomainService>();
            services.TryAddSingleton<IReferenceDataDomainService, ReferenceDataDomainService>();
            services.TryAddSingleton<IValuesDomainService, ValuesDomainService>();
            services.TryAddSingleton<IMessageCenterDomainService, MessageCenterDomainService>();
        
            return services;
        }
    }
}
