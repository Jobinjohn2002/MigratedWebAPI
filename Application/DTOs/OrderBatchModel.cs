using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OrderBatchModel
    /// </summary>
    public class OrderBatchModel
    {
        /// <summary>
        /// Gets or sets BatchId
        /// </summary>
        public Guid BatchId { get; set; }

        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public OrderDetailsConfirmation Confirmation { get; set; }

        /// <summary>
        /// Gets or sets Orders
        /// </summary>
        public List<Order> Orders { get; set; }
    }
}