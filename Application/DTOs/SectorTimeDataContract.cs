using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SectorTimeDataContract
    /// </summary>
    public class SectorTimeDataContract
    {
        /// <summary>
        /// Gets or sets TimeMs
        /// </summary>
        public long TimeMs { get; set; }
        /// <summary>
        /// Gets or sets Tag
        /// </summary>
        public string Tag { get; set; }
    }
}