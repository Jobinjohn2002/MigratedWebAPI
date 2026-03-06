using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyItemRebuildListHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ItemRebuildList concreteItemRebuildList,
                                     ItemRebuildList genericItemRebuildList)
        {
            concreteItemRebuildList.ItemRebuildListId = genericItemRebuildList.ItemRebuildListId;
            concreteItemRebuildList.ContainerMasterId = genericItemRebuildList.ContainerMasterId;
            concreteItemRebuildList.LegacyFacilityOrigin = genericItemRebuildList.LegacyFacilityOrigin;
            concreteItemRebuildList.LegacyImported = genericItemRebuildList.LegacyImported;
        }
    }
}