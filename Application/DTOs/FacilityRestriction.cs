using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FacilityRestriction
    /// </summary>
    public class FacilityRestriction
    {
        /// <summary>
        /// Gets or sets OwningFacility
        /// </summary>
        public FacilityInfo OwningFacility { get; set; }
        /// <summary>
        /// Gets or sets FromEvents
        /// </summary>
        public List<TurnAroundEventTypeIdentifier> FromEvents { get; set; } 
    }
}