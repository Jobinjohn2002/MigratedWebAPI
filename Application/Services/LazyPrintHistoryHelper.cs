using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyPrintHistoryHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(PrintHistory concretePrintHistory, PrintHistory genericPrintHistory)
        {
					
			concretePrintHistory.PrintHistoryId = genericPrintHistory.PrintHistoryId;			
            concretePrintHistory.PrintedByUserId = genericPrintHistory.PrintedByUserId;			
			concretePrintHistory.Created = genericPrintHistory.Created;			
			concretePrintHistory.PrintContentTypeId = genericPrintHistory.PrintContentTypeId;			
			concretePrintHistory.ContentRemoved = genericPrintHistory.ContentRemoved;
		}
	}
}
		