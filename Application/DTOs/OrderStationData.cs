using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// OrderStationData
    /// </summary>
    public class OrderStationData
    {
        /// <summary>
        /// Gets or sets the Order Id
        /// </summary>
        /// <value>Order Id</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets OrderId
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
        /// <summary>
        /// Gets or sets OrderStatus
        /// </summary>
        public string OrderStatus { get; set; }
        /// <summary>
        /// Gets or sets OrderStatusId
        /// </summary>
        public int OrderStatusId { get; set; }
        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets DeliveryDate
        /// </summary>
        public DateTime DeliveryDate { get; set; }
        public DateTime? ProcedureDate { get; set; }
        /// <summary>
        /// Gets or sets CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets OrderNumber
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary>
        /// Gets or sets AlternateId
        /// </summary>
        public string AlternateId { get; set; }
        /// <summary>
        /// Gets or sets BatchNumber
        /// </summary>
        public Guid BatchNumber { get; set; }
        /// <summary>
        /// Gets or sets Trays
        /// </summary>
        public int Trays { get; set; }
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public string Customer { get; set; }
        /// <summary>
        /// Gets or sets Owner
        /// </summary>
        public int Owner { get; set; }
        /// <summary>
        /// Gets or sets OrderLines
        /// </summary>
        public List<OrderLineData> OrderLines { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }

    }
}
