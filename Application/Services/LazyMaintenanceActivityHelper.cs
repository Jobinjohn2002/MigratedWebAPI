using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyMaintenanceActivityHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(MaintenanceActivity concreteMaintenanceActivity, MaintenanceActivity genericMaintenanceActivity)
        {
					
			concreteMaintenanceActivity.MaintenanceActivityId = genericMaintenanceActivity.MaintenanceActivityId;			
			concreteMaintenanceActivity.Text = genericMaintenanceActivity.Text;			
			concreteMaintenanceActivity.Created = genericMaintenanceActivity.Created;			
			concreteMaintenanceActivity.Code = genericMaintenanceActivity.Code;
		}
	}
}
		