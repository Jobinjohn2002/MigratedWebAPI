using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyRoleHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Role concreteRole, Role genericRole)
        {
            concreteRole.RoleId = genericRole.RoleId;
            concreteRole.ArchivedUserId = genericRole.ArchivedUserId;
            concreteRole.Text = genericRole.Text;
            concreteRole.Archived = genericRole.Archived;
            concreteRole.LegacyFacilityOrigin = genericRole.LegacyFacilityOrigin;
            concreteRole.LegacyImported = genericRole.LegacyImported;
        }
    }
}