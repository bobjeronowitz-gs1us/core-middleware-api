using AutoMapper;
using GS1US.Framework.Domain.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS1US.Framework.API.Models.MapperProfiles
{
    public class MessageCenterProfile : Profile
    {
        public MessageCenterProfile()
        {
            CreateMap<MessageCenterCountDto, MessageCenterCountViewModel>();
            
        }
        
    }
}
