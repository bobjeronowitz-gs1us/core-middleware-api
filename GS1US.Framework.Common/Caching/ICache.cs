using System;

namespace GS1US.Framework.Common.Caching
{
    public interface ICache
    {
        bool Add(string key, object value);
        bool Add(string key, object value, TimeSpan timeout);
        bool Contains(string key);
        object Get(string key);
        bool Put(string key, object value);
        bool Put(string key, object value, TimeSpan timeout);
        bool Remove(string key);
    }
}
