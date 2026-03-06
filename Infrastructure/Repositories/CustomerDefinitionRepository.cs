using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class CustomerDefinitionRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public CustomerDefinition Get(int customerDefinitionId)
        {
            return Repository.Find(customerDefinition => customerDefinition.CustomerDefinitionId == customerDefinitionId).FirstOrDefault();
        }

        /// <summary>
        /// Get operation
        /// </summary>
        public List<CustomerDefinition> Get(List<short> facilityIds)
        {
            return Repository.Find(cd => facilityIds.Contains(cd.CurrentCustomer.FacilityId)).ToList();
        }
	}
}