using AutoMapper;
using GS1US.Framework.DAL.Services.Entities;
using System.Collections.Generic;

namespace GS1US.Framework.Domain.Services.Models.MapperProfiles
{
    public class ReferenceDataProfile : Profile
    {
        public ReferenceDataProfile()
        {
            CreateMap<GenericEntity, GenericPocoDto>();
            CreateMap<ReferenceTable, ReferenceTableDto>();
        }
    }
}
