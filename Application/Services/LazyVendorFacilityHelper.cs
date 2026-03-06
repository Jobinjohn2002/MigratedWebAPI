using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyVendorFacilityHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(VendorFacility concreteVendorFacility, VendorFacility genericVendorFacility)
        {
					
			concreteVendorFacility.VendorFacilityId = genericVendorFacility.VendorFacilityId;			
			concreteVendorFacility.VendorId = genericVendorFacility.VendorId;			
			concreteVendorFacility.FacilityId = genericVendorFacility.FacilityId;			
			concreteVendorFacility.Created = genericVendorFacility.Created;			
			concreteVendorFacility.CreatedUserId = genericVendorFacility.CreatedUserId;
		}
	}
}
		