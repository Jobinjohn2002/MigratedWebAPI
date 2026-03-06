using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    internal class WorkFlowCache
    {
        private readonly List<WorkFlowCacheEntry> workFlowIdCache = new List<WorkFlowCacheEntry>();
        private readonly List<WorkFlowCacheEntry> workFlowNextEventCache = new List<WorkFlowCacheEntry>();

        public int? GetWorkFlowId(int? fromEventTypeId, int toEventTypeId, int? itemTypeId, int? facilityId, int? containerMasterId, int? deliveryPointId)
        {
            var entry = workFlowIdCache.FirstOrDefault(w => w.FromEventTypeId == fromEventTypeId && w.ToEventTypeId == toEventTypeId && w.ItemTypeId == itemTypeId &&
                                                          w.FacilityId == facilityId && w.ContainerMasterId == containerMasterId && w.DeliveryPointId == deliveryPointId);

            if (entry != null)
            {
                return entry?.WorkflowId;
            }
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var workflowRepository = WorkflowRepository.New(workUnit);

                var nextWorkflow = workflowRepository.ReadWorkflow(fromEventTypeId, toEventTypeId, itemTypeId, facilityId, containerMasterId, deliveryPointId);

                if (nextWorkflow != null)
                {
                    workFlowIdCache.Add(new WorkFlowCacheEntry
                    {
                        FromEventTypeId = fromEventTypeId,
                        ToEventTypeId = toEventTypeId,
                        ItemTypeId = itemTypeId,
                        FacilityId = facilityId,
                        ContainerMasterId = containerMasterId,
                        DeliveryPointId = deliveryPointId,
                        WorkflowId = nextWorkflow.WorkflowId,
                    });

                    return nextWorkflow.WorkflowId;
                }
            }

            return null;
        }

        /// <summary>
        /// GetNextEventId operation
        /// </summary>
        public WorkFlowCacheEntry GetNextEventId(int? fromEventTypeId, int? itemTypeId, int? facilityId, int? containerMasterId, int? deliveryPointId)
        {
            var entry = workFlowNextEventCache.FirstOrDefault(w => w.FromEventTypeId == fromEventTypeId && w.ItemTypeId == itemTypeId &&
                                                              w.FacilityId == facilityId && w.ContainerMasterId == containerMasterId && w.DeliveryPointId == deliveryPointId);

            if (entry != null)
            {
                return entry;
            }
            {
                var workflowRepository = WorkflowRepository.New(workUnit);

                var nextEvent = workflowRepository.ReadNextEvent(fromEventTypeId, itemTypeId, facilityId, containerMasterId, deliveryPointId);

                if (nextEvent != null)
                {
                    var wcf = new WorkFlowCacheEntry
                    {
                        FromEventTypeId = fromEventTypeId,
                        ToEventTypeId = nextEvent.EventTypeId,
                        ToEventText = nextEvent.Text,
                        ItemTypeId = itemTypeId,
                        FacilityId = facilityId,
                        ContainerMasterId = containerMasterId,
                        DeliveryPointId = deliveryPointId,
                    };

                    workFlowNextEventCache.Add(wcf);

                    return wcf;
                }
            }

            return null;
        }
    }

    class WorkFlowCacheEntry
    {
        public int? FromEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets ToEventTypeId
        /// </summary>
        public int ToEventTypeId { get; set; }

        /// <summary>
        /// Gets or sets ToEventText
        /// </summary>
        public string ToEventText { get; set; }

        public int? ItemTypeId { get; set; }
        public int? FacilityId { get; set; }
        public int? ContainerMasterId { get; set; }
        public int? DeliveryPointId { get; set; }
        public int? WorkflowId { get; set; }
    }

    internal class FacilityCache
    {
        private readonly List<FacilityCacheEntry> facilityCache = new List<FacilityCacheEntry>();

        /// <summary>
        /// GetText operation
        /// </summary>
        public string GetText(int facilityId)
        {
            var entry = facilityCache.FirstOrDefault(f => f.FacilityId == facilityId);

            if (entry != null)
            {
                return entry?.Text;
            }
            {
                var facilityRepository = FacilityRepository.New(workUnit);

                var facility = facilityRepository.Get((short)facilityId);

                if (facility != null)
                {
                    facilityCache.Add(new FacilityCacheEntry
                    {
                        FacilityId = facility.FacilityId,
                        Text = facility.Text,
                    });

                    return facility.Text;
                }
            }

            return null;
        }
    }

    internal class FacilityCacheEntry
    {
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }

        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
    }
}
