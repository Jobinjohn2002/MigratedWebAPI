using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Indicates that a HttpStatusCode and Message can be returned.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    /// <summary>
    /// HttpResultAttribute
    /// </summary>
    public class HttpResultAttribute : Attribute
    {
        /// <summary>
        /// The HttpStatusCode.
        /// </summary>
        /// <summary>
        /// Gets or sets Code
        /// </summary>
        public HttpStatusCode Code { get; set; }
        /// <summary>
        /// The Message.
        /// </summary>
        /// <summary>
        /// Gets or sets Message
        /// </summary>
        public string Message { get; set; }
    }
}