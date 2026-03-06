using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyServiceRequirementExpiryWindowHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ServiceRequirementExpiryWindow concreteServiceRequirementExpiryWindow, ServiceRequirementExpiryWindow genericServiceRequirementExpiryWindow)
        {
					
			concreteServiceRequirementExpiryWindow.ServiceRequirementExpiryWindowId = genericServiceRequirementExpiryWindow.ServiceRequirementExpiryWindowId;			
			concreteServiceRequirementExpiryWindow.ServiceRequirementId = genericServiceRequirementExpiryWindow.ServiceRequirementId;			
			concreteServiceRequirementExpiryWindow.DayOfWeek = genericServiceRequirementExpiryWindow.DayOfWeek;			
			concreteServiceRequirementExpiryWindow.TimeFrom = genericServiceRequirementExpiryWindow.TimeFrom;			
			concreteServiceRequirementExpiryWindow.TimeTo = genericServiceRequirementExpiryWindow.TimeTo;			
			concreteServiceRequirementExpiryWindow.DaysToAdd = genericServiceRequirementExpiryWindow.DaysToAdd;			
			concreteServiceRequirementExpiryWindow.ExpiryTime = genericServiceRequirementExpiryWindow.ExpiryTime;			
			concreteServiceRequirementExpiryWindow.LegacyFacilityOrigin = genericServiceRequirementExpiryWindow.LegacyFacilityOrigin;			
			concreteServiceRequirementExpiryWindow.LegacyImported = genericServiceRequirementExpiryWindow.LegacyImported;
		}
	}
}
		