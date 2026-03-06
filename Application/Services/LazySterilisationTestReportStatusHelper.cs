using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazySterilisationTestReportStatusHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(SterilisationTestReportStatus concreteSterilisationTestReportStatus, SterilisationTestReportStatus genericSterilisationTestReportStatus)
        {
					
			concreteSterilisationTestReportStatus.SterilisationTestReportStatusId = genericSterilisationTestReportStatus.SterilisationTestReportStatusId;			
			concreteSterilisationTestReportStatus.Text = genericSterilisationTestReportStatus.Text;
		}
	}
}
		