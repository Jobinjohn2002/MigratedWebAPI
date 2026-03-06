using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyFacilityAuditRuleHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(FacilityAuditRule concreteFacilityAuditRule, FacilityAuditRule genericFacilityAuditRule)
        {
					
			concreteFacilityAuditRule.FacilityAuditRuleId = genericFacilityAuditRule.FacilityAuditRuleId;			
			concreteFacilityAuditRule.AuditRuleId = genericFacilityAuditRule.AuditRuleId;			
			concreteFacilityAuditRule.FacilityId = genericFacilityAuditRule.FacilityId;
		}
	}
}
		