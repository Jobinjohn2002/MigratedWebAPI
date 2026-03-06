using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyServiceRequirementEventTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ServiceRequirementEventType concreteServiceRequirementEventType, ServiceRequirementEventType genericServiceRequirementEventType)
        {
					
			concreteServiceRequirementEventType.ServiceRequirementEventTypeId = genericServiceRequirementEventType.ServiceRequirementEventTypeId;			
			concreteServiceRequirementEventType.ServiceRequirementId = genericServiceRequirementEventType.ServiceRequirementId;			
			concreteServiceRequirementEventType.EventTypeId = genericServiceRequirementEventType.EventTypeId;			
			concreteServiceRequirementEventType.IsContractedStartEventType = genericServiceRequirementEventType.IsContractedStartEventType;			
			concreteServiceRequirementEventType.IsContractedEndEventType = genericServiceRequirementEventType.IsContractedEndEventType;
		}
	}
}
		