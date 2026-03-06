using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class LazyCostingModelItemTypeHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(CostingModelItemType concreteCostingModelItemType,
                                     CostingModelItemType genericCostingModelItemType)
        {
            concreteCostingModelItemType.CostingModelItemTypeId = genericCostingModelItemType.CostingModelItemTypeId;
            concreteCostingModelItemType.CostingModelId = genericCostingModelItemType.CostingModelId;
            concreteCostingModelItemType.ItemTypeId = genericCostingModelItemType.ItemTypeId;
            concreteCostingModelItemType.LegacyFacilityOrigin = genericCostingModelItemType.LegacyFacilityOrigin;
            concreteCostingModelItemType.LegacyImported = genericCostingModelItemType.LegacyImported;
        }
    }
}