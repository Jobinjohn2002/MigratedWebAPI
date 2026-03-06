using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class ReportCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use ReportCategoryFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public ReportCategory()
        {
            this.Report = new HashSet<Report>();
            this.ChildReportCategories = new HashSet<ReportCategory>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets ReportCategoryId
        /// </summary>
        public byte ReportCategoryId { get; set; }
        /// <summary>
        /// Gets or sets ParentId
        /// </summary>
        public Nullable<byte> ParentId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets IsLive
        /// </summary>
        public bool IsLive { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Report
        /// </summary>
        public virtual ICollection<Report> Report { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ChildReportCategories
        /// </summary>
        public virtual ICollection<ReportCategory> ChildReportCategories { get; set; }
        /// <summary>
        /// Gets or sets ParentReportCategory
        /// </summary>
        public virtual ReportCategory ParentReportCategory { get; set; }
    }
}
