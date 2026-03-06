using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class Vendor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use VendorFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public Vendor()
        {
            this.MaintenanceReport = new HashSet<MaintenanceReport>();
            this.VendorFacility = new HashSet<VendorFacility>();
            this.VendorRepairCost = new HashSet<VendorRepairCost>();
            this.Contract = new HashSet<Contract>();
            this.VendorContact = new HashSet<VendorContact>();
            this.VendorMaintenanceActivity = new HashSet<VendorMaintenanceActivity>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets VendorId
        /// </summary>
        public int VendorId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets AddressId
        /// </summary>
        public Nullable<int> AddressId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        public System.DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public Nullable<int> CreatedUserId { get; set; }
        /// <summary>
        /// Gets or sets ContactName
        /// </summary>
        public string ContactName { get; set; }
    
        /// <summary>
        /// Gets or sets Address
        /// </summary>
        public virtual Address Address { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets MaintenanceReport
        /// </summary>
        public virtual ICollection<MaintenanceReport> MaintenanceReport { get; set; }
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets VendorFacility
        /// </summary>
        public virtual ICollection<VendorFacility> VendorFacility { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets VendorRepairCost
        /// </summary>
        public virtual ICollection<VendorRepairCost> VendorRepairCost { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets Contract
        /// </summary>
        public virtual ICollection<Contract> Contract { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets VendorContact
        /// </summary>
        public virtual ICollection<VendorContact> VendorContact { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets VendorMaintenanceActivity
        /// </summary>
        public virtual ICollection<VendorMaintenanceActivity> VendorMaintenanceActivity { get; set; }
    }
}
