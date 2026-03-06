using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyMachineDetergentHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(MachineDetergent concreteMachineDetergent, MachineDetergent genericMachineDetergent)
        {
					
			concreteMachineDetergent.MachineDetergentId = genericMachineDetergent.MachineDetergentId;			
			concreteMachineDetergent.MachineId = genericMachineDetergent.MachineId;			
			concreteMachineDetergent.UserId = genericMachineDetergent.UserId;			
			concreteMachineDetergent.ValidFrom = genericMachineDetergent.ValidFrom;			
			concreteMachineDetergent.DetergentInformation = genericMachineDetergent.DetergentInformation;
		}
	}
}
		