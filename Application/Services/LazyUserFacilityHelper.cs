using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyUserFacilityHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(UserFacility concreteUserFacility, UserFacility genericUserFacility)
        {
            concreteUserFacility.UserFacilityId = genericUserFacility.UserFacilityId;
            concreteUserFacility.FacilityId = genericUserFacility.FacilityId;
            concreteUserFacility.UserId = genericUserFacility.UserId;
            concreteUserFacility.Selected = genericUserFacility.Selected;
            concreteUserFacility.Primary = genericUserFacility.Primary;
            concreteUserFacility.LegacyFacilityOrigin = genericUserFacility.LegacyFacilityOrigin;
            concreteUserFacility.LegacyImported = genericUserFacility.LegacyImported;
        }
    }
}