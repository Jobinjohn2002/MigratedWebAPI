using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyRetrospectiveEventWhiteListHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(RetrospectiveEventWhiteList concreteRetrospectiveEventWhiteList, RetrospectiveEventWhiteList genericRetrospectiveEventWhiteList)
        {
					
			concreteRetrospectiveEventWhiteList.RetrospectiveEventWhiteListID = genericRetrospectiveEventWhiteList.RetrospectiveEventWhiteListID;			
			concreteRetrospectiveEventWhiteList.EventTypeId = genericRetrospectiveEventWhiteList.EventTypeId;			
			concreteRetrospectiveEventWhiteList.ItemTypeId = genericRetrospectiveEventWhiteList.ItemTypeId;
		}
	}
}
		