using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class FailedBatchRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public FailedBatch Get(int failedBatchUid)
        {
            return Repository.Find(failedBatch => failedBatch.FailedBatchId == failedBatchUid).FirstOrDefault();
        }

        /// <summary>
        /// ReadFailedBatchesByFacility operation
        /// </summary>
        public IQueryable<FailedBatch> ReadFailedBatchesByFacility(short facilityId, DateTime startDateTime)
        {
            return Repository.Find(fb => fb.Batch.Machine.FacilityId == facilityId && fb.Created > startDateTime).OrderByDescending(fb => fb.Created);
        }
	}
}