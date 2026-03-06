using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyExpiryCalculationTypeHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ExpiryCalculationType concreteExpiryCalculationType,
                                     ExpiryCalculationType genericExpiryCalculationType)
        {
            concreteExpiryCalculationType.ExpiryCalculationTypeId = genericExpiryCalculationType.ExpiryCalculationTypeId;
            concreteExpiryCalculationType.Text = genericExpiryCalculationType.Text;
            concreteExpiryCalculationType.LegacyFacilityOrigin = genericExpiryCalculationType.LegacyFacilityOrigin;
            concreteExpiryCalculationType.LegacyImported = genericExpiryCalculationType.LegacyImported;
        }
    }
}