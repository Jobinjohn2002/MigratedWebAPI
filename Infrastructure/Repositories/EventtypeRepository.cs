using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public partial class EventTypeRepository
    {
        /// <summary>
        /// Gets the specified event type id.
        /// </summary>
        /// <param name="eventTypeId">The event type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// Get operation
        /// </summary>
        public EventType Get(int eventTypeId)
        {
            return Repository.Find(et => et.EventTypeId == eventTypeId).FirstOrDefault();
        }

        /// <summary>
        /// Reads the failure types.
        /// </summary>
        /// <param name="eventTypeId">The event type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadFailureTypes operation
        /// </summary>
        public IQueryable<FailureType> ReadFailureTypes(int eventTypeId, int? taskId = null)
        {
            return Repository.Find(et => et.EventTypeId == eventTypeId).SelectMany(et => et.FailureTypeEventType.Where(ftet => ftet.TaskId.Equals(taskId)).Select(ftet => ftet.FailureType));
        }

        /// <summary>
        /// Reads the type of the preferred station.
        /// </summary>
        /// <param name="eventTypeId">The event type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadPreferredStationType operation
        /// </summary>
        public StationType ReadPreferredStationType(int eventTypeId)
        {
            var test = Repository.Find(et => et.EventTypeId == eventTypeId);
            var eventTypeStationType = test.SelectMany(et => et.StationTypes).FirstOrDefault();
            return eventTypeStationType;
        }

        /// <summary>
        /// Reads the type of the preferred event type by station & event type.
        /// </summary>
        /// <param name="stationTypeId">The station type id.</param>
        /// <param name="eventTypeId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadPreferredEventTypeByStationTypeAndEventType operation
        /// </summary>
        public IEventType ReadPreferredEventTypeByStationTypeAndEventType(short stationTypeId,int? eventTypeId) 
        {  
            var eventTypeStationTypeRepository = EventTypeStationTypeRepository.New(Repository.UnitOfWork);
            var eventType = eventTypeStationTypeRepository.Repository.Find(etst => etst.StationTypeId == stationTypeId && etst.Preferred && etst.EventTypeId == eventTypeId).FirstOrDefault();
            return Repository.Find(et => et.EventTypeId == eventType.EventTypeId).FirstOrDefault(); 
        }

        /// <summary>
        /// Reads the event types by category.
        /// </summary>
        /// <param name="eventTypeCategoryId">The event type category id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadEventTypesByCategory operation
        /// </summary>
        public IQueryable<EventType> ReadEventTypesByCategory(int eventTypeCategoryId)
        {
			return Repository.Find(et => et.EventTypeCategoryId == eventTypeCategoryId);
        }
    }
}