using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustomerDefectEmailDataContract
    /// </summary>
    public class CustomerDefectEmailDataContract
    {
        public Guid? CustomerDefectUid { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefectNo
        /// </summary>
        public string CustomerDefectNo { get; set; }
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public string DeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets Turnaround
        /// </summary>
        public string Turnaround { get; set; }
        /// <summary>
        /// Gets or sets DefectReason
        /// </summary>
        public string DefectReason { get; set; }
        /// <summary>
        /// Gets or sets DefectDetail
        /// </summary>
        public string DefectDetail { get; set; }
        /// <summary>
        /// Gets or sets Response
        /// </summary>
        public string Response { get; set; }
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public string Customer { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets ServiceReportId
        /// </summary>
        public string ServiceReportId { get; set; }
        /// <summary>
        /// Gets or sets SerialNumber
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// Gets or sets Username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptions
        /// </summary>
        public List<CustomerDefectEmailItemExceptionsDataContract> ItemExceptions { get; set; }
        /// <summary>
        /// Gets or sets Facility
        /// </summary>
        public FacilityInfoDataContract Facility { get; set; }
        /// <summary>
        /// Gets or sets Culture
        /// </summary>
        public string Culture { get; set; }
        /// <summary>
        /// Gets or sets IsUpdate
        /// </summary>
        public bool IsUpdate { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets History
        /// </summary>
        public List<CustomerDefectEmailDataContract> History { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefectReportURL
        /// </summary>
        public string CustomerDefectReportURL { get; set; }
    }
}
