using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// ItemProcessingDetails
    /// </summary>
    public class ItemProcessingDetails
    {
        /// <summary>
        /// Gets or sets ScanDC
        /// </summary>
        public ScanAssetDataContract ScanDC { get; set; }
        /// <summary>
        /// Gets or sets DeleteTurnaroundWh
        /// </summary>
        public bool DeleteTurnaroundWh { get; set; }
    }
}