using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyClockingEventTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ClockingEventType concreteClockingEventType, ClockingEventType genericClockingEventType)
        {
					
			concreteClockingEventType.ClockingEventTypeId = genericClockingEventType.ClockingEventTypeId;			
			concreteClockingEventType.Text = genericClockingEventType.Text;
		}
	}
}
		