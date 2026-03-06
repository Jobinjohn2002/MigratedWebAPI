using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class UserItemAuditCopyList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use UserItemAuditCopyListFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public UserItemAuditCopyList()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets UserItemAuditCopyListId
        /// </summary>
        public long UserItemAuditCopyListId { get; set; }
        /// <summary>
        /// Gets or sets UserItemAuditId
        /// </summary>
        public long UserItemAuditId { get; set; }
        /// <summary>
        /// Gets or sets PreviousContainerMasterId
        /// </summary>
        public int PreviousContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets NewContainerMasterId
        /// </summary>
        public int NewContainerMasterId { get; set; }
        public System.DateTime Created { get; set; }
    
        /// <summary>
        /// Gets or sets ContainerMaster
        /// </summary>
        public virtual ContainerMaster ContainerMaster { get; set; }
        /// <summary>
        /// Gets or sets ContainerMaster1
        /// </summary>
        public virtual ContainerMaster ContainerMaster1 { get; set; }
        /// <summary>
        /// Gets or sets UserItemAudit
        /// </summary>
        public virtual UserItemAudit UserItemAudit { get; set; }
    }
}
