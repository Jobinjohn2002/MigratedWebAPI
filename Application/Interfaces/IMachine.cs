using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IMachine : IEntityData
	{		
		int MachineId { get; set; }
			
		int? ArchivedUserId { get; set; }
			
		short FacilityId { get; set; }
			
		byte MachineTypeId { get; set; }
			
		string BatchPrefix { get; set; }
			
		string Text { get; set; }
			
		short RunningTime { get; set; }
			
		DateTime? Archived { get; set; }
			
		int? LegacyId { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
			
		int CoolDownPeriod { get; set; }
			
		int? TreeId { get; set; }
			
		bool IsSteam { get; set; }
	}
}