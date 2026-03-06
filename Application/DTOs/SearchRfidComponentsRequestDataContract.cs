using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SearchRfidComponentsRequestDataContract
    /// </summary>
    public class SearchRfidComponentsRequestDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets Tags
        /// </summary>
        public List<string> Tags { get; set; }
    }
}