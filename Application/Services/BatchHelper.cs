using SynergyApplicationFrameworkApi.Application.DTOs.Batch;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// BatchHelper
    /// </summary>
    public class BatchHelper
    {
        /// <summary>
        /// Create operation
        /// </summary>
        public BatchCreatedDataContract Create(CreateBatchRequestDataContract request, bool batchMustNotExist = true, bool allowSameBatch = false)
        {
            var dataContract = new BatchCreatedDataContract();

            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                Batch batch = null;

                var batchRepository = BatchRepository.New(workUnit);
                var machineRepository = MachineRepository.New(workUnit);
                var machine = machineRepository.Get(request.MachineId);

                if (machine.Archived != null)
                {
                    dataContract.ErrorCode = (int)ErrorCodes.MachineArchived;
                    return dataContract;
                }

                if (string.IsNullOrEmpty(request.BatchName))
                {
                    request.BatchName = BatchName.GetNextBatchName(machine, request.FacilityId, request.CreateBatchTime);
                }
                else
                {
                    if (machine.MachineGroup != null)
                    {
                        string batchSuffix = request.BatchName.Replace(machine.BatchPrefix, "");
                        batch = batchRepository.GetBatchForMachineGroupBySuffix(machine.MachineGroup.MachineGroupId, batchSuffix);
                    }
                    else
                    {
                        batch = batchRepository.GetByExternalIdMachineId(request.MachineId, request.BatchName);
                    }
                }

                if (batch != null)
                {
                    var sameBatch = (allowSameBatch && request is ReassignBatchRequestDataContract rbdc && rbdc.BatchId == batch.BatchId);

                    if (!sameBatch && (batchMustNotExist || batch.MachineId != request.MachineId))
                    {
                        dataContract.ErrorCode = (int)ErrorCodes.BatchAlreadyExists;
                    }
                    else
                    {
                        dataContract.CycleName = batch.BatchCycle?.Text ?? string.Empty;
                        dataContract.BatchCycleId = batch.BatchCycleId ?? 0;
                        dataContract.BatchId = batch.BatchId;
                        dataContract.ExternalId = batch.ExternalId;
                    }
                }
                else
                {
                    var newBatch = BatchFactory.CreateEntity(workUnit,
                        externalId: request.BatchName,
                        created: DateTime.UtcNow,
                        machineId: request.MachineId,
                        createdUserId: request.UserId,
                        batchCycleId: request.BatchCycleId,
                        batchStatusId: (int)BatchStatusIdentifier.InProgress);
                    if (request.IsStartBatch)
                    {
                        newBatch.Started = request.StartBatchDate ?? DateTime.UtcNow;
                    }

                    batchRepository.Add(newBatch);
                    workUnit.Save();

                    dataContract.CycleName = newBatch.BatchCycle?.Text ?? string.Empty;
                    dataContract.BatchCycleId = newBatch.BatchCycleId ?? 0;
                    dataContract.BatchId = newBatch.BatchId;
                    dataContract.ExternalId = newBatch.ExternalId;
                    if (request.BatchCycleId != null && newBatch.BatchCycle.IsChargeable && newBatch.Machine.MachineTypeId == (int)MachineTypeIdentifier.Autoclave)
                    {
                        var associateReportRepository = BatchSterilisationTestReportRepository.New(workUnit);

                        using (var repository = new PathwayRepository())
                        {
                            var sterilisationTestReport = repository.Container.SterilisationTestReport
                                .Where(str => str.MachineId == newBatch.MachineId && str.ReportType == (int)SterilisationTestReportType.Daily &&
                                        (str.SterilisationTestReportStatusId == (int)SterilisationTestReportStatusTypeIdentifier.TestReviewed ||
                                         str.SterilisationTestReportStatusId == (int)SterilisationTestReportStatusTypeIdentifier.Completed))
                                .OrderByDescending(o => o.Created).FirstOrDefault();

                            if (sterilisationTestReport != null)
                            {
                                var batchSterilisationTestReport = BatchSterilisationTestReportFactory.CreateEntity(workUnit,
                                    batchId: newBatch.BatchId,
                                    sterilisationTestReportId: sterilisationTestReport.SterilisationTestReportId
                                );

                                associateReportRepository.Add(batchSterilisationTestReport);
                                associateReportRepository.Save();
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(request.BiLotNumber))
                    {
                        var biRepository = BiologicalIndicatorTestRepository.New(workUnit);

                        var b = BiologicalIndicatorTestFactory.CreateEntity(workUnit,
                            batchId: newBatch.BatchId,
                            testBiologicalIndicatorLotNumber: request.BiLotNumber,
                            biologicalIndicatorTestStatusId: (int)BiologicalIndicatorTestStatusIdentifier.Open,
                            pinRequestReasonId: request.PinReason,
                            testedUserId: request.UserId,
                            startDate: DateTime.UtcNow
                        );

                        biRepository.Add(b);
                        biRepository.Save();
                    }
                }
            }

            return dataContract;
        }

        /// <summary>
        /// Fail operation
        /// </summary>
        public void Fail(int batchid, FailureTypeIdentifier fti, int userId, string failureText = null)
        {
            {
                var batchRepository = BatchRepository.New(workUnit);
                var batch = batchRepository.Get(batchid);

                if (batch != null)
                {
                    batch.Failed = DateTime.UtcNow;
                    batch.BatchStatusId = (int)BatchStatusIdentifier.Failed;
                    batch.BatchReleasedUserId = userId;

                    foreach (var bi in batch.BiologicalIndicatorTest)
                    {
                        bi.BiologicalIndicatorTestStatusId = (int)BiologicalIndicatorTestStatusIdentifier.Archived;
                    }
                }

                var failedBatch = FailedBatchFactory.CreateEntity(workUnit, 0, batchid, userId, (byte)fti, DateTime.UtcNow, failureText);
                var failedBatchRepository = FailedBatchRepository.New(workUnit);

                failedBatchRepository.Add(failedBatch);
                workUnit.Save();
            }
        }

        /// <summary>
        /// GetExternalId operation
        /// </summary>
        public string GetExternalId(int newbatchId)
        {
            {
                var batchRepository = BatchRepository.New(workUnit);
                var batch = batchRepository.Get(newbatchId);

                return batch != null ? batch.ExternalId : string.Empty;
            }
        }

        /// <summary>
        /// Archive operation
        /// </summary>
        public void Archive(int batchId, int userId)
        {
            {
                var batchRepository = BatchRepository.New(workUnit);
                var batch = batchRepository.Get(batchId);

                if (batch != null)
                {
                    batch.ExternalId = "*" + batch.ExternalId;
                    batch.ArchivedUserId = userId;
                    batch.Archived = DateTime.UtcNow;
                    batch.BatchStatusId = (int)BatchStatusIdentifier.Archived;

                    batchRepository.Save();
                }
            }
        }

        /// <summary>
        /// SetBatchInProgress operation
        /// </summary>
        public void SetBatchInProgress(int batchId)
        {
            {
                var batchRepository = BatchRepository.New(workUnit);
                var batch = batchRepository.Get(batchId);

                if (batch != null)
                {
                    batch.Started = DateTime.UtcNow;

                    batchRepository.Save();
                    workUnit.Save();
                }
            }
        }

        /// <summary>
        /// UpdateBatchDecontaminationTasks operation
        /// </summary>
        public void UpdateBatchDecontaminationTasks(int batchId, int turnaroundId, int machineId, int userId)
        {
            {
                {
                    var turnaround = repository.Container.Turnaround.FirstOrDefault(t => t.TurnaroundId == turnaroundId);

                    if (turnaround != null)
                    {
                        var machineData =
                        (
                            from m in repository.Container.Machine.Where(m => m.MachineId == machineId)
                            join mt in repository.Container.MachineType on m.MachineTypeId equals mt.MachineTypeId
                            select mt
                        ).FirstOrDefault();

                        if (machineData != null)
                        {
                            var processingDecontaminationTasks = turnaround.ContainerMaster.ProcessingDecontaminationTasks.FirstOrDefault(de => de.DecontaminationTaskId == machineData.DecontaminationTaskId);
                            if (processingDecontaminationTasks != null)
                            {
                                var tasks = BatchDecontaminationTaskFactory.CreateEntity(workUnit,
                                         decontaminationTaskId: processingDecontaminationTasks.DecontaminationTaskId,
                                         batchId: batchId,
                                         turnaroundId: turnaroundId,
                                         userId: userId
                                     );
                                repository.Container.BatchDecontaminationTask.AddObject(tasks);
                                repository.Container.SaveChanges();
                            }
                        }
                    }
                }
            }
        }
    }
}