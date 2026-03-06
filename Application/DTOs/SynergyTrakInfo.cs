using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SynergyTrakInfo
    /// </summary>
    public class SynergyTrakInfo
    {
        /// <summary>
        /// Gets or sets FileLocation
        /// </summary>
        public string FileLocation { get; set; }
        /// <summary>
        /// Gets or sets Version
        /// </summary>
        public Version Version { get; set; }
    }
}