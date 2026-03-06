using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyOwnerReportAccessHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(OwnerReportAccess concreteOwnerReportAccess, OwnerReportAccess genericOwnerReportAccess)
        {
					
			concreteOwnerReportAccess.OwnerReportAccessId = genericOwnerReportAccess.OwnerReportAccessId;			
			concreteOwnerReportAccess.OwnerId = genericOwnerReportAccess.OwnerId;			
			concreteOwnerReportAccess.ReportId = genericOwnerReportAccess.ReportId;
		}
	}
}
		