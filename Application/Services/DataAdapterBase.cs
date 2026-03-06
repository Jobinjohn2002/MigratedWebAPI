using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Global Service event handler base
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// DataAdapterBase
    /// </summary>
    public class DataAdapterBase
    {
        private readonly IUnitOfWork _efUnitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAdapterBase"/> class.
        /// </summary>
        /// <param name="efUnitOfWork">The ef unit of work.</param>
        /// <remarks></remarks>
        public DataAdapterBase(IUnitOfWork efUnitOfWork)
        {
            _efUnitOfWork = efUnitOfWork;
        }

        /// <summary>
        /// Gets the work unit.
        /// </summary>
        /// <remarks></remarks>
        public IUnitOfWork WorkUnit
        {
            get { return _efUnitOfWork; }
        }
    }
}