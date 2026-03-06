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
    /// IPathwayExceptionHandler
    /// </summary>
    public interface IPathwayExceptionHandler
    {
        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        bool HandleException(Exception exception);
        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        bool HandleException<T>(Exception exception);
    }
}