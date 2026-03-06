using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface ITenancySetting : IEntityData
	{		
		int TenancySettingId { get; set; }
			
		int TenancyId { get; set; }
			
		string Name { get; set; }
			
		byte Type { get; set; }
			
		string Value { get; set; }
			
		int ModifiedByUserId { get; set; }
			
		DateTime ModifiedDate { get; set; }
	}
}