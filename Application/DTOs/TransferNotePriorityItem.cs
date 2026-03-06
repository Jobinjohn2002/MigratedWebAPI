using System;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TransferNotePriorityItem
    /// </summary>
    public class TransferNotePriorityItem
    {
        DateTime expiry;
        /// <summary>
        /// Gets or sets TransferNote
        /// </summary>
        public TransferNoteInfo TransferNote { get; set; }
        /// <summary>
        /// Gets or sets Destination
        /// </summary>
        public FacilityInfo Destination { get; set; }
        /// <summary>
        /// Gets or sets DestinationEvent
        /// </summary>
        public TurnAroundEventTypeIdentifier DestinationEvent { get; set; }
        /// <summary>
        /// Gets or sets Transport
        /// </summary>
        public ContainerInstanceInfo Transport { get; set; }
        /// <summary>
        /// Gets or sets ItemCount
        /// </summary>
        public int ItemCount { get; set; }
        public DateTime Expiry
        {
            get
            {
                return expiry;
            }
            set
            {
                expiry = DateTime.SpecifyKind(value, DateTimeKind.Utc);
            }
        }
    }
}