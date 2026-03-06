using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyContainerMasterDefinitionAuditRuleHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ContainerMasterDefinitionAuditRule concreteContainerMasterDefinitionAuditRule, ContainerMasterDefinitionAuditRule genericContainerMasterDefinitionAuditRule)
        {
					
			concreteContainerMasterDefinitionAuditRule.ContainerMasterDefinitionAuditRuleId = genericContainerMasterDefinitionAuditRule.ContainerMasterDefinitionAuditRuleId;			
			concreteContainerMasterDefinitionAuditRule.AuditRuleId = genericContainerMasterDefinitionAuditRule.AuditRuleId;			
			concreteContainerMasterDefinitionAuditRule.ContainerMasterDefinitionId = genericContainerMasterDefinitionAuditRule.ContainerMasterDefinitionId;
		}
	}
}
		