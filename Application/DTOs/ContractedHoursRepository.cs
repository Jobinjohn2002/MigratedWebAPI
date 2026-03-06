using System.Linq;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ContractedHoursRepository
    /// </summary>
    /// <remarks></remarks>
    public partial class ContractedHoursRepository
    {
        /// <summary>
        /// Gets the specified index id.
        /// </summary>
        /// <param name="indexId">The index id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// Get operation
        /// </summary>
        public ContractedHours Get(int indexId)
        {
            return Repository.Find(contractedHours => contractedHours.ContractedHoursId == indexId).FirstOrDefault();
        }

        /// <summary>
        /// Gets the contracted hours by customer.
        /// </summary>
        /// <param name="customerId">The customer id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetContractedHoursByCustomer operation
        /// </summary>
        public IQueryable<ContractedHours> GetContractedHoursByCustomer(int customerId)
        {
            return Repository.Find(contractedHours => contractedHours.CustomerId == customerId).OrderBy(d=>d.DayOfWeek);
        }

        /// <summary>
        /// GetContractedHoursByCustomerDefinitionId operation
        /// </summary>
        public IQueryable<ContractedHours> GetContractedHoursByCustomerDefinitionId(int customerDefinitionId)
        {
            return Repository.Find(contractedHours => contractedHours.Customer.CustomerDefinitionId == customerDefinitionId);
        }
    }
}