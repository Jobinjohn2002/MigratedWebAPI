using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IReportOutputType : IEntityData
	{		
		int ReportOutputTypeId { get; set; }
			
		int OrderPosition { get; set; }
			
		string Name { get; set; }
			
		string ReportingString { get; set; }
			
		bool IsArchived { get; set; }
	}
}