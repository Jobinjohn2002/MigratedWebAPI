using System.Linq;
using SynergyApplicationFrameworkApi.Application.DTOs; //Fix for model move
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class ContractVendorMaintenanceRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public ContractVendorMaintenance Get(int contractVendorMaintenanceId)
        {
            return Repository.Find(contractVendorMaintenance => contractVendorMaintenance.Id == contractVendorMaintenanceId).FirstOrDefault();
        }
	}
}