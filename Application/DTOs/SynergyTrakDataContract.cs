using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SynergyTrakDataContract
    /// </summary>
    public class SynergyTrakDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets ClientName
        /// </summary>
        public string ClientName { get; set; }
        /// <summary>
        /// Gets or sets XML
        /// </summary>
        public string XML { get; set; }
        public int? StationId { get; set; }
    }
}