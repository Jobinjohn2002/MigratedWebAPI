using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazySurgicalProcedureTurnaroundHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(SurgicalProcedureTurnaround concreteSurgicalProcedureTurnaround, SurgicalProcedureTurnaround genericSurgicalProcedureTurnaround)
        {
					
			concreteSurgicalProcedureTurnaround.SurgicalProcedureTurnaroundId = genericSurgicalProcedureTurnaround.SurgicalProcedureTurnaroundId;			
			concreteSurgicalProcedureTurnaround.SurgicalProcedureId = genericSurgicalProcedureTurnaround.SurgicalProcedureId;			
			concreteSurgicalProcedureTurnaround.TurnaroundId = genericSurgicalProcedureTurnaround.TurnaroundId;			
			concreteSurgicalProcedureTurnaround.UsageStatusId = genericSurgicalProcedureTurnaround.UsageStatusId;			
			concreteSurgicalProcedureTurnaround.CreatedByUserId = genericSurgicalProcedureTurnaround.CreatedByUserId;			
			concreteSurgicalProcedureTurnaround.CreatedOn = genericSurgicalProcedureTurnaround.CreatedOn;			
			concreteSurgicalProcedureTurnaround.ModifiedByUserId = genericSurgicalProcedureTurnaround.ModifiedByUserId;			
			concreteSurgicalProcedureTurnaround.ModifiedOn = genericSurgicalProcedureTurnaround.ModifiedOn;
		}
	}
}
		