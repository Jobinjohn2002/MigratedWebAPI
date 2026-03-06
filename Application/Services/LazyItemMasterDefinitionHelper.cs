using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyItemMasterDefinitionHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ItemMasterDefinition concreteItemMasterDefinition,
                                     ItemMasterDefinition genericItemMasterDefinition)
        {
            concreteItemMasterDefinition.ItemMasterDefinitionId = genericItemMasterDefinition.ItemMasterDefinitionId;
            concreteItemMasterDefinition.LegacyId = genericItemMasterDefinition.LegacyId;
            concreteItemMasterDefinition.LegacyFacilityOrigin = genericItemMasterDefinition.LegacyFacilityOrigin;
            concreteItemMasterDefinition.LegacyImported = genericItemMasterDefinition.LegacyImported;
        }
    }
}