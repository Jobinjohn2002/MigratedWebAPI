using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class VendorContact
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use VendorContactFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public VendorContact()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets VendorContactId
        /// </summary>
        public int VendorContactId { get; set; }
        /// <summary>
        /// Gets or sets ContactId
        /// </summary>
        public int ContactId { get; set; }
        /// <summary>
        /// Gets or sets VendorId
        /// </summary>
        public int VendorId { get; set; }
    
        /// <summary>
        /// Gets or sets Vendor
        /// </summary>
        public virtual Vendor Vendor { get; set; }
        /// <summary>
        /// Gets or sets Contact
        /// </summary>
        public virtual Contact Contact { get; set; }
    }
}
