using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IServiceRequirementContractedHours : IEntityData
	{		
		int ServiceRequirementContractedHoursId { get; set; }
			
		short DayOfWeek { get; set; }
			
		TimeSpan Opening { get; set; }
			
		TimeSpan Closing { get; set; }
			
		bool Closed { get; set; }
			
		int ServiceRequirementId { get; set; }
	}
}