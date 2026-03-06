using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyOwnerHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Owner concreteOwner, Owner genericOwner)
        {
					
			concreteOwner.OwnerId = genericOwner.OwnerId;
            concreteOwner.TenancyId = genericOwner.TenancyId;
            concreteOwner.DateTimeFormatId = genericOwner.DateTimeFormatId;
            concreteOwner.TimeZoneId = genericOwner.TimeZoneId;
		}
	}
}
		