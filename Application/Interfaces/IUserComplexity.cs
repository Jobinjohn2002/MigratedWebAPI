using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IUserComplexity : IEntityData
	{		
		int UserComplexitySpeciailityId { get; set; }
			
		int UserId { get; set; }
			
		short SpecialityId { get; set; }
			
		short ComplexityId { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
	}
}