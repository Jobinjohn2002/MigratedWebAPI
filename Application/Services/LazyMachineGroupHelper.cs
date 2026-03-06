using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyMachineGroupHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(MachineGroup concreteMachineGroup, MachineGroup genericMachineGroup)
        {
					
			concreteMachineGroup.MachineGroupId = genericMachineGroup.MachineGroupId;			
			concreteMachineGroup.Text = genericMachineGroup.Text;			
			concreteMachineGroup.FacilityId = genericMachineGroup.FacilityId;
		}
	}
}
		