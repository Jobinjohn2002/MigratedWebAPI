using System;
using System.Linq;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class CostingModelItemTypeDataAdapter : DataAdapterBase, ICostingModelItemTypeDataAdapter
    {
        /// <summary>
        /// Reads IPOH.
        /// </summary>
        /// <param name="itemId">The itemTypeId.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadIPOHForItemType operation
        /// </summary>
        public int ReadIPOHForItemType(int itemTypeId)
        {
            try
            {
                var costingModelItemTypeRepository = CostingModelItemTypeRepository.New(WorkUnit);
                return costingModelItemTypeRepository.ReadIPOHForItemType(itemTypeId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        #region ICostingModelItemTypeDataAdapter Members

        /// <summary>
        /// ArchiveCostingModelItemType operation
        /// </summary>
        public void ArchiveCostingModelItemType(int costingModelItemTypeIndexId, int userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// GetCostingModelItemTypeByCostingModel operation
        /// </summary>
        public IQueryable<ItemType> GetCostingModelItemTypeByCostingModel(int costingModelId)
        {
            try
            {
                var costingModelItemTypeRepository = CostingModelItemTypeRepository.New(WorkUnit);
                return costingModelItemTypeRepository.GetCostingModelItemTypeByCostingModel(costingModelId);
            }
            catch (Exception)
            {
				

				throw;
            }
        }

        #endregion
    }
}