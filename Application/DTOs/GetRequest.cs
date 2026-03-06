using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// GetRequest
    /// </summary>
    public class GetRequest : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets Value
        /// </summary>
        public string Value { get; set; }
        public int Id{ get; set; }
    }
}