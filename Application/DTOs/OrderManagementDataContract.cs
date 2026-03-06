using System;
using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OrderManagementDataContract
    /// </summary>
    public class OrderManagementDataContract : ScanAssetDataContract
    {
        /// <summary>
        /// Gets or sets OrderId
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets IsComplete
        /// </summary>
        public bool IsComplete { get; set; }
        /// <summary>
        /// Gets or sets AlternateId
        /// </summary>
        public string AlternateId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryDate
        /// </summary>
        public DateTime DeliveryDate { get; set; }
        public DateTime? ProcedureDate { get; set; }
        /// <summary>
        /// Gets or sets OrderNumber
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary>
        /// Gets or sets OrderLines
        /// </summary>
        public List<OrderLineDataContract> OrderLines { get; set; }
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Gets or sets AlreadyOnAnotherOrderOrderNumber
        /// </summary>
        public string AlreadyOnAnotherOrderOrderNumber { get; set; }
        /// <summary>
        /// Gets or sets OrderSource
        /// </summary>
        public OrderSourceIdentifier OrderSource { get; set; }
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public OrderStatusIdentifier Status { get; set; }
        /// <summary>
        /// Gets or sets RelatedOrders
        /// </summary>
        public List<OrderManagementDataContract> RelatedOrders { get; set; }
        public DateTime? DispatchedDate { get; set; }
        public int? SurgeonId { get; set; }
        /// <summary>
        /// Gets or sets SurgeonName
        /// </summary>
        public string SurgeonName { get; set; }
        public int? SurgicalProcedureTypeId { get; set; }
        /// <summary>
        /// Gets or sets SurgicalProcedureTypeName
        /// </summary>
        public string SurgicalProcedureTypeName { get; set; }
        /// <summary>
        /// Gets or sets CaseCartNumber
        /// </summary>
        public string CaseCartNumber { get; set; }
        /// <summary>
        /// Gets or sets NotesCount
        /// </summary>
        public int NotesCount { get; set; }
    }
}
