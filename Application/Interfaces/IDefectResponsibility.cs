using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IDefectResponsibility : IEntityData
	{		
		byte DefectResponsibilityId { get; set; }
			
		string Text { get; set; }
			
		byte Priority { get; set; }
			
		DateTime? Archived { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
	}
}