using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface ICostingModel : IEntityData
	{		
		int CostingModelId { get; set; }
			
		byte CostingModelTypeId { get; set; }
			
		int CustomerDefinitionId { get; set; }
			
		bool UseFinancialComponentCount { get; set; }
			
		bool AllowSingleUseCostOverride { get; set; }
			
		bool AllowPriceCategoryOverride { get; set; }
			
		bool AllowPriceCategoryCostOverride { get; set; }
	}
}