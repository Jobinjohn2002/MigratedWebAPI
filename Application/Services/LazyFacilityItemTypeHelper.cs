using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyFacilityItemTypeHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(FacilityItemType concreteFacilityItemType,
                                     FacilityItemType genericFacilityItemType)
        {
            concreteFacilityItemType.FacilityItemTypeId = genericFacilityItemType.FacilityItemTypeId;
            concreteFacilityItemType.FacilityId = genericFacilityItemType.FacilityId;
            concreteFacilityItemType.ItemTypeId = genericFacilityItemType.ItemTypeId;
            concreteFacilityItemType.LegacyFacilityOrigin = genericFacilityItemType.LegacyFacilityOrigin;
            concreteFacilityItemType.LegacyImported = genericFacilityItemType.LegacyImported;

        }
    }
}