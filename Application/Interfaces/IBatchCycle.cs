using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IBatchCycle : IEntityData
	{		
		int BatchCycleId { get; set; }
			
		byte MachineTypeId { get; set; }
			
		string Text { get; set; }
			
		bool IsChargeable { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
			
		DateTime? Archived { get; set; }
			
		int? ArchivedUserId { get; set; }
	}
}