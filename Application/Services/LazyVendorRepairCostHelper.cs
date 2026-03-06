using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyVendorRepairCostHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(VendorRepairCost concreteVendorRepairCost, VendorRepairCost genericVendorRepairCost)
        {
					
			concreteVendorRepairCost.VendorRepairCostId = genericVendorRepairCost.VendorRepairCostId;			
			concreteVendorRepairCost.VendorId = genericVendorRepairCost.VendorId;			
			concreteVendorRepairCost.RepairCategoryId = genericVendorRepairCost.RepairCategoryId;			
			concreteVendorRepairCost.RepairCode = genericVendorRepairCost.RepairCode;			
			concreteVendorRepairCost.Cost = genericVendorRepairCost.Cost;			
			concreteVendorRepairCost.Created = genericVendorRepairCost.Created;			
			concreteVendorRepairCost.CreatedUserId = genericVendorRepairCost.CreatedUserId;
		}
	}
}
		