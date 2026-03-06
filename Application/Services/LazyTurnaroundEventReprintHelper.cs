using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyTurnaroundEventReprintHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(TurnaroundEventReprint concreteTurnaroundEventReprint, TurnaroundEventReprint genericTurnaroundEventReprint)
        {
					
			concreteTurnaroundEventReprint.TurnaroundEventReprintId = genericTurnaroundEventReprint.TurnaroundEventReprintId;			
			concreteTurnaroundEventReprint.TurnaroundEventId = genericTurnaroundEventReprint.TurnaroundEventId;			
			concreteTurnaroundEventReprint.PrintHistoryId = genericTurnaroundEventReprint.PrintHistoryId;
		}
	}
}
		