using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class Task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use TaskFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public Task()
        {
            this.DecontaminationTask = new HashSet<DecontaminationTask>();
            this.FailureTypeEventType = new HashSet<FailureTypeEventType>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets TaskId
        /// </summary>
        public int TaskId { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }
        public System.DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets ModifiedByUserId
        /// </summary>
        public int ModifiedByUserId { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// Gets or sets User1
        /// </summary>
        public virtual User User1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets DecontaminationTask
        /// </summary>
        public virtual ICollection<DecontaminationTask> DecontaminationTask { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets FailureTypeEventType
        /// </summary>
        public virtual ICollection<FailureTypeEventType> FailureTypeEventType { get; set; }
    }
}
