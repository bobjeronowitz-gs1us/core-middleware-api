using AutoMapper;
using GS1US.Framework.DAL.Services.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS1US.Framework.Domain.Services.Models.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductLicense, ProductLicenseDto>();
        }
    }
}
