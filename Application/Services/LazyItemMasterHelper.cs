using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyItemMasterHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ItemMaster concreteItemMaster, ItemMaster genericItemMaster)
        {
            concreteItemMaster.ItemMasterId = genericItemMaster.ItemMasterId;
            concreteItemMaster.BatchCycleId = genericItemMaster.BatchCycleId;
            concreteItemMaster.CategoryId = genericItemMaster.CategoryId;
            concreteItemMaster.ComplexityId = genericItemMaster.ComplexityId;
            concreteItemMaster.CreatedUserId = genericItemMaster.CreatedUserId;
            concreteItemMaster.ItemMasterDefinitionId = genericItemMaster.ItemMasterDefinitionId;
            concreteItemMaster.ItemStatusId = genericItemMaster.ItemStatusId;
            concreteItemMaster.ItemTypeId = genericItemMaster.ItemTypeId;
            concreteItemMaster.SpecialityId = genericItemMaster.SpecialityId;
            concreteItemMaster.ExternalId = genericItemMaster.ExternalId;
            concreteItemMaster.Text = genericItemMaster.Text;
            concreteItemMaster.Revision = genericItemMaster.Revision;
            concreteItemMaster.Created = genericItemMaster.Created;
            concreteItemMaster.ManufacturersReference = genericItemMaster.ManufacturersReference;
            concreteItemMaster.ComponentPartCount = genericItemMaster.ComponentPartCount;
            concreteItemMaster.Trackable = genericItemMaster.Trackable;
            concreteItemMaster.IndependentQualityAssuranceCheck = genericItemMaster.IndependentQualityAssuranceCheck;
            concreteItemMaster.LegacyId = genericItemMaster.LegacyId;
            concreteItemMaster.LegacyFacilityOrigin = genericItemMaster.LegacyFacilityOrigin;
            concreteItemMaster.LegacyImported = genericItemMaster.LegacyImported;
            concreteItemMaster.FinanceId = genericItemMaster.FinanceId;
            concreteItemMaster.PinRequestReasonId = genericItemMaster.PinRequestReasonId;
        }
    }
}