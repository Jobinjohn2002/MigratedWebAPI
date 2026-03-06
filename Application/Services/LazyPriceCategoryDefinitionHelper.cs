using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyPriceCategoryDefinitionHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(PriceCategoryDefinition concretePriceCategoryDefinition,
                                     PriceCategoryDefinition genericPriceCategoryDefinition)
        {
            concretePriceCategoryDefinition.PriceCategoryDefinitionId =
                genericPriceCategoryDefinition.PriceCategoryDefinitionId;
            concretePriceCategoryDefinition.PriceCategoryGroupId = genericPriceCategoryDefinition.PriceCategoryGroupId;
            concretePriceCategoryDefinition.Created = genericPriceCategoryDefinition.Created;
            concretePriceCategoryDefinition.LegacyId = genericPriceCategoryDefinition.LegacyId;
            concretePriceCategoryDefinition.LegacyFacilityOrigin = genericPriceCategoryDefinition.LegacyFacilityOrigin;
            concretePriceCategoryDefinition.LegacyImported = genericPriceCategoryDefinition.LegacyImported;
        }
    }
}