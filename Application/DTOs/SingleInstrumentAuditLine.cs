using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class SingleInstrumentAuditLine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use SingleInstrumentAuditLineFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public SingleInstrumentAuditLine()
        {
            this.ItemInstanceHistory = new HashSet<ItemInstanceHistory>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets SingleInstrumentAuditLineId
        /// </summary>
        public int SingleInstrumentAuditLineId { get; set; }
        /// <summary>
        /// Gets or sets SingleInstrumentAuditId
        /// </summary>
        public int SingleInstrumentAuditId { get; set; }
        /// <summary>
        /// Gets or sets ItemInstanceIdentifierTypeId
        /// </summary>
        public short ItemInstanceIdentifierTypeId { get; set; }
        /// <summary>
        /// Gets or sets ItemInstanceId
        /// </summary>
        public Nullable<int> ItemInstanceId { get; set; }
        /// <summary>
        /// Gets or sets IsRequiredBySpecification
        /// </summary>
        public bool IsRequiredBySpecification { get; set; }
        /// <summary>
        /// Gets or sets AuditLineStatusTypeId
        /// </summary>
        public short AuditLineStatusTypeId { get; set; }
        /// <summary>
        /// Gets or sets AuditLineExceptionReasonId
        /// </summary>
        public Nullable<short> AuditLineExceptionReasonId { get; set; }
        /// <summary>
        /// Gets or sets ScannedBarcodeValue
        /// </summary>
        public string ScannedBarcodeValue { get; set; }
    
        /// <summary>
        /// Gets or sets AuditLineExceptionReason
        /// </summary>
        public virtual AuditLineExceptionReason AuditLineExceptionReason { get; set; }
        /// <summary>
        /// Gets or sets AuditLineStatusType
        /// </summary>
        public virtual AuditLineStatusType AuditLineStatusType { get; set; }
        /// <summary>
        /// Gets or sets ItemInstance
        /// </summary>
        public virtual ItemInstance ItemInstance { get; set; }
        /// <summary>
        /// Gets or sets ItemInstanceIdentifierType
        /// </summary>
        public virtual ItemInstanceIdentifierType ItemInstanceIdentifierType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ItemInstanceHistory
        /// </summary>
        public virtual ICollection<ItemInstanceHistory> ItemInstanceHistory { get; set; }
        /// <summary>
        /// Gets or sets SingleInstrumentAudit
        /// </summary>
        public virtual SingleInstrumentAudit SingleInstrumentAudit { get; set; }
    }
}
