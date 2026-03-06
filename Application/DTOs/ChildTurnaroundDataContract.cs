using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ChildTurnaroundDataContract
    /// </summary>
    public class ChildTurnaroundDataContract
    {
        public int? InstanceId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets Expiry
        /// </summary>
        public DateTime Expiry { get; set; }
        /// <summary>
        /// Gets or sets CreatedTime
        /// </summary>
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// Gets or sets ServiceReq
        /// </summary>
        public string ServiceReq { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets BaseItemTypeId
        /// </summary>
        public int BaseItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets ChildCount
        /// </summary>
        public int ChildCount { get; set; }
        /// <summary>
        /// Gets or sets ChildItems
        /// </summary>
        public List<ScanAssetDataContract> ChildItems { get; set; }
    }
}