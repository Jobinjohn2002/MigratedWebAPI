using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DestinationEvent
    /// </summary>
    public class DestinationEvent
    {
        /// <summary>
        /// Gets or sets EventType
        /// </summary>
        public TurnAroundEventTypeIdentifier EventType { get; set; }
        /// <summary>
        /// Gets or sets Restrictions
        /// </summary>
        public List<FacilityRestriction> Restrictions { get; set; }
    }
}