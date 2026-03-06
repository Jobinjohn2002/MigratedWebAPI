using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyMaintenanceInstrumentStatusHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(MaintenanceInstrumentStatus concreteMaintenanceInstrumentStatus, MaintenanceInstrumentStatus genericMaintenanceInstrumentStatus)
        {
					
			concreteMaintenanceInstrumentStatus.MaintenanceInstrumentStatusId = genericMaintenanceInstrumentStatus.MaintenanceInstrumentStatusId;			
			concreteMaintenanceInstrumentStatus.Text = genericMaintenanceInstrumentStatus.Text;
		}
	}
}
		