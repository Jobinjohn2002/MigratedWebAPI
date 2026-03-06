using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyServiceReportsHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ServiceReports concreteServiceReports, ServiceReports genericServiceReports)
        {
					
			concreteServiceReports.DefectId = genericServiceReports.DefectId;					
			concreteServiceReports.ExternalId = genericServiceReports.ExternalId;			
			concreteServiceReports.DefectType = genericServiceReports.DefectType;			
			concreteServiceReports.Raised = genericServiceReports.Raised;			
			concreteServiceReports.DeliveryPointName = genericServiceReports.DeliveryPointName;			
			concreteServiceReports.CustomerName = genericServiceReports.CustomerName;			
			concreteServiceReports.SerialNumber = genericServiceReports.SerialNumber;			
			concreteServiceReports.ClassificationName = genericServiceReports.ClassificationName;			
			concreteServiceReports.DefectStatusName = genericServiceReports.DefectStatusName;			
			concreteServiceReports.FacilityId = genericServiceReports.FacilityId;				
			concreteServiceReports.DefectStatusId = genericServiceReports.DefectStatusId;
		}
	}
}
		