using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// Synergy exception manager
    /// </summary>
    /// <summary>
    /// ISynergyExceptionManager
    /// </summary>
    public interface ISynergyExceptionManager
    {
        /// <summary>
        /// Manages the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        void ManageException(Exception exception);

        /// <summary>
        /// Manages the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="policyName">Name of the policy.</param>
        void ManageException(Exception exception, String policyName);

        /// <summary>
        /// Manages the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="policyName">Name of the policy.</param>
        /// <param name="exceptionToThrow">The exception to throw.</param>
        void ManageException(Exception exception, String policyName, out Exception exceptionToThrow);
    }
}