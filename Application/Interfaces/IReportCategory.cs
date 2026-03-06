using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IReportCategory : IEntityData
	{		
		byte ReportCategoryId { get; set; }
			
		byte? ParentId { get; set; }
			
		string Text { get; set; }
			
		bool IsLive { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
	}
}