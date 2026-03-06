using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyMultiFacilityProcessRestrictionHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(MultiFacilityProcessRestriction concreteMultiFacilityProcessRestriction, MultiFacilityProcessRestriction genericMultiFacilityProcessRestriction)
        {
					
			concreteMultiFacilityProcessRestriction.MultiFacilityProcessRestrictionId = genericMultiFacilityProcessRestriction.MultiFacilityProcessRestrictionId;			
			concreteMultiFacilityProcessRestriction.MultiFacilityProcessHandShakeId = genericMultiFacilityProcessRestriction.MultiFacilityProcessHandShakeId;			
			concreteMultiFacilityProcessRestriction.FromSenderEventTypeId = genericMultiFacilityProcessRestriction.FromSenderEventTypeId;			
			concreteMultiFacilityProcessRestriction.ToRecipientEventTypeId = genericMultiFacilityProcessRestriction.ToRecipientEventTypeId;
		}
	}
}
		