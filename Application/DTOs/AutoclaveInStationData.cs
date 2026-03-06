using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// AutoclaveInStationData
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    /// <summary>
    /// AutoclaveInStationData
    /// </summary>
    public class AutoclaveInStationData : StationDataBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoclaveInStationData"/> class.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="turnaroundExternalId">The turnaround external id.</param>
        /// <param name="instanceId">The instance id.</param>
        /// <param name="instancePrimarylId">The instance primary id.</param>
        /// <param name="serviceRequirementId">The service requirement id.</param>
        /// <param name="serviceRequirementName">Name of the service requirement.</param>
        /// <param name="itemId">The item id.</param>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="expiry">The expiry.</param>
        /// <param name="defects">The defects.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="itemNotes">The item notes.</param>
        /// <param name="batchId">The batch id.</param>
        /// <param name="nextEvent">The next event.</param>
        /// <remarks></remarks>
        public AutoclaveInStationData(
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
            int? batchId,
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
            BatchId = batchId;
            NextEvent = nextEvent;
        }

        /// <summary>
        /// Gets or sets the batch id.
        /// </summary>
        /// <value>The batch id.</value>
        /// <remarks></remarks>
        public int? BatchId { get; set; }

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