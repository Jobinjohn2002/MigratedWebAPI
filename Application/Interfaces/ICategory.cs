using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface ICategory : IEntityData
	{		
		int CategoryId { get; set; }
			
		int? ParentCategoryId { get; set; }
			
		string Text { get; set; }
			
		int? LegacyId { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
	}
}