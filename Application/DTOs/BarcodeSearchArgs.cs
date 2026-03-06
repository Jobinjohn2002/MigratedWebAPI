using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BarcodeSearchArgs
    /// </summary>
    public class BarcodeSearchArgs
    {
        /// <summary>
        /// Gets or sets Context
        /// </summary>
        public HttpContextBase Context { get; set; }
        /// <summary>
        /// Gets or sets Controller
        /// </summary>
        public string Controller { get; set; }
        /// <summary>
        /// Gets or sets Action
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// Gets or sets RouteValues
        /// </summary>
        public RouteValueDictionary RouteValues { get; set; }
    }
}