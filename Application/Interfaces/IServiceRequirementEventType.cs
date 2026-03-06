using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IServiceRequirementEventType : IEntityData
	{		
		int ServiceRequirementEventTypeId { get; set; }
			
		bool IsContractedStartEventType { get; set; }
			
		bool IsContractedEndEventType { get; set; }
			
		int ServiceRequirementId { get; set; }
			
		short EventTypeId { get; set; }
	}
}