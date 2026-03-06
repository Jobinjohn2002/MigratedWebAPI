using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class Printer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use PrinterFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public Printer()
        {
            this.StationPrinter = new HashSet<StationPrinter>();
            this.UserPrinter = new HashSet<UserPrinter>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets PrinterId
        /// </summary>
        public int PrinterId { get; set; }
        /// <summary>
        /// Gets or sets ArchivedUserId
        /// </summary>
        public Nullable<int> ArchivedUserId { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
        /// <summary>
        /// Gets or sets PrinterTypeId
        /// </summary>
        public byte PrinterTypeId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        public Nullable<System.DateTime> Archived { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
    
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// Gets or sets PrinterType
        /// </summary>
        public virtual PrinterType PrinterType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets StationPrinter
        /// </summary>
        public virtual ICollection<StationPrinter> StationPrinter { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets UserPrinter
        /// </summary>
        public virtual ICollection<UserPrinter> UserPrinter { get; set; }
        /// <summary>
        /// Gets or sets Facility
        /// </summary>
        public virtual Facility Facility { get; set; }
    }
}
