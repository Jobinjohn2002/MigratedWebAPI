using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyPlannedMaintenanceRuleHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(PlannedMaintenanceRule concretePlannedMaintenanceRule, PlannedMaintenanceRule genericPlannedMaintenanceRule)
        {
					
			concretePlannedMaintenanceRule.PlannedMaintenanceRuleId = genericPlannedMaintenanceRule.PlannedMaintenanceRuleId;			
			concretePlannedMaintenanceRule.ContainerMasterDefinitionId = genericPlannedMaintenanceRule.ContainerMasterDefinitionId;			
			concretePlannedMaintenanceRule.ItemMasterDefinitionId = genericPlannedMaintenanceRule.ItemMasterDefinitionId;			
			concretePlannedMaintenanceRule.ContractVendorMaintenanceId = genericPlannedMaintenanceRule.ContractVendorMaintenanceId;			
			concretePlannedMaintenanceRule.ItemMasterGroupId = genericPlannedMaintenanceRule.ItemMasterGroupId;			
			concretePlannedMaintenanceRule.CustomerId = genericPlannedMaintenanceRule.CustomerId;			
			concretePlannedMaintenanceRule.ScheduleId = genericPlannedMaintenanceRule.ScheduleId;			
			concretePlannedMaintenanceRule.CustomerGroupId = genericPlannedMaintenanceRule.CustomerGroupId;			
			concretePlannedMaintenanceRule.Archive = genericPlannedMaintenanceRule.Archive;			
			concretePlannedMaintenanceRule.Created = genericPlannedMaintenanceRule.Created;			
			concretePlannedMaintenanceRule.CreatedUserId = genericPlannedMaintenanceRule.CreatedUserId;
		}
	}
}
		