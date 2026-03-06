using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyStationHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Station concreteStation, Station genericStation)
        {
            concreteStation.StationId = genericStation.StationId;
            concreteStation.ArchivedUserId = genericStation.ArchivedUserId;
            concreteStation.FacilityId = genericStation.FacilityId;
            concreteStation.StationTypeId = genericStation.StationTypeId;
            concreteStation.NTLogon = genericStation.NTLogon;
            concreteStation.Text = genericStation.Text;
            concreteStation.Archived = genericStation.Archived;
            concreteStation.Culture = genericStation.Culture;
            concreteStation.ShowDirectoratesAtDispatch = genericStation.ShowDirectoratesAtDispatch;
            concreteStation.ShowReleaseBatches = genericStation.ShowReleaseBatches;
            concreteStation.ShowPrioritisation = genericStation.ShowPrioritisation;
            concreteStation.LegacyId = genericStation.LegacyId;
            concreteStation.LegacyFacilityOrigin = genericStation.LegacyFacilityOrigin;
            concreteStation.LegacyImported = genericStation.LegacyImported;
            concreteStation.PinRequestReasonId = genericStation.PinRequestReasonId == null || genericStation.PinRequestReasonId == 0 ? null : genericStation.PinRequestReasonId;
            concreteStation.LocationId = genericStation.LocationId;
        }
    }
}