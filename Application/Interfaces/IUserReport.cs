using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IUserReport : IEntityData
	{		
		int UserReportId { get; set; }
			
		short ReportId { get; set; }
			
		int UserId { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
			
		int OwnerReportAccessId { get; set; }
	}
}