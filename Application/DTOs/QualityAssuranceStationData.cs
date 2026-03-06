using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    /// <summary>
    /// QualityAssuranceStationData
    /// </summary>
    public class QualityAssuranceStationData : StationDataBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QualityAssuranceStationData"/> class.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
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
        /// <param name="itemType">Type of the item.</param>
        /// <param name="nextEvent">The next event.</param>
        /// <param name="packer">The packer.</param>
        /// <remarks></remarks>
        public QualityAssuranceStationData(int turnaroundId,
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
            string itemType,
            string nextEvent,
            string packer,bool isTurnaroundPrinted)
            : base(turnaroundId,
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
            ItemType = itemType;
            NextEvent = nextEvent;
            Packer = packer;
            IsTurnaroundPrinted = isTurnaroundPrinted;
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
        /// Gets or sets the type of the item.
        /// </summary>
        /// <value>The type of the item.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public string ItemType { get; set; }

        /// <summary>
        /// Gets or sets the next event.
        /// </summary>
        /// <value>The next event.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets NextEvent
        /// </summary>
        public string NextEvent { get; set; }

        /// <summary>
        /// Gets or sets the packer.
        /// </summary>
        /// <value>The packer.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Packer
        /// </summary>
        public string Packer { get; set; }
        /// <summary>
        /// Gets or sets IsTurnaroundPrinted
        /// </summary>
        public bool IsTurnaroundPrinted { get; set; }

    }
}