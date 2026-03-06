using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyCycleParameterDetailHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(CycleParameterDetail concreteCycleParameterDetail, CycleParameterDetail genericCycleParameterDetail)
        {
					
			concreteCycleParameterDetail.CycleParameterDetailId = genericCycleParameterDetail.CycleParameterDetailId;			
			concreteCycleParameterDetail.CycleParameterId = genericCycleParameterDetail.CycleParameterId;			
			concreteCycleParameterDetail.MinPressure = genericCycleParameterDetail.MinPressure;			
			concreteCycleParameterDetail.MaxPressure = genericCycleParameterDetail.MaxPressure;			
			concreteCycleParameterDetail.MinTemperature = genericCycleParameterDetail.MinTemperature;			
			concreteCycleParameterDetail.MaxTemperature = genericCycleParameterDetail.MaxTemperature;			
			concreteCycleParameterDetail.Duration = genericCycleParameterDetail.Duration;			
			concreteCycleParameterDetail.CycleParameterChamberId = genericCycleParameterDetail.CycleParameterChamberId;			
			concreteCycleParameterDetail.CycleParameterActivityTypeId = genericCycleParameterDetail.CycleParameterActivityTypeId;
		}
	}
}
		