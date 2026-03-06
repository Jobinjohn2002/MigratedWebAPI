using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ChangeRequestCommentEmailModel
    /// </summary>
    public class ChangeRequestCommentEmailModel
    {
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
        /// Gets or sets Comments
        /// </summary>
        public ICollection<Comment> Comments { get; set; }
        /// <summary>
        /// Gets or sets ChangeControlNoteURL
        /// </summary>
        public string ChangeControlNoteURL { get; set; }
    }
}