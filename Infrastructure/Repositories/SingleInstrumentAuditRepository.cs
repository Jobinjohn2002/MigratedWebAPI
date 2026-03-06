using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class SingleInstrumentAuditRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public SingleInstrumentAudit Get(int singleInstrumentAuditId)
        {
            return Repository.Find(singleInstrumentAudit => singleInstrumentAudit.SingleInstrumentAuditId == singleInstrumentAuditId)?.FirstOrDefault();
        }

	    /// <summary>
	    /// GetByExternalId operation
	    /// </summary>
	    public SingleInstrumentAudit GetByExternalId(string singleInstrumentAuditId)
	    {
	        return Repository.Find(singleInstrumentAudit => singleInstrumentAudit.SingleInstrumentExternalAuditId == singleInstrumentAuditId)?.FirstOrDefault();
	    }

        /// <summary>
        /// FindLatestForTurnaroundAndStationType operation
        /// </summary>
        public SingleInstrumentAudit FindLatestForTurnaroundAndStationType(int turnaroundId, int auditLocationTypeId)
        {
            return Repository.Find(singleInstrumentAudit => singleInstrumentAudit.StartingTurnaroundEvent.TurnaroundId == turnaroundId && singleInstrumentAudit.AuditLocationCategoryId == auditLocationTypeId && singleInstrumentAudit.AuditResultTypeId != (short)Enums.SingleInstrumentTracking.AuditResultTypeIdentifier.Cancelled).OrderByDescending(sia => sia.StartingTurnaroundEvent.Created).FirstOrDefault();
        }

        /// <summary>
        /// FindLatestForTurnaround operation
        /// </summary>
        public SingleInstrumentAudit FindLatestForTurnaround(int turnaroundId)
        {
            return Repository.Find(singleInstrumentAudit => singleInstrumentAudit.StartingTurnaroundEvent.TurnaroundId == turnaroundId && singleInstrumentAudit.AuditResultTypeId != (short)Enums.SingleInstrumentTracking.AuditResultTypeIdentifier.Cancelled).OrderByDescending(sia => sia.StartingTurnaroundEvent.Created).FirstOrDefault();
        }
    }
}