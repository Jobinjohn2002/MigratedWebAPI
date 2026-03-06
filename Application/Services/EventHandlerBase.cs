using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Service event handler base
    /// </summary>
    /// <summary>
    /// EventHandlerBase
    /// </summary>
    public class EventHandlerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlerBase"/> class.
        /// </summary>
        /// <param name="efUnitOfWork">The ef unit of work.</param>
        public EventHandlerBase(IUnitOfWork efUnitOfWork)
        {
            OperativeWorkUnit = efUnitOfWork;
        }

        /// <summary>
        /// Gets the operative work unit.
        /// </summary>
        /// <summary>
        /// Gets or sets OperativeWorkUnit
        /// </summary>
        public IUnitOfWork OperativeWorkUnit { get; }

        /// <summary>
        /// Gets or sets PrintDetailsList
        /// </summary>
        public List<IPrintDetails> PrintDetailsList { get; set; } = new List<IPrintDetails>();
    }
}

 