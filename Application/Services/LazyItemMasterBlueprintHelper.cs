using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyItemMasterBlueprintHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ItemMasterBlueprint concreteItemMasterBlueprint, ItemMasterBlueprint genericItemMasterBlueprint)
        {
					
			concreteItemMasterBlueprint.ItemMasterId = genericItemMasterBlueprint.ItemMasterId;			
			concreteItemMasterBlueprint.BlueprintItemMasterId = genericItemMasterBlueprint.BlueprintItemMasterId;
		}
	}
}
		