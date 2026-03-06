using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// EnquiryComment
    /// </summary>
    public class EnquiryComment
    {
        /// <summary>
        /// Gets or sets EnquiryCommentId
        /// </summary>
        public int EnquiryCommentId { get; set; }
        /// <summary>
        /// Gets or sets CommentId
        /// </summary>
        public int CommentId { get; set; }
        /// <summary>
        /// Gets or sets EnquiryCommentDetails
        /// </summary>
        public Comment EnquiryCommentDetails { get; set; }
    }
}
