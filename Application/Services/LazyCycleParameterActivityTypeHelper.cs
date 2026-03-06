using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyCycleParameterActivityTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(CycleParameterActivityType concreteCycleParameterActivityType, CycleParameterActivityType genericCycleParameterActivityType)
        {
					
			concreteCycleParameterActivityType.CycleParameterActivityTypeId = genericCycleParameterActivityType.CycleParameterActivityTypeId;			
			concreteCycleParameterActivityType.Text = genericCycleParameterActivityType.Text;
		}
	}
}
		