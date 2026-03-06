using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyContainerInstanceIdentifierHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ContainerInstanceIdentifier concreteContainerInstanceIdentifier, ContainerInstanceIdentifier genericContainerInstanceIdentifier)
        {
					
			concreteContainerInstanceIdentifier.ContainerInstanceIdentifierId = genericContainerInstanceIdentifier.ContainerInstanceIdentifierId;			
			concreteContainerInstanceIdentifier.ContainerInstanceId = genericContainerInstanceIdentifier.ContainerInstanceId;			
			concreteContainerInstanceIdentifier.ContainerInstanceIdentifierTypeId = genericContainerInstanceIdentifier.ContainerInstanceIdentifierTypeId;			
			concreteContainerInstanceIdentifier.IsPrimary = genericContainerInstanceIdentifier.IsPrimary;			
			concreteContainerInstanceIdentifier.Value = genericContainerInstanceIdentifier.Value;
		}
	}
}
		