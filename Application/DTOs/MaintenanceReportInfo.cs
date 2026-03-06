using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Provices information about a maintenance report, such as ad-hoc repair maintenance or scheduled and planned maintenance.
    /// </summary>
    /// <summary>
    /// MaintenanceReportInfo
    /// </summary>
    public class MaintenanceReportInfo
    {
        /// <summary>
        /// The unique identifier for this resource.
        /// </summary>
        /// <summary>
        /// Gets or sets MaintenanceReportNumber
        /// </summary>
        public string MaintenanceReportNumber { get; set; }
        /// <summary>
        /// Your reference number, e.g. your internal system reference number to link to this record.
        /// </summary>
        /// <summary>
        /// Gets or sets YourReference
        /// </summary>
        public string YourReference { get; set; }
        /// <summary>
        /// The reprocessing serial number (turnaround) for the asset this report is for.
        /// </summary>
        /// <summary>
        /// Gets or sets Turnaround
        /// </summary>
        public long Turnaround { get; set; }
        /// <summary>
        /// The hospital that owns the asset this maintenance report was raised against.
        /// </summary>
        /// <summary>
        /// Gets or sets Hospital
        /// </summary>
        public string Hospital { get; set; }
        /// <summary>
        /// The location the asset is associated with (e.g. is normally delivered to).
        /// </summary>
        /// <summary>
        /// Gets or sets Location
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// The reference of the repair vendor.
        /// </summary>
        /// <summary>
        /// Gets or sets VendorReference
        /// </summary>
        public string VendorReference { get; set; }
        /// <summary>
        /// The reference of the courier.
        /// </summary>
        /// <summary>
        /// Gets or sets CourierReference
        /// </summary>
        public string CourierReference { get; set; }
        /// <summary>
        /// The date the report was created.
        /// </summary>
        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// The estimated completion date of the maintenance activities.
        /// </summary>
        public DateTime? EstimatedCompletionDate { get; set; }
        /// <summary>
        /// The total cost of the maintenance activities.
        /// </summary>
        public decimal? TotalCost { get; set; }
        /// <summary>
        /// The purchase requisition reference.
        /// </summary>
        /// <summary>
        /// Gets or sets PurchaseRequisitionReference
        /// </summary>
        public string PurchaseRequisitionReference { get; set; }
        /// <summary>
        /// The purchase order reference.
        /// </summary>
        /// <summary>
        /// Gets or sets PurchaseOrderReference
        /// </summary>
        public string PurchaseOrderReference { get; set; }
        /// <summary>
        /// The invoice reference.
        /// </summary>
        /// <summary>
        /// Gets or sets InvoiceReference
        /// </summary>
        public string InvoiceReference { get; set; }
        /// <summary>
        /// The quote reference.
        /// </summary>
        /// <summary>
        /// Gets or sets QuoteReference
        /// </summary>
        public string QuoteReference { get; set; }
        /// <summary>
        /// The notes that have been added to the maintenance report.
        /// </summary>
        /// <summary>
        /// Gets or sets Notes
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// The maintenance report status.
        /// </summary>
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// The maintenance lines on the report.
        /// </summary>
        /// <summary>
        /// Gets or sets MaintenanceReportLines
        /// </summary>
        public List<MaintenanceReportLineInfo> MaintenanceReportLines { get; set; }
    }
}