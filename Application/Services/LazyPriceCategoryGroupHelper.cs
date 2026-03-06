using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyPriceCategoryGroupHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(PriceCategoryGroup concretePriceCategoryGroup,
                                     PriceCategoryGroup genericPriceCategoryGroup)
        {
            concretePriceCategoryGroup.PriceCategoryGroupId = genericPriceCategoryGroup.PriceCategoryGroupId;
            concretePriceCategoryGroup.ArchivedUserId = genericPriceCategoryGroup.ArchivedUserId;
            concretePriceCategoryGroup.CreatedUserId = genericPriceCategoryGroup.CreatedUserId;
            concretePriceCategoryGroup.CustomerDefinitionId = genericPriceCategoryGroup.CustomerDefinitionId;
            concretePriceCategoryGroup.Text = genericPriceCategoryGroup.Text;
            concretePriceCategoryGroup.Created = genericPriceCategoryGroup.Created;
            concretePriceCategoryGroup.Archived = genericPriceCategoryGroup.Archived;
            concretePriceCategoryGroup.LegacyId = genericPriceCategoryGroup.LegacyId;
            concretePriceCategoryGroup.LegacyFacilityOrigin = genericPriceCategoryGroup.LegacyFacilityOrigin;
            concretePriceCategoryGroup.LegacyImported = genericPriceCategoryGroup.LegacyImported;
        }
    }
}