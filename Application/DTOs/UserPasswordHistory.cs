using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class UserPasswordHistory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use UserPasswordHistoryFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public UserPasswordHistory()
        {
            this.User = new HashSet<User>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets UserPasswordHistoryId
        /// </summary>
        public int UserPasswordHistoryId { get; set; }
        /// <summary>
        /// Gets or sets Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets Salt
        /// </summary>
        public string Salt { get; set; }
        /// <summary>
        /// Gets or sets Iterations
        /// </summary>
        public int Iterations { get; set; }
        public System.DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual ICollection<User> User { get; set; }
        /// <summary>
        /// Gets or sets User1
        /// </summary>
        public virtual User User1 { get; set; }
    }
}
