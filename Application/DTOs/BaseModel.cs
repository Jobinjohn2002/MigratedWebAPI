using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BaseModel
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// Gets or sets LastRefresh
        /// </summary>
        public string LastRefresh { get; set; }

        /// <summary>
        /// Gets or sets ShowLastRefresh
        /// </summary>
        public bool ShowLastRefresh { get; set; }

        /// <summary>
        /// Gets or sets RefreshFormId
        /// </summary>
        public string RefreshFormId { get; set; }
    }
}