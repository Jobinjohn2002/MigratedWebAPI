using System;
using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class TurnaroundData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <remarks></remarks>
        public TurnaroundData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TurnaroundData"/> class.
        /// </summary>
        /// <param name="genericObj">The generic obj.</param>
        /// <param name="containerInstancePrimaryId">The instance primary id.</param>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="serviceRequirement">The service requirement.</param>
        /// <param name="itemTypeId">The item type id.</param>
        /// <param name="itemType">Type of the item.</param>
        /// <param name="nextEventtypeName"></param>
        /// <remarks></remarks>
        public TurnaroundData(ITurnaround genericObj, string containerInstancePrimaryId, string itemName, string serviceRequirement, short itemTypeId, string itemType, int? lastEventtypeId, int? nextEventtypeid, int containerMasterDefnitionId,string nextEventtypeName = null)
            : this(genericObj)
        {
             
            TurnaroundId = genericObj.TurnaroundId;

            Created = genericObj.Created;

            ServiceRequirementId = genericObj.ServiceRequirementId;

            DeliveryPointId = genericObj.DeliveryPointId;

            DeliveryNoteId = genericObj.DeliveryNoteId;

            Expiry = genericObj.Expiry;

            ItemInstanceId = genericObj.ItemInstanceId;

            ContainerInstanceId = genericObj.ContainerInstanceId;

            ParentTurnaroundId = genericObj.ParentTurnaroundId;

            CreatedUserId = genericObj.CreatedUserId;

            ExternalId = genericObj.ExternalId;

            ContainerInstancePrimaryId = containerInstancePrimaryId;
            ItemName = itemName;
            ServiceRequirementText = serviceRequirement;
            ItemTypeId = itemTypeId;
            ItemType = itemType;
            LastEventTypeId = lastEventtypeId;
            NextEventTypeText = nextEventtypeName;
            NextEventTypeId = nextEventtypeid;
            BatchCycleId = genericObj.BatchCycleId;
            ContainerMasterExternalId = genericObj.ContainerMasterExternalId;
            ItemInstanceTypeId = genericObj.ItemInstanceTypeId;
            BaseItemTypeId = genericObj.BaseItemTypeId;
            ContainerMasterDefinitionId = containerMasterDefnitionId;
        }

        /// <summary>
        /// Create operation
        /// </summary>
        public static TurnaroundData Create(ITurnaround turnaround)
        {
            return new TurnaroundData(turnaround)
            {
                Priority = turnaround.Priority,
                FacilityName =turnaround.FacilityName
            };
        }

        #region extra Members
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
        /// Gets or sets the service requirement.
        /// </summary>
        /// <value>The service requirement.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ServiceRequirementText
        /// </summary>
        public string ServiceRequirementText { get; set; }

        /// <summary>
        /// Gets or sets the service requirement.
        /// </summary>
        /// <summary>
        /// Gets or sets ServiceRequirement
        /// </summary>
        public ServiceRequirementData ServiceRequirement { get; set; }

        /// <summary>
        /// Gets or sets the item type id.
        /// </summary>
        /// <value>The item type id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public short ItemTypeId { get; set; }

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
        /// Gets or sets the master external id.
        /// </summary>
        /// <value>The master external id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets MasterExternalId
        /// </summary>
        public string MasterExternalId { get; set; }

        /// <summary>
        /// Gets or sets the name of the master.
        /// </summary>
        /// <value>The name of the master.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets MasterName
        /// </summary>
        public string MasterName { get; set; }

        /// <summary>
        /// Gets or sets the last event created date.
        /// </summary>
        /// <value>The last event created date.</value>
        /// <remarks></remarks>
        public DateTime? LastEventCreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the last event event type id.
        /// </summary>
        /// <value>The last event event type id.</value>
        /// <remarks></remarks>
        public int? LastEventEventTypeId { get; set; }

        /// <summary>
        /// Gets or sets the last name of the event event type.
        /// </summary>
        /// <value>The last name of the event event type.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets LastEventEventTypeName
        /// </summary>
        public string LastEventEventTypeName { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        /// <remarks></remarks>
        public int? Status { get; set; }
        /// <summary>
        /// Gets or sets StatusDetails
        /// </summary>
        public string StatusDetails { get; set; }
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
        /// Gets or sets the deliverynote external id.
        /// </summary>
        /// <value>The deliverynote external id.</value>
        /// <remarks></remarks>
        public int? DeliveryNoteExternalId { get; set; }

        /// <summary>
        /// Gets or sets the child turnarounds.
        /// </summary>
        /// <value>The child turnarounds.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ChildTurnarounds
        /// </summary>
        public IList<TurnaroundData> ChildTurnarounds { get; set; }
        /// <summary>
        /// Gets or sets LastBatchOfAutoclave
        /// </summary>
        public string LastBatchOfAutoclave { get; set; }

        /// <summary>
        /// The RAG priority of the turnaround
        /// </summary>
        /// <summary>
        /// Gets or sets Priority
        /// </summary>
        public TurnaroundPriority Priority { get; set; }

        /// <summary>
        /// The next event type
        /// </summary>
        /// <summary>
        /// Gets or sets NextEventType
        /// </summary>
        public EventTypeData NextEventType { get; set; }

        /// <summary>
        /// The base item type of the associated container master
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerMasterBaseItemType
        /// </summary>
        public ItemTypeData ContainerMasterBaseItemType { get; set; }

        /// <summary>
        /// When Turnaround objects are grouped, the number of turnarounds in the group
        /// </summary>
        /// <summary>
        /// Gets or sets TurnaroundCount
        /// </summary>
        public int TurnaroundCount { get; set; }

        /// <summary>
        /// The text of the associated container master
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerMasterText
        /// </summary>
        public string ContainerMasterText { get; set; }

        /// <summary>
        /// The ID of the associated base item type of the associated container master
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerMasterBaseItemTypeId
        /// </summary>
        public int ContainerMasterBaseItemTypeId { get; set; }

        /// <summary>
        /// The text of the associated base item type of the associated container master
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerMasterBaseItemTypeText
        /// </summary>
        public string ContainerMasterBaseItemTypeText { get; set; }

        /// <summary>
        /// The text of the associated sub item type of the associated container master
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerMasterItemTypeText
        /// </summary>
        public string ContainerMasterItemTypeText { get; set; }

        /// <summary>
        /// The primary ID of the associated container instance
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }

        /// <summary>
        /// The created date of the associated last event
        /// </summary>
        /// <summary>
        /// Gets or sets LastEventCreated
        /// </summary>
        public DateTime LastEventCreated { get; set; }

        /// <summary>
        /// The text of the associated event type of the associated last event
        /// </summary>
        /// <summary>
        /// Gets or sets LastEventEventTypeText
        /// </summary>
        public string LastEventEventTypeText { get; set; }

        /// <summary>
        /// The text of the associated customer
        /// </summary>
        /// <summary>
        /// Gets or sets CustomerText
        /// </summary>
        public string CustomerText { get; set; }

        /// <summary>
        /// The ID of the associated event type of the associated next event
        /// </summary>
        public int? NextEventTypeId { get; set; }

        /// <summary>
        /// The text of the associated event type of the associated next event
        /// </summary>
        /// <summary>
        /// Gets or sets NextEventTypeText
        /// </summary>
        public string NextEventTypeText { get; set; }

        /// <summary>
        /// The ID of the associated process event type
        /// </summary>
        public int? LastProcessEventTypeId { get; set; }

        /// <summary>
        /// The text of the associated process event type
        /// </summary>
        /// <summary>
        /// Gets or sets LastProcessEventTypeText
        /// </summary>
        public string LastProcessEventTypeText { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionId
        /// </summary>
        public int ContainerMasterDefinitionId { get; set; }

        #endregion extra Members

        /// <summary>
        /// Gets or sets the exist defects.
        /// </summary>
        /// <value>The exist defects.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ExistsDefects
        /// </summary>
        public IList<IDefect> ExistsDefects { get; set; }

        /// <summary>
        /// Gets or sets the exist notes.
        /// </summary>
        /// <value>The exist notes.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ExistsNotes
        /// </summary>
        public IList<ITurnaroundNote> ExistsNotes { get; set; }

        /// <summary>
        /// Gets or sets the exist item notes.
        /// </summary>
        /// <value>The exists item notes.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ExistsItemNotes
        /// </summary>
        public IList<IContainerMasterNote> ExistsItemNotes { get; set; }
        /// <summary>
        /// Gets or sets AnyOverdue
        /// </summary>
        public bool AnyOverdue { get; set; }
        /// <summary>
        /// Gets or sets OverdueTurnaroundCount
        /// </summary>
        public int OverdueTurnaroundCount { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ProductionEventTypeId
        /// </summary>
        public int ProductionEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets ProductionEventTypeText
        /// </summary>
        public string ProductionEventTypeText { get; set; }
        /// <summary>
        /// Gets or sets FacilityEmailAddress
        /// </summary>
        public string FacilityEmailAddress { get; set; }
        public int? LastEventTypeId { get; set; }
        public int? NextEventTypeWHId { get; set; }
        public int? ServiceRequirementDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets QuarantineReasonText
        /// </summary>
        public string QuarantineReasonText { get; set; }

        /// <summary>
        /// The  Process Station Type Id
        /// </summary>
        public int? ProcessStationTypeId { get; set; }

        /// <summary>
        /// The Station Id
        /// </summary>
        public int? StationId { get; set; }

        /// <summary>
        /// The Turnaround Event Required is true or false
        /// </summary>
        public bool? IsTurnaroundEventRequired { get; set; }

        /// <summary>
        /// The Event TypeId
        /// </summary>
        public int? EventTypeId { get; set; }

        /// <summary>
        /// The Workflow Id
        /// </summary>
        public int? WorkflowId { get; set; }

        /// <summary>
        /// The Is Non Sterile Product
        /// </summary>
        /// <summary>
        /// Gets or sets IsNonSterileProduct
        /// </summary>
        public bool IsNonSterileProduct { get; set; }

        /// <summary>
        /// Gets or sets the external id of the Container Master
        /// </summary>
        /// <value>The external id of the Container Master.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerMasterExternalId
        /// </summary>
        public string ContainerMasterExternalId { get; set; }
        /// <summary>
        /// Gets or sets BatchCycleId
        /// </summary>
        public int BatchCycleId { get; set; }

        /// <summary>
        /// When Turnaround objects are grouped, the number of turnarounds in the group
        /// </summary>
        /// <summary>
        /// Gets or sets HighPriorityCount
        /// </summary>
        public int HighPriorityCount { get; set; }

        /// <summary>
        /// When Turnaround objects are grouped, the number of turnarounds in the group
        /// </summary>
        /// <summary>
        /// Gets or sets MediumPriorityCount
        /// </summary>
        public int MediumPriorityCount { get; set; }
        /// <summary>
        /// Gets or sets ActiveItemMasterText
        /// </summary>
        public string ActiveItemMasterText { get; set; }
        /// <summary>
        /// Gets or sets ItemInstanceExternalId
        /// </summary>
        public string ItemInstanceExternalId { get; set; }
        public int? ItemInstanceTypeId { get; set; }
        public short? BaseItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets IsTurnaroundPrinted
        /// </summary>
        public bool IsTurnaroundPrinted { get; set; }
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }

        /// <summary>
        /// EventDisplayOrder
        /// </summary>
        /// <summary>
        /// Gets or sets EventDisplayOrder
        /// </summary>
        public int EventDisplayOrder { get; set; }
        public int? OutgoingCount { get; set; }
        public int? IncomingCount { get; set; }

    }
}