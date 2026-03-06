using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyCustomerItemTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(CustomerItemType concreteCustomerItemType, CustomerItemType genericCustomerItemType)
        {
					
			concreteCustomerItemType.CustomerItemTypeId = genericCustomerItemType.CustomerItemTypeId;			
			concreteCustomerItemType.CustomerDefinitionId = genericCustomerItemType.CustomerDefinitionId;			
			concreteCustomerItemType.ItemTypeId = genericCustomerItemType.ItemTypeId;
		}
	}
}
		