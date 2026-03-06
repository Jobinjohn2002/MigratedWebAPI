using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class admapp_ReadOmniSearchDefectDetail_Result
    {
        /// <summary>
        /// Gets or sets Defectid
        /// </summary>
        public int Defectid { get; set; }
        /// <summary>
        /// Gets or sets Turnaroundid
        /// </summary>
        public Nullable<int> Turnaroundid { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public string TurnaroundExternalId { get; set; }
        public System.DateTime Raised { get; set; }
        /// <summary>
        /// Gets or sets ReportingDepartment
        /// </summary>
        public string ReportingDepartment { get; set; }
        /// <summary>
        /// Gets or sets ReporterUserName
        /// </summary>
        public string ReporterUserName { get; set; }
        /// <summary>
        /// Gets or sets ReporterUserPosition
        /// </summary>
        public string ReporterUserPosition { get; set; }
        /// <summary>
        /// Gets or sets DefectStatus
        /// </summary>
        public string DefectStatus { get; set; }
        /// <summary>
        /// Gets or sets DefectSeverity
        /// </summary>
        public string DefectSeverity { get; set; }
        /// <summary>
        /// Gets or sets DefectClassification
        /// </summary>
        public string DefectClassification { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointid
        /// </summary>
        public int DeliveryPointid { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
        /// <summary>
        /// Gets or sets Customerid
        /// </summary>
        public int Customerid { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets CustomerStatusId
        /// </summary>
        public byte CustomerStatusId { get; set; }
        /// <summary>
        /// Gets or sets LegacyInternalId
        /// </summary>
        public Nullable<int> LegacyInternalId { get; set; }
        /// <summary>
        /// Gets or sets LegacyExternalId
        /// </summary>
        public string LegacyExternalId { get; set; }
        /// <summary>
        /// Gets or sets DefectType
        /// </summary>
        public string DefectType { get; set; }
    }
}
