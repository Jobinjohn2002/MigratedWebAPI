using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IServiceRequirementExpiryWindow : IEntityData
	{		
		int ServiceRequirementExpiryWindowId { get; set; }
			
		int ServiceRequirementId { get; set; }
			
		byte DayOfWeek { get; set; }
			
		TimeSpan TimeFrom { get; set; }
			
		TimeSpan TimeTo { get; set; }
			
		byte DaysToAdd { get; set; }
			
		TimeSpan ExpiryTime { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
	}
}