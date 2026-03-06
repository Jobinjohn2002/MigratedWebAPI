using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class Workflow
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use WorkflowFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public Workflow()
        {
            this.RequiredWorkflows = new HashSet<RequiredWorkflow>();
            this.RequiredWorkflows1 = new HashSet<RequiredWorkflow>();
            this.TurnaroundEvents = new HashSet<TurnaroundEvent>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets WorkflowId
        /// </summary>
        public int WorkflowId { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public short ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets FromEventTypeId
        /// </summary>
        public Nullable<short> FromEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets ToEventTypeId
        /// </summary>
        public short ToEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets IsEnd
        /// </summary>
        public bool IsEnd { get; set; }
        /// <summary>
        /// Gets or sets IsStockLocation
        /// </summary>
        public bool IsStockLocation { get; set; }
        /// <summary>
        /// Gets or sets ForIndividualInstrumentTracking
        /// </summary>
        public bool ForIndividualInstrumentTracking { get; set; }
        /// <summary>
        /// Gets or sets IsRequiredProof
        /// </summary>
        public bool IsRequiredProof { get; set; }
        /// <summary>
        /// Gets or sets IsReleaseRequired
        /// </summary>
        public bool IsReleaseRequired { get; set; }
        /// <summary>
        /// Gets or sets IsBestPractice
        /// </summary>
        public bool IsBestPractice { get; set; }
        /// <summary>
        /// Gets or sets CreatedByUserId
        /// </summary>
        public int CreatedByUserId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets OwnerId
        /// </summary>
        public Nullable<int> OwnerId { get; set; }
        public Nullable<System.DateTime> Archived { get; set; }
        /// <summary>
        /// Gets or sets ArchivedUserId
        /// </summary>
        public Nullable<int> ArchivedUserId { get; set; }
    
        /// <summary>
        /// Gets or sets EventTypeFrom
        /// </summary>
        public virtual EventType EventTypeFrom { get; set; }
        /// <summary>
        /// Gets or sets EventTypeTo
        /// </summary>
        public virtual EventType EventTypeTo { get; set; }
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public virtual ItemType ItemType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets RequiredWorkflows
        /// </summary>
        public virtual ICollection<RequiredWorkflow> RequiredWorkflows { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets RequiredWorkflows1
        /// </summary>
        public virtual ICollection<RequiredWorkflow> RequiredWorkflows1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets TurnaroundEvents
        /// </summary>
        public virtual ICollection<TurnaroundEvent> TurnaroundEvents { get; set; }
        /// <summary>
        /// Gets or sets Owner
        /// </summary>
        public virtual Owner Owner { get; set; }
    }
}
