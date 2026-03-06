using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyContainerMasterDefinitionMaintenanceCapacityTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ContainerMasterDefinitionMaintenanceCapacityType concreteContainerMasterDefinitionMaintenanceCapacityType, ContainerMasterDefinitionMaintenanceCapacityType genericContainerMasterDefinitionMaintenanceCapacityType)
        {
					
			concreteContainerMasterDefinitionMaintenanceCapacityType.ContainerMasterDefinitionMaintenanceCapacityTypeId = genericContainerMasterDefinitionMaintenanceCapacityType.ContainerMasterDefinitionMaintenanceCapacityTypeId;			
			concreteContainerMasterDefinitionMaintenanceCapacityType.Text = genericContainerMasterDefinitionMaintenanceCapacityType.Text;
		}
	}
}
		