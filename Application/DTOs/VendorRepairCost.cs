using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class VendorRepairCost
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use VendorRepairCostFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public VendorRepairCost()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets VendorRepairCostId
        /// </summary>
        public int VendorRepairCostId { get; set; }
        /// <summary>
        /// Gets or sets VendorId
        /// </summary>
        public int VendorId { get; set; }
        /// <summary>
        /// Gets or sets RepairCategoryId
        /// </summary>
        public int RepairCategoryId { get; set; }
        /// <summary>
        /// Gets or sets RepairCode
        /// </summary>
        public string RepairCode { get; set; }
        /// <summary>
        /// Gets or sets Cost
        /// </summary>
        public decimal Cost { get; set; }
        public System.DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public Nullable<int> CreatedUserId { get; set; }
    
        /// <summary>
        /// Gets or sets RepairCategory
        /// </summary>
        public virtual RepairCategory RepairCategory { get; set; }
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// Gets or sets Vendor
        /// </summary>
        public virtual Vendor Vendor { get; set; }
    }
}
