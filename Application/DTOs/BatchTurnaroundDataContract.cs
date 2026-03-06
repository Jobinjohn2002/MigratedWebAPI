using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BatchTurnaroundDataContract
    /// </summary>
    public class BatchTurnaroundDataContract
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
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterName
        /// </summary>
        public string ContainerMasterName { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementId
        /// </summary>
        public int ServiceRequirementId { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementDefinitionId
        /// </summary>
        public int ServiceRequirementDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementName
        /// </summary>
        public string ServiceRequirementName { get; set; }
        /// <summary>
        /// Gets or sets IsFastTrack
        /// </summary>
        public bool IsFastTrack { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets Expiry
        /// </summary>
        public DateTime Expiry { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets NextEvent
        /// </summary>
        public string NextEvent { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public int ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets BatchCycles
        /// </summary>
        public List<BatchCycleDataContract> BatchCycles { get; set; }
        /// <summary>
        /// Gets or sets IsIdentifiedInstance
        /// </summary>
        public bool IsIdentifiedInstance { get; set; }
        /// <summary>
        /// Gets or sets IsOnABatchTag
        /// </summary>
        public bool IsOnABatchTag { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
        [IgnoreDataMember]
        /// <summary>
        /// Gets or sets ExpiryHours
        /// </summary>
        public string ExpiryHours { get; set; }
        [IgnoreDataMember]
        /// <summary>
        /// Gets or sets IsOverDue
        /// </summary>
        public bool IsOverDue { get; set; }
    }
}