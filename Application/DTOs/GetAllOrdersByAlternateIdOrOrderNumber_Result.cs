using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class GetAllOrdersByAlternateIdOrOrderNumber_Result
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
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime DeliveryDate { get; set; }
        /// <summary>
        /// Gets or sets CreatedById
        /// </summary>
        public int CreatedById { get; set; }
        /// <summary>
        /// Gets or sets AlternateId
        /// </summary>
        public string AlternateId { get; set; }
        public System.Guid BatchNumber { get; set; }
        public Nullable<System.DateTime> ProcedureDate { get; set; }
        /// <summary>
        /// Gets or sets OrderNumber
        /// </summary>
        public string OrderNumber { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        /// <summary>
        /// Gets or sets ModifiedById
        /// </summary>
        public Nullable<int> ModifiedById { get; set; }
        /// <summary>
        /// Gets or sets OrderSourceId
        /// </summary>
        public int OrderSourceId { get; set; }
        /// <summary>
        /// Gets or sets CaseCartNumber
        /// </summary>
        public string CaseCartNumber { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets StatusText
        /// </summary>
        public string StatusText { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public string DeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public string Customer { get; set; }
        /// <summary>
        /// Gets or sets ModifyingUser
        /// </summary>
        public string ModifyingUser { get; set; }
        public Nullable<System.DateTime> LastModified { get; set; }
    }
}
