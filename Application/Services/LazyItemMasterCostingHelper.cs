using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyItemMasterCostingHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ItemMasterCosting concreteItemMasterCosting, ItemMasterCosting genericItemMasterCosting)
        {
					
			concreteItemMasterCosting.ItemMasterCostingId = genericItemMasterCosting.ItemMasterCostingId;			
			concreteItemMasterCosting.CustomerDefinitionId = genericItemMasterCosting.CustomerDefinitionId;			
			concreteItemMasterCosting.ItemMasterDefinitionId = genericItemMasterCosting.ItemMasterDefinitionId;			
			concreteItemMasterCosting.Created = genericItemMasterCosting.Created;			
			concreteItemMasterCosting.ItemTypeId = genericItemMasterCosting.ItemTypeId;			
			concreteItemMasterCosting.ComponentPartCount = genericItemMasterCosting.ComponentPartCount;
		}
	}
}
		