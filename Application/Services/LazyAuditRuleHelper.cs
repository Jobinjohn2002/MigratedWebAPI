using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyAuditRuleHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(AuditRule concreteAuditRule, AuditRule genericAuditRule)
        {
					
			concreteAuditRule.AuditRuleId = genericAuditRule.AuditRuleId;			
			concreteAuditRule.AuditTypeId = genericAuditRule.AuditTypeId;		
			concreteAuditRule.IsEnabled = genericAuditRule.IsEnabled;			
			concreteAuditRule.CreatedByUserId = genericAuditRule.CreatedByUserId;			
			concreteAuditRule.Created = genericAuditRule.Created;			
			concreteAuditRule.Archived = genericAuditRule.Archived;
		}
	}
}
		