using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyPrintHistoryTurnaroundHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(PrintHistoryTurnaround concretePrintHistoryTurnaround, PrintHistoryTurnaround genericPrintHistoryTurnaround)
        {
					
			concretePrintHistoryTurnaround.PrintHistoryTurnaroundId = genericPrintHistoryTurnaround.PrintHistoryTurnaroundId;			
			concretePrintHistoryTurnaround.PrintHistoryId = genericPrintHistoryTurnaround.PrintHistoryId;			
			concretePrintHistoryTurnaround.TurnaroundId = genericPrintHistoryTurnaround.TurnaroundId;
		}
	}
}
		