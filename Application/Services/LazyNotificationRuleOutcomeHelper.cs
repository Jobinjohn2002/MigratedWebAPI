using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyNotificationRuleOutcomeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(NotificationRuleOutcome concreteNotificationRuleOutcome, NotificationRuleOutcome genericNotificationRuleOutcome)
        {
					
			concreteNotificationRuleOutcome.NotificationRuleOutcomeId = genericNotificationRuleOutcome.NotificationRuleOutcomeId;			
			concreteNotificationRuleOutcome.Text = genericNotificationRuleOutcome.Text;
		}
	}
}
		