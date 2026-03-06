using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DeniedEventDataContract
    /// </summary>
    public class DeniedEventDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets LastProcessEventTypeId
        /// </summary>
        public short LastProcessEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets ScanType
        /// </summary>
        public short ScanType { get; set; }
        /// <summary>
        /// Gets or sets LocationId
        /// </summary>
        public int LocationId { get; set; }
        public short? EventType { get; set; }
        public int? ErrorCode { get; set; }
    }
}