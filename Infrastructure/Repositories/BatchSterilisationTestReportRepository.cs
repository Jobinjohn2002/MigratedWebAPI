using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class BatchSterilisationTestReportRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public BatchSterilisationTestReport Get(int batchSterilisationTestReportId)
        {
            return Repository.Find(batchSterilisationTestReport => batchSterilisationTestReport.BatchSterilisationTestReportId == batchSterilisationTestReportId).FirstOrDefault();
        }
	}
}