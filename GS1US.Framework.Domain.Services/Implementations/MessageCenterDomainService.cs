using AutoMapper;
using GS1US.Framework.DAL.Services.MockRepositories.Interfaces;
using GS1US.Framework.DAL.Services.Entities;
using GS1US.Framework.Domain.Services.Interfaces;
using GS1US.Framework.Domain.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using GS1US.Framework.Common.Logging;
using GS1US.Framework.Common.Authentication;
using GS1US.Framework.Common.Caching;

namespace GS1US.Framework.Domain.Services.Implementations
{
    public class MessageCenterDomainService : IMessageCenterDomainService
    {
        private const string CACHE_KEY = "MSG_CENTER_COUNTS";
        private IGS1USAppInsightsLogger Logger { get; }
        private IMessageCenterDataStore MessageCenterDataStore { get; }
        private IMapper Mapper { get; }
        private IClaimsPrincipalService ClaimsPrincipalService { get; }
        private IAppCacheService AppCacheService { get; }

        public MessageCenterDomainService(IMessageCenterDataStore msgCenterDataStore,
                                            IClaimsPrincipalService claimsPrincipalService,
                                            IAppCacheService appCacheService,
                                            IMapper mapper, IGS1USAppInsightsLogger logger)
        {
            this.MessageCenterDataStore = msgCenterDataStore;
            this.Logger = logger;
            this.Mapper = mapper;
            this.ClaimsPrincipalService = claimsPrincipalService;
            this.AppCacheService = appCacheService;
        }

        public MessageCenterCountDto GetMessageCenterCountsForUser(string userId = null)
        {
            var messageCenterCounts = new MessageCenterCountDto();
            try
            {
                messageCenterCounts.UserId = userId ?? this.ClaimsPrincipalService.GetIdentityName();
                // see if it is already in cache
                var counts = this.AppCacheService.GetCachedRecord<MessageCenterCountDto>(CACHE_KEY);
                if (counts != null)
                    return counts;

                messageCenterCounts.AlertCount = this.MessageCenterDataStore.GetAlertCountForUser();
                messageCenterCounts.MessageCount = this.MessageCenterDataStore.GetMessageCountForUser();
                messageCenterCounts.DownloadCount = this.MessageCenterDataStore.GetDownloadCountForUser();
                messageCenterCounts.LocationCount = this.MessageCenterDataStore.GetLocationCountForUser();
                
                this.AppCacheService.CacheRecord<MessageCenterCountDto>(CACHE_KEY, messageCenterCounts);

                return messageCenterCounts;
            }
            catch (Exception e)
            {
                this.Logger.Error(e, "Failed to get values data");
            }

            return null;
        }
    }
}
