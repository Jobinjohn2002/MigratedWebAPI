using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IReport : IEntityData
	{		
		short ReportId { get; set; }
			
		byte ReportCategoryId { get; set; }
			
		string Text { get; set; }
			
		string Description { get; set; }
			
		string URL { get; set; }
			
		bool IsLive { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
			
		byte ReportTypeId { get; set; }
			
		int DefaultReportOutputTypeId { get; set; }
	}
}