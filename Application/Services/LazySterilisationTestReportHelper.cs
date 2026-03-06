using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazySterilisationTestReportHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(SterilisationTestReport concreteSterilisationTestReport, ISterilisationTestReport genericSterilisationTestReport)
        {
					
			concreteSterilisationTestReport.SterilisationTestReportId = genericSterilisationTestReport.SterilisationTestReportId;			
			concreteSterilisationTestReport.ReportType = genericSterilisationTestReport.ReportType;			
			concreteSterilisationTestReport.ReportDate = genericSterilisationTestReport.ReportDate;			
			concreteSterilisationTestReport.SerialNumber = genericSterilisationTestReport.SerialNumber;			
			concreteSterilisationTestReport.SterilisationTestReportStatusId = genericSterilisationTestReport.SterilisationTestReportStatusId;			
			concreteSterilisationTestReport.PreOperationalChecks = genericSterilisationTestReport.PreOperationalChecks;			
			concreteSterilisationTestReport.WeeklySafetyChecks = genericSterilisationTestReport.WeeklySafetyChecks;			
			concreteSterilisationTestReport.DateCorrectOnAutoclave = genericSterilisationTestReport.DateCorrectOnAutoclave;			
			concreteSterilisationTestReport.DateCorrectOnSynergyTrak = genericSterilisationTestReport.DateCorrectOnSynergyTrak;			
			concreteSterilisationTestReport.Created = genericSterilisationTestReport.Created;			
			concreteSterilisationTestReport.CreatedUserId = genericSterilisationTestReport.CreatedUserId;			
			concreteSterilisationTestReport.Modified = genericSterilisationTestReport.Modified;			
			concreteSterilisationTestReport.ModifiedUserId = genericSterilisationTestReport.ModifiedUserId;			
			concreteSterilisationTestReport.ExternalId = genericSterilisationTestReport.ExternalId;
            concreteSterilisationTestReport.MachineId = genericSterilisationTestReport.MachineId;
            concreteSterilisationTestReport.PinRequestReasonId = genericSterilisationTestReport.PinRequestReasonId;
            concreteSterilisationTestReport.CompletedDate = genericSterilisationTestReport.CompletedDate;
            concreteSterilisationTestReport.CompletedUserId = genericSterilisationTestReport.CompletedUserId;	
		}
	}
}
		