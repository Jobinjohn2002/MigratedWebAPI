using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class LazyCostingModelTypeHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(CostingModelType concreteCostingModelType,
                                     CostingModelType genericCostingModelType)
        {
            concreteCostingModelType.CostingModelTypeId = genericCostingModelType.CostingModelTypeId;
            concreteCostingModelType.Text = genericCostingModelType.Text;
            concreteCostingModelType.LegacyFacilityOrigin = genericCostingModelType.LegacyFacilityOrigin;
            concreteCostingModelType.LegacyImported = genericCostingModelType.LegacyImported;
        }
    }
}