using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class EventHandlerHelper
    {
        /// <summary>
        /// Helper method to catch exceptions
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="body"></param>
        /// <param name="errorMessage"></param>
        public static T Invoke<T>(Func<T> body, IUnitOfWork unitOfWork, string errorMessage)
        {
            try
            {
                using (unitOfWork.EagerLoad())
                {
                    return body.Invoke();
                }
            }
            catch (Exception ex)
            {
                var handled = EngineExceptionHandler.Instance.HandleException(ex);
                if (handled)
                {
                    throw new PathwayException(null, errorMessage, ex);
                }
                throw;
            }
        }

        /// <summary>
        /// Helper method to catch exceptions
        /// </summary>
        /// <param name="body"></param>
        /// <param name="errorMessage"></param>
        /// <summary>
        /// Invoke operation
        /// </summary>
        public static void Invoke(Action body, IUnitOfWork unitOfWork, string errorMessage)
        {
            Invoke(() => { body.Invoke(); return true; }, unitOfWork, errorMessage);
        }
    }
}
