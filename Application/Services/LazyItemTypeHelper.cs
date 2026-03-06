using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyItemTypeHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ItemType concreteItemType, ItemType genericItemType)
        {
            concreteItemType.ItemTypeId = genericItemType.ItemTypeId;
            concreteItemType.ArchivedUserId = genericItemType.ArchivedUserId;
            concreteItemType.LabelTypeId = genericItemType.LabelTypeId;
            concreteItemType.ParentItemTypeId = genericItemType.ParentItemTypeId;
            concreteItemType.Text = genericItemType.Text;
            concreteItemType.Archived = genericItemType.Archived;
            concreteItemType.ItemTypeFeatures = genericItemType.ItemTypeFeatures;
            concreteItemType.Trackable = genericItemType.Trackable;
            concreteItemType.OwnWorkflow = genericItemType.OwnWorkflow;
            concreteItemType.AllowFinancialSetup = genericItemType.AllowFinancialSetup;
            concreteItemType.LegacyId = genericItemType.LegacyId;
            concreteItemType.LegacyFacilityOrigin = genericItemType.LegacyFacilityOrigin;
            concreteItemType.LegacyImported = genericItemType.LegacyImported;
        }
    }
}