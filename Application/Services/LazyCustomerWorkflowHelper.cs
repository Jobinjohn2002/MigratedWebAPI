using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyCustomerWorkflowHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(CustomerWorkflow concreteCustomerWorkflow, CustomerWorkflow genericCustomerWorkflow)
        {
					
			concreteCustomerWorkflow.CustomerWorkflowId = genericCustomerWorkflow.CustomerWorkflowId;			
			concreteCustomerWorkflow.CustomerDefinitionId = genericCustomerWorkflow.CustomerDefinitionId;			
			concreteCustomerWorkflow.EventTypeId = genericCustomerWorkflow.EventTypeId;			
			concreteCustomerWorkflow.IsStartEvent = genericCustomerWorkflow.IsStartEvent;
		}
	}
}
		