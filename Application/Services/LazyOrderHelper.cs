using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyOrderHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Order concreteOrder, Order genericOrder)
        {
					
			concreteOrder.OrderId = genericOrder.OrderId;			
			concreteOrder.DeliveryPointId = genericOrder.DeliveryPointId;			
			concreteOrder.OrderStatusId = genericOrder.OrderStatusId;			
			concreteOrder.CreatedDate = genericOrder.CreatedDate;			
			concreteOrder.DeliveryDate = genericOrder.DeliveryDate;			
			concreteOrder.CreatedById = genericOrder.CreatedById;			
			concreteOrder.OrderNumber = genericOrder.OrderNumber;			
			concreteOrder.AlternateId = genericOrder.AlternateId;
		}
	}
}
		