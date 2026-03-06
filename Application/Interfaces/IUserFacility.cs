using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IUserFacility : IEntityData
	{		
		int UserFacilityId { get; set; }
			
		short FacilityId { get; set; }
			
		int UserId { get; set; }
			
		bool Selected { get; set; }
			
		bool Primary { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
	}
}