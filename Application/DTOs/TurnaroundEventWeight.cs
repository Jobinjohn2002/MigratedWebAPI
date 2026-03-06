using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class TurnaroundEventWeight
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use TurnaroundEventWeightFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public TurnaroundEventWeight()
        {
            this.ContainerInstanceWeight = new HashSet<ContainerInstanceWeight>();
            this.ContainerInstanceWeight1 = new HashSet<ContainerInstanceWeight>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets TurnaroundEventWeightId
        /// </summary>
        public int TurnaroundEventWeightId { get; set; }
        /// <summary>
        /// Gets or sets WeightKg
        /// </summary>
        public decimal WeightKg { get; set; }
        /// <summary>
        /// Gets or sets ReferenceWeightKg
        /// </summary>
        public decimal ReferenceWeightKg { get; set; }
        /// <summary>
        /// Gets or sets ToleranceKg
        /// </summary>
        public decimal ToleranceKg { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEventId
        /// </summary>
        public int TurnaroundEventId { get; set; }
        /// <summary>
        /// Gets or sets WeightStatusId
        /// </summary>
        public int WeightStatusId { get; set; }
    
        /// <summary>
        /// Gets or sets TurnaroundEvent
        /// </summary>
        public virtual TurnaroundEvent TurnaroundEvent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ContainerInstanceWeight
        /// </summary>
        public virtual ICollection<ContainerInstanceWeight> ContainerInstanceWeight { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ContainerInstanceWeight1
        /// </summary>
        public virtual ICollection<ContainerInstanceWeight> ContainerInstanceWeight1 { get; set; }
    }
}
