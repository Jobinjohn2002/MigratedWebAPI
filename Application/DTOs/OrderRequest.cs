using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Order Request.
    /// </summary>
    /// <summary>
    /// OrderRequest
    /// </summary>
    public class OrderRequest
    {
        /// <summary>
        /// The hospital this order is for.
        /// </summary>
        [Required]
        [MaxLength(50)]
        /// <summary>
        /// Gets or sets Hospital
        /// </summary>
        public string Hospital { get; set; }
        /// <summary>
        /// The delivery location for this order.
        /// </summary>
        [Required]
        [MaxLength(50)]
        /// <summary>
        /// Gets or sets Location
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// The order templates to add to this order.
        /// </summary>
        /// <summary>
        /// Gets or sets Templates
        /// </summary>
        public List<string> Templates { get; set; }
        /// <summary>
        /// The individual products, with quantities, to add to this order.
        /// </summary>
        /// <summary>
        /// Gets or sets Products
        /// </summary>
        public List<OrderRequestLine> Products { get; set; }
        /// <summary>
        /// The delivery date of the order.
        /// </summary>
        [Required]
        /// <summary>
        /// Gets or sets DeliveryDate
        /// </summary>
        public DateTime DeliveryDate { get; set; }
        /// <summary>
        /// The procedure date of the order.
        /// </summary>
        public DateTime? ProcedureDate { get; set; }
        /// <summary>
        /// Your reference number for the order, e.g. your internal system reference number to link to this record.
        /// </summary>
        [MaxLength(64)]
        /// <summary>
        /// Gets or sets YourReference
        /// </summary>
        public string YourReference { get; set; }
    }
}