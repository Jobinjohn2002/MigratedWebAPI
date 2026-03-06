using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class UserItemAudit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use UserItemAuditFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public UserItemAudit()
        {
            this.UserItemAuditCopyList = new HashSet<UserItemAuditCopyList>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets UserItemAuditId
        /// </summary>
        public long UserItemAuditId { get; set; }
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets UserItemAuditTypeId
        /// </summary>
        public short UserItemAuditTypeId { get; set; }
        /// <summary>
        /// Gets or sets RelatedId
        /// </summary>
        public int RelatedId { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.DateTime> Processed { get; set; }
    
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// Gets or sets UserItemAuditType
        /// </summary>
        public virtual UserItemAuditType UserItemAuditType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets UserItemAuditCopyList
        /// </summary>
        public virtual ICollection<UserItemAuditCopyList> UserItemAuditCopyList { get; set; }
    }
}
