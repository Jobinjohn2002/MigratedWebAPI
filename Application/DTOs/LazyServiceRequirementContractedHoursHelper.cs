using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class LazyServiceRequirementContractedHoursHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ServiceRequirementContractedHours concreteServiceRequirementContractedHours, ServiceRequirementContractedHours genericServiceRequirementContractedHours)
        {
					
			concreteServiceRequirementContractedHours.ServiceRequirementContractedHoursId = genericServiceRequirementContractedHours.ServiceRequirementContractedHoursId;			
			concreteServiceRequirementContractedHours.ServiceRequirementId = genericServiceRequirementContractedHours.ServiceRequirementId;			
			concreteServiceRequirementContractedHours.DayOfWeek = genericServiceRequirementContractedHours.DayOfWeek;			
			concreteServiceRequirementContractedHours.Opening = genericServiceRequirementContractedHours.Opening;			
			concreteServiceRequirementContractedHours.Closing = genericServiceRequirementContractedHours.Closing;			
			concreteServiceRequirementContractedHours.Closed = genericServiceRequirementContractedHours.Closed;
		}
	}
}
		