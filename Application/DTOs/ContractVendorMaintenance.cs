using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class ContractVendorMaintenance
    {
        public ContractVendorMaintenance()
        {
            this.PlannedMaintenanceRules = new HashSet<PlannedMaintenanceRule>();
        }
    
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets ContractId
        /// </summary>
        public int ContractId { get; set; }
        /// <summary>
        /// Gets or sets VendorMaintenanceActivityId
        /// </summary>
        public int VendorMaintenanceActivityId { get; set; }
        /// <summary>
        /// Gets or sets Cost
        /// </summary>
        public Nullable<decimal> Cost { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public Nullable<int> CreatedUserId { get; set; }
    
        /// <summary>
        /// Gets or sets Contract
        /// </summary>
        public virtual Contract Contract { get; set; }
        /// <summary>
        /// Gets or sets VendorMaintenanceActivity
        /// </summary>
        public virtual VendorMaintenanceActivity VendorMaintenanceActivity { get; set; }
        /// <summary>
        /// Gets or sets PlannedMaintenanceRules
        /// </summary>
        public virtual ICollection<PlannedMaintenanceRule> PlannedMaintenanceRules { get; set; }
    }
}
