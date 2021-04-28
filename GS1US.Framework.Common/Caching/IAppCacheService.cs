using System;
using System.Collections.Generic;
using System.Text;

namespace GS1US.Framework.Common.Caching
{
    public interface IAppCacheService
    {
        void CacheRecord<T>(string cacheKey, T record);
        void CacheRecords<T>(string cacheKey, List<T> records);
        T GetCachedRecord<T>(string cacheKey);
        IEnumerable<T> GetCachedRecords<T>(string cacheKey);
    }
}
