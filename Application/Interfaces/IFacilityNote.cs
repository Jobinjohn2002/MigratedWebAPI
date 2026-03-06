using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IFacilityNote : IEntityData
	{		
		int FacilityNoteId { get; set; }
			
		int? ArchiveduserId { get; set; }
			
		int CreatedUserId { get; set; }
			
		short? FacilityId { get; set; }
			
		string Text { get; set; }
			
		DateTime Created { get; set; }
			
		DateTime? Archived { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
	}
}