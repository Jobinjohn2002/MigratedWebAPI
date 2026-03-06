using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
   /// <summary>
   /// VendorMaintenance_GetAllContractsForVendor_Result
   /// </summary>
   public class VendorMaintenance_GetAllContractsForVendor_Result
    {
        /// <summary>
        /// Gets or sets VendorId
        /// </summary>
        public int VendorId { get; set; }
        /// <summary>
        /// Gets or sets Cost
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// Gets or sets ContractId
        /// </summary>
        public int ContractId { get; set; }
        /// <summary>
        /// Gets or sets VendorMaintenanceActivityId
        /// </summary>
        public int VendorMaintenanceActivityId { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }
        /// <summary>
        /// Gets or sets ContractVendorMaintenanceId
        /// </summary>
        public int ContractVendorMaintenanceId { get; set; }
        /// <summary>
        /// Gets or sets InUse
        /// </summary>
        public bool InUse { get; set; }
        public DateTime? Created { get; set; }
    }
}
