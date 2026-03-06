using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class VendorData 
	{

        public VendorData()
        { }

        public VendorData(IVendor genericObj,
          AddressData address,
          IList<VendorRepairCostData> vendorRepairCostList)
            : this(genericObj)
        {
            Address = address;
            VendorRepairCostList = vendorRepairCostList;
        }
        /// <summary>
        /// Gets or sets Address
        /// </summary>
        public AddressData Address { get; set; }
        /// <summary>
        /// Gets or sets VendorRepairCostList
        /// </summary>
        public IList<VendorRepairCostData> VendorRepairCostList { get; set; }
        /// <summary>
        /// Gets or sets VendorContactsBookList
        /// </summary>
        public IList<ContactData> VendorContactsBookList { get; set; }
        /// <summary>
        /// Gets or sets VendorMaintenanceActivityList
        /// </summary>
        public IList<VendorActivityData> VendorMaintenanceActivityList { get; set; }  
	}
}
		