using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum CommonGlobalCacheKey
    {
        SystemSettings = 1,
        SynergyTrakVersion = 50,
        DefectClassifications = 100,
        DefectSeverities = 200,
        DefectStatuses = 300,
        CustomerDefectStatuses = 400,
        LoanSetStatuses = 500,
        EnquiryStatuses = 600,
        FastTrackStatuses = 700,
        OrderStatuses = 800,
        DefectSources = 900,
        DefectResponsibilities = 1000,
        QuarantineReasons = 1100,
        UserCategories = 1200,
        EventTypes = 1300,
        UsageStatuses = 1400,
        MaintenanceReportStatuses = 1500,
        MaintenanceTypes = 1600,
        MaintenanceInstrumentStatuses = 1700,
        TraysIdentifiable = 1800,
        AvailableCultures = 1900,
        ItemTypes = 2000,
        ChangeControlNoteStatuses = 2100,
    }

    /// <summary>
    /// GlobalCacheKey
    /// </summary>
    public class GlobalCacheKey : CacheKey
    {
        private const string CacheKeyPrefix = "Global_";
        private const string CacheKeyFormat = CacheKeyPrefix + "{0}";
        private GlobalCacheKey()
        {
        }

        /// <summary>
        /// ToString operation
        /// </summary>
        public override string ToString()
        {
            return CacheKeyFormat.FormatWith(Key);
        }

        /// <summary>
        /// Creates a global cache key with an absolute expiry of 10 minutes
        /// </summary>
        /// <param name="commonKey">The global common key to access the cache with</param>
        /// <returns>A global cache key with an absolute expiry of 10 minutes</returns>
        /// <summary>
        /// Create operation
        /// </summary>
        public static GlobalCacheKey Create(CommonGlobalCacheKey commonKey)
        {
            return Create(commonKey, new TimeSpan(0, 10, 0), true);
        }

        /// <summary>
        /// Creates a global cache key with the specified absolute/sliding expiry
        /// </summary>
        /// <param name="commonKey">The global common key to access the cache with</param>
        /// <param name="expiry">The cache expiry</param>
        /// <param name="absolute">Absolute expiry (true) or sliding expiry (false)</param>
        /// <returns>A global cache key with the specified absolute/sliding expiry</returns>
        /// <summary>
        /// Create operation
        /// </summary>
        public static GlobalCacheKey Create(CommonGlobalCacheKey commonKey, TimeSpan expiry, bool absolute = true)
        {
            return new GlobalCacheKey
            {
                Key = commonKey.ToString("d"),
                Expiry = expiry,
                Absolute = absolute
            };
        }

        /// <summary>
        /// ClearCache operation
        /// </summary>
        public static void ClearCache(ICacheManager cache)
        {
            if (cache == null)
            {
                return;
            }

            cache.Clear(CacheKeyPrefix);
        }
    }
}
