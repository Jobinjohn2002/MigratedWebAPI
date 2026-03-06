using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazySterilisationTemperatureHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(SterilisationTemperature concreteSterilisationTemperature, SterilisationTemperature genericSterilisationTemperature)
        {
					
			concreteSterilisationTemperature.SterilisationTemperatureId = genericSterilisationTemperature.SterilisationTemperatureId;			
			concreteSterilisationTemperature.Text = genericSterilisationTemperature.Text;
		}
	}
}
		