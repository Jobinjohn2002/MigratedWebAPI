using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyTurnaroundFacilityHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(TurnaroundFacility concreteTurnaroundFacility, TurnaroundFacility genericTurnaroundFacility)
        {
					
			concreteTurnaroundFacility.TurnaroundFacilityId = genericTurnaroundFacility.TurnaroundFacilityId;			
			concreteTurnaroundFacility.TurnaroundId = genericTurnaroundFacility.TurnaroundId;			
			concreteTurnaroundFacility.FacilityId = genericTurnaroundFacility.FacilityId;
		}
	}
}
		