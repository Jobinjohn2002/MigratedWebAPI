using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class PriceCategoryDefinition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use PriceCategoryDefinitionFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public PriceCategoryDefinition()
        {
            this.ContainerMasterPrice = new HashSet<ContainerMasterPrice>();
            this.PriceCategory = new HashSet<PriceCategory>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets PriceCategoryDefinitionId
        /// </summary>
        public int PriceCategoryDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets PriceCategoryGroupId
        /// </summary>
        public int PriceCategoryGroupId { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.Guid> LegacyId { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ContainerMasterPrice
        /// </summary>
        public virtual ICollection<ContainerMasterPrice> ContainerMasterPrice { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets PriceCategory
        /// </summary>
        public virtual ICollection<PriceCategory> PriceCategory { get; set; }
        /// <summary>
        /// Gets or sets PriceCategoryGroup
        /// </summary>
        public virtual PriceCategoryGroup PriceCategoryGroup { get; set; }
    }
}
