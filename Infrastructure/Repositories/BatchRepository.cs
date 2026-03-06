using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public partial class BatchRepository
    {
        /// <summary>
        /// Gets the specified batch id.
        /// </summary>
        /// <param name="batchId">The batch id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// Get operation
        /// </summary>
        public Batch Get(int batchId)
        {
            return Repository.Find(batch => batch.BatchId == batchId).FirstOrDefault();
        }

        /// <summary>
        /// Gets the specified batch id.
        /// </summary>
        /// <param name="batchId">The batch id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// Get operation
        /// </summary>
        public Batch Get(string batchId)
        {
            return
                Repository.Find(batch => batch.BatchId.ToString().Equals(batchId, StringComparison.CurrentCulture)).
                    FirstOrDefault();
        }

        /// <summary>
        /// Gets the batch by external id.
        /// </summary>
        /// <param name="batchExternalId">The batch external id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetBatchByExternalId operation
        /// </summary>
        public Batch GetBatchByExternalId(string batchExternalId)
        {
            return Repository.Find(batch => batch.ExternalId.Equals(batchExternalId, StringComparison.CurrentCulture)).FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique batch by suffix, for a given machine group.
        /// </summary>
        /// <param name="machineGroup">The id of the machine group.</param>
        /// <param name="batchSuffix">The suffix of a batch name.</param>
        /// <summary>
        /// GetBatchForMachineGroupBySuffix operation
        /// </summary>
        public Batch GetBatchForMachineGroupBySuffix(int machineGroupId, string batchSuffix)
        {
            return Repository.Find(batch => batch.Archived == null
                    && batch.ExternalId.EndsWith(batchSuffix)
                    && batch.Machine != null
                    && batch.Machine.MachineGroup != null
                    && batch.Machine.MachineGroup.MachineGroupId == machineGroupId).FirstOrDefault();
        }

        /// <summary>
        /// Gets the batch by machine id and external id.
        /// </summary>
        /// <param name="machineId">The machine id.</param>
        /// <param name="batchExternalId">The external batch id.</param>
        /// <summary>
        /// GetByExternalIdMachineId operation
        /// </summary>
        public Batch GetByExternalIdMachineId(int machineId, string batchExternalId)
        {
            return Repository.Find(batch => batch.MachineId == machineId && batch.ExternalId.Equals(batchExternalId, StringComparison.CurrentCulture) && batch.Archived == null).FirstOrDefault();
        }

        /// <summary>
        /// Gets the last batch by machine id.
        /// </summary>
        /// <param name="machineId">The machine id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetLastBatchByMachineId operation
        /// </summary>
        public Batch GetLastBatchByMachineId(int machineId)
        {
            return
                Repository
                .Find(batch => batch.MachineId == machineId && batch.Archived == null)
                .OrderByDescending(batch => batch.Created)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets all turnarounds by batch.
        /// </summary>
        /// <param name="batchId">The batch id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetAllTurnaroundsPreviouslyAssignedByBatch operation
        /// </summary>
        public IQueryable<Turnaround> GetAllTurnaroundsPreviouslyAssignedByBatch(int batchId)
        {
            var returnResult =
                 Repository.Find(batch => batch.BatchId == batchId).SelectMany(batch => batch.TurnaroundEvent)
                 .Where(te => te.Turnaround.TurnaroundEvent.Where(e => e.Batch != null && e.Batch.Machine.MachineType == te.Batch.Machine.MachineType).OrderByDescending(e => e.Created).FirstOrDefault().BatchId == batchId)
                 .Select(bte => bte.Turnaround).Distinct();
            return returnResult;
        }

        /// <summary>
        /// Gets all unpassed turnarounds by batch.
        /// </summary>
        /// <param name="batchId">The batch id.</param>
        /// <param name="eventTypeId">The event type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetAllUnpassedTurnaroundsByBatch operation
        /// </summary>
        public IList<Turnaround> GetAllUnpassedTurnaroundsByBatch(int? batchId, int eventTypeId)
        {
            IList<Turnaround> turnarounds = null;
            using (var context = new OperativeModelContainer())
            {
                turnarounds = context.opsapp_ReadAllUnpassedTurnaroundsByBatch(batchId.GetValueOrDefault()).ToList();
            }
            return turnarounds;
        }

        /// <summary>
        /// Gets all unpassed turnarounds by batch and eventtype.
        /// </summary>
        /// <param name="batchId">The batch id.</param>
        /// <param name="eventTypeId">The event type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetAllUnpassedTurnaroundsByBatchAndEventType operation
        /// </summary>
        public IList<Turnaround> GetAllUnpassedTurnaroundsByBatchAndEventType(int batchId, int eventTypeId)
        {
            using (var repository = new PathwayRepository())
            {
                return repository.DataManager.ExecuteQuery<Turnaround>((row, table, set) =>
                {
                    return new Turnaround
                    {
                        TurnaroundId = Convert.ToInt32(row["TurnaroundId"]),
                        ExternalId = Convert.ToInt32(row["ExternalId"]),
                        ServiceRequirementId = Convert.ToInt32(row["ServiceRequirementId"]),
                        ContainerMasterId = Convert.ToInt32(row["ContainerMasterId"]),
                        Expiry = Convert.ToDateTime(row["Expiry"]),
                        Created = Convert.ToDateTime(row["Created"])
                    };
                },
                "dbo.opsapp_ReadAllUnpassedTurnaroundsByBatchAndEvent",
                CommandType.StoredProcedure,
                new SqlParameter("@BatchId", batchId),
                new SqlParameter("@EventTypeId", eventTypeId)
                );
            }
        }

        /// <summary>
        /// Gets all unpassed turnarounds by batch.
        /// </summary>
        /// <param name="batchId">The batch id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetAllUnpassedTurnaroundsByBatch operation
        /// </summary>
        public IList<Turnaround> GetAllUnpassedTurnaroundsByBatch(int batchId)
        {
            {
                return repository.DataManager.ExecuteQuery<Turnaround>((row, table, set) =>
                {
                    return new Turnaround
                    {
                        TurnaroundId = Convert.ToInt32(row["TurnaroundId"]),
                        ExternalId = Convert.ToInt32(row["ExternalId"]),
                        ServiceRequirementId = Convert.ToInt32(row["ServiceRequirementId"]),
                        ContainerMasterId = Convert.ToInt32(row["ContainerMasterId"]),
                        Expiry = Convert.ToDateTime(row["Expiry"]),
                        Created = Convert.ToDateTime(row["Created"])

                    };
                },
                "dbo.opsapp_ReadAllUnpassedTurnaroundsByBatchRanked",
                CommandType.StoredProcedure,
                new SqlParameter("@BatchId", batchId)
                );
            }
        }

        /// <summary>
        /// Gets all available batchs from machine.
        /// </summary>
        /// <param name="machineId">The machine id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetAllAvailableBatchsFromMachine operation
        /// </summary>
        public IQueryable<Batch> GetAllAvailableBatchsFromMachine(int machineId)
        {
            return Repository.Find(batch => batch.MachineId == machineId
                                            &&
                                            batch.Created >
                                            DateTime.Parse(DateTime.UtcNow.ToShortDateString(), CultureInfo.CurrentCulture) &&
                                            batch.Archived == null);
        }

        /// <summary>
        /// Loads the last batchs.
        /// </summary>
        /// <param name="machineId">The machine id.</param>
        /// <param name="num">The num.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// LoadLastBatchs operation
        /// </summary>
        public IQueryable<Batch> LoadLastBatchs(int machineId, int num)
        {
            return
                Repository.Find(b => b.MachineId == machineId && b.Archived == null).OrderByDescending(b => b.Created).
                    Take(num);
        }

        /// <summary>
        /// Gets the batchs by machine.
        /// </summary>
        /// <param name="machineId">The machine id.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        /// <remarks></remarks>       
        /// <summary>
        /// GetBatchsByMachine operation
        /// </summary>
        public IQueryable<Batch> GetBatchsByMachine(int machineId, DateTime fromDate, DateTime toDate)
        {
            var dateTo = toDate.AddHours(23.99);

            return
               Repository.Find(
                   b =>
                   b.MachineId ==
                   machineId && b.Archived == null && b.Created >= fromDate && b.Created <= dateTo);
        }

        /// <summary>
        /// Reads the turnarounds by batch.
        /// </summary>
        /// <param name="batchId">The batch id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadTurnaroundsByBatch operation
        /// </summary>
        public IQueryable<Turnaround> ReadTurnaroundsByBatch(int batchId)
        {
            return Repository.Find(b => b.BatchId == batchId).SelectMany(b => b.TurnaroundEvent).Select(te => te.Turnaround).Distinct();
        }

        /// <summary>
        /// Reads all autoclave batches by machine.
        /// </summary>
        /// <param name="machineId">The machine id.</param>
        /// <param name="startDateTime">The start date time.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadAllAutoclaveBatchesByMachine operation
        /// </summary>
        public IQueryable<Batch> ReadAllAutoclaveBatchesByMachine(int machineId, DateTime startDateTime)
        {
            return Repository.Find(b => b.MachineId == machineId
                                        && b.Created > startDateTime
                                        && b.Archived == null)
                .OrderBy(b => b.Started)
                .ThenBy(b => b.Created);
        }

        /// <summary>
        /// Reads all autoclave test batches by machine.
        /// </summary>
        /// <param name="machineId">The machine id.</param>
        /// <returns></returns>
        /// <summary>
        /// ReadAutoclaveTestBatchesByMachine operation
        /// </summary>
        public IQueryable<Batch> ReadAutoclaveTestBatchesByMachine(int machineId)
        {
            return Repository.Find(b => b.MachineId == machineId
                                        && b.BatchCycle.IsChargeable == false
                                        && b.Archived == null
                                        && b.Started != null
                                        && (b.BatchStatusId == null || b.BatchStatusId == (int)BatchStatusIdentifier.InProgress))
                .OrderBy(b => b.Started)
                .ThenBy(b => b.Created);
        }

        /// <summary>
        /// Reads all started autoclave batches by facility
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadStartedBatchesByFacility operation
        /// </summary>
        public List<BatchData> ReadStartedBatchesByFacility(int facilityId)
        {
            var parameters = new Dictionary<string, object> { { "FacilityId", facilityId } };
            var commandContext = new OperativeModelContainer();
            var datacommand = DataCommandFactory.CreateCommand(commandContext, CommandType.StoredProcedure, "opsapp_ReadStartedBatchesByFacility", parameters);
            return datacommand.GetEntityList<BatchData>().ToList();
        }

        /// <summary>
        /// Reads all failed autoclave batches by facility
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadFailedBatchesByFacility operation
        /// </summary>
        public IQueryable<IBatch> ReadFailedBatchesByFacility(int facilityId)
        {
            var dt = DateTime.UtcNow.AddDays(-7);

            return Repository.Find(batch => batch.BatchStatusId == (int)BatchStatusIdentifier.Failed && batch.Archived == null && batch.Machine.FacilityId == facilityId && batch.Failed >= dt);

        }

        /// <summary>
        /// Loads the test batches.
        /// </summary>
        /// <param name="machineId">The machine id.</param>
        /// <summary>
        /// LoadTestBatches operation
        /// </summary>
        public IList<BatchData> LoadTestBatches(int machineId)
        {
            {
                var query =
                    from b in context.Batch
                    join bc in context.BatchCycle on b.BatchCycleId equals bc.BatchCycleId
                    join te in context.TurnaroundEvent on b.BatchId equals te.BatchId into batches
                    from set in batches.DefaultIfEmpty()
                    where bc.IsChargeable == false && b.MachineId == machineId && b.Started != null
                    && (b.BatchStatusId == null || b.BatchStatusId == (int)BatchStatusIdentifier.InProgress)
                    select new
                    {
                        Batch = b,
                        TurnarounEventBatchId = set == null ? 0 : set.BatchId
                    };

                var result =
                    from b in query
                    where b.TurnarounEventBatchId == 0
                    select new BatchData
                    {
                        ExternalId = b.Batch.ExternalId,
                        CycleTypeText = b.Batch.BatchCycle.Text,
                        Created = b.Batch.Created,
                        BatchId = b.Batch.BatchId
                    };
                return result.OrderBy(b => b.Created).ToList();
            }
        }
    }
}
