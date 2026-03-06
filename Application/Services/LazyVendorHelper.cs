using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyVendorHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Vendor concreteVendor, Vendor genericVendor)
        {
					
			concreteVendor.VendorId = genericVendor.VendorId;			
			concreteVendor.ExternalId = genericVendor.ExternalId;			
			concreteVendor.AddressId = genericVendor.AddressId;			
			concreteVendor.Text = genericVendor.Text;			
			concreteVendor.Created = genericVendor.Created;			
			concreteVendor.CreatedUserId = genericVendor.CreatedUserId;
		}
	}
}
		