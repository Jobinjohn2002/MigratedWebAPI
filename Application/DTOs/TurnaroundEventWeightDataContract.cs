using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TurnaroundEventWeightDataContract
    /// </summary>
    public class TurnaroundEventWeightDataContract : ScanDetails
    {
        /// <summary>
        /// Gets or sets Weight
        /// </summary>
        public decimal Weight { get; set; }
        /// <summary>
        /// Gets or sets CancelledWeighing
        /// </summary>
        public bool CancelledWeighing { get; set; }
    }
}
