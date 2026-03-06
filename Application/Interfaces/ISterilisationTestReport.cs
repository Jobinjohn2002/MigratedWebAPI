using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface ISterilisationTestReport : IEntityData
	{		
		int SterilisationTestReportId { get; set; }
			
		byte ReportType { get; set; }
			
		DateTime ReportDate { get; set; }
			
		string SerialNumber { get; set; }
			
		int SterilisationTestReportStatusId { get; set; }
			
		bool? PreOperationalChecks { get; set; }
			
		bool? WeeklySafetyChecks { get; set; }
			
		bool? DateCorrectOnAutoclave { get; set; }
			
		bool? DateCorrectOnSynergyTrak { get; set; }
			
		DateTime Created { get; set; }
			
		int CreatedUserId { get; set; }
			
		DateTime? Modified { get; set; }
			
		int? ModifiedUserId { get; set; }
			
		string ExternalId { get; set; }
			
		int MachineId { get; set; }
			
		int? PinRequestReasonId { get; set; }
			
		int? CompletedUserId { get; set; }
			
		DateTime? CompletedDate { get; set; }
	}
}