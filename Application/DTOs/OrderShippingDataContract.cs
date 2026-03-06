using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OrderShippingDataContract
    /// </summary>
    public class OrderShippingDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets ProccesedTurnarounds
        /// </summary>
        public List<ScanAssetDataContract> ProccesedTurnarounds { get; set; }
        public string OrderReference{get; set;}

    }
}