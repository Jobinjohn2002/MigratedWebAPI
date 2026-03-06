using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class UserComplexity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use UserComplexityFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public UserComplexity()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets UserComplexitySpeciailityId
        /// </summary>
        public int UserComplexitySpeciailityId { get; set; }
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets SpecialityId
        /// </summary>
        public short SpecialityId { get; set; }
        /// <summary>
        /// Gets or sets ComplexityId
        /// </summary>
        public short ComplexityId { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
    
        /// <summary>
        /// Gets or sets Complexity
        /// </summary>
        public virtual Complexity Complexity { get; set; }
        /// <summary>
        /// Gets or sets Speciality
        /// </summary>
        public virtual Speciality Speciality { get; set; }
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
    }
}
