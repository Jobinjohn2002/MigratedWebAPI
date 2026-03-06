using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyTestReportTemperatureHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(TestReportTemperature concreteTestReportTemperature, TestReportTemperature genericTestReportTemperature)
        {
					
			concreteTestReportTemperature.SterilisationTestReportId = genericTestReportTemperature.SterilisationTestReportId;			
			concreteTestReportTemperature.SterilisationTestReportId = genericTestReportTemperature.SterilisationTestReportId;			
			concreteTestReportTemperature.SterilisationTemperatureId = genericTestReportTemperature.SterilisationTemperatureId;			
			concreteTestReportTemperature.SterilisationTemperatureId = genericTestReportTemperature.SterilisationTemperatureId;			
			concreteTestReportTemperature.Allowed = genericTestReportTemperature.Allowed;			
			concreteTestReportTemperature.Allowed = genericTestReportTemperature.Allowed;
		}
	}
}
		