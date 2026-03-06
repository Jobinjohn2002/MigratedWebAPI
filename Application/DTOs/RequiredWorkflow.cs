using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class RequiredWorkflow
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use RequiredWorkflowFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public RequiredWorkflow()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets RequiredWorkflowId
        /// </summary>
        public int RequiredWorkflowId { get; set; }
        /// <summary>
        /// Gets or sets FromWorkflowId
        /// </summary>
        public int FromWorkflowId { get; set; }
        /// <summary>
        /// Gets or sets ToWorkflowId
        /// </summary>
        public int ToWorkflowId { get; set; }
        /// <summary>
        /// Gets or sets AutoRun
        /// </summary>
        public bool AutoRun { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
    
        /// <summary>
        /// Gets or sets WorkflowFrom
        /// </summary>
        public virtual Workflow WorkflowFrom { get; set; }
        /// <summary>
        /// Gets or sets WorkflowTo
        /// </summary>
        public virtual Workflow WorkflowTo { get; set; }
    }
}
