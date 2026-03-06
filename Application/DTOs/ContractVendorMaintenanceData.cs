using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class ContractVendorMaintenanceData 
	{
        public ContractVendorMaintenanceData()
        {

        }
        /// <summary>
        /// Gets or sets InUse
        /// </summary>
        public bool InUse { get; set; }
    }
}
		