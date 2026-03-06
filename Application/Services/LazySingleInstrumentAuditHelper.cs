using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazySingleInstrumentAuditHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(SingleInstrumentAudit concreteSingleInstrumentAudit, SingleInstrumentAudit genericSingleInstrumentAudit)
        {
					
			concreteSingleInstrumentAudit.SingleInstrumentAuditId = genericSingleInstrumentAudit.SingleInstrumentAuditId;			
			concreteSingleInstrumentAudit.StartedTurnaroundEventId = genericSingleInstrumentAudit.StartedTurnaroundEventId;			
			concreteSingleInstrumentAudit.EndedTurnaroundEventId = genericSingleInstrumentAudit.EndedTurnaroundEventId;			
			concreteSingleInstrumentAudit.UserId = genericSingleInstrumentAudit.UserId;			
			concreteSingleInstrumentAudit.StationId = genericSingleInstrumentAudit.StationId;						
			concreteSingleInstrumentAudit.AuditResultTypeId = genericSingleInstrumentAudit.AuditResultTypeId;
		}
	}
}
		