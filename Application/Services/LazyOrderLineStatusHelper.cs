using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyOrderLineStatusHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(OrderLineStatus concreteOrderLineStatus, OrderLineStatus genericOrderLineStatus)
        {
					
			concreteOrderLineStatus.OrderLineStatusId = genericOrderLineStatus.OrderLineStatusId;			
			concreteOrderLineStatus.Text = genericOrderLineStatus.Text;
		}
	}
}
		