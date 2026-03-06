using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyCycleParameterAirRemovalHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(CycleParameterAirRemoval concreteCycleParameterAirRemoval, CycleParameterAirRemoval genericCycleParameterAirRemoval)
        {
					
			concreteCycleParameterAirRemoval.CycleParameterAirRemovalId = genericCycleParameterAirRemoval.CycleParameterAirRemovalId;			
			concreteCycleParameterAirRemoval.CycleParameterId = genericCycleParameterAirRemoval.CycleParameterId;			
			concreteCycleParameterAirRemoval.PulseType = genericCycleParameterAirRemoval.PulseType;			
			concreteCycleParameterAirRemoval.MinVacuum = genericCycleParameterAirRemoval.MinVacuum;			
			concreteCycleParameterAirRemoval.MaxVacuum = genericCycleParameterAirRemoval.MaxVacuum;			
			concreteCycleParameterAirRemoval.NoOfPulses = genericCycleParameterAirRemoval.NoOfPulses;			
			concreteCycleParameterAirRemoval.Duration = genericCycleParameterAirRemoval.Duration;
		}
	}
}
		