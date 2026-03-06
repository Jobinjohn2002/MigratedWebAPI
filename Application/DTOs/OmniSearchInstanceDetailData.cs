using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// OmniSearchInstanceDetailData
    /// </summary>
    public class OmniSearchInstanceDetailData
    {
        public OmniSearchInstanceDetailData()
        { }

        public OmniSearchInstanceDetailData(int instanceUid,
                                         string deliveryPoint,
                                         int customerStatusId,
                                         string customer,
                                         long? legacyInternalId,
                                         string legacyExternalId,
                                         string externalId,
                                         string superType)
        {
            InstanceId = instanceUid;
            DeliveryPoint = deliveryPoint;
            CustomerStatusId = customerStatusId;
            Customer = customer;
            LegacyInternalId = legacyInternalId;
            LegacyExternalId = legacyExternalId;
            ExternalId = externalId;
            SuperType = superType;
        }

        public OmniSearchInstanceDetailData(int instanceId,
                                         string deliveryPoint,
                                         string customer,
                                         long? legacyInternalId,
                                         string legacyExternalId,
                                         string externalId,
                                         string superType,
                                        int itemUid,
                                        string itemName,
                                        short itemTypeId,
                                        string itemTypeName,
                                        int turnaroundCount,
                                        string serviceRequirement)
        {
            InstanceId = instanceId;
            DeliveryPoint = deliveryPoint;
            Customer = customer;
            LegacyInternalId = legacyInternalId;
            LegacyExternalId = legacyExternalId;
            ExternalId = externalId;
            SuperType = superType;
            ItemUid = itemUid;
            ItemName = itemName;
            ItemTypeId = itemTypeId;
            ItemTypeName = itemTypeName;
            TurnaroundCount = turnaroundCount;
            ServiceRequirement = serviceRequirement;

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
        /// Gets or sets the instance id.
        /// </summary>
        /// <value>The  instance id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets InstanceId
        /// </summary>
        public int InstanceId { get; set; }
        /// <summary>
        /// Gets or sets CustomerStatusId
        /// </summary>
        public int CustomerStatusId { get; set; }

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
        /// Gets or sets the delivery point.
        /// </summary>
        /// <value>The delivery point.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public string DeliveryPoint { get; set; }

        /// <summary>
        /// Gets or sets the index id.
        /// </summary>
        /// <value>The index id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public string Customer { get; set; }

        /// <summary>
        /// Gets or sets legacy internal id
        /// </summary>
        /// <value>The legacy internal id.</value>
        /// <remarks></remarks>
        public long? LegacyInternalId { get; set; }

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
        /// Gets or sets the external id.
        /// </summary>
        /// <value>The external id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Gets or sets the super type.
        /// </summary>
        /// <value>The super type.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets SuperType
        /// </summary>
        public string SuperType { get; set; }

        /// <summary>
        /// Gets or sets item uid
        /// </summary>
        /// <summary>
        /// Gets or sets ItemUid
        /// </summary>
        public int ItemUid { get; set; }

        /// <summary>
        /// Gets or sets item name
        /// </summary>
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Gets or sets item type id
        /// </summary>
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public short ItemTypeId { get; set; }

        /// <summary>
        /// Gets or sets item type name
        /// </summary>
        /// <summary>
        /// Gets or sets ItemTypeName
        /// </summary>
        public string ItemTypeName { get; set; }

        /// <summary>
        /// Gets or sets turnaround count
        /// </summary>
        /// <summary>
        /// Gets or sets TurnaroundCount
        /// </summary>
        public int TurnaroundCount { get; set; }

        /// <summary>
        /// Gets or sets service requirement
        /// </summary>
        /// <summary>
        /// Gets or sets ServiceRequirement
        /// </summary>
        public string ServiceRequirement { get; set; }

        /// <summary>
        /// Gets or Sets the is Archived record flag.
        /// </summary>
        /// <summary>
        /// Gets or sets IsArchived
        /// </summary>
        public bool IsArchived { get; set; }
    }
}
