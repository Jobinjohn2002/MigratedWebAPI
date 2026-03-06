using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyRolePermissionHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(RolePermission concreteRolePermission,
                                     RolePermission genericRolePermission)
        {
            concreteRolePermission.RolePermissionId = genericRolePermission.RolePermissionId;
            concreteRolePermission.RoleId = genericRolePermission.RoleId;
            concreteRolePermission.PermissionId = genericRolePermission.PermissionId;
            concreteRolePermission.AllowedFunction = genericRolePermission.AllowedFunction;
            concreteRolePermission.LegacyFacilityOrigin = genericRolePermission.LegacyFacilityOrigin;
            concreteRolePermission.LegacyImported = genericRolePermission.LegacyImported;
        }
    }
}