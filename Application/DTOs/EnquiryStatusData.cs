using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// EnquiryStatusData
    /// </summary>
    public class EnquiryStatusData
    {
        /// <summary>
        /// Gets or sets EnquiryStatusId
        /// </summary>
        public int EnquiryStatusId { get; set; }
        /// <summary>
        /// Gets or sets EnquiryStatusText
        /// </summary>
        public string EnquiryStatusText { get; set; }
    }
}
