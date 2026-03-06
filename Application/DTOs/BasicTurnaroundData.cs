using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BasicTurnaroundData
    /// </summary>
    public class BasicTurnaroundData
    {
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public long ExternalId { get; set; }
        /// <summary>
        /// Gets or sets Expiry
        /// </summary>
        public DateTime Expiry { get; set; }
        /// <summary>
        /// Gets or sets Priority
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterText
        /// </summary>
        public string ContainerMasterText { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterBaseItemTypeText
        /// </summary>
        public string ContainerMasterBaseItemTypeText { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterItemTypeText
        /// </summary>
        public string ContainerMasterItemTypeText { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets LastEventCreated
        /// </summary>
        public DateTime LastEventCreated { get; set; }
        /// <summary>
        /// Gets or sets LastEventEventTypeText
        /// </summary>
        public string LastEventEventTypeText { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementText
        /// </summary>
        public string ServiceRequirementText { get; set; }
        /// <summary>
        /// Gets or sets CustomerText
        /// </summary>
        public string CustomerText { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
        /// <summary>
        /// Gets or sets IsProcessEvent
        /// </summary>
        public bool IsProcessEvent { get; set; }
        /// <summary>
        /// Gets or sets QuarantineReasonText
        /// </summary>
        public string QuarantineReasonText { get; set; }
        /// <summary>
        /// Gets or sets IsFastTrack
        /// </summary>
        public bool IsFastTrack { get; set; }
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
        /// <summary>
        /// Gets or sets IsIdentifiable
        /// </summary>
        public bool IsIdentifiable { get; set; }
    }
}
