using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyChargeListCategoryHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ChargeListCategory concreteChargeListCategory,
                                     ChargeListCategory genericChargeListCategory)
        {
            concreteChargeListCategory.ChargeListCategoryId = genericChargeListCategory.ChargeListCategoryId;
            concreteChargeListCategory.Text = genericChargeListCategory.Text;
            concreteChargeListCategory.LegacyFacilityOrigin = genericChargeListCategory.LegacyFacilityOrigin;
            concreteChargeListCategory.LegacyImported = genericChargeListCategory.LegacyImported;
        }
    }
}