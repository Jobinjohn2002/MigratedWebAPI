using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// InboundStationData
    /// </summary>
    public class InboundStationData : StationDataBase
    {
        public InboundStationData(
            int turnaroundId,
            int instanceUid,
            string containerInstancePrimaryId,
            int ServiceRequirementId,
            string serviceRequirementName,
            int itemId,
            string itemName,
            DateTime expiry,
            IList<DefectData> defects,
            IList<TurnaroundNoteData> notes,
            IList<ContainerMasterNoteData> itemNotes,
            DateTime createdDate,
            string nextEvent,
            string itemType)
            : base(turnaroundId,
            instanceUid,
            containerInstancePrimaryId,
            ServiceRequirementId,
            serviceRequirementName,
            itemId,
            itemName,
            expiry,
            defects,
            notes,
            itemNotes)
        {
            CreatedDate = createdDate;
            NextEvent = nextEvent;
            ItemType = itemType;
        }
        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets NextEvent
        /// </summary>
        public string NextEvent { get; set; }
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public string ItemType { get; set; }
    }
}