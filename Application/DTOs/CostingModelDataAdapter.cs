using System;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class CostingModelDataAdapter : DataAdapterBase, ICostingModelDataAdapter
    {
        #region ICostingModelDataAdapter Members

        /// <summary>
        /// ArchiveCostingModel operation
        /// </summary>
        public void ArchiveCostingModel(int costingModelIndexId, int userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// GetCostingModelByCustomer operation
        /// </summary>
        public ICostingModel GetCostingModelByCustomer(int customerDefinitionId)
        {
            try
            {
                var costingModelRepository = CostingModelRepository.New(WorkUnit);
                return costingModelRepository.GetCostingModelByCustomer(customerDefinitionId);
            }
            catch (Exception)
            {
                

                throw;
            }
        }

        #endregion
    }
}