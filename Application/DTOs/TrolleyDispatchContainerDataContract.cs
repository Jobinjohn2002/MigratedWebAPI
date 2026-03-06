using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TrolleyDispatchContainerDataContract
    /// </summary>
    public class TrolleyDispatchContainerDataContract
    {
        public int? InstanceId { get; set; }
        /// <summary>
        /// Gets or sets InstancePrimaryId
        /// </summary>
        public string InstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public long TurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets IsSupplementary
        /// </summary>
        public bool IsSupplementary { get; set; }
        /// <summary>
        /// Gets or sets IsExtra
        /// </summary>
        public bool IsExtra { get; set; }
        /// <summary>
        /// Gets or sets IsTray
        /// </summary>
        public bool IsTray { get; set; }
        /// <summary>
        /// Gets or sets IsFastTrack
        /// </summary>
        public bool IsFastTrack { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirement
        /// </summary>
        public string ServiceRequirement { get; set; }
        public DateTime? ExpiryDate { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointRestrictedForTrolleys
        /// </summary>
        public bool DeliveryPointRestrictedForTrolleys { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets LastEventDateTime
        /// </summary>
        public DateTime LastEventDateTime { get; set; }
        /// <summary>
        /// Gets or sets LastEventType
        /// </summary>
        public TurnAroundEventTypeIdentifier LastEventType { get; set; }
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public string ItemType { get; set; }
        /// <summary>
        /// Gets or sets IsExpiringSoon
        /// </summary>
        public bool IsExpiringSoon { get; set; }
        /// <summary>
        /// Gets or sets BatchExternalId
        /// </summary>
        public string BatchExternalId { get; set; }
        public DateTime? BatchPassedDateTime { get; set; }
    }
}
