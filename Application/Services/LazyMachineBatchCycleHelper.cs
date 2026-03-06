using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyMachineBatchCycleHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(MachineBatchCycle concreteMachineBatchCycle, MachineBatchCycle genericMachineBatchCycle)
        {
					
			concreteMachineBatchCycle.MachineId = genericMachineBatchCycle.MachineId;			
			concreteMachineBatchCycle.BatchCycleId = genericMachineBatchCycle.BatchCycleId;			
			concreteMachineBatchCycle.BiologicalIndicatorEnabled = genericMachineBatchCycle.BiologicalIndicatorEnabled;			
		}
	}
}
		