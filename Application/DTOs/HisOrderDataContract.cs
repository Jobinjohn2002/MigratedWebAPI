using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// HisOrderDataContract
    /// </summary>
    public class HisOrderDataContract
    {
        /// <summary>
        /// Gets or sets HisOrderId
        /// </summary>
        public int HisOrderId { get; set; }
        /// <summary>
        /// Gets or sets OrderRef
        /// </summary>
        public string OrderRef { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public string DeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public string Customer { get; set; }
        public DateTime? ProcedureDate { get; set; }
        /// <summary>
        /// Gets or sets Surgeon
        /// </summary>
        public string Surgeon { get; set; }
        /// <summary>
        /// Gets or sets ProcedureName
        /// </summary>
        public string ProcedureName { get; set; }
        /// <summary>
        /// Gets or sets Notes
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Gets or sets CreatedByUserId
        /// </summary>
        public int CreatedByUserId { get; set; }
        /// <summary>
        /// Gets or sets CreatedByFullname
        /// </summary>
        public string CreatedByFullname { get; set; }
        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets UnMatchedOrderLines
        /// </summary>
        public IEnumerable<HisOrderLineDataContract> UnMatchedOrderLines { get; set; }
        /// <summary>
        /// Gets or sets MatchedOrderLines
        /// </summary>
        public IEnumerable<HisOrderMatchedOrderLineDataContract> MatchedOrderLines { get; set; }
        public int? LatestActiveOrderId { get; set; }
    }
}
