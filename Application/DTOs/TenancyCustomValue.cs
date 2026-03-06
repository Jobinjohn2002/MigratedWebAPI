using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class TenancyCustomValue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use TenancyCustomValueFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public TenancyCustomValue()
        {
            this.Defect = new HashSet<Defect>();
            this.Defect1 = new HashSet<Defect>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets TenancyCustomValueId
        /// </summary>
        public int TenancyCustomValueId { get; set; }
        /// <summary>
        /// Gets or sets TenancyId
        /// </summary>
        public int TenancyId { get; set; }
        /// <summary>
        /// Gets or sets RowId
        /// </summary>
        public int RowId { get; set; }
        /// <summary>
        /// Gets or sets Value
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Gets or sets CreatedById
        /// </summary>
        public int CreatedById { get; set; }
        public System.DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets ArchivedById
        /// </summary>
        public Nullable<int> ArchivedById { get; set; }
        public Nullable<System.DateTime> ArchiveDate { get; set; }
        /// <summary>
        /// Gets or sets CustomisableTableId
        /// </summary>
        public int CustomisableTableId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Defect
        /// </summary>
        public virtual ICollection<Defect> Defect { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Defect1
        /// </summary>
        public virtual ICollection<Defect> Defect1 { get; set; }
        /// <summary>
        /// Gets or sets Tenancy
        /// </summary>
        public virtual Tenancy Tenancy { get; set; }
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// Gets or sets User1
        /// </summary>
        public virtual User User1 { get; set; }
        /// <summary>
        /// Gets or sets CustomisableTable
        /// </summary>
        public virtual CustomisableTable CustomisableTable { get; set; }
    }
}
