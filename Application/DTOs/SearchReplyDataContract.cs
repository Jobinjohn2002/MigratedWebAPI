using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SearchReplyDataContract
    /// </summary>
    public class SearchReplyDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets Results
        /// </summary>
        public List<SearchResult> Results { get; set; }
    }
}