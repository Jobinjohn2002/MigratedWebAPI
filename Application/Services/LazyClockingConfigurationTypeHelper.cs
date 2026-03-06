using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyClockingConfigurationTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ClockingConfigurationType concreteClockingConfigurationType, ClockingConfigurationType genericClockingConfigurationType)
        {
					
			concreteClockingConfigurationType.ClockingConfigurationTypeId = genericClockingConfigurationType.ClockingConfigurationTypeId;			
			concreteClockingConfigurationType.Text = genericClockingConfigurationType.Text;
		}
	}
}
		