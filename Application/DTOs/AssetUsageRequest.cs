using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// AssetUsageRequest
    /// </summary>
    public class AssetUsageRequest
    {
        [Required]
        /// <summary>
        /// Gets or sets Assets
        /// </summary>
        public List<AssetUsageRequestLine> Assets { get; set; }
    }

    /// <summary>
    /// AssetUsageRequestLine
    /// </summary>
    public class AssetUsageRequestLine
    {
        /// <summary>
        /// The number of times the assets was used since the specified usage date
        /// </summary>
        [Required]
        [MaxLength(50)]
        /// <summary>
        /// Gets or sets AssetNumber
        /// </summary>
        public string AssetNumber { get; set; }

        /// <summary>
        /// Used to find usage information occuring after the date specified
        /// </summary>
        [Required]
        /// <summary>
        /// Gets or sets UsageSince
        /// </summary>
        public DateTime UsageSince { get; set; }
    }
}
