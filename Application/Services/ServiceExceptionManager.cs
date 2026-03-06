using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SynergyApplicationFrameworkApi.Application.Interfaces;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.ServiceModel;


namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Service Exception manager
    /// </summary>
    /// <remarks></remarks>
    internal class ServiceExceptionManager : IPathwayExceptionManager
    {
        private static readonly Lazy<IPathwayExceptionManager> Lazy =
            new Lazy<IPathwayExceptionManager>(() => new ServiceExceptionManager());

        private readonly ISynergyExceptionHandler _exceptionHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <remarks></remarks>
        private ServiceExceptionManager()
        {
            _exceptionHandler = GlobalHandler.Instance;
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <remarks></remarks>
        public static IPathwayExceptionManager Instance
        {
            get { return Lazy.Value; }
        }
        
        #region IServiceExceptionManager Members

        /// <summary>
        /// Manages the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <remarks></remarks>
        /// <summary>
        /// ManageException operation
        /// </summary>
        public void ManageException(Exception exception)
        {
            ProcessException<Exception>(exception);
        }

        /// <summary>
        /// Manages the exception.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exception">The exception.</param>
        /// <remarks></remarks>
        public void ManageException<T>(Exception exception)
        {
            ProcessException<T>(exception);
        }

        #endregion

        #region ProcessException
        /// <summary>
        /// Processes the exception.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exception">The exception.</param>
        /// <remarks></remarks>
        protected void ProcessException<T>(Exception exception)
        {
            if (exception is PathwayException)
            {
                if (exception is PathwayException pathwayException)
                {
                    var faultContract = new BasicFaultContract(pathwayException.ExceptionId, pathwayException.ErrorMessage);

                    throw new FaultException<BasicFaultContract>(faultContract, new FaultReason(pathwayException.ErrorMessage));
                }
            }
            else if (exception is SynergyException)
            {
                if (exception is SynergyException synergyException)
                {
                    var faultContract = new BasicFaultContract(synergyException.ExceptionId, synergyException.ErrorMessage);

                    throw new FaultException<BasicFaultContract>(faultContract, new FaultReason(string.Empty));
                }
            }
            else
            {
                _exceptionHandler.HandleException(exception);
                var faultContract = new BasicFaultContract(string.Empty, "Unknown error occurred"); 

                throw new FaultException<BasicFaultContract>(faultContract, new FaultReason("Unknown error occurred."));
            }
        }
        #endregion
    }
}