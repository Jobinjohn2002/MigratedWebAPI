using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyVendorContactHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(VendorContact concreteVendorContact, VendorContact genericVendorContact)
        {
					
			concreteVendorContact.VendorContactId = genericVendorContact.VendorContactId;			
			concreteVendorContact.ContactId = genericVendorContact.ContactId;			
			concreteVendorContact.VendorId = genericVendorContact.VendorId;
		}
	}
}
		