using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyPrintHistoryBatchHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(PrintHistoryBatch concretePrintHistoryBatch, PrintHistoryBatch genericPrintHistoryBatch)
        {
					
			concretePrintHistoryBatch.PrintHistoryBatchId = genericPrintHistoryBatch.PrintHistoryBatchId;			
			concretePrintHistoryBatch.PrintHistoryId = genericPrintHistoryBatch.PrintHistoryId;			
			concretePrintHistoryBatch.BatchId = genericPrintHistoryBatch.BatchId;
		}
	}
}
		