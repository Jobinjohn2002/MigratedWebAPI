using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IPathwayExceptionManager
    /// </summary>
    public interface IPathwayExceptionManager
    {
        /// <summary>
        /// Manages the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <remarks></remarks>
        void ManageException(Exception exception);
        /// <summary>
        /// Manages the exception.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exception">The exception.</param>
        /// <remarks></remarks>
        void ManageException<T>(Exception exception);
    }
}