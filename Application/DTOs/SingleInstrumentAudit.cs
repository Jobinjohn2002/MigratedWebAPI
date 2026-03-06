using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class SingleInstrumentAudit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use SingleInstrumentAuditFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public SingleInstrumentAudit()
        {
            this.SingleInstrumentAuditLine = new HashSet<SingleInstrumentAuditLine>();
            this.SingleInstrumentAuditProcessFault = new HashSet<SingleInstrumentAuditProcessFault>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets SingleInstrumentAuditId
        /// </summary>
        public int SingleInstrumentAuditId { get; set; }
        /// <summary>
        /// Gets or sets StartedTurnaroundEventId
        /// </summary>
        public int StartedTurnaroundEventId { get; set; }
        /// <summary>
        /// Gets or sets EndedTurnaroundEventId
        /// </summary>
        public Nullable<int> EndedTurnaroundEventId { get; set; }
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets StationId
        /// </summary>
        public int StationId { get; set; }
        /// <summary>
        /// Gets or sets AuditResultTypeId
        /// </summary>
        public Nullable<short> AuditResultTypeId { get; set; }
        /// <summary>
        /// Gets or sets SingleInstrumentExternalAuditId
        /// </summary>
        public string SingleInstrumentExternalAuditId { get; set; }
        /// <summary>
        /// Gets or sets AuditRuleId
        /// </summary>
        public Nullable<int> AuditRuleId { get; set; }
        /// <summary>
        /// Gets or sets AuditLocationCategoryId
        /// </summary>
        public byte AuditLocationCategoryId { get; set; }
    
        /// <summary>
        /// Gets or sets AuditResultType
        /// </summary>
        public virtual AuditResultType AuditResultType { get; set; }
        /// <summary>
        /// Gets or sets AuditRule
        /// </summary>
        public virtual AuditRule AuditRule { get; set; }
        /// <summary>
        /// Gets or sets SingleInstrumentAudit1
        /// </summary>
        public virtual SingleInstrumentAudit SingleInstrumentAudit1 { get; set; }
        /// <summary>
        /// Gets or sets SingleInstrumentAudit2
        /// </summary>
        public virtual SingleInstrumentAudit SingleInstrumentAudit2 { get; set; }
        /// <summary>
        /// Gets or sets Station
        /// </summary>
        public virtual Station Station { get; set; }
        /// <summary>
        /// Gets or sets StationTypeCategory
        /// </summary>
        public virtual StationTypeCategory StationTypeCategory { get; set; }
        /// <summary>
        /// Gets or sets StartingTurnaroundEvent
        /// </summary>
        public virtual TurnaroundEvent StartingTurnaroundEvent { get; set; }
        /// <summary>
        /// Gets or sets EndingTurnaroundEvent
        /// </summary>
        public virtual TurnaroundEvent EndingTurnaroundEvent { get; set; }
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SingleInstrumentAuditLine
        /// </summary>
        public virtual ICollection<SingleInstrumentAuditLine> SingleInstrumentAuditLine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SingleInstrumentAuditProcessFault
        /// </summary>
        public virtual ICollection<SingleInstrumentAuditProcessFault> SingleInstrumentAuditProcessFault { get; set; }
    }
}
