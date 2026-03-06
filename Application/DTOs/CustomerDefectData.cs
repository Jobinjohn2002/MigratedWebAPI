using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public sealed partial class CustomerDefectData
    {
        public CustomerDefectData() { }
        public int? InstanceId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets ItemId
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public string Customer { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public long TurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets CreatedUser
        /// </summary>
        public string CreatedUser { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public string DeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefectReasons
        /// </summary>
        public IList<CustomerDefectReasonData> CustomerDefectReasons { get; set; }
        /// <summary>
        /// Gets or sets History
        /// </summary>
        public IList<CustomerDefectData> History { get; set; }        
        /// <summary>
        /// Gets or sets ClassificationName
        /// </summary>
        public string ClassificationName { get; set; }
        /// <summary>
        /// Gets or sets DefectType
        /// </summary>
        public string DefectType { get; set; }
        /// <summary>
        /// Gets or sets DefectTypeName
        /// </summary>
        public string DefectTypeName { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets CustomerEmail
        /// </summary>
        public string CustomerEmail { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointEmail
        /// </summary>
        public string DeliveryPointEmail { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets ProcessedFacilityName
        /// </summary>
        public string ProcessedFacilityName { get; set; }
    }
}
