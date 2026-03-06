using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class VendorFacility
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use VendorFacilityFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public VendorFacility()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets VendorFacilityId
        /// </summary>
        public int VendorFacilityId { get; set; }
        /// <summary>
        /// Gets or sets VendorId
        /// </summary>
        public int VendorId { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
        public System.DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }
    
        /// <summary>
        /// Gets or sets Facility
        /// </summary>
        public virtual Facility Facility { get; set; }
        /// <summary>
        /// Gets or sets Vendor
        /// </summary>
        public virtual Vendor Vendor { get; set; }
    }
}
