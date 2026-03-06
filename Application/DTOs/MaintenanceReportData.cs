using System;
using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public sealed partial class MaintenanceReportData
    {
        public MaintenanceReportData() { }
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public string TurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceReportStatusName
        /// </summary>
        public string MaintenanceReportStatusName { get; set; }
        /// <summary>
        /// Gets or sets ItemId
        /// </summary>
        public string ItemId { get; set; }
        public int? ItemCount { get; set; }
        /// <summary>
        /// Gets or sets CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterExternalId
        /// </summary>
        public string ItemMasterExternalId { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets VendorText
        /// </summary>
        public string VendorText { get; set; }
        /// <summary>
        /// Gets or sets CourierText
        /// </summary>
        public string CourierText { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceTypeText
        /// </summary>
        public string MaintenanceTypeText { get; set; }
        public int? ContainerInstanceId { get; set; }
        public int? ContainerMasterId { get; set; }
        public int? DeliveryPointId { get; set; }
        public short? FacilityId { get; set; }
        public int? TotalRowCount { get; set; }
        public int? CustomerId { get; set; }
        /// <summary>
        /// Gets or sets MasterType
        /// </summary>
        public MasterType MasterType { get; set; }
        /// <summary>
        /// Gets or sets Priority
        /// </summary>
        public MaintenancePriority Priority { get; set; }
        public int? LatestContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets StatusModified
        /// </summary>
        public DateTime StatusModified { get; set; }
        /// <summary>
        /// Gets or sets Comments
        /// </summary>
        public List<CommentData> Comments { get; set; }
    }
}
