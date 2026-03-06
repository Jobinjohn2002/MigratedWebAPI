using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ImsMaintenanceRequest
    /// </summary>
    public class ImsMaintenanceRequest
    {
        [MaxLength(50)]
        /// <summary>
        /// Gets or sets YourReference
        /// </summary>
        public string YourReference { get; set; }
        public DateTime? EstimatedCompletionDate { get; set; }
        public decimal? TotalCost { get; set; }
        [MaxLength(50)]
        /// <summary>
        /// Gets or sets Courier
        /// </summary>
        public string Courier { get; set; }
        [MaxLength(50)]
        /// <summary>
        /// Gets or sets CourierRef
        /// </summary>
        public string CourierRef { get; set; }
        [MaxLength(500)]
        /// <summary>
        /// Gets or sets PurchaseRequisitionReference
        /// </summary>
        public string PurchaseRequisitionReference { get; set; }
        [MaxLength(50)]
        /// <summary>
        /// Gets or sets PurchaseOrderReference
        /// </summary>
        public string PurchaseOrderReference { get; set; }
        [MaxLength(50)]
        /// <summary>
        /// Gets or sets InvoiceReference
        /// </summary>
        public string InvoiceReference { get; set; }
        [MaxLength(50)]
        /// <summary>
        /// Gets or sets QuoteReference
        /// </summary>
        public string QuoteReference { get; set; }
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceActivities
        /// </summary>
        public List<ImsMaintenanceActivity> MaintenanceActivities { get; set; }
    }

    /// <summary>
    /// ImsMaintenanceActivity
    /// </summary>
    public class ImsMaintenanceActivity
    {
        [Required]
        [MaxLength(100)]
        /// <summary>
        /// Gets or sets InstrumentReference
        /// </summary>
        public string InstrumentReference { get; set; }
        [MaxLength(50)]
        /// <summary>
        /// Gets or sets Activity
        /// </summary>
        public string Activity { get; set; }
        public int? Quantity { get; set; }
        public decimal? CostPerItem { get; set; }
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }
    }
}
