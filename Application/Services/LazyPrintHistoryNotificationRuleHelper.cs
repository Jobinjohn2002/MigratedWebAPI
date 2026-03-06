using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyPrintHistoryNotificationRuleHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(PrintHistoryNotificationRule concretePrintHistoryNotificationRule, PrintHistoryNotificationRule genericPrintHistoryNotificationRule)
        {
					
			concretePrintHistoryNotificationRule.PrintHistoryNotificationRuleId = genericPrintHistoryNotificationRule.PrintHistoryNotificationRuleId;			
			concretePrintHistoryNotificationRule.PrintHistoryId = genericPrintHistoryNotificationRule.PrintHistoryId;				
			concretePrintHistoryNotificationRule.NotificationRuleId = genericPrintHistoryNotificationRule.NotificationRuleId;	
		}
	}
}
		