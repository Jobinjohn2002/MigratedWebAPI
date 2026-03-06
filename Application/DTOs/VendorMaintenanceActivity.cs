using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class VendorMaintenanceActivity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use VendorMaintenanceActivityFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public VendorMaintenanceActivity()
        {
            this.ContractVendorMaintenance = new HashSet<ContractVendorMaintenance>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets VendorMaintenanceActivityId
        /// </summary>
        public int VendorMaintenanceActivityId { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceActivityId
        /// </summary>
        public Nullable<int> MaintenanceActivityId { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        /// <summary>
        /// Gets or sets VendorId
        /// </summary>
        public Nullable<int> VendorId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets Code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public Nullable<int> CreatedUserId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets ContractVendorMaintenance
        /// </summary>
        public virtual ICollection<ContractVendorMaintenance> ContractVendorMaintenance { get; set; }
        /// <summary>
        /// Gets or sets Vendor
        /// </summary>
        public virtual Vendor Vendor { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceActivity
        /// </summary>
        public virtual MaintenanceActivity MaintenanceActivity { get; set; }
    }
}
