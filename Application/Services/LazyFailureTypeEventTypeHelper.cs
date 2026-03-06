using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyFailureTypeEventTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(FailureTypeEventType concreteFailureTypeEventType, FailureTypeEventType genericFailureTypeEventType)
        {
					
			concreteFailureTypeEventType.EventTypeId = genericFailureTypeEventType.EventTypeId;			
			concreteFailureTypeEventType.FailureTypeId = genericFailureTypeEventType.FailureTypeId;			
			concreteFailureTypeEventType.TaskId = genericFailureTypeEventType.TaskId;			
		}
	}
}
		