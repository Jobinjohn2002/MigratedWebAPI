using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyStationTypeCategoryHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(StationTypeCategory concreteStationTypeCategory,
                                     StationTypeCategory genericStationTypeCategory)
        {
            concreteStationTypeCategory.StationTypeCategoryId = genericStationTypeCategory.StationTypeCategoryId;
            concreteStationTypeCategory.Text = genericStationTypeCategory.Text;
            concreteStationTypeCategory.DispalyOrder = genericStationTypeCategory.DispalyOrder;
            concreteStationTypeCategory.LegacyFacilityOrigin = genericStationTypeCategory.LegacyFacilityOrigin;
            concreteStationTypeCategory.LegacyImported = genericStationTypeCategory.LegacyImported;
        }
    }
}