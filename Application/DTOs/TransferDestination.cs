using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TransferDestination
    /// </summary>
    public class TransferDestination
    {
        /// <summary>
        /// Gets or sets Facility
        /// </summary>
        public FacilityInfo Facility { get; set; }
        /// <summary>
        /// Gets or sets RelationshipToSender
        /// </summary>
        public RelationshipType RelationshipToSender { get; set; }
        /// <summary>
        /// Gets or sets DestinationEvents
        /// </summary>
        public List<DestinationEvent> DestinationEvents { get; set; }
        /// <summary>
        /// Gets or sets SelectedDestinationEvent
        /// </summary>
        public DestinationEvent SelectedDestinationEvent { get; set; }
    }
}