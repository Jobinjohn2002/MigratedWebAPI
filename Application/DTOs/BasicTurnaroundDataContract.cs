using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BasicTurnaroundDataContract
    /// </summary>
    public class BasicTurnaroundDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets BatchName
        /// </summary>
        public string BatchName { get; set; }
        /// <summary>
        /// Gets or sets BatchId
        /// </summary>
        public int BatchId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterName
        /// </summary>
        public string ContainerMasterName { get; set; }
        public int? ContainerInstanceId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public int TurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementName
        /// </summary>
        public string ServiceRequirementName { get; set; }
        /// <summary>
        /// Gets or sets IsFastTrack
        /// </summary>
        public bool IsFastTrack { get; set; }
        /// <summary>
        /// Gets or sets Expiry
        /// </summary>
        public DateTime Expiry { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets NextEvent
        /// </summary>
        public string NextEvent { get; set; }
        /// <summary>
        /// Gets or sets PossibleEvents
        /// </summary>
        public List<EventTypeDataContract> PossibleEvents { get; set; }
    }
}
