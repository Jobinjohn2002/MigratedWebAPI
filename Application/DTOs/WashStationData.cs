using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// WashStationData
    /// </summary>
    public class WashStationData : StationDataBase
    {
        public WashStationData(
            int turnaroundId,
            int containerInstanceId,
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
            string itemType,
            string nextEvent,long? turnaroundExternalId=null)
            : base(turnaroundId,
            containerInstanceId,
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
            ItemType = itemType;
            NextEvent = nextEvent;
            TurnaroundExternalId = turnaroundExternalId.GetValueOrDefault();
        }

        public WashStationData(
            int turnaroundId,
            int containerInstanceId,
            string containerInstancePrimaryId,
            DateTime createdDate,
            int noOfItems)
            : base(turnaroundId,
            containerInstanceId,
            containerInstancePrimaryId,
            0,
            string.Empty,
            0,
            string.Empty,
            DateTime.MinValue,
            null,
            null,
            null)
        {
            CreatedDate = createdDate;
            NoOfItems = noOfItems;
        }
        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public string ItemType { get; set; }
        /// <summary>
        /// Gets or sets NextEvent
        /// </summary>
        public string NextEvent { get; set; }
        /// <summary>
        /// Gets or sets NoOfItems
        /// </summary>
        public int NoOfItems { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public int ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets BaseItemType
        /// </summary>
        public int BaseItemType { get; set; }
        public short? NextEventTypeId { get; set; }
    }
}