using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyTurnaroundEventWeightHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(TurnaroundEventWeight concreteTurnaroundEventWeight, TurnaroundEventWeight genericTurnaroundEventWeight)
        {
					
			concreteTurnaroundEventWeight.TurnaroundEventWeightId = genericTurnaroundEventWeight.TurnaroundEventWeightId;			
			concreteTurnaroundEventWeight.WeightKg = genericTurnaroundEventWeight.WeightKg;			
			concreteTurnaroundEventWeight.ReferenceWeightKg = genericTurnaroundEventWeight.ReferenceWeightKg;			
			concreteTurnaroundEventWeight.ToleranceKg = genericTurnaroundEventWeight.ToleranceKg;			
			concreteTurnaroundEventWeight.TurnaroundEventId = genericTurnaroundEventWeight.TurnaroundEventId;
		}
	}
}
		