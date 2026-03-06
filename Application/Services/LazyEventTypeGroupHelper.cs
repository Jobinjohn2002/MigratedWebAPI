using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyEventTypeGroupHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(EventTypeGroup concreteEventTypeGroup, EventTypeGroup genericEventTypeGroup)
        {
					
			concreteEventTypeGroup.EventTypeGroupId = genericEventTypeGroup.EventTypeGroupId;			
			concreteEventTypeGroup.Name = genericEventTypeGroup.Name;
		}
	}
}
		