using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class SterilisationTestReportStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use SterilisationTestReportStatusFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public SterilisationTestReportStatus()
        {
            this.SterilisationTestReport = new HashSet<SterilisationTestReport>();
            this.SterilisationTestReportAuditHistory = new HashSet<SterilisationTestReportAuditHistory>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets SterilisationTestReportStatusId
        /// </summary>
        public int SterilisationTestReportStatusId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SterilisationTestReport
        /// </summary>
        public virtual ICollection<SterilisationTestReport> SterilisationTestReport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SterilisationTestReportAuditHistory
        /// </summary>
        public virtual ICollection<SterilisationTestReportAuditHistory> SterilisationTestReportAuditHistory { get; set; }
    }
}
