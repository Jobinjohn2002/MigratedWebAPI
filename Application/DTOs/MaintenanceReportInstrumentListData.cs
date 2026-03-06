using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// MaintenanceReportInstrumentListData
    /// </summary>
    public class MaintenanceReportInstrumentListData
    {
        /// <summary>
        /// Gets or sets MaintenanceReportInstrumentId
        /// </summary>
        public int MaintenanceReportInstrumentId { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceReportId
        /// </summary>
        public int MaintenanceReportId { get; set; }
        /// <summary>
        /// Gets or sets ItemExternalId
        /// </summary>
        public string ItemExternalId { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterDefinitionId
        /// </summary>
        public int ItemMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterId
        /// </summary>
        public int ItemMasterId { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceActivity
        /// </summary>
        public string MaintenanceActivity { get; set; }
        /// <summary>
        /// Gets or sets QuantityForMaintenance
        /// </summary>
        public int QuantityForMaintenance { get; set; }
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or sets Cost
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// Gets or sets SerialNumber
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// Gets or sets StatusId
        /// </summary>
        public int StatusId { get; set; }
        /// <summary>
        /// Gets or sets StatusText
        /// </summary>
        public string StatusText { get; set; }
        public int? LocationId { get; set; }
        /// <summary>
        /// Gets or sets Location
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Gets or sets ReplacementSerialNumber
        /// </summary>
        public string ReplacementSerialNumber { get; set; }
        /// <summary>
        /// Gets or sets Notes
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Gets or sets No
        /// </summary>
        public long No { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceActivityId
        /// </summary>
        public int MaintenanceActivityId { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }
        /// <summary>
        /// Gets or sets ReturnStockLocationId
        /// </summary>
        public int ReturnStockLocationId { get; set; }
    }
}
