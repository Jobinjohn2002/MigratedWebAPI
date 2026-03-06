using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyBatchSterilisationTestReportHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(BatchSterilisationTestReport concreteBatchSterilisationTestReport, BatchSterilisationTestReport genericBatchSterilisationTestReport)
        {
					
			concreteBatchSterilisationTestReport.BatchSterilisationTestReportId = genericBatchSterilisationTestReport.BatchSterilisationTestReportId;			
			concreteBatchSterilisationTestReport.SterilisationTestReportId = genericBatchSterilisationTestReport.SterilisationTestReportId;			
			concreteBatchSterilisationTestReport.BatchId = genericBatchSterilisationTestReport.BatchId;			
			concreteBatchSterilisationTestReport.LotNumber = genericBatchSterilisationTestReport.LotNumber;			
			concreteBatchSterilisationTestReport.ExpiryDate = genericBatchSterilisationTestReport.ExpiryDate;			

		}
	}
}
		