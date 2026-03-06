using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyReportOutputTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ReportOutputType concreteReportOutputType, ReportOutputType genericReportOutputType)
        {
					
			concreteReportOutputType.ReportOutputTypeId = genericReportOutputType.ReportOutputTypeId;			
			concreteReportOutputType.OrderPosition = genericReportOutputType.OrderPosition;			
			concreteReportOutputType.Name = genericReportOutputType.Name;			
			concreteReportOutputType.ReportingString = genericReportOutputType.ReportingString;			
			concreteReportOutputType.IsArchived = genericReportOutputType.IsArchived;
		}
	}
}
		