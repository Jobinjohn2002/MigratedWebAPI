using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ReprintRequest
    /// </summary>
    public class ReprintRequest : BaseRequestDataContract
    {
        public int? TurnaroundId { get; set; }
        public int? TurnaroundEventId { get; set; }
        public int? BatchId { get; set; }
        public int? PrintHistoryId { get; set; }
        /// <summary>
        /// Gets or sets ScanDC
        /// </summary>
        public ScanAssetDataContract ScanDC { get; set; }
        /// <summary>
        /// Gets or sets FetchDataWithoutPrinting
        /// </summary>
        public bool FetchDataWithoutPrinting { get; set; }
    }
}
