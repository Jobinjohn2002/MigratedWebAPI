using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// OwnerResultData
    /// </summary>
    public class OwnerResultData
    {
        /// <summary>
        /// Gets or sets OwnerId
        /// </summary>
        public int OwnerId { get; set; }
        /// <summary>
        /// Gets or sets TenancyId
        /// </summary>
        public int TenancyId { get; set; }
        /// <summary>
        /// Gets or sets DateTimeFormatId
        /// </summary>
        public int DateTimeFormatId { get; set; }
        /// <summary>
        /// Gets or sets TimeZoneId
        /// </summary>
        public int TimeZoneId { get; set; }

    }
}