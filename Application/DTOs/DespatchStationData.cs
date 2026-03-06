using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// DespatchStationData
    /// </summary>
    public class DespatchStationData : StationDataBase
    {
        public DespatchStationData(
            int turnaroundId,
            long turnaroundExternalId,
            int containerInstanceId,
            string containerInstancePrimaryId,
            int serviceRequirementId,
            string serviceRequirementName,
            int itemId,
            string itemName,
            DateTime expiry,
            IList<DefectData> defects,
            IList<TurnaroundNoteData> notes,
            IList<ContainerMasterNoteData> itemNotes,
            int deliveryNoteId,
            int deliveryNoteExternalId)
            : base(turnaroundId,
            turnaroundExternalId,
            containerInstanceId,
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
            DeliveryNoteId = deliveryNoteId;
            DeliveryNoteExternalId = deliveryNoteExternalId;
        }
        /// <summary>
        /// Gets or sets DeliveryNoteId
        /// </summary>
        public int DeliveryNoteId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryNoteExternalId
        /// </summary>
        public int DeliveryNoteExternalId { get; set; }
    }
}