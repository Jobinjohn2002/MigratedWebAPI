using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyChargeListHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ChargeList concreteChargeList, ChargeList genericChargeList)
        {
            concreteChargeList.ChargeListId = genericChargeList.ChargeListId;
            concreteChargeList.ArchivedUserId = genericChargeList.ArchivedUserId;
            concreteChargeList.ChargeListCategoryId = genericChargeList.ChargeListCategoryId;
            concreteChargeList.CreatedUserId = genericChargeList.CreatedUserId;
            concreteChargeList.CustomerDefinitionId = genericChargeList.CustomerDefinitionId;
            concreteChargeList.Charge = genericChargeList.Charge;
            concreteChargeList.Created = genericChargeList.Created;
            concreteChargeList.Text = genericChargeList.Text;
            concreteChargeList.Archived = genericChargeList.Archived;
            concreteChargeList.LegacyFacilityOrigin = genericChargeList.LegacyFacilityOrigin;
            concreteChargeList.LegacyImported = genericChargeList.LegacyImported;
        }
    }
}