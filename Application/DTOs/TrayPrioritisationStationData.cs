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
    /// TrayPrioritisationStationData
    /// </summary>
    public class TrayPrioritisationStationData : StationDataBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TrayPrioritisationStationData"/> class.
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
        /// <param name="itemTypeId">The item type id.</param>
        /// <param name="itemType">Type of the item.</param>
        /// <param name="customerId">The customer id.</param>
        /// <param name="customerdefinitionId">The customerdefinition id.</param>
        /// <param name="customerName">Name of the customer.</param>
        /// <param name="deliveryPointId">The delivery point id.</param>
        /// <param name="deliveryPointName">Name of the delivery point.</param>
        /// <remarks></remarks>
        public TrayPrioritisationStationData(int turnaroundId,
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
                                             int itemTypeId,
                                             string itemType,
                                             int customerId,
                                             int customerdefinitionId,
                                             string customerName,
                                             int deliveryPointId,
                                             string deliveryPointName)
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
            ItemTypeId = itemTypeId;
            ItemType = itemType;
            CustomerId = customerId;
            CustomerDefinitionId = customerdefinitionId;
            CustomerName = customerName;
            DeliveryPointId = deliveryPointId;
            DeliveryPointName = deliveryPointName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrayPrioritisationStationData"/> class.
        /// </summary>
        /// <param name="result">if set to <c>true</c> [result].</param>
        /// <remarks></remarks>
        public TrayPrioritisationStationData(bool result)
        {
            OperateResult = result;
        }

        public TrayPrioritisationStationData(int turnaroundId, long turnaroundExternalId, int instanceId, string containerInstancePrimaryId,
            int serviceRequirementId, string serviceRequirementName, int itemId, string itemName, DateTime expiry, IList<DefectData> defects,
            IList<TurnaroundNoteData> notes, IList<ContainerMasterNoteData> itemNotes, DateTime startEventTime,
            int containerMasterItemTypeId, string containerMasterItemType, int customerId, int customerdefinitionId, string customerName, int deliveryPointId, string deliveryPointName,int containerMasterId)
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
            CreatedDate = startEventTime;
            DeliveryPointName = deliveryPointName;
            TurnaroundExternalId = turnaroundExternalId;
            ItemTypeId = containerMasterItemTypeId;
            ItemType = containerMasterItemType;
            CustomerId = customerId;
            CustomerDefinitionId = customerdefinitionId;
            CustomerName = customerName;
            DeliveryPointId = deliveryPointId;
            ContainerMasterId = containerMasterId;
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
        /// Gets or sets a value indicating whether [operate result].
        /// </summary>
        /// <value><c>true</c> if [operate result]; otherwise, <c>false</c>.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets OperateResult
        /// </summary>
        public bool OperateResult { get; set; }

        /// <summary>
        /// Gets or sets the item type id.
        /// </summary>
        /// <value>The item type id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public int ItemTypeId { get; set; }

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
        /// Gets or sets the customer id.
        /// </summary>
        /// <value>The customer id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customerdefinition id.
        /// </summary>
        /// <value>The customerdefinition id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>The name of the customer.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the delivery point id.
        /// </summary>
        /// <value>The delivery point id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }

        /// <summary>
        /// Gets or sets the name of the delivery point.
        /// </summary>
        /// <value>The name of the delivery point.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }

        /// <summary>
        /// Gets or sets the name of the ContainerMasterId
        /// </summary>
        /// <value>The name of the ContainerMasterId.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }
    }
}