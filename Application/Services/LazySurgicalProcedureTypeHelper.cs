using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazySurgicalProcedureTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(SurgicalProcedureType concreteSurgicalProcedureType, SurgicalProcedureType genericSurgicalProcedureType)
        {
					
			concreteSurgicalProcedureType.SurgicalProcedureTypeId = genericSurgicalProcedureType.SurgicalProcedureTypeId;			
			concreteSurgicalProcedureType.Reference = genericSurgicalProcedureType.Reference;			
			concreteSurgicalProcedureType.Name = genericSurgicalProcedureType.Name;			
			concreteSurgicalProcedureType.CreatedByUserId = genericSurgicalProcedureType.CreatedByUserId;			
			concreteSurgicalProcedureType.CreatedOn = genericSurgicalProcedureType.CreatedOn;			
			concreteSurgicalProcedureType.ModifiedByUserId = genericSurgicalProcedureType.ModifiedByUserId;			
			concreteSurgicalProcedureType.ModifiedOn = genericSurgicalProcedureType.ModifiedOn;			
			concreteSurgicalProcedureType.TenancyId = genericSurgicalProcedureType.TenancyId;
		}
	}
}
		