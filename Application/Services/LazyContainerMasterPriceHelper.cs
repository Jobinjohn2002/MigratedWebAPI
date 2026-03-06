using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyContainerMasterPriceHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ContainerMasterPrice concreteContainerMasterPrice,
                                     ContainerMasterPrice genericContainerMasterPrice)
        {
            concreteContainerMasterPrice.ContainerMasterPriceId = genericContainerMasterPrice.ContainerMasterPriceId;
            concreteContainerMasterPrice.ContainerMasterId = genericContainerMasterPrice.ContainerMasterId;
            concreteContainerMasterPrice.PriceCategoryDefinitionId =
                genericContainerMasterPrice.PriceCategoryDefinitionId;
            concreteContainerMasterPrice.ManualPriceCategoryCharge =
                genericContainerMasterPrice.ManualPriceCategoryCharge;
            concreteContainerMasterPrice.ManualSingleUseItemCharge =
                genericContainerMasterPrice.ManualSingleUseItemCharge;
            concreteContainerMasterPrice.LegacyId = genericContainerMasterPrice.LegacyId;
            concreteContainerMasterPrice.LegacyCustomerId = genericContainerMasterPrice.LegacyCustomerId;
            concreteContainerMasterPrice.LegacyFacilityOrigin = genericContainerMasterPrice.LegacyFacilityOrigin;
            concreteContainerMasterPrice.LegacyImported = genericContainerMasterPrice.LegacyImported;
        }
    }
}