using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    internal class EngineExceptionHandler
    {
        private static readonly Lazy<IEngineExceptionHandler> Lazy =
            new Lazy<IEngineExceptionHandler>(() => new EngineExceptionHandler());

        private readonly ISynergyExceptionHandler _exceptionHandler;
        private readonly ISynergyExceptionManager _exceptionManager;

        private EngineExceptionHandler()
        {
            _exceptionManager = GlobalManager.Instance;
            _exceptionHandler = GlobalHandler.Instance;
        }

        public static IEngineExceptionHandler Instance
        {
            get { return Lazy.Value; }
        }

        #region IEngineExceptionHandler Members

        /// <summary>
        /// HandleException operation
        /// </summary>
        public bool HandleException(Exception exception)
        {
            return ProcessException<Exception>(exception, true);
        }

        public bool HandleException<T>(Exception exception)
        {
            return ProcessException<T>(exception, true);
        }

        /// <summary>
        /// ManageException operation
        /// </summary>
        public void ManageException(Exception exception)
        {
            ProcessException<Exception>(exception, false);
        }

        public void ManageException<T>(Exception exception)
        {
            ProcessException<T>(exception, false);
        }

        #endregion

        protected bool ProcessException<T>(Exception exception, bool awaitingReturn)
        {
            if (awaitingReturn)
            {
                return _exceptionHandler.HandleException(exception);
            }
            _exceptionManager.ManageException(exception);
            return true;
        }
    }
}