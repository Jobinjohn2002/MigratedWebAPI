using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyPriceCategoryHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(PriceCategory concretePriceCategory, PriceCategory genericPriceCategory)
        {
            concretePriceCategory.PriceCategoryId = genericPriceCategory.PriceCategoryId;
            concretePriceCategory.ArchivedUserId = genericPriceCategory.ArchivedUserId;
            concretePriceCategory.CreatedUserId = genericPriceCategory.CreatedUserId;
            concretePriceCategory.PriceCategoryDefinitionId = genericPriceCategory.PriceCategoryDefinitionId;
            concretePriceCategory.ExternalId = genericPriceCategory.ExternalId;
            concretePriceCategory.Text = genericPriceCategory.Text;
            concretePriceCategory.MaximumComponents = genericPriceCategory.MaximumComponents;
            concretePriceCategory.Created = genericPriceCategory.Created;
            concretePriceCategory.Archived = genericPriceCategory.Archived;
            concretePriceCategory.LegacyId = genericPriceCategory.LegacyId;
            concretePriceCategory.LegacyFacilityOrigin = genericPriceCategory.LegacyFacilityOrigin;
            concretePriceCategory.LegacyImported = genericPriceCategory.LegacyImported;
        }
    }
}