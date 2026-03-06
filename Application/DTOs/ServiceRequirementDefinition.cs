using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class ServiceRequirementDefinition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use ServiceRequirementDefinitionFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public ServiceRequirementDefinition()
        {
            this.ServiceRequirement = new HashSet<ServiceRequirement>();
            this.ContainerInstance = new HashSet<ContainerInstance>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets ServicerequirementDefinitionId
        /// </summary>
        public int ServicerequirementDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets LegacyId
        /// </summary>
        public Nullable<int> LegacyId { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ServiceRequirement
        /// </summary>
        public virtual ICollection<ServiceRequirement> ServiceRequirement { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinition
        /// </summary>
        public virtual CustomerDefinition CustomerDefinition { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ContainerInstance
        /// </summary>
        public virtual ICollection<ContainerInstance> ContainerInstance { get; set; }
    }
}
