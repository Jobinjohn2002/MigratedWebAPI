using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// GetListRequest
    /// </summary>
    public class GetListRequest : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets Ids
        /// </summary>
        public List<int> Ids { get; set; }
    }
}