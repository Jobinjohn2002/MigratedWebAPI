using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazySingleInstrumentAuditLineHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(SingleInstrumentAuditLine concreteSingleInstrumentAuditLine, SingleInstrumentAuditLine genericSingleInstrumentAuditLine)
        {
					
			concreteSingleInstrumentAuditLine.SingleInstrumentAuditLineId = genericSingleInstrumentAuditLine.SingleInstrumentAuditLineId;			
			concreteSingleInstrumentAuditLine.SingleInstrumentAuditId = genericSingleInstrumentAuditLine.SingleInstrumentAuditId;			
			concreteSingleInstrumentAuditLine.ItemInstanceIdentifierTypeId = genericSingleInstrumentAuditLine.ItemInstanceIdentifierTypeId;			
			concreteSingleInstrumentAuditLine.ItemInstanceId = genericSingleInstrumentAuditLine.ItemInstanceId;			
			concreteSingleInstrumentAuditLine.IsRequiredBySpecification = genericSingleInstrumentAuditLine.IsRequiredBySpecification;			
			concreteSingleInstrumentAuditLine.AuditLineStatusTypeId = genericSingleInstrumentAuditLine.AuditLineStatusTypeId;			
			concreteSingleInstrumentAuditLine.AuditLineExceptionReasonId = genericSingleInstrumentAuditLine.AuditLineExceptionReasonId;
		}
	}
}
		