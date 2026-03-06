using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyNotificationOutputHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(NotificationOutput concreteNotificationOutput, NotificationOutput genericNotificationOutput)
        {
					
			concreteNotificationOutput.NotificationOutputId = genericNotificationOutput.NotificationOutputId;			
			concreteNotificationOutput.NotificationRuleId = genericNotificationOutput.NotificationRuleId;			
			concreteNotificationOutput.OutputTypeId = genericNotificationOutput.OutputTypeId;			
			concreteNotificationOutput.CommunicationTypeId = genericNotificationOutput.CommunicationTypeId;			
			concreteNotificationOutput.RecipientTypeId = genericNotificationOutput.RecipientTypeId;			
			concreteNotificationOutput.NumberOfCopies = genericNotificationOutput.NumberOfCopies;			
			concreteNotificationOutput.CustomStationeryId = genericNotificationOutput.CustomStationeryId;
		}
	}
}
		