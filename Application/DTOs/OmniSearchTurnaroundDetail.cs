using System;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OmniSearchTurnaroundDetail
    /// </summary>
    public class OmniSearchTurnaroundDetail
    {
        public OmniSearchTurnaroundDetail() { }

        public OmniSearchTurnaroundDetail(int turnaroundId,
                                            DateTime createdDate,
                                            int serviceRequirementId,
                                            string servicerequirementName,
                                            int deliveryPointId,
                                            string deliveryPointName,
                                            int customerId,
                                            int customerStatusId,
                                            string customerName,
                                            string itemName,
                                            int? deliveryNoteId,
                                            DateTime expiry,
                                            int? legacyInternalId,
                                            long externalId)
        {
            TurnaroundId = turnaroundId;
            CreatedDate = createdDate;
            ServiceRequirementId = serviceRequirementId;
            ServicerequirementName = servicerequirementName;
            DeliveryPointId = deliveryPointId;
            DeliveryPointName = deliveryPointName;
            CustomerId = customerId;
            CustomerStatusId = customerStatusId;
            CustomerName = customerName;
            ItemName = itemName;
            DeliveryNoteId = deliveryNoteId;
            Expiry = expiry;
            LegacyInternalId = legacyInternalId;
            ExternalId = externalId;
        }

        public OmniSearchTurnaroundDetail(int turnaroundId,
                                            DateTime createdDate,
                                            int serviceRequirementId,
                                            string servicerequirementName,
                                            int deliveryPointId,
                                            string deliveryPointName,
                                            int customerId,
                                            int customerStatusId,
                                            string customerName,
                                            string itemName,
                                            int? deliveryNoteId,
                                            DateTime expiry,
                                            int? legacyInternalId,
                                            long externalId, bool isArchived)
        {
            TurnaroundId = turnaroundId;
            CreatedDate = createdDate;
            ServiceRequirementId = serviceRequirementId;
            ServicerequirementName = servicerequirementName;
            DeliveryPointId = deliveryPointId;
            DeliveryPointName = deliveryPointName;
            CustomerId = customerId;
            CustomerStatusId = customerStatusId;
            CustomerName = customerName;
            ItemName = itemName;
            DeliveryNoteId = deliveryNoteId;
            Expiry = expiry;
            LegacyInternalId = legacyInternalId;
            ExternalId = externalId;
            IsArchived = isArchived;
        }

        public OmniSearchTurnaroundDetail(int turnaroundId,
                                            DateTime createdDate,
                                            int serviceRequirementId,
                                            string servicerequirementName,
                                            int deliveryPointId,
                                            string deliveryPointName,
                                            int customerId,
                                            string customerName,
                                            int itemUid,
                                            string itemExternalId,
                                            string itemName,
                                            int? instanceId,
                                            string containerInstancePrimaryId,
                                            int? deliveryNoteId,
                                            DateTime expiry,
                                            int? legacyInternalId,
                                            long externalId
                                           )
        {
            TurnaroundId = turnaroundId;
            CreatedDate = createdDate;
            ServiceRequirementId = serviceRequirementId;
            ServicerequirementName = servicerequirementName;
            DeliveryPointId = deliveryPointId;
            DeliveryPointName = deliveryPointName;
            CustomerId = customerId;
            CustomerName = customerName;
            ItemId = itemUid;
            ItemName = itemName;
            ItemExternalId = itemExternalId;
            ContainerInstancePrimaryId = containerInstancePrimaryId;
            InstanceId = instanceId;
            DeliveryNoteId = deliveryNoteId;
            Expiry = expiry;
            LegacyInternalId = legacyInternalId;
            ExternalId = externalId;
        }

        public OmniSearchTurnaroundDetail(int turnaroundId,
                                           DateTime createdDate,
                                           int serviceRequirementId,
                                           string servicerequirementName,
                                           int deliveryPointId,
                                           string deliveryPointName,
                                           int customerId,
                                           string customerName,
                                           int itemUid,
                                           string itemExternalId,
                                           string itemName,
                                           int? instanceId,
                                           string containerInstancePrimaryId,
                                           int? deliveryNoteId,
                                           DateTime expiry,
                                           int? legacyInternalId,
                                           long externalId,
                                            string lastEvent,
                                            DateTime lastEventDate
                                          )
        {
            TurnaroundId = turnaroundId;
            CreatedDate = createdDate;
            ServiceRequirementId = serviceRequirementId;
            ServicerequirementName = servicerequirementName;
            DeliveryPointId = deliveryPointId;
            DeliveryPointName = deliveryPointName;
            CustomerId = customerId;
            CustomerName = customerName;
            ItemId = itemUid;
            ItemName = itemName;
            ItemExternalId = itemExternalId;
            ContainerInstancePrimaryId = containerInstancePrimaryId;
            InstanceId = instanceId;
            DeliveryNoteId = deliveryNoteId;
            Expiry = expiry;
            LegacyInternalId = legacyInternalId;
            ExternalId = externalId;
            LastEvent = lastEvent;
            LastEventDate = lastEventDate;
        }
        /// <summary>
        /// Gets or sets the index id.
        /// </summary>
        /// <value>The index id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets IndexId
        /// </summary>
        public int IndexId { get; set; }

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
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the service requiement id.
        /// </summary>
        /// <value>The service requirement id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ServiceRequirementId
        /// </summary>
        public int ServiceRequirementId { get; set; }

        /// <summary>
        /// Gets or sets the service requiement name.
        /// </summary>
        /// <value>The service requiement name.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ServicerequirementName
        /// </summary>
        public string ServicerequirementName { get; set; }

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
        /// Gets or sets the delivery point name.
        /// </summary>
        /// <value>The delivery point name.</value>
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
        /// Gets or sets the customer status id.
        /// </summary>
        /// <value>The customer status id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerStatusId
        /// </summary>
        public int CustomerStatusId { get; set; }

        /// <summary>
        /// Gets or sets the customer name.
        /// </summary>
        /// <value>The customer name.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        /// <value>The item id.</value>
        /// <remarks></remarks>
        public int? ItemId { get; set; }

        /// <summary>
        /// Gets or sets the item name.
        /// </summary>
        /// <value>The item name.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        /// <value>The item id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemExternalId
        /// </summary>
        public string ItemExternalId { get; set; }

        /// <summary>
        /// Gets or sets the instance id.
        /// </summary>
        /// <value>The instance id.</value>
        /// <remarks></remarks>
        public int? InstanceId { get; set; }

        /// <summary>
        /// Gets or sets the instance id.
        /// </summary>
        /// <value>The instance id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }

        /// <summary>
        /// Gets or sets the delivery note id.
        /// </summary>
        /// <value>The delivery note id.</value>
        /// <remarks></remarks>
        public int? DeliveryNoteId { get; set; }

        /// <summary>
        /// Gets or sets the expiry.
        /// </summary>
        /// <value>The expiry id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Expiry
        /// </summary>
        public DateTime Expiry { get; set; }

        /// <summary>
        /// Gets or sets the legacy internal id.
        /// </summary>
        /// <value>The legacy internal id.</value>
        /// <remarks></remarks>
        public int? LegacyInternalId { get; set; }

        /// <summary>
        /// Gets or sets the external id.
        /// </summary>
        /// <value>The external id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public long ExternalId { get; set; }
        /// <summary>
        /// Gets or sets the last event.
        /// </summary>
        /// <value>The last event.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets LastEvent
        /// </summary>
        public string LastEvent { get; set; }

        /// <summary>
        /// Gets or sets the last event date.
        /// </summary>
        /// <value>The last event date.</value>
        /// <remarks></remarks>
        public DateTime? LastEventDate { get; set; }

        /// <summary>
        /// Gets or Sets the is Archived record flag.
        /// </summary>
        /// <summary>
        /// Gets or sets IsArchived
        /// </summary>
        public bool IsArchived { get; set; }

        /// <summary>
        /// The RAG priority of the turnaround
        /// </summary>
        public TurnaroundPriority Priority
        {
            get
            {
                return Turnaround.CalculatePriority(CreatedDate, Expiry);
            }
        }
    }
}
