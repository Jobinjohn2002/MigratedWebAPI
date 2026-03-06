using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Global exception manager
    /// </summary>
    [Serializable]
    /// <summary>
    /// SynergyException
    /// </summary>
    public class SynergyException : Exception
    {
        /// <summary>
        /// Gets or sets the exception id.
        /// </summary>
        /// <value>The exception id.</value>
        /// <summary>
        /// Gets or sets ExceptionId
        /// </summary>
        public string ExceptionId { get; set; }
        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        /// <summary>
        /// Gets or sets ErrorMessage
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// Gets or sets the dev notes.
        /// </summary>
        /// <value>The dev notes.</value>
        /// <summary>
        /// Gets or sets DevNotes
        /// </summary>
        public string DevNotes { get; set; }
        /// <summary>
        /// Gets or sets the wrapped exception.
        /// </summary>
        /// <value>The wrapped exception.</value>
        /// <summary>
        /// Gets or sets WrappedException
        /// </summary>
        public Exception WrappedException { get; set; }
    }
}