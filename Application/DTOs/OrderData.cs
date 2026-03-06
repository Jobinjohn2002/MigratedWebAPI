using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// OrderData
    /// </summary>
    public class OrderData
    {
        /// <summary>
        /// Gets or sets OrderId
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
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
        /// Gets or sets CreatedById
        /// </summary>
        public int CreatedById { get; set; }
        /// <summary>
        /// Gets or sets OrderNumber
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary>
        /// Gets or sets AlternateId
        /// </summary>
        public string AlternateId { get; set; }
        /// <summary>
        /// Gets or sets CreatedBy
        /// </summary>
        public UserData CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets BatchNumber
        /// </summary>
        public Guid BatchNumber { get; set; }
        public Guid? BatchNumberToUpdate { get; set; }
        /// <summary>
        /// Gets or sets OrderStatus
        /// </summary>
        public OrderStatusData OrderStatus { get; set; }
        /// <summary>
        /// Gets or sets OrderLines
        /// </summary>
        public IEnumerable<OrderLineData> OrderLines { get; set; }
        /// <summary>
        /// Gets or sets UnmatchedOrderLines
        /// </summary>
        public List<HisOrderLineDataContract> UnmatchedOrderLines { get; set; }
        /// <summary>
        /// Gets or sets OrderDates
        /// </summary>
        public IEnumerable<OrderDateData> OrderDates { get; set; }
        /// <summary>
        /// Gets or sets TotalRecords
        /// </summary>
        public int TotalRecords { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
        /// <summary>
        /// Gets or sets TrayCount
        /// </summary>
        public int TrayCount { get; set; }
        /// <summary>
        /// Gets or sets OrderSourceId
        /// </summary>
        public int OrderSourceId { get; set; }
        /// <summary>
        /// Gets or sets NumberOfIssues
        /// </summary>
        public int NumberOfIssues { get; set; }
        public int? HisOrderId { get; set; }     
        /// <summary>
        /// Gets or sets NewOrders
        /// </summary>
        public int NewOrders { get; set; }
        /// <summary>
        /// Gets or sets InProcessOrders
        /// </summary>
        public int InProcessOrders { get; set; }
    }
}