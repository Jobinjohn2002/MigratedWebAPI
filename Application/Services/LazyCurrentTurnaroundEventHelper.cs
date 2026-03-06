using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyCurrentTurnaroundEventHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(CurrentTurnaroundEvent concreteCurrentTurnaroundEvent, CurrentTurnaroundEvent genericCurrentTurnaroundEvent)
        {
					
			concreteCurrentTurnaroundEvent.TurnaroundId = genericCurrentTurnaroundEvent.TurnaroundId;			
			concreteCurrentTurnaroundEvent.TurnaroundEventId = genericCurrentTurnaroundEvent.TurnaroundEventId;			
			concreteCurrentTurnaroundEvent.EventTypeId = genericCurrentTurnaroundEvent.EventTypeId;
		}
	}
}
		