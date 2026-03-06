using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyPriceCategoryBatchCycleHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(PriceCategoryBatchCycle concretePriceCategoryBatchCycle,
                                     PriceCategoryBatchCycle genericPriceCategoryBatchCycle)
        {
            concretePriceCategoryBatchCycle.PriceCategoryBatchCycleId =
                genericPriceCategoryBatchCycle.PriceCategoryBatchCycleId;
            concretePriceCategoryBatchCycle.BatchCycleId = genericPriceCategoryBatchCycle.BatchCycleId;
            concretePriceCategoryBatchCycle.PriceCategoryId = genericPriceCategoryBatchCycle.PriceCategoryId;
            concretePriceCategoryBatchCycle.Charge = genericPriceCategoryBatchCycle.Charge;
            concretePriceCategoryBatchCycle.LegacyId = genericPriceCategoryBatchCycle.LegacyId;
            concretePriceCategoryBatchCycle.LegacyFacilityOrigin = genericPriceCategoryBatchCycle.LegacyFacilityOrigin;
            concretePriceCategoryBatchCycle.LegacyImported = genericPriceCategoryBatchCycle.LegacyImported;
        }
    }
}