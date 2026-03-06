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
    /// <summary>
    /// GlobalManager
    /// </summary>
    public class GlobalManager
    {
        private static readonly Lazy<ISynergyExceptionManager> Lazy =
            new Lazy<ISynergyExceptionManager>(() => new EntLibWrapper());

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        private GlobalManager()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static ISynergyExceptionManager Instance => Lazy.Value;

        #region ISynergyExceptionManager Members

        /// <summary>
        /// Manages the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <summary>
        /// ManageException operation
        /// </summary>
        public void ManageException(Exception exception)
        {
            Instance.ManageException(exception);
        }

        /// <summary>
        /// Manages the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="policyName">Name of the policy.</param>
        /// <summary>
        /// ManageException operation
        /// </summary>
        public void ManageException(Exception exception, String policyName)
        {
            Instance.ManageException(exception, policyName);
        }

        /// <summary>
        /// Manages the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="policyName">Name of the policy.</param>
        /// <param name="exceptionToThrow">The exception to throw.</param>
        /// <summary>
        /// ManageException operation
        /// </summary>
        public void ManageException(Exception exception, String policyName, out Exception exceptionToThrow)
        {
            Instance.ManageException(exception, policyName, out exceptionToThrow);
        }

        #endregion
    }
}