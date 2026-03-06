using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface ITurnaroundNote : IEntityData
	{		
		int TurnaroundNoteId { get; set; }
			
		int CreatedUserId { get; set; }
			
		int TurnaroundId { get; set; }
			
		string Text { get; set; }
			
		DateTime Created { get; set; }
			
		int LegacyId { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
	}
}