using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ServiceParameterModel
    /// </summary>
    public class ServiceParameterModel
    {
        /// <summary>
        /// Gets or sets Ticks
        /// </summary>
        public long Ticks { get; set; }
        /// <summary>
        /// Gets or sets Token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Gets or sets Filename
        /// </summary>
        public string Filename { get; set; }
        public byte[] Data { get; set; }
    }
}