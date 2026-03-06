using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyOrderTemplateHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(OrderTemplate concreteOrderTemplate, OrderTemplate genericOrderTemplate)
        {
					
			concreteOrderTemplate.OrderTemplateId = genericOrderTemplate.OrderTemplateId;			
			concreteOrderTemplate.CreatedDate = genericOrderTemplate.CreatedDate;			
			concreteOrderTemplate.CreatedById = genericOrderTemplate.CreatedById;			
			concreteOrderTemplate.AlternateId = genericOrderTemplate.AlternateId;			
		}
	}
}
		