using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IItemExceptionReason : IEntityData
	{		
		byte ItemExceptionReasonId { get; set; }
			
		int? ArchivedUserId { get; set; }
			
		string Text { get; set; }
			
		DateTime? Archived { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
			
		bool RemovedFromContainer { get; set; }
	}
}