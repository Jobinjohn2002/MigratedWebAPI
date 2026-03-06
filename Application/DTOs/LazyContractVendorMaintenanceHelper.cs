using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class LazyContractVendorMaintenanceHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ContractVendorMaintenance concreteContractVendorMaintenance, ContractVendorMaintenance genericContractVendorMaintenance)
        {
					
			concreteContractVendorMaintenance.Id = genericContractVendorMaintenance.Id;			
			concreteContractVendorMaintenance.ContractId = genericContractVendorMaintenance.ContractId;			
			concreteContractVendorMaintenance.VendorMaintenanceActivityId = genericContractVendorMaintenance.VendorMaintenanceActivityId;			
			concreteContractVendorMaintenance.Cost = genericContractVendorMaintenance.Cost;			
			concreteContractVendorMaintenance.Created = genericContractVendorMaintenance.Created;			
			concreteContractVendorMaintenance.CreatedUserId = genericContractVendorMaintenance.CreatedUserId;
		}
	}
}
		