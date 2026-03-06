using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// IndividualInstrumentTrackingEventContract
    /// </summary>
    /// <remarks></remarks>
    public partial class IndividualInstrumentTrackingEventContract
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndividualInstrumentTrackingEventContract"/> class.
        /// </summary>
        /// <param name="individualInstrumentTrackingEventId">The individual instrument tracking event id.</param>
        /// <param name="itemInstanceId">The item instance id.</param>
        /// <param name="turnaroundEventId">The turnaround event id.</param>
        /// <param name="trackDateTime">The track date time.</param>
        /// <remarks></remarks>
        public IndividualInstrumentTrackingEventContract(
            int individualInstrumentTrackingEventId,
            int itemInstanceId,
            int turnaroundEventId,
            DateTime trackDateTime)
        {
            IndividualInstrumentTrackingEventId = individualInstrumentTrackingEventId;

            ItemInstanceId = itemInstanceId;

            TurnaroundEventId = turnaroundEventId;

            Created = trackDateTime;

            EntityKeyValue = IndividualInstrumentTrackingEventId.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndividualInstrumentTrackingEventContract"/> class.
        /// </summary>
        /// <param name="itemInstanceId">The item instance id.</param>
        /// <param name="turnaroundEventId">The turnaround event id.</param>
        /// <param name="trackDateTime">The track date time.</param>
        /// <remarks></remarks>
        public IndividualInstrumentTrackingEventContract(
            int itemInstanceId,
            int turnaroundEventId,
            DateTime trackDateTime)
        {
            ItemInstanceId = itemInstanceId;

            TurnaroundEventId = turnaroundEventId;

            Created = trackDateTime;

            EntityKeyValue = IndividualInstrumentTrackingEventId.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndividualInstrumentTrackingEventContract"/> class.
        /// </summary>
        /// <param name="itemInstanceId">The item instance id.</param>
        /// <param name="turnaroundEventId">The turnaround event id.</param>
        /// <param name="trackDateTime">The track date time.</param>
        /// <param name="itemMasterId">The item master id.</param>
        /// <remarks></remarks>
        public IndividualInstrumentTrackingEventContract(
            int itemInstanceId,
            int turnaroundEventId,
            DateTime trackDateTime,
            int itemMasterId)
        {
            ItemInstanceId = itemInstanceId;

            TurnaroundEventId = turnaroundEventId;

            Created = trackDateTime;

            EntityKeyValue = IndividualInstrumentTrackingEventId.ToString();

            ItemMasterId = itemMasterId;
        }

        /// <summary>
        /// Gets or sets the item master id.
        /// </summary>
        /// <value>The item master id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemMasterId
        /// </summary>
        public int ItemMasterId { get; set; }
    }
}
