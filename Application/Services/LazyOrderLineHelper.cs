using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyOrderLineHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(OrderLine concreteOrderLine, OrderLine genericOrderLine)
        {
					
			concreteOrderLine.OrderLineId = genericOrderLine.OrderLineId;			
			concreteOrderLine.OrderId = genericOrderLine.OrderId;			
			concreteOrderLine.ContainerMasterDefinitionId = genericOrderLine.ContainerMasterDefinitionId;			
			concreteOrderLine.TurnaroundId = genericOrderLine.TurnaroundId;
		}
	}
}
		