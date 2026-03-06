using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class TurnaroundEventFailureType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use TurnaroundEventFailureTypeFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public TurnaroundEventFailureType()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets TurnaroundEventFailureTypeId
        /// </summary>
        public int TurnaroundEventFailureTypeId { get; set; }
        /// <summary>
        /// Gets or sets FailureTypeId
        /// </summary>
        public byte FailureTypeId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEventId
        /// </summary>
        public Nullable<int> TurnaroundEventId { get; set; }
    
        /// <summary>
        /// Gets or sets FailureType
        /// </summary>
        public virtual FailureType FailureType { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEvent
        /// </summary>
        public virtual TurnaroundEvent TurnaroundEvent { get; set; }
    }
}
