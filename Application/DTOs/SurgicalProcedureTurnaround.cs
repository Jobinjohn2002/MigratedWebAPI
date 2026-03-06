using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Represents an item that is scanned at a surgical procedure
    /// </summary>
    /// <summary>
    /// SurgicalProcedureTurnaround
    /// </summary>
    public class SurgicalProcedureTurnaround
    {
        /// <summary>
        /// The turnaround serial number of the item that has been scanned at the surgical procedure
        /// </summary>
        [Required]
        /// <summary>
        /// Gets or sets Turnaround
        /// </summary>
        public long Turnaround { get; set; }

        /// <summary>
        /// The usage state of the scanned turnaround
        /// </summary>
        [Required]
        /// <summary>
        /// Gets or sets UsageStatus
        /// </summary>
        public SurgicalProcedureTurnaroundUsageStatus UsageStatus { get; set; }
    }
}