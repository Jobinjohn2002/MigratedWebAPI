using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyEventTypeCategoryHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(EventTypeCategory concreteEventTypeCategory,
                                     EventTypeCategory genericEventTypeCategory)
        {
            concreteEventTypeCategory.EventTypeCategoryId = genericEventTypeCategory.EventTypeCategoryId;
            concreteEventTypeCategory.Category = genericEventTypeCategory.Category;
            concreteEventTypeCategory.LegacyFacilityOrigin = genericEventTypeCategory.LegacyFacilityOrigin;
            concreteEventTypeCategory.LegacyImported = genericEventTypeCategory.LegacyImported;
        }
    }
}