using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
    public partial class FacilityAuditRuleRepository
    {
        /// <summary>
        /// Get operation
        /// </summary>
        public FacilityAuditRule Get(int facilityAuditRuleId)
        {
            return Repository.Find(facilityAuditRule => facilityAuditRule.FacilityAuditRuleId == facilityAuditRuleId).FirstOrDefault();
        }

        /// <summary>
        /// GetAllForFacility operation
        /// </summary>
        public List<FacilityAuditRule> GetAllForFacility(short facilityId)
        {
            return Repository.Find(far => far.FacilityId == facilityId && far.AuditRule.Archived == null).ToList();
        }
    }
}