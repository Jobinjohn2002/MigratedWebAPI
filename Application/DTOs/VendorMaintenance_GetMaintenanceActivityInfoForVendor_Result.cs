using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
   /// <summary>
   /// VendorMaintenance_GetMaintenanceActivityInfoForVendor_Result
   /// </summary>
   public class VendorMaintenance_GetMaintenanceActivityInfoForVendor_Result
    {
        /// <summary>
        /// Gets or sets VendorMaintenanceActivityId
        /// </summary>
        public int VendorMaintenanceActivityId { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceActivityId
        /// </summary>
        public int MaintenanceActivityId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        public DateTime? Created { get; set; }
        /// <summary>
        /// Gets or sets NumberOfCustomersActivityEnabledFor
        /// </summary>
        public int NumberOfCustomersActivityEnabledFor { get; set; }
        /// <summary>
        /// Gets or sets NumberOfContractsActivityInUse
        /// </summary>
        public int NumberOfContractsActivityInUse { get; set; }

    }
}
