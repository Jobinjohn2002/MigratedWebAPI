using System;
using Microsoft.Data.SqlClient;
using System.Linq;
using WorkflowDataContract = Pathway.Core.Services.DataContracts.WorkflowDataContract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public partial class WorkflowRepository
    {
        /// <summary>
        /// Gets the specified workflow id.
        /// </summary>
        /// <param name="workflowId">The workflow id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// Get operation
        /// </summary>
        public Workflow Get(int workflowId)
        {
            return Repository.Find(workflow => workflow.WorkflowId == workflowId).FirstOrDefault();
        }

        ///// <summary>
        ///// Get all of the workflow entries for this facility
        ///// </summary>
        ///// <param name="facilityId"></param>
        ///// <returns></returns>

        /// <summary>
        /// Reads the next events.
        /// </summary>
        /// <param name="fromEventType">Type of from event.</param>
        /// <param name="itemTypeId">The item type id.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="containerMasterId"></param>
        /// <param name="deliveryPointId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadNextEvents operation
        /// </summary>
        public IQueryable<EventType> ReadNextEvents(int? fromEventType, int? itemTypeId, int? facilityId, int? containerMasterId, int? deliveryPointId)
        {
            using (var repository = new PathwayRepository())
            {
                var workflows = repository.DataManager.ExecuteQuery((row, table, set) => new
                {
                    IsEnd = Convert.ToBoolean(row["IsEnd"]),
                    IsBestPractice = Convert.ToBoolean(row["IsBestPractice"]),
                    FacilityId = row["FacilityId"] is DBNull ? (int?)null : Convert.ToInt32(row["FacilityId"]),
                    ItemTypeId = Convert.ToInt32(row["ItemTypeId"]),
                    ForIndividualInstrumentTracking = Convert.ToBoolean(row["ForIndividualInstrumentTracking"]),
                    IsRequiredProof = Convert.ToBoolean(row["IsRequiredProof"]),
                    IsReleaseRequired = Convert.ToBoolean(row["IsReleaseRequired"]),
                    FromEventTypeID = row["FromEventTypeId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["FromEventTypeId"]),
                    FromEvent = row["FromEvent"] == DBNull.Value ? null : "" + row["FromEvent"],
                    NextEventTypeId = Convert.ToInt32(row["NextEventTypeId"]),
                    NextEvent = row["NextEvent"].ToString(),
                    WorkflowId = Convert.ToInt32(row["WorkflowId"])
                },
                    "dbo.Workflow_GetAllPossibleWorkflow",
                    CommandType.StoredProcedure,
                    new SqlParameter("FacilityId", facilityId),
                    new SqlParameter("ItemTypeId", itemTypeId),
                    new SqlParameter("ContainerMasterId", containerMasterId),
                    new SqlParameter("DeliveryPointId", deliveryPointId)
                );

                var nextEvents = workflows
                    .Where(w => w.FromEventTypeID == fromEventType)
                    .Select(w => w.NextEventTypeId)
                    .Distinct()
                    .ToList();

                if (fromEventType == (int)TurnAroundEventTypeIdentifier.AddedToTrolley || fromEventType == (int)TurnAroundEventTypeIdentifier.AddedToTransferNote || fromEventType == (int)TurnAroundEventTypeIdentifier.DeconStart)
                {
                    nextEvents.Add((int)TurnAroundEventTypeIdentifier.IntoQuarantine);
                }

                if (fromEventType == (int)TurnAroundEventTypeIdentifier.AddedToTrolley)
                {
                    nextEvents.Add((int)TurnAroundEventTypeIdentifier.Archived);
                }
                return ((OperativeModelContainer)_repository.UnitOfWork.Context).EventType.Where(et => nextEvents.Contains(et.EventTypeId));
            }
        }

        /// <summary>
        /// Reads the next events by category.
        /// </summary>
        /// <param name="fromEventType">Type of from event.</param>
        /// <param name="itemTypeId">The item type id.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="deliveryPointId"></param>
        /// <param name="category">The category.</param>
        /// <param name="containerMasterId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadNextEventsByCategory operation
        /// </summary>
        public IQueryable<EventType> ReadNextEventsByCategory(int? fromEventType, int? itemTypeId, int? facilityId, int? containerMasterId, int? deliveryPointId, EventTypeCategoryIdentifier category)
        {
            {
                var workflows = repository.DataManager.ExecuteQuery((row, table, set) => new
                {
                    IsEnd = Convert.ToBoolean(row["IsEnd"]),
                    IsBestPractice = Convert.ToBoolean(row["IsBestPractice"]),
                    FacilityId = row["FacilityId"] is DBNull ? (int?)null : Convert.ToInt32(row["FacilityId"]),
                    ItemTypeId = Convert.ToInt32(row["ItemTypeId"]),
                    ForIndividualInstrumentTracking = Convert.ToBoolean(row["ForIndividualInstrumentTracking"]),
                    IsRequiredProof = Convert.ToBoolean(row["IsRequiredProof"]),
                    IsReleaseRequired = Convert.ToBoolean(row["IsReleaseRequired"]),
                    FromEventTypeID = row["FromEventTypeId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["FromEventTypeId"]),
                    FromEvent = row["FromEvent"] == DBNull.Value ? null : "" + row["FromEvent"],
                    FromEventTypeCategoryId = row["FromEventTypeCategoryId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["FromEventTypeCategoryId"]),
                    NextEventTypeId = Convert.ToInt32(row["NextEventTypeId"]),
                    NextEvent = row["NextEvent"].ToString(),
                    NextEventTypeCategoryId = Convert.ToInt32(row["NextEventTypeCategoryId"]),
                    WorkflowId = Convert.ToInt32(row["WorkflowId"])
                },
                    "dbo.Workflow_GetAllPossibleWorkflow",
                    CommandType.StoredProcedure,
                    new SqlParameter("FacilityId", facilityId),
                    new SqlParameter("ItemTypeId", itemTypeId),
                    new SqlParameter("ContainerMasterId", containerMasterId),
                    new SqlParameter("DeliveryPointId", deliveryPointId)
                );

                var nextEvents = workflows
                    .Where(w => w.FromEventTypeID == fromEventType && w.NextEventTypeCategoryId == (int)category)
                    .Select(w => w.NextEventTypeId)
                    .Distinct();

                return ((OperativeModelContainer)_repository.UnitOfWork.Context).EventType.Where(et => nextEvents.Contains(et.EventTypeId));
            }
        }

        /// <summary>
        /// Reads the next event.
        /// </summary>
        /// <param name="lastWorkflowId">The last workflow id.</param>
        /// <param name="fromEventType">Type of from event.</param>
        /// <param name="itemTypeId">The item type id.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="containerMasterId"></param>
        /// <param name="deliveryPointId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadNextEvent operation
        /// </summary>
        public EventType ReadNextEvent(int? fromEventType, int? itemTypeId, int? facilityId, int? containerMasterId, int? deliveryPointId)
        {
            {
                var workflow = repository.DataManager.ExecuteQuery((row, table, set) => new
                {
                    WorkflowId = Convert.ToInt32(row["WorkflowId"])
                },
                    "dbo.Workflow_SuggestNextWorkflow",
                    CommandType.StoredProcedure,
                    new SqlParameter("FacilityId", facilityId),
                    new SqlParameter("FromEventTypeId", fromEventType),
                    new SqlParameter("ItemTypeId", itemTypeId),
                    new SqlParameter("ContainerMasterId", containerMasterId),
                    new SqlParameter("DeliveryPointId", deliveryPointId)
                );

                var workflowId = workflow.Any() ? (int?)workflow.First().WorkflowId : null;

                return workflowId == null ? null : repository.Container.Workflow.FirstOrDefault(wf => wf.WorkflowId == workflowId).EventTypeTo;
            }
        }

        /// <summary>
        /// Reads the next stock event.
        /// </summary>
        /// <param name="lastWorkflowId">The last workflow id.</param>
        /// <param name="fromEventType">Type of from event.</param>
        /// <param name="itemTypeId">The item type id.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="containerMasterId"></param>
        /// <param name="deliveryPointId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadNextStockEvent operation
        /// </summary>
        public EventType ReadNextStockEvent(int? lastWorkflowId, int? fromEventType, int? itemTypeId, int? parentItemTypeId, int? facilityId, int? containerMasterId, int? deliveryPointId)
        {
            if (lastWorkflowId != null)
            {
                var lastWorkflow = Get(lastWorkflowId.GetValueOrDefault());
                if (lastWorkflow.IsEnd)
                {
                    return null;
                }
            }

            {
                var workflow = repository.DataManager.ExecuteQuery((row, table, set) => new
                {
                    WorkflowId = Convert.ToInt32(row["WorkflowId"])
                },
                    "dbo.Workflow_SuggestNextWorkflow",
                    CommandType.StoredProcedure,
                    new SqlParameter("FacilityId", facilityId),
                    new SqlParameter("FromEventTypeId", fromEventType),
                    new SqlParameter("ItemTypeId", itemTypeId),
                    new SqlParameter("ContainerMasterId", containerMasterId),
                    new SqlParameter("DeliveryPointId", deliveryPointId)
                );

                var workflowId = workflow.Any() ? (int?)workflow.First().WorkflowId : null;

                return workflowId == null ? null : 
                    repository.Container.Workflow.Where(wf => wf.WorkflowId == workflowId && wf.IsStockLocation).Select(wf => wf.EventTypeTo).FirstOrDefault();
            }
        }

        /// <summary>
        /// Reads the workflow.
        /// </summary>
        /// <param name="fromEventTypeId">From event type id.</param>
        /// <param name="toEventTypeId">To event type id.</param>
        /// <param name="itemTypeId">The item type id.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="containerMasterId">The container master id.</param>
        /// <param name="deliveryPointId">The delivery point id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadWorkflow operation
        /// </summary>
        public Workflow ReadWorkflow(int? fromEventTypeId, int toEventTypeId, int? itemTypeId, int? facilityId, int? containerMasterId, int? deliveryPointId)
        {
            {
                var workflow = repository.DataManager.ExecuteQuery((row, table, set) => new
                {
                    IsEnd = Convert.ToBoolean(row["IsEnd"]),
                    IsBestPractice = Convert.ToBoolean(row["IsBestPractice"]),
                    ItemTypeId = Convert.ToInt32(row["ItemTypeId"]),
                    ForIndividualInstrumentTracking = Convert.ToBoolean(row["ForIndividualInstrumentTracking"]),
                    IsRequiredProof = Convert.ToBoolean(row["IsRequiredProof"]),
                    IsReleaseRequired = Convert.ToBoolean(row["IsReleaseRequired"]),
                    NextEventTypeId = Convert.ToInt32(row["NextEventTypeId"]),
                    NextEvent = row["NextEvent"].ToString(),
                    WorkflowId = Convert.ToInt32(row["WorkflowId"]),
                    Rank = Convert.ToInt32(row["Rank"]),
                },
                    "dbo.Workflow_GetWorkflowToApply",
                    CommandType.StoredProcedure,
                    new SqlParameter("FacilityId", facilityId),
                    new SqlParameter("FromEventTypeId", fromEventTypeId),
                    new SqlParameter("ToEventTypeId", toEventTypeId),
                    new SqlParameter("ItemTypeId", itemTypeId),
                    new SqlParameter("ContainerMasterId", containerMasterId),
                    new SqlParameter("DeliveryPointId", deliveryPointId)
                );

                var workflowId = workflow.Any() ? (int?)workflow.First().WorkflowId : null;

                return workflowId == null ? null : repository.Container.Workflow.FirstOrDefault(wf => wf.WorkflowId == workflowId);
            }
        }

        /// <summary>
        /// Reads all possible workflow.
        /// </summary>
        /// <param name="itemTypeId">The item type id.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="containerMasterId"></param>
        /// <param name="deliveryPointId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadAllPossibleWorkflow operation
        /// </summary>
        public IQueryable<StationType> ReadAllPossibleWorkflow(int? itemTypeId, int? facilityId, int? containerMasterId, int? deliveryPointId)
        {
            {
                var workflow = repository.DataManager.ExecuteQuery((row, table, set) => new
                {
                    IsEnd = Convert.ToBoolean(row["IsEnd"]),
                    IsBestPractice = Convert.ToBoolean(row["IsBestPractice"]),
                    FacilityId = row["FacilityId"] is DBNull ? (int?)null : Convert.ToInt32(row["FacilityId"]),
                    ItemTypeId = Convert.ToInt32(row["ItemTypeId"]),
                    ForIndividualInstrumentTracking = Convert.ToBoolean(row["ForIndividualInstrumentTracking"]),
                    IsRequiredProof = Convert.ToBoolean(row["IsRequiredProof"]),
                    IsReleaseRequired = Convert.ToBoolean(row["IsReleaseRequired"]),
                    NextEventTypeId = Convert.ToInt32(row["NextEventTypeId"]),
                    NextEvent = row["NextEvent"].ToString(),
                    WorkflowId = Convert.ToInt32(row["WorkflowId"])
                },
                    "dbo.Workflow_GetAllPossibleWorkflow",
                    CommandType.StoredProcedure,
                    new SqlParameter("FacilityId", facilityId),
                    new SqlParameter("ItemTypeId", itemTypeId),
                    new SqlParameter("ContainerMasterId", containerMasterId),
                    new SqlParameter("DeliveryPointId", deliveryPointId)
                );

                var workflowIds = workflow.Select(w => w.WorkflowId);

                var workflowId = workflow.Any() ? (int?)workflow.First().WorkflowId : null;

                return workflowId == null 
                    ? null 
                    : _repository.Find(wf => workflowIds.Contains(wf.WorkflowId))
                        .SelectMany(wf => wf.EventTypeTo.EventTypeStationTypes.Select(etst => etst.StationType))
                        .Distinct();
            }
        }

        /// <summary>
        /// Decides whather a turnaround can be ended.
        /// </summary>
        /// <param name="turnaroundId">TurnaroundId</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// CanTurnaroundBeEnded operation
        /// </summary>
        public bool CanTurnaroundBeEnded(int turnaroundId)
        {
            {
                var data = repository.DataManager.ExecuteQuery((row, table, set) => new
                {
                    CanEndTurnaround = Convert.ToBoolean(row["CanEndTurnaround"])
                },
                    "dbo.Workflow_CanTurnaroundBeEnded",
                    CommandType.StoredProcedure,
                    new SqlParameter("TurnaroundId", turnaroundId)
                );

                var firstOrDefault = data.FirstOrDefault();
                return firstOrDefault != null && firstOrDefault.CanEndTurnaround;
            }
        }

        /// <summary>
        /// GetOutOfQuarantineEvents operation
        /// </summary>
        public IQueryable<EventType> GetOutOfQuarantineEvents(int turnaroundId)
        {
            {
                var outOfQuarantineEvents = repository.DataManager.ExecuteQuery((row, table, set) => new
                {
                    NextEventTypeId = Convert.ToInt16(row["NextEventTypeId"]),
                },
                    "dbo.Workflow_GetOutOfQuarantineEvents",
                    CommandType.StoredProcedure,
                    new SqlParameter("TurnaroundId", turnaroundId)
                );

                var result = outOfQuarantineEvents.Select(a => a.NextEventTypeId);

                return ((OperativeModelContainer)_repository.UnitOfWork.Context).EventType.Where(et => result.Contains(et.EventTypeId));
            }
        }

        /// <summary>
        /// GetReRouteEvents operation
        /// </summary>
        public IQueryable<TurnaroundEventTypeDataContract> GetReRouteEvents(int turnaroundId)
        {
            {
                var events = repository.DataManager.ExecuteQuery((row, table, set) => new TurnaroundEventTypeDataContract
                {
                    EventTypeId = Convert.ToInt16(row["NextEventTypeId"]),
                    Name = row["NextEvent"].ToString(),
                    IsProcessEvent = true,
                    CategoryId = 1
                },
                    "dbo.Workflow_GetOutOfQuarantineEvents",
                    CommandType.StoredProcedure,
                    new SqlParameter("TurnaroundId", turnaroundId)
                );

                return events.AsQueryable();
            }
        }

        public IQueryable<Pathway.DataContracts.WorkflowDataContract> GetTransferNoteRerouteEvents(int turnaroundId)
        {
            {
                var events = repository.DataManager.ExecuteQuery((row, table, set) => new
                {
                    NextEventTypeId = Convert.ToInt16(row["NextEventTypeId"]),
                    EventType = row["NextEvent"].ToString(),
                    Rank = Convert.ToInt16(row["Rank"])
                },
                    "dbo.Workflow_GetTransferNoteRerouteEvents",
                    CommandType.StoredProcedure,
                    new SqlParameter("TurnaroundId", turnaroundId)
                );

                var result = events.Select(e => new Pathway.DataContracts.WorkflowDataContract
                {
                    NextEventTypeId = e.NextEventTypeId,
                    NextEvent = e.EventType,
                    Rank = e.Rank
                });

                return result.AsQueryable();
            }
        }

        struct GraphNode
        {
            public int From;
            public List<int> Children;
        }

        /// <summary>
        /// Works out if the end event can be reached from the start event in the workflow
        /// </summary>
        /// <param name="itemTypeId">TurnaroundId</param>
        /// <param name="startEventTypeId">TurnaroundId</param>
        /// <param name="endEventTypeId">TurnaroundId</param>
        /// <param name="ownerId">TurnaroundId</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// CheckEventTypeCanBeReached operation
        /// </summary>
        public bool CheckEventTypeCanBeReached(int itemTypeId, int startEventTypeId, int endEventTypeId, int facilityId, int containerMasterId, int deliveryPointId)
        {
            using (var repository = InstanceFactory.GetInstance<IPathwayRepository>())
            {
                var workflow = repository.DataManager.ExecuteQuery((row, table, set) => 
                new WorkflowDetail
                {
                    IsEnd = Convert.ToBoolean(row["IsEnd"]),
                    FromEventTypeId = Int32.TryParse(row["FromEventTypeId"].ToString(), out var tempVal) ? tempVal : (int?)null,
                    NextEventTypeId = Convert.ToInt32(row["NextEventTypeId"]),
                    NextEventTypeCategoryId = Convert.ToInt32(row["NextEventTypeCategoryId"]),
                    WorkflowId = Convert.ToInt32(row["WorkflowId"])
                },
                    StoredProcedureNames.Workflow_GetAllPossibleWorkflow,
                    CommandType.StoredProcedure,
                    new SqlParameter("FacilityId", facilityId),
                    new SqlParameter("ItemTypeId", itemTypeId),
                    new SqlParameter("ContainerMasterId", containerMasterId),
                    new SqlParameter("DeliveryPointId", deliveryPointId)
                );

                List<GraphNode> graph = workflow.Where(wf => wf.FromEventTypeId != null && wf.NextEventTypeCategoryId == (int)EventTypeCategoryIdentifier.Normal)
                    .GroupBy(wf => wf.FromEventTypeId)
                    .Select(group => new GraphNode{From = (int)group.Key, Children = group.Select(wf => wf.NextEventTypeId).ToList() }).ToList();
                GraphNode start = graph.SingleOrDefault(wf => wf.From == startEventTypeId);

                if (!start.Equals(default(GraphNode)))
                {
                    var visited = new HashSet<int>();
                    var stack = new Stack<GraphNode>();

                    stack.Push(start);

                    while (stack.Count != 0)
                    {
                        var current = stack.Pop();
                        if (!visited.Add(current.From))
                            continue;

                        var neighbours = current.Children.Where(ch => !visited.Contains(ch));

                        if (neighbours.Contains(endEventTypeId))
                        {
                            return true;
                        }

                        foreach (var neighbour in neighbours)
                        { 
                            if (graph.Exists(g => g.From == neighbour))
                            {
                                stack.Push(graph.Single(g => g.From == neighbour));
                            }
                        }
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Works out if the end event can be reached from the start event in the workflow
        /// </summary>
        /// <param name="itemTypeId">TurnaroundId</param>
        /// <param name="startEventTypeId">TurnaroundId</param>
        /// <param name="endEventTypeId">TurnaroundId</param>
        /// <param name="ownerId">TurnaroundId</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// CheckEventTypeCanBeReached operation
        /// </summary>
        public bool CheckEventTypeCanBeReached(int itemTypeId, int startEventTypeId, IEnumerable<int> endEventTypeIds, int facilityId, int containerMasterId, int deliveryPointId)
        {
            {
                var workflow = repository.DataManager.ExecuteQuery((row, table, set) =>
                new WorkflowDetail
                {
                    IsEnd = Convert.ToBoolean(row["IsEnd"]),
                    FromEventTypeId = Int32.TryParse(row["FromEventTypeId"].ToString(), out var tempVal) ? tempVal : (int?)null,
                    NextEventTypeId = Convert.ToInt32(row["NextEventTypeId"]),
                    NextEventTypeCategoryId = Convert.ToInt32(row["NextEventTypeCategoryId"]),
                    WorkflowId = Convert.ToInt32(row["WorkflowId"])
                },
                    StoredProcedureNames.Workflow_GetAllPossibleWorkflow,
                    CommandType.StoredProcedure,
                    new SqlParameter("FacilityId", facilityId),
                    new SqlParameter("ItemTypeId", itemTypeId),
                    new SqlParameter("ContainerMasterId", containerMasterId),
                    new SqlParameter("DeliveryPointId", deliveryPointId)
                );

                List<GraphNode> graph = workflow.Where(wf => wf.FromEventTypeId != null && wf.NextEventTypeCategoryId == (int)EventTypeCategoryIdentifier.Normal)
                    .GroupBy(wf => wf.FromEventTypeId)
                    .Select(group => new GraphNode { From = (int)group.Key, Children = group.Select(wf => wf.NextEventTypeId).ToList() }).ToList();
                GraphNode start = graph.SingleOrDefault(wf => wf.From == startEventTypeId);

                var visited = new HashSet<int>();
                var stack = new Stack<GraphNode>();

                stack.Push(start);

                while (stack.Count != 0)
                {
                    var current = stack.Pop();
                    if (!visited.Add(current.From))
                        continue;

                    var neighbours = current.Children.Where(ch => !visited.Contains(ch));

                    if (neighbours.Intersect(endEventTypeIds).Count() > 0)
                    {
                        return true;
                    }

                    foreach (var neighbour in neighbours)
                    {
                        if (graph.Exists(g => g.From == neighbour))
                        {
                            stack.Push(graph.Single(g => g.From == neighbour));
                        }
                    }
                }

                return false;
            }
        }
    }
}