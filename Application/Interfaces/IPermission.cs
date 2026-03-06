using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IPermission : IEntityData
	{		
		short PermissionId { get; set; }
			
		string Text { get; set; }
			
		byte AllowableBitMask { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
			
		string Description { get; set; }
			
		bool UsedInOperative { get; set; }
			
		bool UsedInAdmin { get; set; }
			
		bool UsedInSAF { get; set; }
			
		bool UsedInFinance { get; set; }
			
		bool UsedInAPI { get; set; }
	}
}