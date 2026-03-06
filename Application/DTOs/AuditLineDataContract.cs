using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// AuditLineDataContract
    /// </summary>
    public class AuditLineDataContract
    {
        /// <summary>
        /// Gets or sets ItemInstanceIdentifierType
        /// </summary>
        public short ItemInstanceIdentifierType { get; set;}
        public int? ItemInstanceId { get; set; }
        /// <summary>
        /// Gets or sets IsRequiredBySpecification
        /// </summary>
        public bool IsRequiredBySpecification { get; set; }
        /// <summary>
        /// Gets or sets AuditLineStatusTypeId
        /// </summary>
        public short AuditLineStatusTypeId { get; set; }
        public short? AuditLineExceptionReasonId { get; set; }
        /// <summary>
        /// Gets or sets ScannedBarcode
        /// </summary>
        public string ScannedBarcode { get; set; }
        /// <summary>
        /// Gets or sets Processed
        /// </summary>
        public bool Processed { get; set; }
    }
}
