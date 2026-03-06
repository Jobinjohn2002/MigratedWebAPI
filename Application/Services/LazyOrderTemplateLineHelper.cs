using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyOrderTemplateLineHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(OrderTemplateLine concreteOrderTemplateLine, OrderTemplateLine genericOrderTemplateLine)
        {
					
			concreteOrderTemplateLine.OrderTemplateLineId = genericOrderTemplateLine.OrderTemplateLineId;			
			concreteOrderTemplateLine.OrderTemplateId = genericOrderTemplateLine.OrderTemplateId;			
			concreteOrderTemplateLine.ContainerMasterDefinitionId = genericOrderTemplateLine.ContainerMasterDefinitionId;
		}
	}
}
		