using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// ContractedHoursDataAdapter interface
    /// </summary>
    /// <remarks></remarks>
    public partial interface IContractedHoursDataAdapter
    {
        /// <summary>
        /// Reads the contracted hours by customer.
        /// </summary>
        /// <param name="customerId">The customer id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IQueryable<IContractedHours> ReadContractedHoursByCustomer(int customerId);
    }
}