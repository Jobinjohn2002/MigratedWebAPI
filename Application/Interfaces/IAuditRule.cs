using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IAuditRule : IEntityData
	{		
		int AuditRuleId { get; set; }
			
		short AuditTypeId { get; set; }
			
		bool IsEnabled { get; set; }
			
		int CreatedByUserId { get; set; }
			
		DateTime Created { get; set; }
			
		DateTime? Archived { get; set; }
			
		byte StationTypeCategoryId { get; set; }
	}
}