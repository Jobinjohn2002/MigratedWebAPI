using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Order Info.
    /// </summary>
    /// <summary>
    /// OrderInfo
    /// </summary>
    public class OrderInfo
    {
        /// <summary>
        /// The unique identifier for this resource.
        /// </summary>
        /// <summary>
        /// Gets or sets OrderNumber
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary>
        /// Your reference number for the order, e.g. your internal system reference number to link to this record.
        /// </summary>
        /// <summary>
        /// Gets or sets YourReference
        /// </summary>
        public string YourReference { get; set; }
        /// <summary>
        /// The hospital.
        /// </summary>
        /// <summary>
        /// Gets or sets Hospital
        /// </summary>
        public string Hospital { get; set; }
        /// <summary>
        /// The location.
        /// </summary>
        /// <summary>
        /// Gets or sets Location
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// The date the order was created.
        /// </summary>
        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// The order delivery date.
        /// </summary>
        /// <summary>
        /// Gets or sets DeliveryDate
        /// </summary>
        public DateTime DeliveryDate { get; set; }
        /// <summary>
        /// The procedure date the order is required for.
        /// </summary>
        public DateTime? ProcedureDate { get; set; }
        /// <summary>
        /// The order lines.
        /// </summary>
        /// <summary>
        /// Gets or sets OrderLines
        /// </summary>
        public List<OrderLineInfo> OrderLines { get; set; }
        /// <summary>
        /// The order status.
        /// </summary>
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Indicates if the order is complete.
        /// </summary>
        /// <summary>
        /// Gets or sets Complete
        /// </summary>
        public bool Complete { get; set; }
    }
}