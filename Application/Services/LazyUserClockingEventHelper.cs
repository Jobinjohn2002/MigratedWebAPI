using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyUserClockingEventHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(UserClockingEvent concreteUserClockingEvent, UserClockingEvent genericUserClockingEvent)
        {
					
			concreteUserClockingEvent.UserClockingEventId = genericUserClockingEvent.UserClockingEventId;			
			concreteUserClockingEvent.UserId = genericUserClockingEvent.UserId;			
			concreteUserClockingEvent.ClockingTime = genericUserClockingEvent.ClockingTime;			
			concreteUserClockingEvent.StationId = genericUserClockingEvent.StationId;			
			concreteUserClockingEvent.LocationPath = genericUserClockingEvent.LocationPath;			
			concreteUserClockingEvent.LocationId = genericUserClockingEvent.LocationId;			
			concreteUserClockingEvent.ClockingEventTypeId = genericUserClockingEvent.ClockingEventTypeId;			
			concreteUserClockingEvent.IsAutomatic = genericUserClockingEvent.IsAutomatic;			
			concreteUserClockingEvent.InitiatedFromLocationId = genericUserClockingEvent.InitiatedFromLocationId;			
			concreteUserClockingEvent.InitiatedByUserId = genericUserClockingEvent.InitiatedByUserId;			
			concreteUserClockingEvent.InitiatedFromStationId = genericUserClockingEvent.InitiatedFromStationId;
		}
	}
}
		