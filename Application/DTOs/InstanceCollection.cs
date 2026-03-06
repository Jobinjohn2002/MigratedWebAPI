using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Instance Collection
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// InstanceCollection
    /// </summary>
    public class InstanceCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InstanceCollection"/> class.
        /// </summary>
        /// <param name="instanceId">The instance id.</param>
        /// <param name="externalId">The external id.</param>
        /// <param name="instanceTypeId">The instance type id.</param>
        /// <param name="name">The name.</param>
        /// <param name="createdDate">The created date.</param>
        /// <param name="deliveryPointId">The delivery point id.</param>
        /// <param name="deliveryPointName">Name of the delivery point.</param>
        /// <param name="serviceRequirementId">The service requirement id.</param>
        /// <param name="serviceRequirementName">Name of the service requirement.</param>
        /// <param name="archived">The archived.</param>
        /// <param name="archivedUserId">The archived user id.</param>
        /// <param name="archivedUserName">Name of the archived user.</param>
        /// <param name="customerId">The customer id.</param>
        /// <param name="customerName">Name of the customer.</param>
        /// <param name="itemId">The item id.</param>
        /// <param name="itemExternalId">The item external id.</param>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="itemTypeId">The item type id.</param>
        /// <param name="itemTypeName">Name of the item type.</param>
        /// <param name="turnaroundCount">The turnaround count.</param>
        /// <param name="turnaroundWarningCount">The turnaroundWarningCount count.</param>
        /// <remarks></remarks>
        public InstanceCollection(int instanceId,int containerMasterDefinitionId,
                                  string externalId,
                                  short instanceTypeId,
                                  string name,
                                  DateTime createdDate,
                                  int deliveryPointId,
                                  string deliveryPointName,
                                  int serviceRequirementId,
                                  string serviceRequirementName,
                                  DateTime? archived,
                                  int? archivedUserId,
                                  string archivedUserName,
                                  int customerId,
                                  string customerName,
                                  int itemId,
                                  string itemExternalId,
                                  string itemName,
                                  short itemTypeId,
                                  string itemTypeName,
                                  int turnaroundCount,
                                  int turnaroundWarningCount)
        {
            InstanceId = instanceId;
            MasterDefinitionId = containerMasterDefinitionId;
            ExternalId = externalId;
            InstanceTypeId = instanceTypeId;
            Name = name;
            CreatedDate = createdDate;
            DeliveryPointId = deliveryPointId;
            DeliveryPointName = deliveryPointName;
            ServiceRequirementId = serviceRequirementId;
            ServiceRequirementName = serviceRequirementName;
            Archived = archived;
            ArchivedUserId = archivedUserId;
            ArchivedUserName = archivedUserName;
            CustomerId = customerId;
            CustomerName = customerName;
            ItemId = itemId;
            ItemExternalId = itemExternalId;
            ItemName = itemName;
            ItemTypeId = itemTypeId;
            ItemTypeName = itemTypeName;
            TurnaroundCount = turnaroundCount;
            TurnaroundWarningCount = turnaroundWarningCount;
        }

        public InstanceCollection(int instanceId, int containerMasterDefinitionId,
                                 string externalId,
                                 short instanceTypeId,
                                 string name,
                                 DateTime createdDate,
                                 int deliveryPointId,
                                 string deliveryPointName,
                                 int serviceRequirementId,
                                 string serviceRequirementName,
                                 DateTime? archived,
                                 int? archivedUserId,
                                 string archivedUserName,
                                 int customerId,
                                 string customerName,
                                 int itemId,
                                 string itemExternalId,
                                 string itemName,
                                 short itemTypeId,
                                 string itemTypeName,
                                 int turnaroundCount,
                                 int turnaroundWarningCount,
                                int? lastTurnaroundId,
                                long? lastTurnaroundExternalId,
                                string lastTurnaroundServiceRequirement,
                                short? lastEventTypeId,
                                string lastTurnaroundEvent,
            short? quarantineReasonId,
            string quarantineReason)
            : this(instanceId,containerMasterDefinitionId,
                externalId,
                instanceTypeId,
                name,
                createdDate,
                deliveryPointId,
                deliveryPointName,
                serviceRequirementId,
                serviceRequirementName,
                archived,
                archivedUserId,
                archivedUserName,
                customerId,
                customerName,
                itemId,
                itemExternalId,
                itemName,
                itemTypeId,
                itemTypeName,
                turnaroundCount,
                turnaroundWarningCount)
        {
            LastTurnaroundId = lastTurnaroundId;
            LastTurnaroundExternalId = lastTurnaroundExternalId;
            LastTurnaroundServiceRequirement = lastTurnaroundServiceRequirement;
            LastEventTypeId = lastEventTypeId;
            LastTurnaroundEvent = lastTurnaroundEvent;
            QuarantineReasoneId = quarantineReasonId;
            QuarantineReason = quarantineReason;

        }

        #region IInstanceCollection Members

        /// <summary>
        /// Gets or sets the instance id.
        /// </summary>
        /// <value>The instance id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets InstanceId
        /// </summary>
        public int InstanceId { get; set; }

        /// <summary>
        /// Gets or sets the instance id.
        /// </summary>
        /// <value>The instance id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets MasterDefinitionId
        /// </summary>
        public int MasterDefinitionId { get; set; }

        /// <summary>
        /// Gets or sets the external id.
        /// </summary>
        /// <value>The external id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Gets or sets the instance type id.
        /// </summary>
        /// <value>The instance type id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets InstanceTypeId
        /// </summary>
        public short InstanceTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

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
        /// Gets or sets the archived.
        /// </summary>
        /// <value>The archived.</value>
        /// <remarks></remarks>
        public DateTime? Archived { get; set; }

        /// <summary>
        /// Gets or sets the archived user uid.
        /// </summary>
        /// <value>The archived user uid.</value>
        /// <remarks></remarks>
        public int? ArchivedUserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the archived user.
        /// </summary>
        /// <value>The name of the archived user.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ArchivedUserName
        /// </summary>
        public string ArchivedUserName { get; set; }

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
        /// Gets or sets the item id.
        /// </summary>
        /// <value>The item id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemId
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        ///  Gets or sets the item external id.
        /// </summary>
       /// <summary>
       /// Gets or sets ItemExternalId
       /// </summary>
       public string ItemExternalId { get; set; }

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
        /// Gets or sets the item type id.
        /// </summary>
        /// <value>The item type id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public short ItemTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the item type.
        /// </summary>
        /// <value>The name of the item type.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemTypeName
        /// </summary>
        public string ItemTypeName { get; set; }

        /// <summary>
        /// Gets or sets the turnaround count.
        /// </summary>
        /// <value>The turnaround count.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets TurnaroundCount
        /// </summary>
        public int TurnaroundCount { get; set; }

        /// <summary>
        /// Gets or sets the id of last turnaround.
        /// </summary>
        public int? LastTurnaroundId { get; set; }

        /// <summary>
        /// Gets or sets the external id of last turnaround.
        /// </summary>
        public long? LastTurnaroundExternalId { get; set; }

        /// <summary>
        /// Gets or sets the service requirement of turnaround.
        /// </summary>
        /// <summary>
        /// Gets or sets LastTurnaroundServiceRequirement
        /// </summary>
        public string LastTurnaroundServiceRequirement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short? LastEventTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of last turnaround event.
        /// </summary>
        /// <summary>
        /// Gets or sets LastTurnaroundEvent
        /// </summary>
        public string LastTurnaroundEvent { get; set; }

          /// <summary>
        /// Gets or sets  id of quarantine reasone.
        /// </summary>
        public short? QuarantineReasoneId { get; set; }

        /// <summary>
        /// Gets or sets the name of  quarantine reasone.
        /// </summary>
        /// <summary>
        /// Gets or sets QuarantineReason
        /// </summary>
        public string QuarantineReason { get; set; }

        /// <summary>
        /// Gets or sets the name of  quarantine reasone.
        /// </summary>
        /// <summary>
        /// Gets or sets TurnaroundWarningCount
        /// </summary>
        public int TurnaroundWarningCount { get; set; }

        #endregion
    }
}