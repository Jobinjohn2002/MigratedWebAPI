using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Service event handler base
    /// </summary>
    public static class EventHandlerFactory
    {
        /// <summary>
        /// Gets the utility event handler.
        /// </summary>
        /// <param name="efUnitOfWork">The ef unit of work.</param>
        /// <summary>
        /// GetUtilityEventHandler operation
        /// </summary>
        public static IUtilityEventHandler GetUtilityEventHandler(IUnitOfWork efUnitOfWork)
        {
            return new UtilityEventHandler(efUnitOfWork);
        }

        /// <summary>
        /// Gets the administration event handler.
        /// </summary>
        /// <param name="efUnitOfWork">The ef unit of work.</param>
        /// <summary>
        /// GetAdministrationEventHandler operation
        /// </summary>
        public static IAdministrationEventHandler GetAdministrationEventHandler(IUnitOfWork efUnitOfWork)
        {
            return new AdministrationEventHandler(efUnitOfWork);
        }

        /// <summary>
        /// Gets the synergycustomer event handler.
        /// </summary>
        /// <param name="efUnitOfWork">The ef unit of work.</param>
        /// <summary>
        /// GetReportingEventHandler operation
        /// </summary>
        public static IReportingEventHandler GetReportingEventHandler(IUnitOfWork efUnitOfWork)
        {
            return new ReportingEventHandler(efUnitOfWork);
        }

        /// <summary>
        /// Gets the print event handler.
        /// </summary>
        /// <param name="efUnitOfWork">The ef unit of work.</param>
        /// <summary>
        /// GetPrintEventHandler operation
        /// </summary>
        public static IPrintEventHandler GetPrintEventHandler(IUnitOfWork efUnitOfWork)
        {
            return new PrintEventHandler(efUnitOfWork);
        }
    }
}