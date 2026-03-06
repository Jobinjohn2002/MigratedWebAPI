using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyPrintHistoryContentHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(PrintHistoryContent concretePrintHistoryContent, PrintHistoryContent genericPrintHistoryContent)
        {
					
			concretePrintHistoryContent.PrintHistoryContentId = genericPrintHistoryContent.PrintHistoryContentId;			
			concretePrintHistoryContent.PrintHistoryId = genericPrintHistoryContent.PrintHistoryId;			
			concretePrintHistoryContent.PrinterTypeId = genericPrintHistoryContent.PrinterTypeId;			
			concretePrintHistoryContent.ContentId = genericPrintHistoryContent.ContentId;			
			concretePrintHistoryContent.Ordinal = genericPrintHistoryContent.Ordinal;
		}
	}
}
		