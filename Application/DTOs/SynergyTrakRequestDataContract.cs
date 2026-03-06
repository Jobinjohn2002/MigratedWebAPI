using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// SynergyTrakRequestDataContract
    /// </summary>
    public class SynergyTrakRequestDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets Version
        /// </summary>
        public string Version { get; set; }
        public byte[] Bytes { get; set; }
        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets RequestType
        /// </summary>
        public ProcessRequestType RequestType { get; set; }
    }
}
