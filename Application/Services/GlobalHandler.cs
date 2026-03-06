using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SynergyApplicationFrameworkApi.Application.Interfaces;
namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Global exception handler
    /// </summary>
    /// <summary>
    /// GlobalHandler
    /// </summary>
    public class GlobalHandler
    {
        private static readonly Lazy<ISynergyExceptionHandler> Lazy =
            new Lazy<ISynergyExceptionHandler>(() => new EntLibWrapper());

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        private GlobalHandler()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static ISynergyExceptionHandler Instance
        {
            get { return Lazy.Value; }
        }

        #region ISynergyExceptionHandler Members

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <summary>
        /// HandleException operation
        /// </summary>
        public bool HandleException(Exception exception)
        {
            return Instance.HandleException(exception);
        }

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="policyName">Name of the policy.</param>
        /// <summary>
        /// HandleException operation
        /// </summary>
        public bool HandleException(Exception exception, String policyName)
        {
            return Instance.HandleException(exception, policyName);
        }

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="policyName">Name of the policy.</param>
        /// <param name="exceptionToThrow">The exception to throw.</param>
        /// <summary>
        /// HandleException operation
        /// </summary>
        public bool HandleException(Exception exception, String policyName, out Exception exceptionToThrow)
        {
            return Instance.HandleException(exception, policyName, out exceptionToThrow);
        }

        #endregion
    }
}