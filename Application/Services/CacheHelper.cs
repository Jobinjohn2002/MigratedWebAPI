using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class CacheHelper
    {
        /// <summary>
        /// Check for item in cache
        /// </summary>
        /// <summary>
        /// Exists operation
        /// </summary>
        public static bool Exists(string key)
        {
            return HttpRuntime.Cache[key] != null;
        }

        /// <summary>
        /// Retrieve cached item
        /// </summary>
        public static bool Get<T>(string key, out T value)
        {
            try
            {
                if (!Exists(key))
                {
                    value = default(T);
                    return false;
                }

                value = (T)HttpRuntime.Cache.Get(key);
            }
            catch
            {
                value = default(T);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Add cached item
        /// </summary>
        public static T Add<T>(string key, T value, int absoluteExpirySeconds)
        {
            if (HttpRuntime.Cache.Get(key) == null)
            {
                HttpRuntime.Cache.Add(key, value, null, DateTime.UtcNow.AddSeconds(absoluteExpirySeconds), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
            }
            return (T)HttpRuntime.Cache.Get(key);
        }

        /// <summary>
        /// RemoveFromCache operation
        /// </summary>
        public static void RemoveFromCache()
        {
            var cacheEnum = HttpRuntime.Cache.GetEnumerator();
            while(cacheEnum.MoveNext())
            {
                HttpRuntime.Cache.Remove(cacheEnum.Key.ToString());
            }
        }
    }
}
