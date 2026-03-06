using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class ServiceRequirementEventType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use ServiceRequirementEventTypeFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public ServiceRequirementEventType()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets ServiceRequirementEventTypeId
        /// </summary>
        public int ServiceRequirementEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets IsContractedStartEventType
        /// </summary>
        public bool IsContractedStartEventType { get; set; }
        /// <summary>
        /// Gets or sets IsContractedEndEventType
        /// </summary>
        public bool IsContractedEndEventType { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementId
        /// </summary>
        public int ServiceRequirementId { get; set; }
        /// <summary>
        /// Gets or sets EventTypeId
        /// </summary>
        public short EventTypeId { get; set; }
    
        /// <summary>
        /// Gets or sets EventType
        /// </summary>
        public virtual EventType EventType { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirement
        /// </summary>
        public virtual ServiceRequirement ServiceRequirement { get; set; }
    }
}
