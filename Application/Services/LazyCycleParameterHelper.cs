using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyCycleParameterHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(CycleParameter concreteCycleParameter, ICycleParameter genericCycleParameter)
        {
			concreteCycleParameter.CycleParameterId = genericCycleParameter.CycleParameterId;			
			concreteCycleParameter.BatchId = genericCycleParameter.BatchId;			
			concreteCycleParameter.CycleStartTime = genericCycleParameter.CycleStartTime;			
			concreteCycleParameter.DryingMaximumVacuum = genericCycleParameter.DryingMaximumVacuum;			
			concreteCycleParameter.DryingDuration = genericCycleParameter.DryingDuration;			
			concreteCycleParameter.VacuumBreakDuration = genericCycleParameter.VacuumBreakDuration;			
			concreteCycleParameter.CycleEndTimeDuration = genericCycleParameter.CycleEndTimeDuration;			
			concreteCycleParameter.IsTemperatureAboveNinety = genericCycleParameter.IsTemperatureAboveNinety;			
			concreteCycleParameter.CreatedUserId = genericCycleParameter.CreatedUserId;			
			concreteCycleParameter.CreatedDate = genericCycleParameter.CreatedDate;			
			concreteCycleParameter.UpdatedUserId = genericCycleParameter.UpdatedUserId;			
			concreteCycleParameter.UpdatedDate = genericCycleParameter.UpdatedDate;
		}
	}
}
		