using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SynergyTrakApplicationDataContract
    /// </summary>
    public class SynergyTrakApplicationDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets ClientVersion
        /// </summary>
        public string ClientVersion { get; set; }
        /// <summary>
        /// Gets or sets UseCompression
        /// </summary>
        public bool UseCompression { get; set; }
    }
}