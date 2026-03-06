using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// LazyCostingModelHelper
    /// </summary>
    /// <remarks></remarks>
    public partial class LazyCostingModelHelper
    {
        /// <summary>
        /// Populates the concrete.
        /// </summary>
        /// <param name="concreteCostingModel">The concrete costing model.</param>
        /// <param name="genericCostingModel">The generic costing model.</param>
        /// <remarks></remarks>
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(CostingModel concreteCostingModel, CostingModel genericCostingModel)
        {
            concreteCostingModel.CostingModelId = genericCostingModel.CostingModelId;
            concreteCostingModel.CostingModelTypeId = genericCostingModel.CostingModelTypeId;
            concreteCostingModel.CustomerDefinitionId = genericCostingModel.CustomerDefinitionId;
            concreteCostingModel.AllowSingleUseCostOverride = genericCostingModel.AllowSingleUseCostOverride;
            concreteCostingModel.AllowPriceCategoryOverride = genericCostingModel.AllowPriceCategoryOverride;
            concreteCostingModel.AllowPriceCategoryCostOverride = genericCostingModel.AllowPriceCategoryCostOverride;
            concreteCostingModel.UseFinancialComponentCount = genericCostingModel.UseFinancialComponentCount;
        }
    }
}