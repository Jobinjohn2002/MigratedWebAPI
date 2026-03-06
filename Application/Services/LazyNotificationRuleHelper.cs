using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyNotificationRuleHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(NotificationRule concreteNotificationRule, NotificationRule genericNotificationRule)
        {
					
			concreteNotificationRule.NotificationRuleId = genericNotificationRule.NotificationRuleId;			
			concreteNotificationRule.TenancyId = genericNotificationRule.TenancyId;			
			concreteNotificationRule.FacilityId = genericNotificationRule.FacilityId;			
			concreteNotificationRule.CustomerDefinitionId = genericNotificationRule.CustomerDefinitionId;			
			concreteNotificationRule.EventTypeId = genericNotificationRule.EventTypeId;			
			concreteNotificationRule.ItemTypeId = genericNotificationRule.ItemTypeId;			
			concreteNotificationRule.IsIdentifiable = genericNotificationRule.IsIdentifiable;			
			concreteNotificationRule.Deny = genericNotificationRule.Deny;			
			concreteNotificationRule.PerBatch = genericNotificationRule.PerBatch;			
			concreteNotificationRule.Archived = genericNotificationRule.Archived;			
			concreteNotificationRule.CreatedUserId = genericNotificationRule.CreatedUserId;			
			concreteNotificationRule.CreatedDate = genericNotificationRule.CreatedDate;			
			concreteNotificationRule.ModifiedUserId = genericNotificationRule.ModifiedUserId;			
			concreteNotificationRule.ModifiedDate = genericNotificationRule.ModifiedDate;
		}
	}
}
		