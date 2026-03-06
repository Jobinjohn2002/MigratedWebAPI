using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IBatch : IEntityData
	{		
		int BatchId { get; set; }
			
		int? ArchivedUserId { get; set; }
			
		byte? BatchArchiveReasonId { get; set; }
			
		int CreatedUserId { get; set; }
			
		int? BatchCycleId { get; set; }
			
		byte? BatchFailureReasonId { get; set; }
			
		int? FailedUserId { get; set; }
			
		int? MachineId { get; set; }
			
		string ExternalId { get; set; }
			
		DateTime Created { get; set; }
			
		DateTime? Started { get; set; }
			
		DateTime? Failed { get; set; }
			
		DateTime? Archived { get; set; }
			
		int? LegacyId { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
			
		int? BatchStatusId { get; set; }
			
		int? BatchReleasedUserId { get; set; }
			
		DateTime? DateChecked { get; set; }
	}
}