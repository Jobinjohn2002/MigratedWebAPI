using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyPermissionHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Permission concretePermission, Permission genericPermission)
        {
            concretePermission.PermissionId = genericPermission.PermissionId;
            concretePermission.Text = genericPermission.Text;
            concretePermission.AllowableBitMask = genericPermission.AllowableBitMask;
            concretePermission.LegacyFacilityOrigin = genericPermission.LegacyFacilityOrigin;
            concretePermission.LegacyImported = genericPermission.LegacyImported;
        }
    }
}