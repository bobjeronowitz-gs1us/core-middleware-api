using GS1US.Framework.Common.Logging;
using Newtonsoft.Json;
using System;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace GS1US.Framework.Common.Caching
{
    public class MemoryCache : IMemoryCache
    {
        private static readonly System.Runtime.Caching.MemoryCache _cache;
        private readonly TimeSpan _cacheItemSlidingExpirationDefault = new TimeSpan(1, 0, 0);
        private IGS1USAppInsightsLogger Logger { get; }

        static MemoryCache()
        {
            _cache = new System.Runtime.Caching.MemoryCache("GS1Cache");
        }

        public MemoryCache(IGS1USAppInsightsLogger logger)
        {
            Logger = logger;
        }

        public bool Add(string key, object value)
        {
            return Add(key, value, _cacheItemSlidingExpirationDefault);
        }

        public bool Add(string key, object value, TimeSpan slidingExpiration)
        {
            CacheItemPolicy policy = GetCacheItemPolicy(slidingExpiration);
            var entry = _cache.AddOrGetExisting(key, value, policy);
            if (entry == null)
            {
                LogInfo("Cache entry added", key, value);
                return true;
            }

            LogInfo("Cache entry not added", key, value, entry);
            return false;
        }

        public object Get(string key)
        {
            var value = _cache.Get(key);
            LogInfo(value != null ? "Cache entry returned" : "Cache entry not returned", key, true);

            return value;
        }

        public bool Contains(string key)
        {
            var contains = _cache.Contains(key);
            LogInfo(contains ? "Cache entry exists" : "Cache entry does not exist", key);

            return contains;
        }

        public bool Put(string key, object value)
        {
            return Put(key, value, _cacheItemSlidingExpirationDefault);
        }

        public bool Put(string key, object value, TimeSpan slidingExpiration)
        {
            CacheItemPolicy policy = GetCacheItemPolicy(slidingExpiration);
            _cache.Set(key, value, policy);
            LogInfo("Cache entry updated", key, value);
            return true;
        }

        public bool Remove(string key)
        {
            var value = _cache.Remove(key);
            if (value == null)
            {
                LogInfo("Cache entry not removed", key);
                return false;
            }

            LogInfo("Cache entry removed", key);

            return true;
        }

        private void CacheItemRemovedCallback(CacheEntryRemovedArguments args)
        {
            LogInfo($"Cache entry removed. CacheItem Removed Reason: {args.RemovedReason.ToString()};", args.CacheItem.Key);
        }

        private CacheItemPolicy GetCacheItemPolicy(TimeSpan slidingExpiration)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            if (slidingExpiration.Equals(TimeSpan.Zero))
            {
                slidingExpiration = _cacheItemSlidingExpirationDefault;
            }

            policy.SlidingExpiration = slidingExpiration;
            policy.RemovedCallback = CacheItemRemovedCallback;
            return policy;
        }


        private void LogInfo(string message, string key)
        {
            if (Logger.IsInfoEnabled)
            {
                Task.Run(() =>
                {
                    Logger.Info(message + $": Key: {key}; Cache Count:  {_cache.GetCount()} ");
                });
            }
        }

        private void LogInfo(string message, string key, object value, bool logValueLengthOnly = false)
        {
            if (Logger.IsInfoEnabled)
            {
                Task.Run(() =>
                {
                    var serializedValue = JsonConvert.SerializeObject(value);
                    if (!logValueLengthOnly)
                        Logger.Info($"{message}; Key: {key}; Cache Count:  {_cache.GetCount()}; Value Length: {serializedValue?.Length}{Environment.NewLine}Value: {serializedValue}");
                    else
                        Logger.Info($"{message}; Key: {key}; Cache Count:  {_cache.GetCount()}; Value Length: {serializedValue?.Length}{Environment.NewLine}Value: NOT LOGGED");
                });
            }
        }

        private void LogInfo(string message, string key, object value, object existingValue)
        {
            if (Logger.IsInfoEnabled)
            {
                Task.Run(() =>
                {
                    var serializedValue = JsonConvert.SerializeObject(value);
                    var serializedExistingValue = JsonConvert.SerializeObject(existingValue);

                    Logger.Info($"{message}; Key: {key}; Cache Count:  {_cache.GetCount()}; Value Length: {serializedValue?.Length}; Existing Value Length: {serializedExistingValue?.Length}{Environment.NewLine}Value: {serializedValue}{Environment.NewLine}Existing Value:{serializedExistingValue}");
                });
            }
        }
    }
}
