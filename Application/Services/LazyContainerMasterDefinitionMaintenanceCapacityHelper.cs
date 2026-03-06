using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyContainerMasterDefinitionMaintenanceCapacityHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ContainerMasterDefinitionMaintenanceCapacity concreteContainerMasterDefinitionMaintenanceCapacity, ContainerMasterDefinitionMaintenanceCapacity genericContainerMasterDefinitionMaintenanceCapacity)
        {

            concreteContainerMasterDefinitionMaintenanceCapacity.ContainerMasterDefinitionMaintenanceCapacityTypeId = genericContainerMasterDefinitionMaintenanceCapacity.ContainerMasterDefinitionMaintenanceCapacityTypeId;
            concreteContainerMasterDefinitionMaintenanceCapacity.ContainerMasterDefinitionId = genericContainerMasterDefinitionMaintenanceCapacity.ContainerMasterDefinitionId;			
			concreteContainerMasterDefinitionMaintenanceCapacity.Value = genericContainerMasterDefinitionMaintenanceCapacity.Value;			
			concreteContainerMasterDefinitionMaintenanceCapacity.ContainerMasterDefinitionMaintenanceCapacityId = genericContainerMasterDefinitionMaintenanceCapacity.ContainerMasterDefinitionMaintenanceCapacityId;
			concreteContainerMasterDefinitionMaintenanceCapacity.ModifiedByUserId = genericContainerMasterDefinitionMaintenanceCapacity.ModifiedByUserId;
		}
	}
}
		