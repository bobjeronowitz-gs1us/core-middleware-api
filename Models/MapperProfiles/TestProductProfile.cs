using AutoMapper;
using GS1US.Framework.Domain.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS1US.Framework.API.Models.MapperProfiles
{
    public class TestProductProfile : Profile
    {
        public TestProductProfile()
        {
            CreateMap<ProductDto, TestProductViewModel>()
                .ForMember(dest => dest.BrandName, opts => opts.MapFrom(src => src.License.BrandName));
        }
        
    }
}
