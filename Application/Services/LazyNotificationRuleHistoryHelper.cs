using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyNotificationRuleHistoryHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(NotificationRuleHistory concreteNotificationRuleHistory, NotificationRuleHistory genericNotificationRuleHistory)
        {
					
			concreteNotificationRuleHistory.NotificationRuleHistoryId = genericNotificationRuleHistory.NotificationRuleHistoryId;			
			concreteNotificationRuleHistory.NotificationRuleId = genericNotificationRuleHistory.NotificationRuleId;			
			concreteNotificationRuleHistory.TurnaroundEventId = genericNotificationRuleHistory.TurnaroundEventId;			
			concreteNotificationRuleHistory.Processed = genericNotificationRuleHistory.Processed;			
			concreteNotificationRuleHistory.NotificationRuleOutcomeId = genericNotificationRuleHistory.NotificationRuleOutcomeId;
		}
	}
}
		