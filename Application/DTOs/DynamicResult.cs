using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DynamicResult
    /// </summary>
    public class DynamicResult
    {
        /// <summary>
        /// Gets or sets View
        /// </summary>
        public string View { get; set; }
        /// <summary>
        /// Gets or sets Model
        /// </summary>
        public object Model { get; set; }
    }
}