using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyIndividualInstrumentTrackingEventHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(IndividualInstrumentTrackingEvent concreteIndividualInstrumentTrackingEvent,
                                     IndividualInstrumentTrackingEvent genericIndividualInstrumentTrackingEvent)
        {
            concreteIndividualInstrumentTrackingEvent.IndividualInstrumentTrackingEventId =
                genericIndividualInstrumentTrackingEvent.IndividualInstrumentTrackingEventId;
            concreteIndividualInstrumentTrackingEvent.IndividualInstrumentTrackingEventTypeId =
                genericIndividualInstrumentTrackingEvent.IndividualInstrumentTrackingEventTypeId;
            concreteIndividualInstrumentTrackingEvent.ItemInstanceId =
                genericIndividualInstrumentTrackingEvent.ItemInstanceId;
            concreteIndividualInstrumentTrackingEvent.TurnaroundEventId =
                genericIndividualInstrumentTrackingEvent.TurnaroundEventId;
            concreteIndividualInstrumentTrackingEvent.Created = genericIndividualInstrumentTrackingEvent.Created;
        }
    }
}