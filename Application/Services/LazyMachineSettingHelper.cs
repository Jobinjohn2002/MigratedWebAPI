using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyMachineSettingHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(MachineSetting concreteMachineSetting, MachineSetting genericMachineSetting)
        {
					
			concreteMachineSetting.MachineSettingId = genericMachineSetting.MachineSettingId;			
			concreteMachineSetting.MachineId = genericMachineSetting.MachineId;			
			concreteMachineSetting.Name = genericMachineSetting.Name;			
			concreteMachineSetting.Type = genericMachineSetting.Type;			
			concreteMachineSetting.Value = genericMachineSetting.Value;			
			concreteMachineSetting.ModifiedByUserId = genericMachineSetting.ModifiedByUserId;			
			concreteMachineSetting.ModifiedDate = genericMachineSetting.ModifiedDate;
		}
	}
}
		