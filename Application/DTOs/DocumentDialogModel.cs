using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Flags]
    public enum DocumentOptions
    {
        None = 0,
        Print = 1,
        Download = 2,
        Email = 4
    }

    /// <summary>
    /// DocumentDialogModel
    /// </summary>
    public class DocumentDialogModel
    {
        /// <summary>
        /// Gets or sets Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets SubTitle
        /// </summary>
        public string SubTitle { get; set; }
        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets DocumentUrl
        /// </summary>
        public string DocumentUrl { get; set; }
        /// <summary>
        /// Gets or sets Options
        /// </summary>
        public DocumentOptions Options { get; set; }
    }
}