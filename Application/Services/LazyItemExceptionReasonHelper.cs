using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyItemExceptionReasonHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ItemExceptionReason concreteItemExceptionReason, ItemExceptionReason genericItemExceptionReason)
        {
					
			concreteItemExceptionReason.ItemExceptionReasonId = genericItemExceptionReason.ItemExceptionReasonId;			
			concreteItemExceptionReason.ArchivedUserId = genericItemExceptionReason.ArchivedUserId;			
			concreteItemExceptionReason.Text = genericItemExceptionReason.Text;			
			concreteItemExceptionReason.Archived = genericItemExceptionReason.Archived;			
			concreteItemExceptionReason.LegacyFacilityOrigin = genericItemExceptionReason.LegacyFacilityOrigin;			
			concreteItemExceptionReason.LegacyImported = genericItemExceptionReason.LegacyImported;			
			concreteItemExceptionReason.RemovedFromContainer = genericItemExceptionReason.RemovedFromContainer;
		}
	}
}
		