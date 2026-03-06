using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyUserPermissionHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(UserPermission concreteUserPermission,
                                     UserPermission genericUserPermission)
        {
            concreteUserPermission.UserPermissionId = genericUserPermission.UserPermissionId;
            concreteUserPermission.PermissionId = genericUserPermission.PermissionId;
            concreteUserPermission.UserId = genericUserPermission.UserId;
            concreteUserPermission.AllowedFunction = genericUserPermission.AllowedFunction;
            concreteUserPermission.LegacyFacilityOrigin = genericUserPermission.LegacyFacilityOrigin;
            concreteUserPermission.LegacyImported = genericUserPermission.LegacyImported;
        }
    }
}