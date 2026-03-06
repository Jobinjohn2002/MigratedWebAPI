using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IStationType : IEntityData
	{		
		byte StationTypeId { get; set; }
			
		byte StationTypeCategoryId { get; set; }
			
		string Text { get; set; }
			
		short DisplayOrder { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
			
		bool AllowAssignPPM { get; set; }
			
		bool AllowAssignNotes { get; set; }
	}
}