using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyMultiFacilityProcessHandShakeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(MultiFacilityProcessHandShake concreteMultiFacilityProcessHandShake, IMultiFacilityProcessHandShake genericMultiFacilityProcessHandShake)
        {
					
			concreteMultiFacilityProcessHandShake.MultiFacilityProcessHandShakeId = genericMultiFacilityProcessHandShake.MultiFacilityProcessHandShakeId;			
			concreteMultiFacilityProcessHandShake.MultiFacilityProcessingId = genericMultiFacilityProcessHandShake.MultiFacilityProcessingId;			
			concreteMultiFacilityProcessHandShake.RequestingFacilityId = genericMultiFacilityProcessHandShake.RequestingFacilityId;			
			concreteMultiFacilityProcessHandShake.ProcessingFacilityName = genericMultiFacilityProcessHandShake.ProcessingFacilityName;			
			concreteMultiFacilityProcessHandShake.RecipientEmail = genericMultiFacilityProcessHandShake.RecipientEmail;			
			concreteMultiFacilityProcessHandShake.RequestedEmailBody = genericMultiFacilityProcessHandShake.RequestedEmailBody;			
			concreteMultiFacilityProcessHandShake.RequestedById = genericMultiFacilityProcessHandShake.RequestedById;			
			concreteMultiFacilityProcessHandShake.RequestedDate = genericMultiFacilityProcessHandShake.RequestedDate;			
			concreteMultiFacilityProcessHandShake.IsEnabled = genericMultiFacilityProcessHandShake.IsEnabled;			
			concreteMultiFacilityProcessHandShake.ModifiedById = genericMultiFacilityProcessHandShake.ModifiedById;			
			concreteMultiFacilityProcessHandShake.ModifiedByDate = genericMultiFacilityProcessHandShake.ModifiedByDate;
		}
	}
}
		