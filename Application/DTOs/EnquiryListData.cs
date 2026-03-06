using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// EnquiryListData
    /// </summary>
    public class EnquiryListData
    {
        /// <summary>
        /// Gets or sets EnquiryId
        /// </summary>
        public int EnquiryId { get; set; }
        /// <summary>
        /// Gets or sets EnquiryStatusId
        /// </summary>
        public int EnquiryStatusId { get; set; }
        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets Subject
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Gets or sets CreatedById
        /// </summary>
        public int CreatedById { get; set; }
        /// <summary>
        /// Gets or sets Message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets EnquiryStatus
        /// </summary>
        public string EnquiryStatus { get; set; }
        /// <summary>
        /// Gets or sets EnquiryComments
        /// </summary>
        public IEnumerable<Comment> EnquiryComments { get; set; }
        /// <summary>
        /// Gets or sets TotalEnquiries
        /// </summary>
        public int TotalEnquiries { get; set; }
        public int? DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
        public int UpdatedByUserId {get;set; }
    }
}
