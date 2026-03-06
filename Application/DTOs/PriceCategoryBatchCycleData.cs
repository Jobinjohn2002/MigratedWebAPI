using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class PriceCategoryBatchCycleData 
	{
        public PriceCategoryBatchCycleData(int priceCategoryBatchCycleId, int batchCycleId, string batchCycleText, int priceCategoryId, decimal charge, int? legacyId, int? legacyFacilityOrigin, DateTime? legacyImported)
        {

            PriceCategoryBatchCycleId = priceCategoryBatchCycleId;

            BatchCycleId = batchCycleId;

            BatchCycleText = batchCycleText;

            PriceCategoryId = priceCategoryId;

            Charge = charge;

            LegacyId = legacyId;

            LegacyFacilityOrigin = legacyFacilityOrigin;

            LegacyImported = legacyImported;

            EntityKeyValue = PriceCategoryBatchCycleId.ToString();
        }
        /// <summary>
        /// Gets or sets BatchCycleText
        /// </summary>
        public string BatchCycleText { get; set; }
    }
}
