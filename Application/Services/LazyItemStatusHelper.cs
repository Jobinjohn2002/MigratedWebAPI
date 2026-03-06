using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyItemStatusHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ItemStatus concreteItemStatus, ItemStatus genericItemStatus)
        {
            concreteItemStatus.ItemStatusId = genericItemStatus.ItemStatusId;
            concreteItemStatus.Text = genericItemStatus.Text;
            concreteItemStatus.LegacyFacilityOrigin = genericItemStatus.LegacyFacilityOrigin;
            concreteItemStatus.LegacyImported = genericItemStatus.LegacyImported;
        }
    }
}