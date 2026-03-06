using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum StockExpiryIndicator
    {
        Ok = 0,
        NonSterile = 1,
        Expiring = 2,
        Expired = 3
    }

    /// <summary>
    /// StockItem
    /// </summary>
    public class StockItem
    {
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public string TurnaroundExternalId { get; set; }
        public int? ContainerInstanceId { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets InstanceBarcode
        /// </summary>
        public string InstanceBarcode { get; set; }
        public DateTime? SterileExpiry { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public string DeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public int ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public string ItemType { get; set; }
        /// <summary>
        /// Gets or sets IsNonSterile
        /// </summary>
        public bool IsNonSterile { get; set; }
        /// <summary>
        /// Gets or sets ExpiryIndicator
        /// </summary>
        public StockExpiryIndicator ExpiryIndicator { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirement
        /// </summary>
        public string ServiceRequirement { get; set; }
    }
}