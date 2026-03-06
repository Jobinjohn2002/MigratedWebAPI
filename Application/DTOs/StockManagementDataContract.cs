using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// StockManagementDataContract
    /// </summary>
    public class StockManagementDataContract<T> : BaseReplyDataContract where T : ScanAssetDataContract, new()
    {
        public int? LocationId { get; set; }
        /// <summary>
        /// Gets or sets EventType
        /// </summary>
        public short EventType { get; set; }
        /// <summary>
        /// Gets or sets ScannedAssets
        /// </summary>
        public List<T> ScannedAssets { get; set; }
    }
}

