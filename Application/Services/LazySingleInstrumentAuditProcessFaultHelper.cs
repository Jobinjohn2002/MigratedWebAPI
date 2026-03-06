using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazySingleInstrumentAuditProcessFaultHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(SingleInstrumentAuditProcessFault concreteSingleInstrumentAuditProcessFault, SingleInstrumentAuditProcessFault genericSingleInstrumentAuditProcessFault)
        {
					
			concreteSingleInstrumentAuditProcessFault.SingleInstrumentAuditProcessFaultId = genericSingleInstrumentAuditProcessFault.SingleInstrumentAuditProcessFaultId;			
			concreteSingleInstrumentAuditProcessFault.SingleInstrumentAuditId = genericSingleInstrumentAuditProcessFault.SingleInstrumentAuditId;			
			concreteSingleInstrumentAuditProcessFault.ScannedBarcodeValue = genericSingleInstrumentAuditProcessFault.ScannedBarcodeValue;			
			concreteSingleInstrumentAuditProcessFault.AuditProcessFaultReasonId = genericSingleInstrumentAuditProcessFault.AuditProcessFaultReasonId;
		}
	}
}
		