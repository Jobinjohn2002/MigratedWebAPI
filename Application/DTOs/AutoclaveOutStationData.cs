using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// AutoclaveOutStationData
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    /// <summary>
    /// AutoclaveOutStationData
    /// </summary>
    public class AutoclaveOutStationData : StationDataBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoclaveOutStationData"/> class.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="turnaroundExternalId">The turnaround external id.</param>
        /// <param name="instanceId">The instance id.</param>
        /// <param name="containerInstancePrimaryId">The instance primary id.</param>
        /// <param name="serviceRequirementId">The service requirement id.</param>
        /// <param name="serviceRequirementName">Name of the service requirement.</param>
        /// <param name="itemId">The item id.</param>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="expiry">The expiry.</param>
        /// <param name="defects">The defects.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="itemNotes">The item notes.</param>
        /// <param name="createdDate">The created date.</param>
        /// <param name="batchId">The batch id.</param>
        /// <param name="nextEvent">The next event.</param>
        /// <remarks></remarks>
        public AutoclaveOutStationData(
            int turnaroundId,
            Int64 turnaroundExternalId,
            int instanceId,
            string containerInstancePrimaryId,
            int serviceRequirementId,
            string serviceRequirementName,
            int itemId,
            string itemName,
            DateTime expiry,
            IList<DefectData> defects,
            IList<TurnaroundNoteData> notes,
            IList<ContainerMasterNoteData> itemNotes,
            DateTime createdDate,
            string batchId,
            string nextEvent)
            : base(turnaroundId,
                   turnaroundExternalId,
                   instanceId,
                   containerInstancePrimaryId,
                   serviceRequirementId,
                   serviceRequirementName,
                   itemId,
                   itemName,
                   expiry,
                   defects,
                   notes,
                   itemNotes)
        {
            CreatedDate = createdDate;
            BatchId = batchId;
            NextEvent = nextEvent;
        }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the batch id.
        /// </summary>
        /// <value>The batch id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets BatchId
        /// </summary>
        public string BatchId { get; set; }

        /// <summary>
        /// Gets or sets the next event.
        /// </summary>
        /// <value>The next event.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets NextEvent
        /// </summary>
        public string NextEvent { get; set; }
    }
}