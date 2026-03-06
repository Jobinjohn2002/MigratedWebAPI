using System;
using SynergyApplicationFrameworkApi.Application.DTOs;
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
    /// <summary>
    /// TurnaroundWHDetailData
    /// </summary>
    public class TurnaroundWHDetailData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <remarks></remarks>
        public TurnaroundWHDetailData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TurnaroundWHDetailData"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <remarks></remarks>
        public TurnaroundWHDetailData(ITurnaroundWHDetail data)
        {
            TurnaroundWHId = data.TurnaroundWHId;
            ContainerMasterId = data.ContainerMasterId;
            ContainerMasterDefinitionId = data.ContainerMasterDefinitionId;
            ContainerMasterExternalId = data.ContainerMasterExternalId;
            ContainerMasterName = data.ContainerMasterName;
            ContainerMasterItemTypeId = data.ContainerMasterItemTypeId;
            ContainerMasterItemType = data.ContainerMasterItemType;
            ContainerMasterBaseItemTypeId = data.ContainerMasterBaseItemTypeId;
            ContainerMasterBaseItemType = data.ContainerMasterBaseItemType;
            ContainerInstanceId = data.ContainerInstanceId;
            ContainerInstanceExternalId = data.ContainerInstanceExternalId;
            ServiceRequirementId = data.ServiceRequirementId;
            ServiceRequirementName = data.ServiceRequirementName;
            DeliveryPointId = data.DeliveryPointId;
            DeliveryPointName = data.DeliveryPointName;
            CustomerId = data.CustomerId;
            CustomerName = data.CustomerName;
            FacilityId = data.FacilityId;
            FacilityName = data.FacilityName;
            DeliveryNoteId = data.DeliveryNoteId;
            StartEventTime = data.StartEventTime;
            LastEventId = data.LastEventId;
            LastEventTypeId = data.LastEventTypeId;
            LastEventName = data.LastEventName;
            LastEventTime = data.LastEventTime;
            NextEventTypeId = data.NextEventTypeId;
            NextEventName = data.NextEventName;
            Expiry = data.Expiry;
            BatchId = data.BatchId;
            TurnaroundId = data.TurnaroundId;
            ParentTurnaroundId = data.ParentTurnaroundId;
            HasChildren = data.HasChildren;
            TurnaroundExternalId = data.TurnaroundExternalId;
            DeliveryNoteExternalId = data.DeliveryNoteExternalId;
            Order = data.Order;
            LegacyExternalId = data.LegacyExternalId;
            Priority = data.Priority;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TurnaroundWHDetailData"/> class.
        /// </summary>
        /// <param name="turnaroundWHId">The turnaround WH id.</param>
        /// <param name="containerMasterId">The container master id.</param>
        /// <param name="containerMasterDefinitionId">The container master definition id.</param>
        /// <param name="containerMasterExternalId">The container master external id.</param>
        /// <param name="containerMasterName">Name of the container master.</param>
        /// <param name="containerMasterItemTypeId">The container master item type id.</param>
        /// <param name="containerMasterItemType">Type of the container master item.</param>
        /// <param name="containerMasterBaseItemTypeId">The container master base item type id.</param>
        /// <param name="containerMasterBaseItemType">Type of the container master base item.</param>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="containerInstanceExternalId">The container instance external id.</param>
        /// <param name="serviceRequirementId">The service requirement id.</param>
        /// <param name="serviceRequirementName">Name of the service requirement.</param>
        /// <param name="deliveryPointId">The delivery point id.</param>
        /// <param name="deliveryPointName">Name of the delivery point.</param>
        /// <param name="customerId">The customer id.</param>
        /// <param name="customerName">Name of the customer.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="facilityName">Name of the facility.</param>
        /// <param name="deliveryNoteId">The deliverynote id.</param>
        /// <param name="startEventTime">The start event time.</param>
        /// <param name="lastEventId">The last event id.</param>
        /// <param name="lastEventTypeId">The last event type id.</param>
        /// <param name="lastEventName">Last name of the event.</param>
        /// <param name="lastEventTime">The last event time.</param>
        /// <param name="nextEventTypeId">The next event type id.</param>
        /// <param name="nextEventName">Name of the next event.</param>
        /// <param name="expiry">The expiry.</param>
        /// <param name="batchId">The batch id.</param>
        /// <param name="turnaroundid">The turnaroundid.</param>
        /// <param name="parentTurnaroundId">The parent turnaround id.</param>
        /// <param name="hasChildren">The has children.</param>
        /// <param name="turnaroundExternalId">The turnaround external id.</param>
        /// <param name="deliveryNoteExternalId">The deliverynote external id.</param>
        /// <param name="order">The order.</param>
        /// <param name="legacyExternalId">The legacy external id.</param>
        /// <remarks></remarks>
        public TurnaroundWHDetailData(int turnaroundWHId, int containerMasterId, int containerMasterDefinitionId,
                                      string containerMasterExternalId, string containerMasterName,
                                      int containerMasterItemTypeId, string containerMasterItemType,
                                      int containerMasterBaseItemTypeId, string containerMasterBaseItemType,
                                      int containerInstanceId, string containerInstanceExternalId,
                                      int serviceRequirementId, string serviceRequirementName, int deliveryPointId,
                                      string deliveryPointName, int customerId, string customerName, short facilityId,
                                      string facilityName, int deliveryNoteId, DateTime? startEventTime, int lastEventId,
                                      int? lastEventTypeId, string lastEventName, DateTime? lastEventTime,
                                      int? nextEventTypeId, string nextEventName, DateTime expiry, int batchId,
                                      int turnaroundid, int? parentTurnaroundId, bool? hasChildren,
                                      long turnaroundExternalId, int? deliveryNoteExternalId, int? order,
                                      string legacyExternalId)
        {
            TurnaroundWHId = turnaroundWHId;
            ContainerMasterId = containerMasterId;
            ContainerMasterDefinitionId = containerMasterDefinitionId;
            ContainerMasterExternalId = containerMasterExternalId;
            ContainerMasterName = containerMasterName;
            ContainerMasterItemTypeId = containerMasterItemTypeId;
            ContainerMasterItemType = containerMasterItemType;
            ContainerMasterBaseItemTypeId = containerMasterBaseItemTypeId;
            ContainerMasterBaseItemType = containerMasterBaseItemType;
            ContainerInstanceId = containerInstanceId;
            ContainerInstanceExternalId = containerInstanceExternalId;
            ServiceRequirementId = serviceRequirementId;
            ServiceRequirementName = serviceRequirementName;
            DeliveryPointId = deliveryPointId;
            DeliveryPointName = deliveryPointName;
            CustomerId = customerId;
            CustomerName = customerName;
            FacilityId = facilityId;
            FacilityName = facilityName;
            DeliveryNoteId = deliveryNoteId;
            StartEventTime = startEventTime;
            LastEventId = lastEventId;
            LastEventTypeId = lastEventTypeId;
            LastEventName = lastEventName;
            LastEventTime = lastEventTime;
            NextEventTypeId = nextEventTypeId;
            NextEventName = nextEventName;
            Expiry = expiry;
            BatchId = batchId;
            TurnaroundId = turnaroundid;
            ParentTurnaroundId = parentTurnaroundId;
            HasChildren = hasChildren;
            TurnaroundExternalId = turnaroundExternalId;
            DeliveryNoteExternalId = deliveryNoteExternalId;
            Order = order;
            LegacyExternalId = legacyExternalId;
        }

        #region ITurnaroundWHDetail Members

        /// <summary>
        /// Gets or sets the turnaround WH id.
        /// </summary>
        /// <value>The turnaround WH id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets TurnaroundWHId
        /// </summary>
        public int TurnaroundWHId { get; set; }

        /// <summary>
        /// Gets or sets the container master id.
        /// </summary>
        /// <value>The container master id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }

        /// <summary>
        /// Gets or sets the container master definition id.
        /// </summary>
        /// <value>The container master definition id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionId
        /// </summary>
        public int ContainerMasterDefinitionId { get; set; }

        /// <summary>
        /// Gets or sets the container master external id.
        /// </summary>
        /// <value>The container master external id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerMasterExternalId
        /// </summary>
        public string ContainerMasterExternalId { get; set; }

        /// <summary>
        /// Gets or sets the name of the container master.
        /// </summary>
        /// <value>The name of the container master.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerMasterName
        /// </summary>
        public string ContainerMasterName { get; set; }

        /// <summary>
        /// Gets or sets the container master item type id.
        /// </summary>
        /// <value>The container master item type id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerMasterItemTypeId
        /// </summary>
        public int ContainerMasterItemTypeId { get; set; }

        /// <summary>
        /// Gets or sets the type of the container master item.
        /// </summary>
        /// <value>The type of the container master item.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerMasterItemType
        /// </summary>
        public string ContainerMasterItemType { get; set; }

        /// <summary>
        /// Gets or sets the container master base item type id.
        /// </summary>
        /// <value>The container master base item type id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerMasterBaseItemTypeId
        /// </summary>
        public int ContainerMasterBaseItemTypeId { get; set; }

        /// <summary>
        /// Gets or sets the type of the container master base item.
        /// </summary>
        /// <value>The type of the container master base item.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerMasterBaseItemType
        /// </summary>
        public string ContainerMasterBaseItemType { get; set; }

        /// <summary>
        /// Gets or sets the container instance id.
        /// </summary>
        /// <value>The container instance id.</value>
        /// <remarks></remarks>
        public int? ContainerInstanceId { get; set; }

        /// <summary>
        /// Gets or sets the container instance external id.
        /// </summary>
        /// <value>The container instance external id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerInstanceExternalId
        /// </summary>
        public string ContainerInstanceExternalId { get; set; }

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
        /// Gets or sets the customer id.
        /// </summary>
        /// <value>The customer id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }

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
        /// Gets or sets the facility id.
        /// </summary>
        /// <value>The facility id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }

        /// <summary>
        /// Gets or sets the name of the facility.
        /// </summary>
        /// <value>The name of the facility.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }

        /// <summary>
        /// Gets or sets the deliverynote id.
        /// </summary>
        /// <value>The deliverynote id.</value>
        /// <remarks></remarks>
        public int? DeliveryNoteId { get; set; }

        /// <summary>
        /// Gets or sets the start event time.
        /// </summary>
        /// <value>The start event time.</value>
        /// <remarks></remarks>
        public DateTime? StartEventTime { get; set; }

        /// <summary>
        /// Gets or sets the last event id.
        /// </summary>
        /// <value>The last event id.</value>
        /// <remarks></remarks>
        public int? LastEventId { get; set; }

        /// <summary>
        /// Gets or sets the last event type id.
        /// </summary>
        /// <value>The last event type id.</value>
        /// <remarks></remarks>
        public int? LastEventTypeId { get; set; }

        /// <summary>
        /// Gets or sets the last name of the event.
        /// </summary>
        /// <value>The last name of the event.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets LastEventName
        /// </summary>
        public string LastEventName { get; set; }

        /// <summary>
        /// Gets or sets the last event time.
        /// </summary>
        /// <value>The last event time.</value>
        /// <remarks></remarks>
        public DateTime? LastEventTime { get; set; }

        /// <summary>
        /// Gets or sets the next event type id.
        /// </summary>
        /// <value>The next event type id.</value>
        /// <remarks></remarks>
        public int? NextEventTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the next event.
        /// </summary>
        /// <value>The name of the next event.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets NextEventName
        /// </summary>
        public string NextEventName { get; set; }

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
        /// Gets or sets the batch id.
        /// </summary>
        /// <value>The batch id.</value>
        /// <remarks></remarks>
        public int? BatchId { get; set; }

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
        /// Gets or sets the parent turnaround id.
        /// </summary>
        /// <value>The parent turnaround id.</value>
        /// <remarks></remarks>
        public long? ParentTurnaroundId { get; set; }

        /// <summary>
        /// Gets or sets the has children.
        /// </summary>
        /// <value>The has children.</value>
        /// <remarks></remarks>
        public bool? HasChildren { get; set; }

        /// <summary>
        /// Gets or sets the turnaround external id.
        /// </summary>
        /// <value>The turnaround external id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public long TurnaroundExternalId { get; set; }

        /// <summary>
        /// Gets or sets the deliverynote external id.
        /// </summary>
        /// <value>The deliverynote external id.</value>
        /// <remarks></remarks>
        public int? DeliveryNoteExternalId { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        /// <remarks></remarks>
        public int? Order { get; set; }

        /// <summary>
        /// Gets or sets the legacy external id.
        /// </summary>
        /// <value>The legacy external id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets LegacyExternalId
        /// </summary>
        public string LegacyExternalId { get; set; }

        /// <summary>
        /// The RAG priority of the turnaround
        /// </summary>
        /// <summary>
        /// Gets or sets Priority
        /// </summary>
        public TurnaroundPriority Priority { get; set; }

        #endregion
    }
}