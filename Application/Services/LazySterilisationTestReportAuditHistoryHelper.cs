using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazySterilisationTestReportAuditHistoryHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(SterilisationTestReportAuditHistory concreteSterilisationTestReportAuditHistory, ISterilisationTestReportAuditHistory genericSterilisationTestReportAuditHistory)
        {
					
			concreteSterilisationTestReportAuditHistory.SterilisationTestReportAuditHistoryId = genericSterilisationTestReportAuditHistory.SterilisationTestReportAuditHistoryId;			
			concreteSterilisationTestReportAuditHistory.SterilisationTestReportId = genericSterilisationTestReportAuditHistory.SterilisationTestReportId;			
			concreteSterilisationTestReportAuditHistory.SterilisationTestReportStatusId = genericSterilisationTestReportAuditHistory.SterilisationTestReportStatusId;			
			concreteSterilisationTestReportAuditHistory.Created = genericSterilisationTestReportAuditHistory.Created;			
			concreteSterilisationTestReportAuditHistory.CreatedUserId = genericSterilisationTestReportAuditHistory.CreatedUserId;
		}
	}
}
		