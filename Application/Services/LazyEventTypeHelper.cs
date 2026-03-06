using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyEventTypeHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(EventType concreteEventType, EventType genericEventType)
        {
            concreteEventType.EventTypeId = genericEventType.EventTypeId;
            concreteEventType.EventTypeCategoryId = genericEventType.EventTypeCategoryId;
            concreteEventType.Text = genericEventType.Text;
            concreteEventType.ProcessEvent = genericEventType.ProcessEvent;
            concreteEventType.IsStartEvent = genericEventType.IsStartEvent;
            concreteEventType.IsEndEvent = genericEventType.IsEndEvent;
            concreteEventType.IsArchiveEvent = genericEventType.IsArchiveEvent;
            concreteEventType.DisplayOrder = genericEventType.DisplayOrder;
            concreteEventType.ProcessLocation = genericEventType.ProcessLocation;
            concreteEventType.LegacyFacilityOrigin = genericEventType.LegacyFacilityOrigin;
            concreteEventType.LegacyImported = genericEventType.LegacyImported;
        }
    }
}