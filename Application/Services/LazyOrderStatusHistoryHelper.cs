using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyOrderStatusHistoryHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(OrderStatusHistory concreteOrderStatusHistory, OrderStatusHistory genericOrderStatusHistory)
        {
					
			concreteOrderStatusHistory.OrderStatusHistoryId = genericOrderStatusHistory.OrderStatusHistoryId;			
			concreteOrderStatusHistory.OrderId = genericOrderStatusHistory.OrderId;			
			concreteOrderStatusHistory.OrderStatusId = genericOrderStatusHistory.OrderStatusId;			
			concreteOrderStatusHistory.CommentId = genericOrderStatusHistory.CommentId;			
			concreteOrderStatusHistory.CreatedDate = genericOrderStatusHistory.CreatedDate;			
			concreteOrderStatusHistory.UserId = genericOrderStatusHistory.UserId;
		}
	}
}
		