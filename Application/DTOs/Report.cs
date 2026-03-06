using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class Report
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use ReportFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public Report()
        {
            this.UserReport = new HashSet<UserReport>();
            this.FavouriteReport = new HashSet<FavouriteReport>();
            this.OwnerReportAccess = new HashSet<OwnerReportAccess>();
            this.ReportOutputType = new HashSet<ReportOutputType>();
            this.Role = new HashSet<Role>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets ReportId
        /// </summary>
        public short ReportId { get; set; }
        /// <summary>
        /// Gets or sets ReportCategoryId
        /// </summary>
        public byte ReportCategoryId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets URL
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// Gets or sets IsLive
        /// </summary>
        public bool IsLive { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
        /// <summary>
        /// Gets or sets ReportTypeId
        /// </summary>
        public byte ReportTypeId { get; set; }
        /// <summary>
        /// Gets or sets DefaultReportOutputTypeId
        /// </summary>
        public int DefaultReportOutputTypeId { get; set; }
    
        /// <summary>
        /// Gets or sets ReportCategory
        /// </summary>
        public virtual ReportCategory ReportCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets UserReport
        /// </summary>
        public virtual ICollection<UserReport> UserReport { get; set; }
        /// <summary>
        /// Gets or sets ReportType
        /// </summary>
        public virtual ReportType ReportType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets FavouriteReport
        /// </summary>
        public virtual ICollection<FavouriteReport> FavouriteReport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets OwnerReportAccess
        /// </summary>
        public virtual ICollection<OwnerReportAccess> OwnerReportAccess { get; set; }
        /// <summary>
        /// Gets or sets DefaultReportOutputType
        /// </summary>
        public virtual ReportOutputType DefaultReportOutputType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ReportOutputType
        /// </summary>
        public virtual ICollection<ReportOutputType> ReportOutputType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Role
        /// </summary>
        public virtual ICollection<Role> Role { get; set; }
    }
}
