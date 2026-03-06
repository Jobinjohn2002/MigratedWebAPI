using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class SterilisationExpiryTime
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use SterilisationExpiryTimeFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public SterilisationExpiryTime()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets SterilisationExpiryTimeId
        /// </summary>
        public int SterilisationExpiryTimeId { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public Nullable<short> ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public Nullable<int> CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ExpiryDays
        /// </summary>
        public int ExpiryDays { get; set; }
        public System.DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        /// <summary>
        /// Gets or sets ModifiedUserId
        /// </summary>
        public Nullable<int> ModifiedUserId { get; set; }
    
        /// <summary>
        /// Gets or sets Facility
        /// </summary>
        public virtual Facility Facility { get; set; }
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public virtual ItemType ItemType { get; set; }
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// Gets or sets User1
        /// </summary>
        public virtual User User1 { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinition
        /// </summary>
        public virtual CustomerDefinition CustomerDefinition { get; set; }
    }
}
