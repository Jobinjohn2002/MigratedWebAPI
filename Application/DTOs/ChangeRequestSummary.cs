using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ChangeRequestSummary
    /// </summary>
    public class ChangeRequestSummary
    {
        /// <summary>
        /// Gets or sets ChangeControlNoteId
        /// </summary>
        public int ChangeControlNoteId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        public string ItemExternalId {get;set;}
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets Request
        /// </summary>
        public string Request { get; set; }
    }
}
