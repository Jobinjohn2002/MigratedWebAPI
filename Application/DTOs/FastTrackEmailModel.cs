using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FastTrackEmailModel
    /// </summary>
    public class FastTrackEmailModel
    {
        /// <summary>
        /// Gets or sets Reference
        /// </summary>
        public string Reference { get; set; }
        /// <summary>
        /// Gets or sets RequestedBy
        /// </summary>
        public string RequestedBy { get; set; }
        /// <summary>
        /// Gets or sets Location
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public string Customer { get; set; }
        /// <summary>
        /// Gets or sets ItemDetails
        /// </summary>
        public string ItemDetails { get; set; }
        /// <summary>
        /// Gets or sets RequestDate
        /// </summary>
        public string RequestDate { get; set; }
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public FastTrackConfirmation Confirmation { get; set; }
        /// <summary>
        /// Gets or sets CommentText
        /// </summary>
        public string CommentText { get; set; }
        /// <summary>
        /// Gets or sets CreatedByFullName
        /// </summary>
        public string CreatedByFullName { get; set; }
        /// <summary>
        /// Gets or sets Lines
        /// </summary>
        public List<FastTrackDetailsLineModel> Lines { get; set; }
        /// <summary>
        /// Gets or sets FastTrackURL
        /// </summary>
        public string FastTrackURL { get; set; }
        /// <summary>
        /// Gets or sets ForCustomer
        /// </summary>
        public bool ForCustomer { get; set; }
        /// <summary>
        /// Gets or sets Comments
        /// </summary>
        public IEnumerable<Comment> Comments { get; set; }
    }
}