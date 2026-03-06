using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum EnquiryDetailsTab
    {
        Details = 0,
        Comments = 1
    }

    public enum EnquiryDetailsConfirmation
    {
        None = 0,
        New = 1,
        StatusChanged = 2,
        Comment = 3
    }

    /// <summary>
    /// EnquiryDetailsModel
    /// </summary>
    public class EnquiryDetailsModel
    {
        /// <summary>
        /// Gets or sets Enquiry
        /// </summary>
        public Enquiry Enquiry { get; set; }
        /// <summary>
        /// Gets or sets SelectedTab
        /// </summary>
        public EnquiryDetailsTab SelectedTab { get; set; }
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public EnquiryDetailsConfirmation Confirmation { get; set; }
        /// <summary>
        /// Gets or sets EnquiryStatuses
        /// </summary>
        public IEnumerable<SelectListItem> EnquiryStatuses { get; set; }
        /// <summary>
        /// Gets or sets LocationName
        /// </summary>
        public string LocationName { get; set; }
    }
}