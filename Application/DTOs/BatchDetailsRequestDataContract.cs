using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BatchDetailsRequestDataContract
    /// </summary>
    public class BatchDetailsRequestDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets BatchId
        /// </summary>
        public int BatchId { get; set; }
        /// <summary>
        /// Gets or sets IsUnpassed
        /// </summary>
        public bool IsUnpassed { get; set; }
        public int? StationTypeId { get; set; }
    }
}