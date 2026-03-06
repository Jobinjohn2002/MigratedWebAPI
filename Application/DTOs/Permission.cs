using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class Permission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /// <summary>
        /// If you require lazy loaded navigation properties use PermissionFactory.CreateEntity(WorkUnit) instead of this constructor
        /// </summary>
        public Permission()
        {
            this.RolePermission = new HashSet<RolePermission>();
            this.UserPermission = new HashSet<UserPermission>();
        }
    
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    
        /// <summary>
        /// Gets or sets PermissionId
        /// </summary>
        public short PermissionId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets AllowableBitMask
        /// </summary>
        public byte AllowableBitMask { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets UsedInOperative
        /// </summary>
        public bool UsedInOperative { get; set; }
        /// <summary>
        /// Gets or sets UsedInAdmin
        /// </summary>
        public bool UsedInAdmin { get; set; }
        /// <summary>
        /// Gets or sets UsedInSAF
        /// </summary>
        public bool UsedInSAF { get; set; }
        /// <summary>
        /// Gets or sets UsedInFinance
        /// </summary>
        public bool UsedInFinance { get; set; }
        /// <summary>
        /// Gets or sets UsedInAPI
        /// </summary>
        public bool UsedInAPI { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets RolePermission
        /// </summary>
        public virtual ICollection<RolePermission> RolePermission { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        /// <summary>
        /// Gets or sets UserPermission
        /// </summary>
        public virtual ICollection<UserPermission> UserPermission { get; set; }
    }
}
