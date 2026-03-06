using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ChangeRequestEmailModel
    /// </summary>
    public class ChangeRequestEmailModel
    {
        /// <summary>
        /// Gets or sets Reference
        /// </summary>
        public string Reference { get; set; }
        /// <summary>
        /// Gets or sets Date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
        /// <summary>
        /// Gets or sets ProductReference
        /// </summary>
        public string ProductReference { get; set; }
        /// <summary>
        /// Gets or sets ProductDescription
        /// </summary>
        public string ProductDescription { get; set; }
        /// <summary>
        /// Gets or sets AttachProductSpecification
        /// </summary>
        public string AttachProductSpecification { get; set; }
        /// <summary>
        /// Gets or sets AttachManafacturersInstructions
        /// </summary>
        public string AttachManafacturersInstructions { get; set; }
        /// <summary>
        /// Gets or sets Reason
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// Gets or sets Request
        /// </summary>
        public string Request { get; set; }
        /// <summary>
        /// Gets or sets Comments
        /// </summary>
        public ICollection<Comment> Comments { get; set; }
        public int? EstimatedAnnualUsage { get; set; }
        /// <summary>
        /// Gets or sets RequestedBy
        /// </summary>
        public string RequestedBy { get; set; }
        /// <summary>
        /// Gets or sets RequestAction
        /// </summary>
        public string RequestAction { get; set; }
        /// <summary>
        /// Gets or sets ChangeControlNoteStatus
        /// </summary>
        public string ChangeControlNoteStatus { get; set; }
        /// <summary>
        /// Gets or sets ChangeControlNoteURL
        /// </summary>
        public string ChangeControlNoteURL { get; set; }

        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets CommentText
        /// </summary>
        public string CommentText { get; set; }
        /// <summary>
        /// Gets or sets CreatedByFullName
        /// </summary>
        public string CreatedByFullName { get; set; }

        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public ChangeControlConfirmation Confirmation { get; set; }
        /// <summary>
        /// Gets or sets ChangeControlNote
        /// </summary>
        public ChangeControlNote ChangeControlNote { get; set; }
    }
}