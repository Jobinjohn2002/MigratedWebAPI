using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyUserRoleHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(UserRole concreteUserRole, UserRole genericUserRole)
        {
            concreteUserRole.UserRoleId = genericUserRole.UserRoleId;
            concreteUserRole.UserId = genericUserRole.UserId;
            concreteUserRole.RoleId = genericUserRole.RoleId;
            concreteUserRole.LegacyFacilityOrigin = genericUserRole.LegacyFacilityOrigin;
            concreteUserRole.LegacyImported = genericUserRole.LegacyImported;
        }
    }
}