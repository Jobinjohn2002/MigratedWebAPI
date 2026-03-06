using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class ServiceRequirementExpiryWindow
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use ServiceRequirementExpiryWindowFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public ServiceRequirementExpiryWindow()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets ServiceRequirementExpiryWindowId
        /// </summary>
        public int ServiceRequirementExpiryWindowId { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementId
        /// </summary>
        public int ServiceRequirementId { get; set; }
        /// <summary>
        /// Gets or sets DayOfWeek
        /// </summary>
        public byte DayOfWeek { get; set; }
        public System.TimeSpan TimeFrom { get; set; }
        public System.TimeSpan TimeTo { get; set; }
        /// <summary>
        /// Gets or sets DaysToAdd
        /// </summary>
        public byte DaysToAdd { get; set; }
        public System.TimeSpan ExpiryTime { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
    
        /// <summary>
        /// Gets or sets ServiceRequirement
        /// </summary>
        public virtual ServiceRequirement ServiceRequirement { get; set; }
    }
}
