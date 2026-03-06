using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class EventTypeStationTypeRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public EventTypeStationType Get(int eventTypeStationTypeId)
        {
            return Repository.Find(eventTypeStationType => eventTypeStationType.EventTypeStationTypeId == eventTypeStationTypeId).FirstOrDefault();
        }
	}
}