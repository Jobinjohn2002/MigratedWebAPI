using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustomerDefectModel
    /// </summary>
    public class CustomerDefectModel
    {
        /// <summary>
        /// Gets or sets CustomerDefectID
        /// </summary>
        public int CustomerDefectID { get; set; }
        /// <summary>
        /// Gets or sets InitialCustomerDefectId
        /// </summary>
        public int InitialCustomerDefectId { get; set; }
        /// <summary>
        /// Gets or sets ReportID
        /// </summary>
        public string ReportID { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundID
        /// </summary>
        public int TurnaroundID { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundExternalID
        /// </summary>
        public long TurnaroundExternalID { get; set; }
        public int? ItemInstanceID { get; set; }
        /// <summary>
        /// Gets or sets ItemInstanceExternalID
        /// </summary>
        public string ItemInstanceExternalID { get; set; }
        public int? ItemID { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets ItemExternalID
        /// </summary>
        public string ItemExternalID { get; set; }
        /// <summary>
        /// Gets or sets ManufacturersReference
        /// </summary>
        public string ManufacturersReference { get; set; }

        [DateOnly(AssumeDateOnlyTimeComponent.AssumeUtcMidday)]
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets MissingInformation
        /// </summary>
        public string MissingInformation { get; set; }
        /// <summary>
        /// Gets or sets Reasons
        /// </summary>
        public IEnumerable<string> Reasons { get; set; }
        /// <summary>
        /// Gets or sets Details
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// Gets or sets Response
        /// </summary>
        public string Response { get; set; }
        /// <summary>
        /// Gets or sets StatusID
        /// </summary>
        public byte StatusID { get; set; }
        /// <summary>
        /// Gets or sets Responded
        /// </summary>
        public bool Responded { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public string DeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets HistoryTable
        /// </summary>
        public TableModel HistoryTable { get; set; }
        /// <summary>
        /// Gets or sets ReturnAction
        /// </summary>
        public string ReturnAction { get; set; }
    }

    /// <summary>
    /// CustomerDefectHistoryItem
    /// </summary>
    public class CustomerDefectHistoryItem
    {
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets Response
        /// </summary>
        public string Response { get; set; }
    }
}