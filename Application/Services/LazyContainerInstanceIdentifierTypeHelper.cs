using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyContainerInstanceIdentifierTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ContainerInstanceIdentifierType concreteContainerInstanceIdentifierType, ContainerInstanceIdentifierType genericContainerInstanceIdentifierType)
        {
					
			concreteContainerInstanceIdentifierType.ContainerInstanceIdentifierTypeId = genericContainerInstanceIdentifierType.ContainerInstanceIdentifierTypeId;			
			concreteContainerInstanceIdentifierType.Text = genericContainerInstanceIdentifierType.Text;			
			concreteContainerInstanceIdentifierType.IsEditable = genericContainerInstanceIdentifierType.IsEditable;			
			concreteContainerInstanceIdentifierType.IsUnique = genericContainerInstanceIdentifierType.IsUnique;
		}
	}
}
		