using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyIndividualInstrumentTrackingEventTypeHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(
            IndividualInstrumentTrackingEventType concreteIndividualInstrumentTrackingEventType,
            IndividualInstrumentTrackingEventType genericIndividualInstrumentTrackingEventType)
        {
            concreteIndividualInstrumentTrackingEventType.IndividualInstrumentTrackingEventTypeId =
                genericIndividualInstrumentTrackingEventType.IndividualInstrumentTrackingEventTypeId;
            concreteIndividualInstrumentTrackingEventType.Text = genericIndividualInstrumentTrackingEventType.Text;
        }
    }
}