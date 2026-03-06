using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyDeniedTurnaroundEventHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(DeniedTurnaroundEvent concreteDeniedTurnaroundEvent, DeniedTurnaroundEvent genericDeniedTurnaroundEvent)
        {
					
			concreteDeniedTurnaroundEvent.DeniedTurnaroundEventId = genericDeniedTurnaroundEvent.DeniedTurnaroundEventId;			
			concreteDeniedTurnaroundEvent.TurnaroundId = genericDeniedTurnaroundEvent.TurnaroundId;			
			concreteDeniedTurnaroundEvent.CreatedDate = genericDeniedTurnaroundEvent.CreatedDate;			
			concreteDeniedTurnaroundEvent.CreatedByUserId = genericDeniedTurnaroundEvent.CreatedByUserId;			
			concreteDeniedTurnaroundEvent.StationId = genericDeniedTurnaroundEvent.StationId;			
			concreteDeniedTurnaroundEvent.LocationId = genericDeniedTurnaroundEvent.LocationId;			
			concreteDeniedTurnaroundEvent.FromEventTypeId = genericDeniedTurnaroundEvent.FromEventTypeId;			
			concreteDeniedTurnaroundEvent.ToEventTypeId = genericDeniedTurnaroundEvent.ToEventTypeId;			
			concreteDeniedTurnaroundEvent.DeniedTurnaroundEventReasonId = genericDeniedTurnaroundEvent.DeniedTurnaroundEventReasonId;
		}
	}
}
		