using AutoMapper;
using GS1US.Framework.API.ControllerServices.Interfaces;
using GS1US.Framework.API.Models;
using GS1US.Framework.Common.Logging;
using GS1US.Framework.Domain.Services.Interfaces;
using GS1US.Framework.Domain.Services.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GS1US.Framework.API.ControllerServices
{
    public class MessageCenterControllerService : IMessageCenterControllerService
    {
        private IGS1USAppInsightsLogger Logger { get; }
        private IMapper Mapper { get; }
        private IMessageCenterDomainService ValuesDomainService { get; }

        public MessageCenterControllerService(IMessageCenterDomainService valuesDomainService,
                                        IMapper mapper,
                                        IGS1USAppInsightsLogger logger)
        {
            ValuesDomainService = valuesDomainService;
            Logger = logger;
            this.Mapper = mapper;
        }

        public MessageCenterCountViewModel GetMessageCenterCountsForUser(string UserId = null)
        {
            try
            {
                var response = ValuesDomainService.GetMessageCenterCountsForUser(UserId);
                

                if (response == null)
                {
                    return null;
                }
                
                // TBD: DELETE ONLY FOR TESTING
                Logger.Error(new Exception("Testing Correlation"), "Failed to get values data");
                return MapValueStrings(response);
            }
            catch (HttpRequestException e)
            {
                Logger.Error(e, "Failed to get values data");
            }
            
            return null;
        }

        private MessageCenterCountViewModel MapValueStrings(MessageCenterCountDto messageCenterCounts) 
        {
            return this.Mapper.Map<MessageCenterCountViewModel>(messageCenterCounts);
        }
    }
}
