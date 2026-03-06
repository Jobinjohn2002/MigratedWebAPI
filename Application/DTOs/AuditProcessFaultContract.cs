using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// AuditProcessFaultContract
    /// </summary>
    public class AuditProcessFaultContract
    {
        /// <summary>
        /// Gets or sets ScannedBarcode
        /// </summary>
        public string ScannedBarcode { get; set; }
        /// <summary>
        /// Gets or sets FaultReasonId
        /// </summary>
        public short FaultReasonId { get; set; }
        /// <summary>
        /// Gets or sets Processed
        /// </summary>
        public bool Processed { get; set; }
    }
}
