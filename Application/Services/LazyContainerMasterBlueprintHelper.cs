using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyContainerMasterBlueprintHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ContainerMasterBlueprint concreteContainerMasterBlueprint, ContainerMasterBlueprint genericContainerMasterBlueprint)
        {
					
			concreteContainerMasterBlueprint.ContainerMasterId = genericContainerMasterBlueprint.ContainerMasterId;			
			concreteContainerMasterBlueprint.BlueprintContainerMasterId = genericContainerMasterBlueprint.BlueprintContainerMasterId;
		}
	}
}
		