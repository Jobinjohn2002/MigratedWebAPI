using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IStation : IEntityData
	{		
		int StationId { get; set; }
			
		int? ArchivedUserId { get; set; }
			
		short FacilityId { get; set; }
			
		byte StationTypeId { get; set; }
			
		string NTLogon { get; set; }
			
		string Text { get; set; }
			
		DateTime? Archived { get; set; }
			
		string Culture { get; set; }
			
		bool ShowDirectoratesAtDispatch { get; set; }
			
		bool ShowReleaseBatches { get; set; }
			
		bool ShowPrioritisation { get; set; }
			
		int? LegacyId { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
			
		int? PinRequestReasonId { get; set; }
			
		bool PerformanceDial { get; set; }
			
		bool CountdownTimer { get; set; }
			
		int? LocationId { get; set; }
	}
}