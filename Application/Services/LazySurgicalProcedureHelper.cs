using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazySurgicalProcedureHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(SurgicalProcedure concreteSurgicalProcedure, SurgicalProcedure genericSurgicalProcedure)
        {
					
			concreteSurgicalProcedure.SurgicalProcedureId = genericSurgicalProcedure.SurgicalProcedureId;			
			concreteSurgicalProcedure.ExternalId = genericSurgicalProcedure.ExternalId;			
			concreteSurgicalProcedure.LocationId = genericSurgicalProcedure.LocationId;			
			concreteSurgicalProcedure.SurgeonId = genericSurgicalProcedure.SurgeonId;			
			concreteSurgicalProcedure.SurgicalProcedureTypeId = genericSurgicalProcedure.SurgicalProcedureTypeId;			
			concreteSurgicalProcedure.CaseReference = genericSurgicalProcedure.CaseReference;			
			concreteSurgicalProcedure.PatientReference = genericSurgicalProcedure.PatientReference;			
			concreteSurgicalProcedure.ScheduledOn = genericSurgicalProcedure.ScheduledOn;			
			concreteSurgicalProcedure.Duration = genericSurgicalProcedure.Duration;			
			concreteSurgicalProcedure.CreatedByUserId = genericSurgicalProcedure.CreatedByUserId;			
			concreteSurgicalProcedure.CreatedOn = genericSurgicalProcedure.CreatedOn;			
			concreteSurgicalProcedure.ModifiedByUserId = genericSurgicalProcedure.ModifiedByUserId;			
			concreteSurgicalProcedure.ModifiedOn = genericSurgicalProcedure.ModifiedOn;			
			concreteSurgicalProcedure.AdditionalInstrumentsUsed = genericSurgicalProcedure.AdditionalInstrumentsUsed;			
			concreteSurgicalProcedure.ArchivedByUserId = genericSurgicalProcedure.ArchivedByUserId;			
			concreteSurgicalProcedure.ArchivedOn = genericSurgicalProcedure.ArchivedOn;
		}
	}
}
		