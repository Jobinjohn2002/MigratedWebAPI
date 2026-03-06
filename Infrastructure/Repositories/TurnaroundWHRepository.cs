using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    public partial class TurnaroundWHRepository
    {
        /// <summary>
        /// Get operation
        /// </summary>
        public TurnaroundWH Get(int turnaroundWHId)
        {
            return Repository.Find(turnaroundWh => turnaroundWh.TurnaroundWHId == turnaroundWHId).FirstOrDefault();
        }

        /// <summary>
        /// GetByTurnaround operation
        /// </summary>
        public TurnaroundWH GetByTurnaround(int turnaroundId)
        {
            return Repository.Find(turnaroundWh => turnaroundWh.TurnaroundId == turnaroundId).FirstOrDefault();
        }

        /// <summary>
        /// Used to populate Priority Screens in Operative
        /// </summary>
        /// <summary>
        /// ReadAwaitingEventByStation operation
        /// </summary>
        public IList<opsapp_ReadAwaitingEventsByStationType_Result> ReadAwaitingEventByStation(int toEventTypeId, int stationId, short facilityId, int stationTypeId)
        {
            IList<opsapp_ReadAwaitingEventsByStationType_Result> turnaroundWH = null;
            using (var context = new OperativeModelContainer())
            {
                var parameters = new Dictionary<string, object>();
                parameters.Add("nextEventTypeId", toEventTypeId);
                parameters.Add("facilityId", facilityId);
                parameters.Add("stationId", stationId);
                parameters.Add("stationTypeId", stationTypeId);

                var datacommand = DataCommandFactory.CreateCommand(context, CommandType.StoredProcedure,
                                                                "opsapp_ReadAwaitingEventsByStation", parameters);

                turnaroundWH = datacommand.GetEntityList<opsapp_ReadAwaitingEventsByStationType_Result>().Where(x => (ItemTypeIdentifier)x.ContainerMasterBaseItemTypeId != ItemTypeIdentifier.BatchTag &&
                        (ItemTypeIdentifier)x.ContainerMasterBaseItemTypeId != ItemTypeIdentifier.BaseCarriage &&
                        (ItemTypeIdentifier)x.ContainerMasterBaseItemTypeId != ItemTypeIdentifier.ProcessTag &&
                        (ItemTypeIdentifier)x.ContainerMasterBaseItemTypeId != ItemTypeIdentifier.Trolley).ToList();
            }

            return turnaroundWH;
        }

        /// <summary>
        /// Used to populate Priority Screens in Operative
        /// </summary>
        /// <summary>
        /// ReadAwaitingEventByStationType operation
        /// </summary>
        public IList<opsapp_ReadAwaitingEventsByStationType_Result> ReadAwaitingEventByStationType(int stationTypeId, short facilityId, int stationId)
        {
            IList<opsapp_ReadAwaitingEventsByStationType_Result> turnaroundWh = null;

            {
                turnaroundWh = context.opsapp_ReadAwaitingEventsByStationType(stationTypeId, stationId, facilityId)
                    .Where(x => (ItemTypeIdentifier)x.ContainerMasterBaseItemTypeId != ItemTypeIdentifier.BatchTag &&
                        (ItemTypeIdentifier)x.ContainerMasterBaseItemTypeId != ItemTypeIdentifier.BaseCarriage &&
                        (ItemTypeIdentifier)x.ContainerMasterBaseItemTypeId != ItemTypeIdentifier.ProcessTag &&
                        (ItemTypeIdentifier)x.ContainerMasterBaseItemTypeId != ItemTypeIdentifier.Trolley).ToList();
            }

            return turnaroundWh;
        }

        /// <summary>
        /// Reads all the current events that are processing events in a facility
        /// </summary>
        /// <summary>
        /// ReadEventsByFacility operation
        /// </summary>
        public IQueryable<TurnaroundWH> ReadEventsByFacility(short facilityId)
        {
            return Repository.Find(turnaroundWh => turnaroundWh.FacilityId == facilityId);
        }

        /// <summary>
        /// ReadByFacility operation
        /// </summary>
        public IList<TurnaroundWH> ReadByFacility(short facilityId)
        {
            return Repository.
                Find(turnaroundWh => turnaroundWh.FacilityId == facilityId && turnaroundWh.LastEventType.ProcessEvent).
                ToList().
                Select(i => new TurnaroundWH
                {
                    BatchId = i.BatchId,
                    ContainerInstanceId = i.ContainerInstanceId,
                    ContainerMasterBaseItemType = i.ContainerMasterBaseItemType,
                    ContainerMasterBaseItemTypeId = i.ContainerMasterBaseItemTypeId,
                    ContainerMasterDefinitionId = i.ContainerMasterDefinitionId,
                    ContainerMasterExternalId = i.ContainerMasterExternalId,
                    ContainerMasterItemType = i.ContainerMasterItemType,
                    ContainerMasterItemTypeId = i.ContainerMasterItemTypeId,
                    ContainerMasterName = i.ContainerMasterName,
                    ContainerMasterId = i.ContainerMasterId,
                    CustomerName = i.CustomerName,
                    CustomerId = i.CustomerId,
                    DeliveryNoteExternalId = i.DeliveryNoteExternalId,
                    DeliveryNoteId = i.DeliveryNoteId,
                    DeliveryPointName = i.DeliveryPointName,
                    DeliveryPointId = i.DeliveryPointId,
                    Expiry = i.Expiry,
                    FacilityName = i.FacilityName,
                    FacilityId = i.FacilityId,
                    HasChildren = i.HasChildren,
                    LastEventName = i.LastEventName,
                    LastEventTime = i.LastEventTime,
                    LastEventTypeId = i.LastEventTypeId,
                    LastEventId = i.LastEventId,
                    NextEventName = i.NextEventName,
                    NextEventTypeId = i.NextEventTypeId,
                    DisplayOrder = i.LastEventType.DisplayOrder,
                    ParentTurnaroundId = i.ParentTurnaroundId,
                    ServiceRequirementName = i.ServiceRequirementName,
                    ServiceRequirementId = i.ServiceRequirementId,
                    StartEventTime = i.StartEventTime,
                    TurnaroundExternalId = i.TurnaroundExternalId,
                    TurnaroundId = i.TurnaroundId,
                    TurnaroundWHId = i.TurnaroundWHId,
                }).
                OrderBy(t => t.Expiry).
                ToList();
        }
    }
}