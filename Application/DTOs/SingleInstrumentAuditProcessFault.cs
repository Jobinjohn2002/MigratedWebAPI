using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class SingleInstrumentAuditProcessFault
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use SingleInstrumentAuditProcessFaultFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public SingleInstrumentAuditProcessFault()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets SingleInstrumentAuditProcessFaultId
        /// </summary>
        public int SingleInstrumentAuditProcessFaultId { get; set; }
        /// <summary>
        /// Gets or sets SingleInstrumentAuditId
        /// </summary>
        public int SingleInstrumentAuditId { get; set; }
        /// <summary>
        /// Gets or sets ScannedBarcodeValue
        /// </summary>
        public string ScannedBarcodeValue { get; set; }
        /// <summary>
        /// Gets or sets AuditProcessFaultReasonId
        /// </summary>
        public short AuditProcessFaultReasonId { get; set; }
    
        /// <summary>
        /// Gets or sets AuditProcessFaultReason
        /// </summary>
        public virtual AuditProcessFaultReason AuditProcessFaultReason { get; set; }
        /// <summary>
        /// Gets or sets SingleInstrumentAudit
        /// </summary>
        public virtual SingleInstrumentAudit SingleInstrumentAudit { get; set; }
    }
}
