using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Base Station Data
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    /// <summary>
    /// StationDataBase
    /// </summary>
    public class StationDataBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <remarks></remarks>
        public StationDataBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StationDataBase"/> class.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="turnaroundExternalId"></param>
        /// <param name="containerContainerInstanceId">The container instance id.</param>
        /// <param name="containerInstancePrimaryId">The container instance primary id.</param>
        /// <param name="serviceRequirementId">The service requirement id.</param>
        /// <param name="serviceRequirementName">Name of the service requirement.</param>
        /// <param name="itemId">The item id.</param>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="expiry">The expiry.</param>
        /// <param name="defects">The defects.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="itemNotes">The item notes.</param>
        /// <remarks></remarks>
        public StationDataBase(
            int turnaroundId,
            long turnaroundExternalId,
            int containerContainerInstanceId,
            string containerInstancePrimaryId,
            int serviceRequirementId,
            string serviceRequirementName,
            int itemId,
            string itemName,
            DateTime expiry,
            IList<DefectData> defects,
            IList<TurnaroundNoteData> notes,
            IList<ContainerMasterNoteData> itemNotes)
        {
            TurnaroundId = turnaroundId;
            ContainerInstanceId = containerContainerInstanceId;
            ContainerInstancePrimaryId = containerInstancePrimaryId;
            ServiceRequirementId = serviceRequirementId;
            ServiceRequirementName = serviceRequirementName;
            ItemId = itemId;
            ItemName = itemName;
            Expiry = expiry;
            Defects = defects;
            Notes = notes;
            ItemNotes = itemNotes;
            TurnaroundExternalId = turnaroundExternalId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StationDataBase"/> class.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="containerContainerInstanceId">The container instance id.</param>
        /// <param name="containerInstanceExternalId">The container instance external id.</param>
        /// <param name="serviceRequirementId">The service requirement id.</param>
        /// <param name="serviceRequirementName">Name of the service requirement.</param>
        /// <param name="itemId">The item id.</param>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="expiry">The expiry.</param>
        /// <param name="defects">The defects.</param>
        /// <param name="notes">The notes.</param>
        /// <param name="itemNotes">The item notes.</param>
        /// <remarks></remarks>
        public StationDataBase(
            int turnaroundId,
            int containerContainerInstanceId,
            string containerInstanceExternalId,
            int serviceRequirementId,
            string serviceRequirementName,
            int itemId,
            string itemName,
            DateTime expiry,
            IList<DefectData> defects,
            IList<TurnaroundNoteData> notes,
            IList<ContainerMasterNoteData> itemNotes)
        {
            TurnaroundId = turnaroundId;
            ContainerInstanceId = containerContainerInstanceId;
            this.ContainerInstancePrimaryId = containerInstanceExternalId;
            ServiceRequirementId = serviceRequirementId;
            ServiceRequirementName = serviceRequirementName;
            ItemId = itemId;
            ItemName = itemName;
            Expiry = expiry;
            Defects = defects;
            Notes = notes;
            ItemNotes = itemNotes;
        }

        #region IStationData Members
        /// <summary>
        /// Gets or sets PrintJobs
        /// </summary>
        public IList<PrintDetailsDataContract> PrintJobs { get; set; }

        /// <summary>
        /// Gets or sets the turnaround id.
        /// </summary>
        /// <value>The turnaround id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }

        /// <summary>
        /// Gets or sets the container instance id.
        /// </summary>
        /// <value>The container instance id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public int ContainerInstanceId { get; set; }

        /// <summary>
        /// Gets or sets the container instance id.
        /// </summary>
        /// <value>The container instance id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public long TurnaroundExternalId { get; set; }

        /// <summary>
        /// Gets or sets the instance primary id.
        /// </summary>
        /// <value>The instance primary id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }

        /// <summary>
        /// Gets or sets the service requirement id.
        /// </summary>
        /// <value>The service requirement id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ServiceRequirementId
        /// </summary>
        public int ServiceRequirementId { get; set; }

        /// <summary>
        /// Gets or sets the name of the service requirement.
        /// </summary>
        /// <value>The name of the service requirement.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ServiceRequirementName
        /// </summary>
        public string ServiceRequirementName { get; set; }

        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        /// <value>The item id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemId
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        /// <value>The name of the item.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Gets or sets the expiry.
        /// </summary>
        /// <value>The expiry.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Expiry
        /// </summary>
        public DateTime Expiry { get; set; }

        /// <summary>
        /// Gets or sets the defects.
        /// </summary>
        /// <value>The defects.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Defects
        /// </summary>
        public IList<DefectData> Defects { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Notes
        /// </summary>
        public IList<TurnaroundNoteData> Notes { get; set; }

        /// <summary>
        /// Gets or sets the item notes.
        /// </summary>
        /// <value>The item notes.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemNotes
        /// </summary>
        public IList<ContainerMasterNoteData> ItemNotes { get; set; }

        #endregion
    }
}