using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyReportTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ReportType concreteReportType, ReportType genericReportType)
        {
					
			concreteReportType.ReportTypeId = genericReportType.ReportTypeId;			
			concreteReportType.Text = genericReportType.Text;
		}
	}
}
		