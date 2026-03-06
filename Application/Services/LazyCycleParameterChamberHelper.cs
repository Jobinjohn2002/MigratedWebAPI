using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyCycleParameterChamberHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(CycleParameterChamber concreteCycleParameterChamber, CycleParameterChamber genericCycleParameterChamber)
        {
					
			concreteCycleParameterChamber.CycleParameterChamberId = genericCycleParameterChamber.CycleParameterChamberId;			
			concreteCycleParameterChamber.Text = genericCycleParameterChamber.Text;
		}
	}
}
		