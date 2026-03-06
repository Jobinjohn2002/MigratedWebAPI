using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyBatchDecontaminationTaskHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(BatchDecontaminationTask concreteBatchDecontaminationTask, BatchDecontaminationTask genericBatchDecontaminationTask)
        {
					
			concreteBatchDecontaminationTask.BatchDecontaminationTaskId = genericBatchDecontaminationTask.BatchDecontaminationTaskId;			
			concreteBatchDecontaminationTask.DecontaminationTaskId = genericBatchDecontaminationTask.DecontaminationTaskId;			
			concreteBatchDecontaminationTask.BatchId = genericBatchDecontaminationTask.BatchId;
		}
	}
}
		