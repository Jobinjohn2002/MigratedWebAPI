using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OrderReviewItem
    /// </summary>
    public class OrderReviewItem
    {
        /// <summary>
        /// Gets or sets OrderId
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Gets or sets OrderNumber
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary>
        /// Gets or sets AlternateID
        /// </summary>
        public string AlternateID { get; set; }
        /// <summary>
        /// Gets or sets OrderStatus
        /// </summary>
        public string OrderStatus { get; set; }
        /// <summary>
        /// Gets or sets DeliveryDate
        /// </summary>
        public DateTime DeliveryDate { get; set; }
        public DateTime? ProcedureDate { get; set; }
        /// <summary>
        /// Gets or sets Lines
        /// </summary>
        public List<OrderItem> Lines { get; set; }
        /// <summary>
        /// Gets or sets Forecast
        /// </summary>
        public List<StockForecast> Forecast { get; set; }
    }

    /// <summary>
    /// OrderReviewModel
    /// </summary>
    public class OrderReviewModel
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
        public List<OrderReviewItem> Orders { get; set; }

        /// <summary>
        /// Gets or sets ShowGettingStarted
        /// </summary>
        public bool ShowGettingStarted { get; set; }
    }
}