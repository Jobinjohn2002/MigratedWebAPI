using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// EndoscopyLocationScanAssetDataContract
    /// </summary>
    public class EndoscopyLocationScanAssetDataContract : ScanAssetDataContract
    {
        /// <summary>
        /// Gets or sets EndoscopyLocationDataContract
        /// </summary>
        public EndoscopyLocationDataContract EndoscopyLocationDataContract { get; set; }
        /// <summary>
        /// Gets or sets ModifiedEndoscope
        /// </summary>
        public EndoscopeDataContract ModifiedEndoscope { get; set; }
    }
}
