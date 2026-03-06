using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IRolePermission : IEntityData
	{		
		int RolePermissionId { get; set; }
			
		short RoleId { get; set; }
			
		short PermissionId { get; set; }
			
		byte AllowedFunction { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
	}
}