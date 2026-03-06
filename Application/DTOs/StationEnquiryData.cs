using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// StationEnquiryData
    /// </summary>
    public class StationEnquiryData : StationDataBase
    {
        public StationEnquiryData(
            int turnaroundId,
            Int64 turnaroundExternalId,
            int instanceUid,
            string containerInstancePrimaryId,
            int serviceRequirementId,
            string serviceRequirementName,
            int itemUid,
            string itemName,
            DateTime expiry,
            IList<DefectData> defects,
            IList<TurnaroundNoteData> notes,
            IList<ContainerMasterNoteData> itemNotes,
            DateTime createdDate,
            IList<TurnaroundEventData> turnaroundEvents,
            string nextState)
            : base(turnaroundId,
            turnaroundExternalId,
            instanceUid,
            containerInstancePrimaryId,
            serviceRequirementId,
            serviceRequirementName,
            itemUid,
            itemName,
            expiry,
            defects,
            notes,
            itemNotes)
        {
            CreatedDate = createdDate;
            TurnaroundEvents = turnaroundEvents;
            NextState = nextState;
        }
        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEvents
        /// </summary>
        public IList<TurnaroundEventData> TurnaroundEvents { get; set; }
        /// <summary>
        /// Gets or sets NextState
        /// </summary>
        public string NextState { get; set; }

    }
}