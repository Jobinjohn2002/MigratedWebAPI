using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Describes a Cache Key
    /// </summary>
    public abstract class CacheKey
    {
        /// <summary>
        /// The expiry duration
        /// </summary>
        public TimeSpan Expiry
        {
            get;
            set;
        }

        /// <summary>
        /// True if the key has absolute expiry, otherwise sliding expiry
        /// </summary>
        public bool Absolute
        {
            get;
            set;
        }

        /// <summary>
        /// The cache key
        /// </summary>
        public string Key 
        { 
            get; 
            set; 
        }
    }
}
