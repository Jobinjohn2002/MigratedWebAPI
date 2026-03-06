using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// EndoscopyScanDataContract
    /// </summary>
    public class EndoscopyScanDataContract : ScanAssetDataContract
    {
        /// <summary>
        /// Gets or sets Endoscope
        /// </summary>
        public EndoscopeDataContract Endoscope { get; set; }
    }
}
