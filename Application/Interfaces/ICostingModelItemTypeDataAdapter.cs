using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    public partial interface ICostingModelItemTypeDataAdapter
    {
        /// <summary>
        /// /
        /// </summary>
        /// <param name="costingModelId"></param>
        /// <returns></returns>
        IQueryable<ItemType> GetCostingModelItemTypeByCostingModel(int costingModelId);

        /// <summary>
        /// Reads IPOH.
        /// </summary>
        /// <param name="itemId">The itemTypeId.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        int ReadIPOHForItemType(int itemTypeId);
    }
}
