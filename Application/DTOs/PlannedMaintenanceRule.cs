using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class PlannedMaintenanceRule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use PlannedMaintenanceRuleFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public PlannedMaintenanceRule()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets PlannedMaintenanceRuleId
        /// </summary>
        public int PlannedMaintenanceRuleId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionId
        /// </summary>
        public Nullable<int> ContainerMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterDefinitionId
        /// </summary>
        public int ItemMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ContractVendorMaintenanceId
        /// </summary>
        public int ContractVendorMaintenanceId { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterGroupId
        /// </summary>
        public Nullable<int> ItemMasterGroupId { get; set; }
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets ScheduleId
        /// </summary>
        public Nullable<int> ScheduleId { get; set; }
        /// <summary>
        /// Gets or sets CustomerGroupId
        /// </summary>
        public Nullable<int> CustomerGroupId { get; set; }
        public Nullable<System.DateTime> Archive { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public Nullable<int> CreatedUserId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
    
        /// <summary>
        /// Gets or sets ContainerMasterDefinition
        /// </summary>
        public virtual ContainerMasterDefinition ContainerMasterDefinition { get; set; }
        /// <summary>
        /// Gets or sets ContractVendorMaintenance
        /// </summary>
        public virtual ContractVendorMaintenance ContractVendorMaintenance { get; set; }
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public virtual Customer Customer { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterDefinition
        /// </summary>
        public virtual ItemMasterDefinition ItemMasterDefinition { get; set; }
        /// <summary>
        /// Gets or sets Schedule
        /// </summary>
        public virtual Schedule Schedule { get; set; }
    }
}
