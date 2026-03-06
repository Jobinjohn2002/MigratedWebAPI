using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class SterilisationTestReportAuditHistory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use SterilisationTestReportAuditHistoryFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public SterilisationTestReportAuditHistory()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets SterilisationTestReportAuditHistoryId
        /// </summary>
        public int SterilisationTestReportAuditHistoryId { get; set; }
        /// <summary>
        /// Gets or sets SterilisationTestReportId
        /// </summary>
        public int SterilisationTestReportId { get; set; }
        /// <summary>
        /// Gets or sets SterilisationTestReportStatusId
        /// </summary>
        public int SterilisationTestReportStatusId { get; set; }
        public System.DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }
    
        /// <summary>
        /// Gets or sets SterilisationTestReport
        /// </summary>
        public virtual SterilisationTestReport SterilisationTestReport { get; set; }
        /// <summary>
        /// Gets or sets SterilisationTestReportStatus
        /// </summary>
        public virtual SterilisationTestReportStatus SterilisationTestReportStatus { get; set; }
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
    }
}
