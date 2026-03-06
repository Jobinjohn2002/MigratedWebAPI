using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Provides a description of a Http Header.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    /// <summary>
    /// HttpHeaderAttribute
    /// </summary>
    public class HttpHeaderAttribute : Attribute
    {
        /// <summary>
        /// The name of the header.
        /// </summary>
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the header.
        /// </summary>
        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// An example value for the header.
        /// </summary>
        /// <summary>
        /// Gets or sets Example
        /// </summary>
        public string Example { get; set; }
    }
}