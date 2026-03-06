using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// EnquiryEmailModel
    /// </summary>
    public class EnquiryEmailModel
    {
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public EnquiryDetailsConfirmation Confirmation { get; set; }
        /// <summary>
        /// Gets or sets Enquiry
        /// </summary>
        public Enquiry Enquiry { get; set; }
        /// <summary>
        /// Gets or sets LocationName
        /// </summary>
        public string LocationName { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
    }
}