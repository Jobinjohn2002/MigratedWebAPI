using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class StationTypeCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use StationTypeCategoryFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public StationTypeCategory()
        {
            this.StationType = new HashSet<StationType>();
            this.AuditRule = new HashSet<AuditRule>();
            this.SingleInstrumentAudit = new HashSet<SingleInstrumentAudit>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets StationTypeCategoryId
        /// </summary>
        public byte StationTypeCategoryId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets DispalyOrder
        /// </summary>
        public byte DispalyOrder { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets StationType
        /// </summary>
        public virtual ICollection<StationType> StationType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets AuditRule
        /// </summary>
        public virtual ICollection<AuditRule> AuditRule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SingleInstrumentAudit
        /// </summary>
        public virtual ICollection<SingleInstrumentAudit> SingleInstrumentAudit { get; set; }
    }
}
