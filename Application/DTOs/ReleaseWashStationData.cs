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
    /// ReleaseWashStationData
    /// </summary>
    public class ReleaseWashStationData : StationDataBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReleaseWashStationData"/> class.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="containerInstanceId">The container instance id.</param>
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
        /// <param name="washBatch">The wash batch.</param>
        /// <remarks></remarks>
        public ReleaseWashStationData(
            int turnaroundId,
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
            DateTime createdDate,
            string itemType,
            string washBatch)
            : base(turnaroundId,
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
            CreatedDate = createdDate;
            ItemType = itemType;
            WashBatch = washBatch;
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
        /// Gets or sets the wash batch.
        /// </summary>
        /// <value>The wash batch.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets WashBatch
        /// </summary>
        public string WashBatch { get; set; }
        /// <summary>
        /// Gets or sets ChildDefects
        /// </summary>
        public List<DefectDc> ChildDefects { get; set; }
    }
    /// <summary>
    /// DefectDc
    /// </summary>
    public class DefectDc
    {
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public long TurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets Defects
        /// </summary>
        public List<DefectInstanceDc> Defects { get; set; }
    }
    /// <summary>
    /// DefectInstanceDc
    /// </summary>
    public class DefectInstanceDc
    {
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets ClassificationId
        /// </summary>
        public int ClassificationId { get; set; }
    }
}