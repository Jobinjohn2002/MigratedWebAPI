using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IDefectAuditHistory : IEntityData
	{		
		int DefectAuditHistoryId { get; set; }
			
		int DefectId { get; set; }
			
		int CreatedUserId { get; set; }
			
		DateTime Created { get; set; }
			
		string Field { get; set; }
			
		string FromValue { get; set; }
			
		string ToValue { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
	}
}