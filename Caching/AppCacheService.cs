using GS1US.Framework.Common.Authentication;
using GS1US.Framework.Common.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS1US.Framework.API.Caching
{
    public class AppCacheService : IAppCacheService
    {
        private IMemoryCache MemoryCache { get; }
        private IClaimsPrincipalService ClaimsPrincipalService { get; }
        private const string CACHE_GENERAL = "gs1_us_";
        private const string CACHE_GENERIC = "9999_9999_";
        public AppCacheService(IMemoryCache memoryCache, IClaimsPrincipalService claimsPrincipalService)
        {
            this.MemoryCache = memoryCache;
            this.ClaimsPrincipalService = claimsPrincipalService;
        }


        public void CacheRecord<T>(string cacheKey, T record) 
        {   
            this.MemoryCache.Put($"{CACHE_GENERAL}{GetUserIdentity()}{cacheKey}", record, new System.TimeSpan(0, 20, 0));
        }

        public void CacheRecords<T>(string cacheKey, List<T> records)
        {
            this.MemoryCache.Put($"{CACHE_GENERAL}{GetUserIdentity()}{cacheKey}", records, new System.TimeSpan(0, 20, 0));
        }

        public T GetCachedRecord<T>(string cacheKey) 
        {
            return (T)this.MemoryCache.Get($"{CACHE_GENERAL}{GetUserIdentity()}{cacheKey}");
        }

        public IEnumerable<T> GetCachedRecords<T>(string cacheKey) 
        {
            yield return (T)this.MemoryCache.Get($"{CACHE_GENERAL}{GetUserIdentity()}{cacheKey}");
        }

        private string GetUserIdentity() 
        {
            var identityName = this.ClaimsPrincipalService.GetIdentityName();
            return !string.IsNullOrWhiteSpace(identityName) ? $"{identityName}_" : CACHE_GENERIC;
        }

    }
}
