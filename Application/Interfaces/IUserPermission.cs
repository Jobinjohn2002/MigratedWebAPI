using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IUserPermission : IEntityData
	{		
		int UserPermissionId { get; set; }
			
		short PermissionId { get; set; }
			
		int UserId { get; set; }
			
		byte AllowedFunction { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
	}
}