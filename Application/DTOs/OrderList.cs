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
    /// OrderList
    /// </summary>
    public class OrderList
    {
        /// <summary>
        /// Gets or sets Orders
        /// </summary>
        public List<OrderData> Orders { get; set; }
        /// <summary>
        /// Gets or sets OrderQuickFilters
        /// </summary>
        public Dictionary<OrderStatusIdentifier, int> OrderQuickFilters { get; set; }
    }
}
