using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyPriceCategoryGroupItemTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(PriceCategoryGroupItemType concretePriceCategoryGroupItemType, PriceCategoryGroupItemType genericPriceCategoryGroupItemType)
        {
					
			concretePriceCategoryGroupItemType.PriceCategoryGroupItemTypeId = genericPriceCategoryGroupItemType.PriceCategoryGroupItemTypeId;			
			concretePriceCategoryGroupItemType.ItemTypeId = genericPriceCategoryGroupItemType.ItemTypeId;			
			concretePriceCategoryGroupItemType.PriceCategoryGroupId = genericPriceCategoryGroupItemType.PriceCategoryGroupId;
		}
	}
}
		