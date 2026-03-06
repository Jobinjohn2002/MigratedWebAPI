using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// TransferNoteDataContract
    /// </summary>
    public class TransferNoteDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets DestinationFacility
        /// </summary>
        public FacilityInfo DestinationFacility { get; set; }
        /// <summary>
        /// Gets or sets DestinationEventType
        /// </summary>
        public EventTypeInfo DestinationEventType { get; set; }
        /// <summary>
        /// Gets or sets Transport
        /// </summary>
        public TurnaroundInfo Transport { get; set; }
        /// <summary>
        /// Gets or sets Lines
        /// </summary>
        public IEnumerable<TransferNoteLineInfo> Lines { get; set; }
        /// <summary>
        /// Gets or sets SendingFacility
        /// </summary>
        public FacilityInfo SendingFacility { get; set; }
    }
}