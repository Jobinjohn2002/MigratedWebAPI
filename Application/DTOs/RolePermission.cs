using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class RolePermission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use RolePermissionFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public RolePermission()
        {
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets RolePermissionId
        /// </summary>
        public int RolePermissionId { get; set; }
        /// <summary>
        /// Gets or sets RoleId
        /// </summary>
        public short RoleId { get; set; }
        /// <summary>
        /// Gets or sets PermissionId
        /// </summary>
        public short PermissionId { get; set; }
        /// <summary>
        /// Gets or sets AllowedFunction
        /// </summary>
        public byte AllowedFunction { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
    
        /// <summary>
        /// Gets or sets Permission
        /// </summary>
        public virtual Permission Permission { get; set; }
        /// <summary>
        /// Gets or sets Role
        /// </summary>
        public virtual Role Role { get; set; }
    }
}
