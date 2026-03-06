using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyStationTypeHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(StationType concreteStationType, StationType genericStationType)
        {
            concreteStationType.StationTypeId = genericStationType.StationTypeId;
            concreteStationType.StationTypeCategoryId = genericStationType.StationTypeCategoryId;
            concreteStationType.Text = genericStationType.Text;
            concreteStationType.DisplayOrder = genericStationType.DisplayOrder;
            concreteStationType.LegacyFacilityOrigin = genericStationType.LegacyFacilityOrigin;
            concreteStationType.LegacyImported = genericStationType.LegacyImported;
            concreteStationType.AllowAssignPPM = genericStationType.AllowAssignPPM;			
			concreteStationType.AllowAssignNotes = genericStationType.AllowAssignNotes;
        }
    }
}