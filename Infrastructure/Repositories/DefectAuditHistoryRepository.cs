using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class DefectAuditHistoryRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public DefectAuditHistory Get(int defectAuditHistoryId)
        {
			return Repository.Find(defectAuditHistory => defectAuditHistory.DefectAuditHistoryId == defectAuditHistoryId).FirstOrDefault();
        }

        /// <summary>
        /// Read all Defect Audit History Report.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetAllDefectAuditHistory operation
        /// </summary>
        public IQueryable<IDefectAuditHistory> GetAllDefectAuditHistory(int defectId)
        {
            return
                Repository.Find(
                    defectAuditHistoryReport =>
                    defectAuditHistoryReport.DefectId == defectId).OrderBy(
                        auditHistory => auditHistory.User.UserName).ThenBy(auditHistory => auditHistory.Created);
        }
	}
}