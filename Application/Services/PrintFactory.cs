using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Printer factory
    /// </summary>
    public static class PrintFactory
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <summary>
        /// Create operation
        /// </summary>
        public static PrintUtility Create()
        {
            return new PrintUtility();
        }
    }
}