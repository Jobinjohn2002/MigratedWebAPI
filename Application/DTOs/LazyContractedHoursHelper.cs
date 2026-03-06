using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class LazyContractedHoursHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ContractedHours concreteContractedHours,
                                     ContractedHours genericContractedHours)
        {
            concreteContractedHours.ContractedHoursId = genericContractedHours.ContractedHoursId;
            concreteContractedHours.CustomerId = genericContractedHours.CustomerId;
            concreteContractedHours.DayOfWeek = genericContractedHours.DayOfWeek;
            concreteContractedHours.Opening = genericContractedHours.Opening;
            concreteContractedHours.Closing = genericContractedHours.Closing;
            concreteContractedHours.Closed = genericContractedHours.Closed;
            concreteContractedHours.LegacyFacilityOrigin = genericContractedHours.LegacyFacilityOrigin;
            concreteContractedHours.LegacyImported = genericContractedHours.LegacyImported;
        }
    }
}