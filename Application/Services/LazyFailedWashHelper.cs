using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyFailedWashHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(FailedWash concreteFailedWash, FailedWash genericFailedWash)
        {
					
			concreteFailedWash.FailedWashId = genericFailedWash.FailedWashId;			
			concreteFailedWash.TurnaroundEventId = genericFailedWash.TurnaroundEventId;			
			concreteFailedWash.Notes = genericFailedWash.Notes;
		}
	}
}
		