using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// EnquiryModel
    /// </summary>
    public class EnquiryModel
    {
        /// <summary>
        /// Gets or sets Reference
        /// </summary>
        public string Reference { get; set; }

        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Subject
        /// </summary>
        public string Subject { get; set; }

        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets ShowGettingStarted
        /// </summary>
        public bool ShowGettingStarted { get; set; }
 
        public int? LocationID { get; set; }
    }
}