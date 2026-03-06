using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyPrintHistoryTurnaroundEventHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(PrintHistoryTurnaroundEvent concretePrintHistoryTurnaroundEvent, PrintHistoryTurnaroundEvent genericPrintHistoryTurnaroundEvent)
        {
					
			concretePrintHistoryTurnaroundEvent.PrintHistoryTurnaroundEventId = genericPrintHistoryTurnaroundEvent.PrintHistoryTurnaroundEventId;			
			concretePrintHistoryTurnaroundEvent.PrintHistoryId = genericPrintHistoryTurnaroundEvent.PrintHistoryId;			
			concretePrintHistoryTurnaroundEvent.TurnaroundEventId = genericPrintHistoryTurnaroundEvent.TurnaroundEventId;
		}
	}
}
		