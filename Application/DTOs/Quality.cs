using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class Quality
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use QualityFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public Quality()
        {
            this.ContainerMasterDefinition = new HashSet<ContainerMasterDefinition>();
            this.ItemMasterDefinition = new HashSet<ItemMasterDefinition>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets QualityId
        /// </summary>
        public short QualityId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets QualityTypeId
        /// </summary>
        public short QualityTypeId { get; set; }
        /// <summary>
        /// Gets or sets IsUserSelectable
        /// </summary>
        public bool IsUserSelectable { get; set; }
        public Nullable<System.DateTime> Archived { get; set; }
        /// <summary>
        /// Gets or sets ArchivedUserId
        /// </summary>
        public Nullable<int> ArchivedUserId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ContainerMasterDefinition
        /// </summary>
        public virtual ICollection<ContainerMasterDefinition> ContainerMasterDefinition { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ItemMasterDefinition
        /// </summary>
        public virtual ICollection<ItemMasterDefinition> ItemMasterDefinition { get; set; }
        /// <summary>
        /// Gets or sets QualityType
        /// </summary>
        public virtual QualityType QualityType { get; set; }
    }
}
