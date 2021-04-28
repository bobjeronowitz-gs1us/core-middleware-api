using AutoMapper;
using GS1US.Framework.DAL.Services.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS1US.Framework.Domain.Services.Models.MapperProfiles
{
    public class ValueProfile : Profile
    {
        public ValueProfile()
        {
            CreateMap<ValuesString, ValueStringDto>();
        }
    }
}
