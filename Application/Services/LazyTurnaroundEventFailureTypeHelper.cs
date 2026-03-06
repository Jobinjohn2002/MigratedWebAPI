using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyTurnaroundEventFailureTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(TurnaroundEventFailureType concreteTurnaroundEventFailureType, TurnaroundEventFailureType genericTurnaroundEventFailureType)
        {
					
			concreteTurnaroundEventFailureType.TurnaroundEventFailureTypeId = genericTurnaroundEventFailureType.TurnaroundEventFailureTypeId;			
			concreteTurnaroundEventFailureType.FailureTypeId = genericTurnaroundEventFailureType.FailureTypeId;			
			concreteTurnaroundEventFailureType.TurnaroundEventId = genericTurnaroundEventFailureType.TurnaroundEventId;
		}
	}
}
		