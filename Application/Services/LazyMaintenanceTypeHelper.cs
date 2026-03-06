using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyMaintenanceTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(MaintenanceType concreteMaintenanceType, MaintenanceType genericMaintenanceType)
        {
					
			concreteMaintenanceType.MaintenanceTypeId = genericMaintenanceType.MaintenanceTypeId;			
			concreteMaintenanceType.Text = genericMaintenanceType.Text;			
			concreteMaintenanceType.IsSytemProcess = genericMaintenanceType.IsSytemProcess;
		}
	}
}
		