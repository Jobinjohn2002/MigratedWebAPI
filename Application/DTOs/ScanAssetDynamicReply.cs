using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ScanAssetDynamicReply
    /// </summary>
    public class ScanAssetDynamicReply<T> : ScanAssetDataContract
    {
        /// <summary>
        /// Gets or sets Value
        /// </summary>
        public T Value { get; set; }
    }
}
