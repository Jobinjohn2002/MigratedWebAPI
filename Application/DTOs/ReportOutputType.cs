using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class ReportOutputType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use ReportOutputTypeFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public ReportOutputType()
        {
            this.FavouriteReport = new HashSet<FavouriteReport>();
            this.DefaultReport = new HashSet<Report>();
            this.Report = new HashSet<Report>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets ReportOutputTypeId
        /// </summary>
        public int ReportOutputTypeId { get; set; }
        /// <summary>
        /// Gets or sets OrderPosition
        /// </summary>
        public int OrderPosition { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets ReportingString
        /// </summary>
        public string ReportingString { get; set; }
        /// <summary>
        /// Gets or sets IsArchived
        /// </summary>
        public bool IsArchived { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets FavouriteReport
        /// </summary>
        public virtual ICollection<FavouriteReport> FavouriteReport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets DefaultReport
        /// </summary>
        public virtual ICollection<Report> DefaultReport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Report
        /// </summary>
        public virtual ICollection<Report> Report { get; set; }
    }
}
