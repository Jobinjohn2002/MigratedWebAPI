using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class UserReport
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use UserReportFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public UserReport()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets UserReportId
        /// </summary>
        public int UserReportId { get; set; }
        /// <summary>
        /// Gets or sets ReportId
        /// </summary>
        public short ReportId { get; set; }
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
        /// <summary>
        /// Gets or sets OwnerReportAccessId
        /// </summary>
        public int OwnerReportAccessId { get; set; }
    
        /// <summary>
        /// Gets or sets Report
        /// </summary>
        public virtual Report Report { get; set; }
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// Gets or sets OwnerReportAccess
        /// </summary>
        public virtual OwnerReportAccess OwnerReportAccess { get; set; }
    }
}
