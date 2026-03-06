using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// Describes a Cache Manager implementation
    /// </summary>
    /// <summary>
    /// ICacheManager
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// Stores an object using the specified key
        /// </summary>
        /// <param name="key">The key to store the object with</param>
        /// <param name="obj">The object to store in the cache</param>
        /// <param name="expiration">The duration to store the object for</param>
        /// <param name="absolute">True if absolute expiry, otherwise sliding expiry</param>
        void Store(string key, object obj, TimeSpan expiration, bool absolute);
        
        /// <summary>
        /// Stores an object using a CacheKey
        /// </summary>
        /// <param name="key">The CacheKey to store the object with</param>
        /// <param name="obj">The object to store in the cache</param>
        void Store(CacheKey key, object obj);

        /// <summary>
        /// Tries to fetch an object from the cache
        /// </summary>
        /// <typeparam name="T">The type of object to retrieve</typeparam>
        /// <param name="key">The cache key string to retrieve the object from</param>
        /// <param name="obj">The object returned from the cache</param>
        /// <returns>True if retrieved, otherwise false</returns>
        bool TryFetch<T>(string key, out T obj);

        /// <summary>
        /// Tries to fetch an object from the cache
        /// </summary>
        /// <typeparam name="T">The type of object to retrieve</typeparam>
        /// <param name="key">The CacheKey to retrieve the object from</param>
        /// <param name="obj">The object returned from the cache</param>
        /// <returns>True if retrieved, otherwise false</returns>
        bool TryFetch<T>(CacheKey key, out T obj);

        /// <summary>
        /// Clears the cache of all keys and objects
        /// </summary>
        void Clear();

        /// <summary>
        /// Clears all cache keys that start with the specified string
        /// </summary>
        /// <param name="startsWith">The cache keys to remove that start with the specified string</param>
        void Clear(string startsWith);

        /// <summary>
        /// Clears the specific cache key, and stored item, from the cache.
        /// </summary>
        /// <param name="cacheKey">The cache key to remove from the cache.</param>
        void Clear(CacheKey cacheKey);

        /// <summary>
        /// Clears all cache entries whose key ends with the supplied string
        /// </summary>
        /// <param name="endsWith">The string the cache keys end with</param>
        void ClearEndsWith(string endsWith);
    }
}
