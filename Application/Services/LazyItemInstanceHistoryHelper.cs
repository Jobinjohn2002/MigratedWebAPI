using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyItemInstanceHistoryHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ItemInstanceHistory concreteItemInstanceHistory, ItemInstanceHistory genericItemInstanceHistory)
        {
					
			concreteItemInstanceHistory.ItemInstanceHistoryId = genericItemInstanceHistory.ItemInstanceHistoryId;			
			concreteItemInstanceHistory.ItemInstanceId = genericItemInstanceHistory.ItemInstanceId;			
			concreteItemInstanceHistory.ContainerInstanceId = genericItemInstanceHistory.ContainerInstanceId;			
			concreteItemInstanceHistory.ItemInstanceHistoryTypeId = genericItemInstanceHistory.ItemInstanceHistoryTypeId;			
			concreteItemInstanceHistory.Date = genericItemInstanceHistory.Date;			
			concreteItemInstanceHistory.UserId = genericItemInstanceHistory.UserId;
		}
	}
}
		