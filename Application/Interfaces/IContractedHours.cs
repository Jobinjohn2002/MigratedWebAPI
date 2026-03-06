using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IContractedHours : IEntityData
	{		
		int ContractedHoursId { get; set; }
			
		int CustomerId { get; set; }
			
		short DayOfWeek { get; set; }
			
		short Opening { get; set; }
			
		short Closing { get; set; }
			
		bool Closed { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
	}
}