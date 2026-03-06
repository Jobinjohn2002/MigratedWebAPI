using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface ITurnaroundEvent : IEntityData
	{		
		int TurnaroundEventId { get; set; }
			
		int? BatchId { get; set; }
			
		int CreatedUserId { get; set; }
			
		short EventTypeId { get; set; }
			
		byte? FailureTypeId { get; set; }
			
		byte ProcessStationTypeId { get; set; }
			
		int StationId { get; set; }
			
		int TurnaroundId { get; set; }
			
		int? WorkflowId { get; set; }
			
		DateTime Created { get; set; }
			
		int? LegacyId { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
			
		int? PinRequestReasonId { get; set; }
			
		int? StoragePointId { get; set; }
			
		short? QuarantineReasonId { get; set; }
			
		int? LocationId { get; set; }
			
		short? AbandonReasonId { get; set; }
	}
}