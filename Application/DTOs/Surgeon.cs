using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class Surgeon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use SurgeonFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public Surgeon()
        {
            this.SurgicalProcedure = new HashSet<SurgicalProcedure>();
            this.HisOrder = new HashSet<HisOrder>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets SurgeonId
        /// </summary>
        public int SurgeonId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets Reference
        /// </summary>
        public string Reference { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets CreatedByUserId
        /// </summary>
        public int CreatedByUserId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        /// <summary>
        /// Gets or sets ModifiedByUserId
        /// </summary>
        public Nullable<int> ModifiedByUserId { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        /// <summary>
        /// Gets or sets TenancyId
        /// </summary>
        public int TenancyId { get; set; }
    
        /// <summary>
        /// Gets or sets Tenancy
        /// </summary>
        public virtual Tenancy Tenancy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets SurgicalProcedure
        /// </summary>
        public virtual ICollection<SurgicalProcedure> SurgicalProcedure { get; set; }
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// Gets or sets User1
        /// </summary>
        public virtual User User1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets HisOrder
        /// </summary>
        public virtual ICollection<HisOrder> HisOrder { get; set; }
    }
}
