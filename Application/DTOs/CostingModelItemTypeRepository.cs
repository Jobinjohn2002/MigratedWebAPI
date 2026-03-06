using System.Linq;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class CostingModelItemTypeRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public CostingModelItemType Get(int indexId)
        {
            return Repository.Find(costingModelItemType => costingModelItemType.CostingModelItemTypeId == indexId).FirstOrDefault();
        }

        /// <summary>
        /// GetCostingModelItemTypeByCostingModel operation
        /// </summary>
        public IQueryable<ItemType> GetCostingModelItemTypeByCostingModel(int costingModelId)
        {
            return Repository.Find(cmit => cmit.CostingModelId == costingModelId).Select(i => i.ItemType);
        }

        /// <summary>
        /// ReadIPOHForItemType operation
        /// </summary>
        public int ReadIPOHForItemType(int itemTypeId)
        {
            return Repository.Find(cmit => cmit.ItemTypeId == itemTypeId).Count();
        }
	}
}