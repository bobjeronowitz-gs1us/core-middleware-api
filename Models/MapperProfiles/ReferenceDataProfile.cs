using AutoMapper;
using GS1US.Framework.API.Models.ReferenceDataEntities;
using GS1US.Framework.Domain.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS1US.Framework.API.Models.MapperProfiles
{
    public class ReferenceDataProfile : Profile
    {
        public ReferenceDataProfile()
        {
            CreateMap<GenericPocoDto, GenericPocoViewModel>();
            CreateMap<ReferenceTableDto, ReferenceEntityViewModel>()
                .ForMember(d => d.Items, opt => opt.MapFrom(s => s.Items));

            CreateMap<GenericPocoViewModel, CountryDataItemViewModel>();
            CreateMap<GenericPocoViewModel, GDDUnitOfMeasureItemViewModel>();
            CreateMap<GenericPocoViewModel, UnitOfMeasureItemViewModel>();
            CreateMap<GenericPocoViewModel, IndustryDataItemViewModel>();
            CreateMap<GenericPocoViewModel, LanguageDataItemViewModel>();
            CreateMap<GenericPocoViewModel, LevelCategoryItemViewModel>();
            CreateMap<GenericPocoViewModel, LevelCategoryIndustryItemViewModel>();
            CreateMap<GenericPocoViewModel, LevelCategoryRuleItemViewModel>();
        }
        
    }
}
