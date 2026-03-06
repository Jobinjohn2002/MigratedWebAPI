using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class BiologicalIndicatorTestRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public BiologicalIndicatorTest Get(int biologicalIndicatorTestId)
        {
            return Repository.Find(biologicalIndicatorTest => biologicalIndicatorTest.BiologicalIndicatorTestId == biologicalIndicatorTestId).FirstOrDefault();
        }

	    /// <summary>
	    /// GetByBatchId operation
	    /// </summary>
	    public BiologicalIndicatorTest GetByBatchId(int batchId)
	    {
	        return Repository.Find(x => x.BatchId == batchId).FirstOrDefault();
	    }
	}
}