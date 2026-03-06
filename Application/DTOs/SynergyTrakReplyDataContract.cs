using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// SynergyTrakReplyDataContract
    /// </summary>
    public class SynergyTrakReplyDataContract : BaseReplyDataContract
    {
        public byte[] Bytes { get; set; }
        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public string Type { get; set; }
    }
}
