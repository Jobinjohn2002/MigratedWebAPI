using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SearchRequestDataContract
    /// </summary>
    public class SearchRequestDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets SearchTerm
        /// </summary>
        public string SearchTerm { get; set; }
        /// <summary>
        /// Gets or sets SearchType
        /// </summary>
        public int SearchType { get; set; }
        public int? LocationId { get; set; }
    }
}