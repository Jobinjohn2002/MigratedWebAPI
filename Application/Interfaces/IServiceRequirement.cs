using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IServiceRequirement : IEntityData
	{		
		int ServiceRequirementId { get; set; }
			
		int? ArchivedUserId { get; set; }
			
		int CreatedUserId { get; set; }
			
		byte ExpiryCalculationTypeId { get; set; }
			
		int ServiceRequirementDefinitionId { get; set; }
			
		string Text { get; set; }
			
		short Revision { get; set; }
			
		short TurnaroundMinutes { get; set; }
			
		double Margin { get; set; }
			
		bool MarginAppliesToReprocessing { get; set; }
			
		bool MarginAppliesToSingleUse { get; set; }
			
		bool MarginAppliesToOther { get; set; }
			
		short GraceMinutes { get; set; }
			
		DateTime Effective { get; set; }
			
		DateTime Created { get; set; }
			
		DateTime? Archived { get; set; }
			
		int? LegacyId { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
			
		bool? IsFastTrack { get; set; }
	}
}