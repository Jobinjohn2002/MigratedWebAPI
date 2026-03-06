using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// StationScanModel
    /// </summary>
    public class StationScanModel
    {
        /// <summary>
        /// Gets or sets ScannedStation
        /// </summary>
        public string ScannedStation { get; set; }
        /// <summary>
        /// Gets or sets ReturnUrl
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}