using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazySterilisationExpiryTimeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(SterilisationExpiryTime concreteSterilisationExpiryTime, SterilisationExpiryTime genericSterilisationExpiryTime)
        {
					
			concreteSterilisationExpiryTime.SterilisationExpiryTimeId = genericSterilisationExpiryTime.SterilisationExpiryTimeId;			
			concreteSterilisationExpiryTime.FacilityId = genericSterilisationExpiryTime.FacilityId;			
			concreteSterilisationExpiryTime.ItemTypeId = genericSterilisationExpiryTime.ItemTypeId;			
			concreteSterilisationExpiryTime.CustomerDefinitionId = genericSterilisationExpiryTime.CustomerDefinitionId;			
			concreteSterilisationExpiryTime.ExpiryDays = genericSterilisationExpiryTime.ExpiryDays;			
			concreteSterilisationExpiryTime.Created = genericSterilisationExpiryTime.Created;			
			concreteSterilisationExpiryTime.CreatedUserId = genericSterilisationExpiryTime.CreatedUserId;			
			concreteSterilisationExpiryTime.Modified = genericSterilisationExpiryTime.Modified;			
			concreteSterilisationExpiryTime.ModifiedUserId = genericSterilisationExpiryTime.ModifiedUserId;
		}
	}
}
		