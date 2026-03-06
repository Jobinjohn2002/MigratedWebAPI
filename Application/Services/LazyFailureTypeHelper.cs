using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyFailureTypeHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(FailureType concreteFailureType, FailureType genericFailureType)
        {
            concreteFailureType.FailureTypeId = genericFailureType.FailureTypeId;
            concreteFailureType.Text = genericFailureType.Text;
            concreteFailureType.LegacyFacilityOrigin = genericFailureType.LegacyFacilityOrigin;
            concreteFailureType.LegacyImported = genericFailureType.LegacyImported;
        }
    }
}