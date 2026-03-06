using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyVendorMaintenanceActivityHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(VendorMaintenanceActivity concreteVendorMaintenanceActivity, VendorMaintenanceActivity genericVendorMaintenanceActivity)
        {
					
			concreteVendorMaintenanceActivity.VendorMaintenanceActivityId = genericVendorMaintenanceActivity.VendorMaintenanceActivityId;			
			concreteVendorMaintenanceActivity.MaintenanceActivityId = genericVendorMaintenanceActivity.MaintenanceActivityId;			
			concreteVendorMaintenanceActivity.Created = genericVendorMaintenanceActivity.Created;			
			concreteVendorMaintenanceActivity.VendorId = genericVendorMaintenanceActivity.VendorId;			
			concreteVendorMaintenanceActivity.Text = genericVendorMaintenanceActivity.Text;			
			concreteVendorMaintenanceActivity.Code = genericVendorMaintenanceActivity.Code;			
			concreteVendorMaintenanceActivity.CreatedUserId = genericVendorMaintenanceActivity.CreatedUserId;
		}
	}
}
		