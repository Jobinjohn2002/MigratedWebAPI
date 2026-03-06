using System.Linq;
using SynergyApplicationFrameworkApi.Application.DTOs; //Fix for model move
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class CostingModelRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public CostingModel Get(int indexId)
        {
            return Repository.Find(costingModel => costingModel.CostingModelId == indexId).FirstOrDefault();
        }

        /// <summary>
        /// GetCostingModelByCustomer operation
        /// </summary>
        public CostingModel GetCostingModelByCustomer(int customerDefinitionId)
        {
            return Repository.Find(costingModel => costingModel.CustomerDefinitionId == customerDefinitionId).FirstOrDefault();
        }

        /// <summary>
        /// ReadCostingModelTypeByCustomerDefinition operation
        /// </summary>
        public int ReadCostingModelTypeByCustomerDefinition(int customerDefinitionId)
        {
            return Repository.Find(cm => cm.CustomerDefinitionId == customerDefinitionId).Select(cm => cm.CostingModelTypeId).SingleOrDefault();
        }
	}
}