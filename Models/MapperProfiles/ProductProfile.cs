using AutoMapper;
using GS1US.Framework.Domain.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS1US.Framework.API.Models.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, ProductViewModel>()
                .ForMember(target => target.CountryCode, opts => opts.MapFrom(src => src.License.CountryCode))
                .ForMember(target => target.CompanyName, opts => opts.MapFrom(src => src.License.Company))
                .ForMember(target => target.BrandName, opts => opts.MapFrom(src => src.License.BrandName));
            
        }
        
    }
}
