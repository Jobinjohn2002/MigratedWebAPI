using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyChargeReoccurringHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ChargeReoccurring concreteChargeReoccurring,
                                     ChargeReoccurring genericChargeReoccurring)
        {
            concreteChargeReoccurring.ChargeReoccurringId = genericChargeReoccurring.ChargeReoccurringId;
            concreteChargeReoccurring.ChargeId = genericChargeReoccurring.ChargeId;
            concreteChargeReoccurring.Day = genericChargeReoccurring.Day;
            concreteChargeReoccurring.LegacyFacilityOrigin = genericChargeReoccurring.LegacyFacilityOrigin;
            concreteChargeReoccurring.LegacyImported = genericChargeReoccurring.LegacyImported;
        }
    }
}