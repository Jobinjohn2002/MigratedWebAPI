using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyItemInstanceHistoryTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ItemInstanceHistoryType concreteItemInstanceHistoryType, ItemInstanceHistoryType genericItemInstanceHistoryType)
        {
					
			concreteItemInstanceHistoryType.ItemInstanceHistoryTypeId = genericItemInstanceHistoryType.ItemInstanceHistoryTypeId;			
			concreteItemInstanceHistoryType.Text = genericItemInstanceHistoryType.Text;
		}
	}
}
		