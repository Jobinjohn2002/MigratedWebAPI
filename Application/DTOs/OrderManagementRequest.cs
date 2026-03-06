using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OrderManagementRequest
    /// </summary>
    public class OrderManagementRequest : BaseRequestDataContract
    {
        public int? OrderId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets OrderStatusId
        /// </summary>
        public int OrderStatusId { get; set; }
        /// <summary>
        /// Gets or sets AlternateId
        /// </summary>
        public string AlternateId { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? ProcedureDate { get; set; }
        /// <summary>
        /// Gets or sets InitialOrderLine
        /// </summary>
        public ScanDetails InitialOrderLine { get; set; }
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Gets or sets CaseCartNumber
        /// </summary>
        public string CaseCartNumber { get; set; }
        [IgnoreDataMember]
        public Guid? BatchNumber { get; set; }

        [IgnoreDataMember]
        public int? OrderSourceId { get; set; }

        [IgnoreDataMember]
        public int? HisOrderId { get; set; }
    }
}