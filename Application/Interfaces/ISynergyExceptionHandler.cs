using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// Synergy Exception handler
    /// </summary>
    /// <summary>
    /// ISynergyExceptionHandler
    /// </summary>
    public interface ISynergyExceptionHandler
    {
        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        bool HandleException(Exception exception);
        
        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="policyName">Name of the policy.</param>
        bool HandleException(Exception exception, String policyName);

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="policyName">Name of the policy.</param>
        /// <param name="exceptionToThrow">The exception to throw.</param>
        bool HandleException(Exception exception, String policyName, out Exception exceptionToThrow);
    }
}