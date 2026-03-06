using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BasicInvoiceScheduleData
    /// </summary>
    public class BasicInvoiceScheduleData
    {
        public BasicInvoiceScheduleData(string text, int id, string facilityName,int invoicePeriodId, int facilityId)
        {
            Text = text;
            Id = id;
            FacilityName = facilityName;
            InvoicePeriodId = invoicePeriodId;
            FacilityId = facilityId;
        }
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets InvoicePeriodId
        /// </summary>
        public int InvoicePeriodId { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }
    }
}