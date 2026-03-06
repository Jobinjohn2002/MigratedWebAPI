using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FailedScanDataContract
    /// </summary>
    public class FailedScanDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets Input
        /// </summary>
        public string Input { get; set; }
        /// <summary>
        /// Gets or sets ScanType
        /// </summary>
        public short ScanType { get; set; }
        public int? LocationId { get; set; }
        public short? EventType { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}