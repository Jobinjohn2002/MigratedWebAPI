using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyRepairCategoryHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(RepairCategory concreteRepairCategory, RepairCategory genericRepairCategory)
        {
					
			concreteRepairCategory.RepairCategoryId = genericRepairCategory.RepairCategoryId;			
			concreteRepairCategory.Text = genericRepairCategory.Text;
		}
	}
}
		