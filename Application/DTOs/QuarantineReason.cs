using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class QuarantineReason
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use QuarantineReasonFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public QuarantineReason()
        {
            this.TurnaroundEvent = new HashSet<TurnaroundEvent>();
            this.ContainerInstance = new HashSet<ContainerInstance>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets QuarantineReasonId
        /// </summary>
        public short QuarantineReasonId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets IsUserSelectable
        /// </summary>
        public bool IsUserSelectable { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets TurnaroundEvent
        /// </summary>
        public virtual ICollection<TurnaroundEvent> TurnaroundEvent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ContainerInstance
        /// </summary>
        public virtual ICollection<ContainerInstance> ContainerInstance { get; set; }
    }
}
