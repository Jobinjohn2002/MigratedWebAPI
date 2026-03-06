using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class MaintenanceReport
    {
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public string TurnaroundExternalId { get; set; }

        /// <summary>
        /// Gets or sets ItemId
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }

        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }

        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets VendorName
        /// </summary>
        public string VendorName { get; set; }

        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public int ContainerInstanceId { get; set; }

        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }

        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }

        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }

        /// <summary>
        /// Gets or sets MaintenanceReportStatusName
        /// </summary>
        public string MaintenanceReportStatusName { get; set; }

        public int? ItemCount { get; set; }

        /// <summary>
        /// Gets or sets ItemInstanceId
        /// </summary>
        public int ItemInstanceId { get; set; }

        /// <summary>
        /// Gets or sets ItemMasterId
        /// </summary>
        public int ItemMasterId { get; set; }

        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Gets or sets StatusModified
        /// </summary>
        public DateTime StatusModified { get; set; } 
    }
}
