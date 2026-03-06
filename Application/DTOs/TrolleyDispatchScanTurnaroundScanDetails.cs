using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TrolleyDispatchScanTurnaroundScanDetails
    /// </summary>
    public class TrolleyDispatchScanTurnaroundScanDetails : ScanDetails
    {
        /// <summary>
        /// Gets or sets TrolleyExternalId
        /// </summary>
        public string TrolleyExternalId { get; set; }
        /// <summary>
        /// Gets or sets TrolleyContainerInstanceId
        /// </summary>
        public int TrolleyContainerInstanceId { get; set; }
        /// <summary>
        /// Gets or sets RemoveFromPreviousTrolley
        /// </summary>
        public bool RemoveFromPreviousTrolley { get; set; }
        public bool? StartNewTrolleyTurnaround { get; set; }
    }
}
