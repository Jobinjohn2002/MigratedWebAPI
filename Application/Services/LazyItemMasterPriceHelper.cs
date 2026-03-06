using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyItemMasterPriceHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ItemMasterPrice concreteItemMasterPrice,
                                     ItemMasterPrice genericItemMasterPrice)
        {
            concreteItemMasterPrice.ItemMasterPriceId = genericItemMasterPrice.ItemMasterPriceId;
            concreteItemMasterPrice.ItemMasterId = genericItemMasterPrice.ItemMasterId;
            concreteItemMasterPrice.CustomerDefinitionId = genericItemMasterPrice.CustomerDefinitionId;
            concreteItemMasterPrice.BasePrice = genericItemMasterPrice.BasePrice;
            concreteItemMasterPrice.LegacyId = genericItemMasterPrice.LegacyId;
            concreteItemMasterPrice.LegacyFacilityOrigin = genericItemMasterPrice.LegacyFacilityOrigin;
            concreteItemMasterPrice.LegacyImported = genericItemMasterPrice.LegacyImported;
        }
    }
}