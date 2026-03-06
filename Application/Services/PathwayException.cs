using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    [Serializable]
    /// <summary>
    /// PathwayException
    /// </summary>
    public class PathwayException : SynergyException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PathwayException"/> class.
        /// </summary>
        /// <param name="exceptionToWrap">The exception to wrap.</param>
        /// <remarks></remarks>
        public PathwayException(Exception exceptionToWrap)
        {
            WrappedException = exceptionToWrap;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathwayException"/> class.
        /// </summary>
        /// <param name="exceptionId">The exception id.</param>
        /// <remarks></remarks>
        public PathwayException(string exceptionId)
        {
            ExceptionId = exceptionId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathwayException"/> class.
        /// </summary>
        /// <param name="exceptionId">The exception id.</param>
        /// <param name="exceptionToWrap">The exception to wrap.</param>
        /// <remarks></remarks>
        public PathwayException(string exceptionId, Exception exceptionToWrap)
        {
            WrappedException = exceptionToWrap;
            ExceptionId = exceptionId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathwayException"/> class.
        /// </summary>
        /// <param name="exceptionId">The exception id.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <remarks></remarks>
        public PathwayException(string exceptionId, string errorMessage)
        {
            ExceptionId = exceptionId;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathwayException"/> class.
        /// </summary>
        /// <param name="exceptionId">The exception id.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="exceptionToWrap">The exception to wrap.</param>
        /// <remarks></remarks>
        public PathwayException(string exceptionId, string errorMessage, Exception exceptionToWrap)
        {
            WrappedException = exceptionToWrap;
            ExceptionId = exceptionId;
            ErrorMessage = errorMessage;
        }

    }
}