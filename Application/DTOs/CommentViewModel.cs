using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CommentViewModel
    /// </summary>
    public class CommentViewModel
    {
        /// <summary>
        /// Gets or sets Comments
        /// </summary>
        public IEnumerable<Comment> Comments { get; set; }
        /// <summary>
        /// Gets or sets ReadOnly
        /// </summary>
        public bool ReadOnly { get; set; }
    }
}