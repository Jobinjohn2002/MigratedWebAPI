using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyEventTypeStationTypeHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(EventTypeStationType concreteEventTypeStationType,
                                     EventTypeStationType genericEventTypeStationType)
        {
            concreteEventTypeStationType.EventTypeStationTypeId = genericEventTypeStationType.EventTypeStationTypeId;
            concreteEventTypeStationType.EventTypeId = genericEventTypeStationType.EventTypeId;
            concreteEventTypeStationType.StationTypeId = genericEventTypeStationType.StationTypeId;
            concreteEventTypeStationType.Preferred = genericEventTypeStationType.Preferred;
        }
    }
}