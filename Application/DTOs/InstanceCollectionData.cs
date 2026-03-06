using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// InstanceCollectionData
    /// </summary>
    public class InstanceCollectionData
    {
        public InstanceCollectionData(IInstanceCollection instance)
        {
            InstanceId = instance.InstanceId;
            MasterDefinitionId = instance.MasterDefinitionId;
            ExternalId = instance.ExternalId;
            InstanceTypeId = instance.InstanceTypeId;
            Name = instance.Name;
            CreatedDate = instance.CreatedDate;
            DeliveryPointId = instance.DeliveryPointId;
            DeliveryPointName = instance.DeliveryPointName;
            ServiceRequirementId = instance.ServiceRequirementId;
            ServiceRequirementName = instance.ServiceRequirementName;
            Archived = instance.Archived;
            ArchivedUserId = instance.ArchivedUserId;
            ArchivedUserName = instance.ArchivedUserName;
            CustomerId = instance.CustomerId;
            CustomerName = instance.CustomerName;
            ItemId = instance.ItemId;
            ItemName = instance.ItemName;
            ItemExternalId = instance.ItemExternalId;
            ItemTypeId = instance.ItemTypeId;
            ItemTypeName = instance.ItemTypeName;
            TurnaroundCount = instance.TurnaroundCount;
            LastTurnaroundId = instance.LastTurnaroundId;
            LastTurnaroundExternalId = instance.LastTurnaroundExternalId;
            LastTurnaroundServiceRequirement = instance.LastTurnaroundServiceRequirement;
            LastEventTypeId = instance.LastEventTypeId;
            LastTurnaroundEvent = instance.LastTurnaroundEvent;
            QuarantineReasoneId = instance.QuarantineReasoneId;
            QuarantineReason = instance.QuarantineReason;
            TurnaroundWarningCount = instance.TurnaroundWarningCount;

        }
        /// <summary>
        /// Gets or sets InstanceId
        /// </summary>
        public int InstanceId { get; set; }
        /// <summary>
        /// Gets or sets MasterDefinitionId
        /// </summary>
        public int MasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets InstanceTypeId
        /// </summary>
        public short InstanceTypeId { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementId
        /// </summary>
        public int ServiceRequirementId { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementName
        /// </summary>
        public string ServiceRequirementName { get; set; }
        public DateTime? Archived { get; set; }
        public int? ArchivedUserId { get; set; }
        /// <summary>
        /// Gets or sets ArchivedUserName
        /// </summary>
        public string ArchivedUserName { get; set; }
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets ItemId
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// Gets or sets ItemExternalId
        /// </summary>
        public string ItemExternalId { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public short ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeName
        /// </summary>
        public string ItemTypeName { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundCount
        /// </summary>
        public int TurnaroundCount { get; set; }
        public int? LastTurnaroundId { get; set; }
        public long? LastTurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets LastTurnaroundServiceRequirement
        /// </summary>
        public string LastTurnaroundServiceRequirement { get; set; }
        public short? LastEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets LastTurnaroundEvent
        /// </summary>
        public string LastTurnaroundEvent { get; set; }
        public short? QuarantineReasoneId { get; set; }
        /// <summary>
        /// Gets or sets QuarantineReason
        /// </summary>
        public string QuarantineReason { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundWarningCount
        /// </summary>
        public int TurnaroundWarningCount { get; set; }
    }
}
