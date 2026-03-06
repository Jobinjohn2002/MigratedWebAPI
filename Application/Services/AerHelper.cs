using SynergyApplicationFrameworkApi.Application.DTOs.Scan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// AerHelper
    /// </summary>
    public class AerHelper : BaseHelper
    {
        public AerHelper(SynergyTrakData data) : base(data) { }

        #region public methods

        /// <summary>
        /// GetAersForStation operation
        /// </summary>
        public List<AerDataContract> GetAersForStation()
        {
            using (var unitOfWork = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var failureEventTypes = GetFailureEventTypes(unitOfWork, Data.FacilityId);

                return GetAerData(Data.StationId.Value, null, failureEventTypes);
            }
        }

        /// <summary>
        /// GetAerForStation operation
        /// </summary>
        public AerDataContract GetAerForStation(MachineIdRequestDataContract request)
        {
            {
                var failureEventTypes = GetFailureEventTypes(unitOfWork, request.FacilityId);

                return GetAerData(Data.StationId.Value, request.MachineId, failureEventTypes).FirstOrDefault();
            }
        }

        /// <summary>
        /// IsAerRunning operation
        /// </summary>
        public bool IsAerRunning(Machine aer)
        {
            var status = GetStatusForAer(aer);

            return status == AerStatus.RunningDisinfectionCycle
                || status == AerStatus.RunningTestCycle
                || status == AerStatus.Washing;

        }

        /// <summary>
        /// ChangeDetergent operation
        /// </summary>
        public ChangeDetergentResultIdentifier ChangeDetergent(EndoscopyChangeDetergentRequest endoscopyChangeDetergentRequest)
        {
            ChangeDetergentResultIdentifier result = ChangeDetergentResultIdentifier.Success;

            try
            {
                using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                {
                    var machineId = endoscopyChangeDetergentRequest?.EndoscopyChangeDetergentDetails?.FirstOrDefault()?.MachineId;
                    if (!machineId.HasValue)
                    {
                        return ChangeDetergentResultIdentifier.UnknownFailure;
                    }

                    var machineRepository = MachineRepository.New(workUnit);
                    var machine = machineRepository.Get(machineId.Value);
                    if (machine == null)
                    {
                        return ChangeDetergentResultIdentifier.UnknownFailure;
                    }
                    if (IsAerRunning(machine))
                    {
                        return ChangeDetergentResultIdentifier.AerRunningFailure;
                    }
                    if ((machine.MachineGroup != null && machine.MachineGroup.Machine.Any(IsAerRunning)))
                    {
                        return ChangeDetergentResultIdentifier.MachineGroupAerRunningFailure;
                    }

                    var machineDetergentRepository = MachineDetergentRepository.New(workUnit);

                    foreach (var details in endoscopyChangeDetergentRequest.EndoscopyChangeDetergentDetails)
                    {
                        if (!details.MachineDetergentId.HasValue)
                        {
                            MachineDetergent newRecord = MachineDetergentFactory.CreateEntity(workUnit,
                                machineId: details.MachineId,
                                detergentInformation: details.DetergentInformation,
                                batchInformation: details.BatchInformation,
                                userId: endoscopyChangeDetergentRequest.UserId,
                                validFrom: DateTime.UtcNow
                            );

                            machineDetergentRepository.Add(newRecord);
                        }
                        else if (details.Archived)
                        {
                            var machineDetergent = machineDetergentRepository.Get(details.MachineDetergentId.Value);
                            machineDetergent.Archived = DateTime.UtcNow;
                        }
                    }

                    machineDetergentRepository.Save();
                }
            }
            catch(Exception ex)
            {
                result = ChangeDetergentResultIdentifier.UnknownFailure;
            }

            return result;
        }

        /// <summary>
        /// AssignEndoscopeToAer operation
        /// </summary>
        public ScanAssetDynamicReply<AerDataContract> AssignEndoscopeToAer(AssignEndoscopeToAerRequestDataContract request)
        {
            ScanAssetDynamicReply<AerDataContract> taskResult = new ScanAssetDynamicReply<AerDataContract>();

            ScanDetailsBatchRequestDataContract scanDetails = new ScanDetailsBatchRequestDataContract
            {
                ApplyToBatch = true,
                ApplyEvent = true,
                StationId = request.StationId,
                FacilityId = request.FacilityId,
                UserId = request.UserId,
                ExternalId = request.ExternalId,
                MachineId = request.MachineId,
                StationTypeId = request.StationTypeId.HasValue ? request.StationTypeId.Value : 0,
                StationLocationId = request.LocationId,
                InstanceId = request.InstanceId,
                BatchName = request.NewBatchName,
                PinReason = request.PinReasonId,
                Events = new List<ScanEventDataContract>
                {
                    new ScanEventDataContract
                    {
                        EventType = (int)TurnAroundEventTypeIdentifier.AssignedToAer
                    }
                },
                IsNetworkPrinting = request.IsNetworkPrinting,
                LaserPrinter = request.LaserPrinter,
                LabelPrinter = request.LabelPrinter,
                IgnoreNotesWarningsAndDecon = request.IgnoreNotesWarningsAndDecon
            };

            var mk3Helper = new SynergyTrakHelperMk3(Data, true);
            var aerStatus = GetStatusForAer(request.MachineId);

            if (aerStatus == AerStatus.Loading || aerStatus == AerStatus.Ready)
            {
                mk3Helper.Scan(scanDetails, taskResult);
            }
            else
            {
                taskResult.ErrorCode = (int)ErrorCodes.AerNotAvailable;
            }

            var aerDC = GetAerForStation(new MachineIdRequestDataContract()
            {
                MachineId = request.MachineId,
                FacilityId = request.FacilityId
            });

            taskResult.Value = aerDC;

            return taskResult;
        }

        /// <summary>
        /// RemoveEndoscopeFromAer operation
        /// </summary>
        public ScanAssetDynamicReply<AerDataContract> RemoveEndoscopeFromAer(AssignEndoscopeToAerRequestDataContract request)
        {
            var mk3Helper = new SynergyTrakHelperMk3(Data, true);

            var scanDetails = new ScanDetails
            {
                ApplyToBatch = true,
                ApplyEvent = true,
                StationId = request.StationId,
                FacilityId = request.FacilityId,
                UserId = request.UserId,
                InstanceId = request.InstanceId,
                MachineId = request.MachineId,
                StationTypeId = request.StationTypeId.HasValue ? request.StationTypeId.Value : 0,
                StationLocationId = request.LocationId,
                IsRemoveFromParent = true,
                PinReason = request.PinReasonId,
                Events = new List<ScanEventDataContract>
                {
                    new ScanEventDataContract
                    {
                        EventType = (int)TurnAroundEventTypeIdentifier.RemovedFromAer
                    }
                },
                IsNetworkPrinting = request.IsNetworkPrinting,
                LaserPrinter = request.LaserPrinter,
                LabelPrinter = request.LabelPrinter
            };

            ScanAssetDynamicReply<AerDataContract> taskResult = new ScanAssetDynamicReply<AerDataContract>();

            mk3Helper.Scan(scanDetails, taskResult);

            taskResult.Value = GetAerForStation(new MachineIdRequestDataContract()
            {
                MachineId = request.MachineId,
                FacilityId = request.FacilityId
            });

            return taskResult;
        }

        /// <summary>
        /// StartWash operation
        /// </summary>
        public ScanAssetDataContract StartWash(StartAerRequestDataContract request)
        {
            ScanAssetDataContract result = new ScanAssetDataContract();

            {
                var mk3Helper = new SynergyTrakHelperMk3(Data, true);
                var batchRepository = BatchRepository.New(workUnit);

                var hasDetergent = AerHasDetergent(request.MachineId, workUnit);
                var aer = GetAerForStation(new MachineIdRequestDataContract()
                {
                    MachineId = request.MachineId,
                    FacilityId = request.FacilityId
                });
                var lastBatch = batchRepository.GetLastBatchByMachineId(request.MachineId);

                if (aer.Status == AerStatus.OutOfService)
                {
                    result.ErrorCode = (int)ErrorCodes.AerOutOfService;
                }
                else if (!hasDetergent)
                {
                    result.ErrorCode = (int)ErrorCodes.AerOutOfDetergent;
                }
                else if (lastBatch == null || lastBatch.BatchStatusId != (int)BatchStatusIdentifier.InProgress)
                {
                    result.ErrorCode = (int)ErrorCodes.BatchDoesNotExist;
                }
                else if (lastBatch.Started != null || lastBatch.CurrentlyAssignedTurnarounds == null || !lastBatch.CurrentlyAssignedTurnarounds.Any())
                {
                    result.ErrorCode = (int)ErrorCodes.AerBatchAlreadyStarted;
                }
                else
                {
                    lastBatch.Started = DateTime.UtcNow;
                    var turnaround = lastBatch.CurrentlyAssignedTurnarounds.First();

                    result = new ScanAssetDataContract();

                    var scanDetails = new ScanDetails
                    {
                        ApplyToBatch = true,
                        ApplyEvent = true,
                        StationId = request.StationId,
                        FacilityId = request.FacilityId,
                        UserId = request.UserId,
                        MachineId = request.MachineId,
                        TurnaroundId = turnaround.TurnaroundId,
                        BatchId = lastBatch.BatchId,
                        StationTypeId = request.StationTypeId.HasValue ? request.StationTypeId.Value : 0,
                        PinReason = request.PinReasonId,
                        Events = new List<ScanEventDataContract>
                        {
                            new ScanEventDataContract
                            {
                                EventType = (int)TurnAroundEventTypeIdentifier.AerStart,
                                BatchId = lastBatch.BatchId
                            }
                        },
                        IsNetworkPrinting = request.IsNetworkPrinting,
                        LaserPrinter = request.LaserPrinter,
                        LabelPrinter = request.LabelPrinter
                    };

                    mk3Helper.Scan(scanDetails, result);

                    if (result.ErrorCode != null)
                    {
                        return result;
                    }
                }

                workUnit.Save();
            }

            return result;
        }

        /// <summary>
        /// SetAerBatchStatus operation
        /// </summary>
        public ScanAssetDataContract SetAerBatchStatus(SetAerBatchStatusDataContract request)
        {
            var result = new ScanAssetDataContract();
            var notes = new List<NoteDataContract>();

            {
                var eventToApply = TurnAroundEventTypeIdentifier.AerPassed;

                if (request.FailureTypeId.HasValue)
                {
                    eventToApply = TurnAroundEventTypeIdentifier.AerFailed;
                }

                var status = GetStatusForAer(request.MachineId);
                if (status != AerStatus.Washing)
                {
                    result.ErrorCode = (int)ErrorCodes.InvalidRequest;
                    return result;
                }

                var batchRepository = BatchRepository.New(workUnit);
                var batch = batchRepository.GetLastBatchByMachineId(request.MachineId);

                if (batch == null)
                {
                    result.ErrorCode = (int)ErrorCodes.BatchDoesNotExist;
                    return result;
                }

                if (batch.CurrentlyAssignedTurnarounds.Any())
                {
                    for (int i = 0; i < batch.CurrentlyAssignedTurnarounds.Count(); i++)
                    {
                        var turnaround = batch.CurrentlyAssignedTurnarounds.ElementAt(i);
                        var turnaroundNotes = turnaround.ContainerMaster.ContainerMasterNote
                           .Where(c => c.ContainerMasterNoteStationType.Any(e => e.EventTypeId == (int)TurnAroundEventTypeIdentifier.AerPassed)).Select(x => new NoteDataContract
                           {
                               ContainerInstancePrimaryId = turnaround.ContainerInstance.PrimaryId,
                               ContainerMasterName = turnaround.ContainerMaster.Text,
                               Id = x.ContainerMasterNoteId,
                               TurnaroundId = turnaround.TurnaroundId,
                               Text = x.Text,
                               Type = x.ContainerMasterNoteTypeId
                           }).ToList();
                        notes.AddRange(turnaroundNotes);

                        if (i == 0)
                        {
                            var scanDetails = new ScanDetails
                            {
                                BatchId = batch.BatchId,
                                ApplyToBatch = true,
                                ApplyEvent = request.GetNotesFirst == true ? false : true,
                                StationId = request.StationId,
                                StationTypeId = request.StationTypeId,
                                StationLocationId = request.StationLocationId,
                                FacilityId = request.FacilityId,
                                IgnoreNotesWarningsAndDecon = request.GetNotesFirst == true ? false : true,
                                IgnorePlannedMaintenance = true,
                                UserId = request.UserId,
                                TurnaroundId = turnaround.TurnaroundId,
                                PinReason = request.PinReasonId,
                                Events = new List<ScanEventDataContract>
                            {
                                new ScanEventDataContract
                                {
                                    EventType = (int)eventToApply
                                }
                            },
                                IsNetworkPrinting = request.IsNetworkPrinting,
                                LaserPrinter = request.LaserPrinter,
                                LabelPrinter = request.LabelPrinter
                            };

                            var mk3Helper = new SynergyTrakHelperMk3(Data, true);
                            mk3Helper.Scan(scanDetails, result);

                            if (result.ErrorCode != null && result.ErrorCode != (int)ErrorCodes.NoCurrentTurnaround)
                            {
                                return result;
                            }
                            result.PmQuarantined = new List<KeyValueDataContract>();
                            result.PmWarned = new List<KeyValueDataContract>();
                        }

                        if (request.GetNotesFirst != true)
                        {
                            var quarantineScanDetails = new ScanDetails
                            {
                                BatchId = batch.BatchId,
                                ApplyToBatch = false,
                                ApplyEvent = true,
                                StationId = request.StationId,
                                StationTypeId = request.StationTypeId,
                                StationLocationId = request.StationLocationId,
                                FacilityId = request.FacilityId,
                                UserId = request.UserId,
                                TurnaroundId = turnaround.TurnaroundId,
                                PinReason = request.PinReasonId,
                                Events = new List<ScanEventDataContract>
                            {
                                new ScanEventDataContract
                                {
                                    EventType = (int)eventToApply
                                }
                            },
                                IsNetworkPrinting = request.IsNetworkPrinting,
                                LaserPrinter = request.LaserPrinter,
                                LabelPrinter = request.LabelPrinter
                            };
                            PlannedMaintenance plannedMaintenance = new PlannedMaintenance(Data);
                            ScanAssetDataContract quarantineScanAssetDataContract = new ScanAssetDataContract
                            {
                                StartTurnaroundEventId = turnaround.StartEventId,
                                FacilityId = request.FacilityId,
                                DeliveryPtId = turnaround.DeliveryPointId,
                                UserId = request.UserId,
                                TurnaroundId = turnaround.TurnaroundId,
                                PinReasonId = request.PinReasonId,
                                StationId = request.StationId ?? 0,
                                StationTypeId = request.StationTypeId,
                                BatchId = batch.BatchId,
                                LocationId = request.StationLocationId,
                                LastProcessEventTypeId = TurnAroundEventTypeIdentifier.AerPassed,
                                Asset = new AssetDetailsDataContract
                                {
                                    ContainerInstanceId = turnaround.ContainerInstanceId,
                                    ContainerInstancePrimaryId = turnaround.ContainerInstancePrimaryId,
                                    ContainerMasterId = turnaround.ContainerMasterId,
                                    ItemTypeId = turnaround.ContainerMaster?.ItemTypeId ?? 0
                                },
                                Expiry = turnaround.Expiry,
                                TurnaroundEvents = new List<TurnaroundEventDataContract>(),
                            };
                            plannedMaintenance.CheckPlannedMaintenance(quarantineScanAssetDataContract, quarantineScanDetails);
                            if (quarantineScanAssetDataContract.PmQuarantined != null)
                            {
                                quarantineScanAssetDataContract.LastProcessEventId = (int)TurnAroundEventTypeIdentifier.IntoQuarantine;
                                foreach (var item in quarantineScanAssetDataContract.PmQuarantined)
                                {
                                    var turnaroundEventId = quarantineScanAssetDataContract.TurnaroundEvents.LastOrDefault(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoQuarantine).TurnaroundEventId;
                                    var notificationEngineHelper = new NotificationEngineHelper();

                                    var thisTurnaroundEventNotificationsFired = notificationEngineHelper.ProcessNotifications(quarantineScanAssetDataContract, quarantineScanDetails, turnaroundEventId);
                                    if (result.NotificationTypesFired == null)
                                    {
                                        result.NotificationTypesFired = thisTurnaroundEventNotificationsFired;
                                    }
                                    else
                                    {
                                        result.NotificationTypesFired.AddRange(thisTurnaroundEventNotificationsFired);
                                    }
                                    var childToAddReportTo = result.ChildItems.SingleOrDefault(x => x.TurnaroundId == quarantineScanAssetDataContract.TurnaroundId);
                                    if (childToAddReportTo != null)
                                    {
                                        if (childToAddReportTo.Reports == null)
                                        {
                                            childToAddReportTo.Reports = quarantineScanAssetDataContract.Reports;
                                        }
                                        else
                                        {
                                            childToAddReportTo.Reports.AddRange(quarantineScanAssetDataContract.Reports);
                                        }
                                    }

                                    result.PmQuarantined.Add(item);
                                }
                            }
                            if (quarantineScanAssetDataContract.PmWarned != null)
                            {
                                foreach (var item in quarantineScanAssetDataContract.PmWarned)
                                {
                                    result.PmWarned.Add(item);
                                }
                            }
                        }
                    }
                }
                var utcNow = DateTime.UtcNow;
                if (eventToApply == TurnAroundEventTypeIdentifier.AerFailed)
                {
                    batch.BatchStatusId = (int)BatchStatusIdentifier.Failed;
                    batch.Failed = utcNow;
                    batch.FailedUserId = request.UserId;

                    batch.FailedBatch.Add(
                        FailedBatchFactory.CreateEntity(workUnit,
                            createdUserId: request.UserId,
                            failureTypeId: request.FailureTypeId.Value,
                            created: utcNow,
                            text: request.FailureText
                        )
                    );
                }
                else
                {
                    batch.BatchStatusId = (int)BatchStatusIdentifier.Passed;
                    batch.BatchReleasedUserId = request.UserId;
                    batch.DateChecked = utcNow;
                }
                if (request.GetNotesFirst == true)
                {
                    result.ContainerMasterNotes = notes;
                }
                else
                {
                    workUnit.Save();
                }

            }

            return result;
        }

        /// <summary>
        /// GetNextBatchExternalId operation
        /// </summary>
        public string GetNextBatchExternalId(CreateBatchRequestDataContract request)
        {
            {
                var machineRepo = MachineRepository.New(workUnit);
                var machine = machineRepo.Get(request.MachineId);

                return BatchName.GetNextBatchName(machine, request.FacilityId, request.CreateBatchTime);
            }
        }

        /// <summary>
        /// GetMachineDetergentDetails operation
        /// </summary>
        public AerDetergentDetails GetMachineDetergentDetails(MachineIdRequestDataContract request)
        {
            var detergentDetailsDC = new AerDetergentDetails();

            {
                var machineRepository = MachineRepository.New(workUnit);
                var machine = machineRepository.Get(request.MachineId);

                detergentDetailsDC.MachineGroupName = machine.MachineGroup?.Text;
                detergentDetailsDC.DetergentDetails = GetDetergentForMachine(machine, workUnit);
            }

            return detergentDetailsDC;
        }

        /// <summary>
        /// StartAerMaintenanceCycle operation
        /// </summary>
        public BaseReplyDataContract StartAerMaintenanceCycle(AerCycleRequest request)
        {
            {
                var batchRepository = BatchRepository.New(workUnit);

                var batch = batchRepository.GetLastBatchByMachineId(request.MachineId);
                if (batch?.BatchStatusId == (int)BatchStatusIdentifier.InProgress)
                {
                    if (batch.Started != null || batch.CurrentlyAssignedTurnarounds.Any())
                    {
                        return new BaseReplyDataContract
                        {
                            ErrorCode = (int)ErrorCodes.AerBatchAlreadyStarted
                        };
                    }
                    else
                    {
                        var batchDataAdapter = DataAdapterFactory.GetBatchDataAdapter(workUnit);
                        batchDataAdapter.ArchiveBatch(batch.BatchId, request.UserId);
                    }
                }
            }

            var aerStatus = GetStatusForAer(request.MachineId);
            if (aerStatus != AerStatus.Ready)
            {
                return new BaseReplyDataContract
                {
                    ErrorCode = (int)ErrorCodes.InvalidRequest
                };
            }

            BatchHelper batchHelper = new BatchHelper();
            CreateBatchRequestDataContract createBatchDC = new CreateBatchRequestDataContract()
            {
                MachineId = request.MachineId,
                UserId = request.UserId,
                BatchCycleId = (int)request.CycleType,
                BatchName = request.BatchExternalId,
                FacilityId = request.FacilityId,
                StationId = request.StationId
            };

            var newBatch = batchHelper.Create(createBatchDC, true);

            if (newBatch.ErrorCode != null)
            {
                return new BaseReplyDataContract
                {
                    ErrorCode = newBatch.ErrorCode
                };
            }

            {
                var batchRepository = BatchRepository.New(workUnit);

                var batch = batchRepository.Get(newBatch.BatchId);

                batch.Started = DateTime.UtcNow;

                workUnit.Save();
            }

            return new BaseReplyDataContract();
        }

        /// <summary>
        /// EndAerMaintenanceCycle operation
        /// </summary>
        public BaseReplyDataContract EndAerMaintenanceCycle(AerCycleRequest request)
        {

            if (request.CycleType != BatchCycleTypeIdentifier.AERDisinfection &&
                request.CycleType != BatchCycleTypeIdentifier.AERTest)
            {
                return new BaseReplyDataContract
                {
                    ErrorCode = (int)ErrorCodes.InvalidRequest
                };
            }

            var isDisinfection = request.CycleType == BatchCycleTypeIdentifier.AERDisinfection;

            var aerStatus = GetStatusForAer(request.MachineId);
            if (
                (isDisinfection && aerStatus != AerStatus.RunningDisinfectionCycle)
                || (!isDisinfection && aerStatus != AerStatus.RunningTestCycle)
                )//can't end a maintenance cycle if it isn't running.
            {
                return new BaseReplyDataContract
                {
                    ErrorCode = (int)ErrorCodes.InvalidRequest
                };
            }

            {
                var batchRepository = BatchRepository.New(workUnit);

                var machinesLastBatch = batchRepository.GetLastBatchByMachineId(request.MachineId);
                if (machinesLastBatch?.BatchStatusId != (int)BatchStatusIdentifier.InProgress)
                {
                    return new BaseReplyDataContract
                    {
                        ErrorCode = (int)ErrorCodes.BatchDoesNotExist
                    };
                }

                var utcNow = DateTime.UtcNow;
                if (!string.IsNullOrEmpty(request.BatchExternalId))
                {

                    var machineRepository = MachineRepository.New(workUnit);
                    var machine = machineRepository.Get(request.MachineId);
                    if (machine == null)
                    {
                        return new BaseReplyDataContract { ErrorCode = (int)ErrorCodes.InvalidRequest };
                    }

                    var machineGroupId = machine.MachineGroup?.MachineGroupId;
                    Batch newBatch;
                    if (machineGroupId.HasValue)
                    {
                        var batchSuffix = request.BatchExternalId.Replace($"{machine.BatchPrefix}-", string.Empty);
                        newBatch = batchRepository.GetBatchForMachineGroupBySuffix(machineGroupId.Value, batchSuffix);
                    }
                    else
                    {
                        newBatch = batchRepository.GetByExternalIdMachineId(request.MachineId, request.BatchExternalId);
                    }

                    if (newBatch == null)
                    {
                        machinesLastBatch.ExternalId = request.BatchExternalId;
                    }
                    else if (newBatch.BatchId == machinesLastBatch.BatchId)
                    {
                    }
                    else
                    {
                        return new BaseReplyDataContract { ErrorCode = (int)ErrorCodes.BatchAlreadyExists };
                    }

                }

                if (request.Failed)
                {
                    machinesLastBatch.BatchStatusId = (int)BatchStatusIdentifier.Failed;
                    machinesLastBatch.Failed = utcNow;
                    machinesLastBatch.FailedUserId = request.UserId;

                    machinesLastBatch.FailedBatch.Add(
                        FailedBatchFactory.CreateEntity(workUnit,
                            createdUserId: request.UserId,
                            failureTypeId: isDisinfection ? (byte)FailureTypeIdentifier.AerDisinfectionFailure : (byte)FailureTypeIdentifier.AerTestFailure,
                            created: utcNow,
                            text: request.FailText
                        )
                    );
                }
                else
                {
                    machinesLastBatch.BatchStatusId = (int)BatchStatusIdentifier.Passed;
                    machinesLastBatch.DateChecked = utcNow;
                    machinesLastBatch.BatchReleasedUserId = request.UserId;
                }

                workUnit.Save();
            }

            return new BaseReplyDataContract();
        }

        /// <summary>
        /// ChangeCycleNumber operation
        /// </summary>
        public BaseReplyDataContract ChangeCycleNumber(ChangeCycleNumberRequestDataContract request)
        {
            BaseReplyDataContract result = new BaseReplyDataContract();
            ScanAssetDataContract taskResult = new ScanAssetDataContract();

            {
                var batchHelper = new BatchHelper();
                var mk3Helper = new SynergyTrakHelperMk3(Data, true);
                var batchRepository = BatchRepository.New(workUnit);
                var machineRepository = MachineRepository.New(workUnit);

                var machine = machineRepository.Get(request.MachineId);

                var lastBatch = batchRepository.GetLastBatchByMachineId(request.MachineId);

                CreateBatchRequestDataContract createBatchDC = new CreateBatchRequestDataContract()
                {
                    MachineId = lastBatch.MachineId.Value,
                    UserId = request.UserId,
                    BatchCycleId = (int)BatchCycleTypeIdentifier.AERStandard,
                    BatchName = request.NewCycleNumber,
                    FacilityId = request.FacilityId,
                    StationId = request.StationId,
                    IsStartBatch = request.BatchIsStarted,
                    StartBatchDate = lastBatch.Started
                };

                var newBatch = batchHelper.Create(createBatchDC);

                if (newBatch.ErrorCode == null)
                {
                    foreach (var turnaround in lastBatch.CurrentlyAssignedTurnarounds)
                    {
                        var scanDetails = new ScanDetails
                        {
                            ApplyToBatch = true,
                            ApplyEvent = true,
                            StationId = request.StationId,
                            FacilityId = request.FacilityId,
                            UserId = request.UserId,
                            MachineId = lastBatch.MachineId,
                            TurnaroundId = turnaround.TurnaroundId,
                            BatchId = newBatch.BatchId,
                            StationTypeId = request.StationTypeId,
                            StationLocationId = turnaround.TurnaroundEvent.Where(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.AssignedToAer).Last().LocationId.Value,
                            Events = new List<ScanEventDataContract>
                            {
                                new ScanEventDataContract
                                {
                                    EventType = (int)TurnAroundEventTypeIdentifier.ChangedBatch,
                                    BatchId = newBatch.BatchId
                                }
                            },
                            LaserPrinter = request.LaserPrinter,
                            LabelPrinter = request.LabelPrinter
                        };

                        mk3Helper.Scan(scanDetails, taskResult);
                    }

                    batchHelper.Archive(lastBatch.BatchId, request.UserId);
                }
                else
                {
                    result.ErrorCode = newBatch.ErrorCode;
                }

                workUnit.Save();
            }

            return result;
        }

        public ErrorCodes? CheckCanSetAerOutOfService(Machine aer)
        {

            if (aer.Archived.HasValue)
            {
                return ErrorCodes.InvalidRequest;
            }

            var aerStatus = GetStatusForAer(aer);

            if (aerStatus != AerStatus.Ready)
            {
                return ErrorCodes.InvalidRequest;
            }

            return null;
        }

        /// <summary>
        /// GetDetergentForMachine operation
        /// </summary>
        public List<MachineDetergentDataContract> GetDetergentForMachine(Machine machine, IUnitOfWork workUnit)
        {
            var machineDetergentRepository = MachineDetergentRepository.New(workUnit);

            if (machine.MachineGroup != null)
            {
                return machineDetergentRepository.Repository.Find(md => md.Machine.MachineGroup != null && md.Archived == null && md.Machine.MachineGroup.MachineGroupId == machine.MachineGroup.MachineGroupId).ToList()
                    .Select(md => ConvertToMachineDetergentDataContractCollection(md)).ToList();
            }
            else
            {
                return machineDetergentRepository.Repository.Find(md => md.MachineId == machine.MachineId && md.Archived == null).ToList()
                    .Select(md => ConvertToMachineDetergentDataContractCollection(md)).ToList();
            }
        }

        /// <summary>
        /// AerHasDetergent operation
        /// </summary>
        public bool AerHasDetergent(int machineId, IUnitOfWork workUnit)
        {
            var machineRepository = MachineRepository.New(workUnit);
            var machine = machineRepository.Get(machineId);

            var detergents = GetDetergentForMachine(machine, workUnit);

            return detergents.Any();
        }

        /// <summary>
        /// GetStatusForAer operation
        /// </summary>
        public AerStatus GetStatusForAer(int machineId)
        {
            {
                var machineRepository = MachineRepository.New(workUnit);
                var machine = machineRepository.Get(machineId);

                return GetStatusForAer(machine);
            }
        }

        /// <summary>
        /// GetStatusForAer operation
        /// </summary>
        public AerStatus GetStatusForAer(Machine aer)
        {
            var latestMachineEventTypeId = aer.MachineEvent.OrderByDescending(e => e.Created).FirstOrDefault()?.MachineEventTypeId;
            var currentBatchHasTurnaroundsAssigned = aer.CurrentInProgressBatch?.CurrentlyAssignedTurnarounds.Any() ?? false;

            return GetStatusForAer(latestMachineEventTypeId, aer.CurrentInProgressBatch != null, aer.CurrentInProgressBatch?.Started, currentBatchHasTurnaroundsAssigned, aer.CurrentInProgressBatch?.BatchCycleId);
        }

        #endregion

        #region private methods

        private List<AerDataContract> GetAerData(int stationId, int? machineId, List<DataValueDataContract> failureEventTypes)
        {
            using (var context = new OperativeModelContainer())
            {
                var data = context.opsapp_GetAerData(DateTime.UtcNow, stationId, machineId).ToList();

                var result = new List<AerDataContract>();

                foreach (var d in data)
                {
                    if (!result.Any(r => r.MachineId == d.MachineId))
                    {
                        result.Add(new AerDataContract
                        {
                            FailureTypes = failureEventTypes,

                            MachineId = d.MachineId,
                            BatchPrefix = d.BatchPrefix,
                            Name = d.MachineText,
                            RunningTime = d.RunningTime,
                            ReadOnly = d.ReadOnly,

                            BatchId = d.CurrentlyInProgressBatchId,
                            CycleNumber = d.CurrentlyInProgressBatchExternalId,
                            Started = d.CurrentlyInProgressBatchStarted != null ? DateTime.SpecifyKind(d.CurrentlyInProgressBatchStarted.Value, DateTimeKind.Utc) : (DateTime?)null,

                            Status = GetStatusForAer(
                                d.MachineEventTypeId,
                                d.CurrentlyInProgressBatchId != null,
                                d.CurrentlyInProgressBatchStarted,
                                d.CurrentlyInProgressBatchHasCurrentlyAssignedTurnarounds ?? false,
                                d.CurrentlyInProgressBatchCycleId),

                            DisinfectionCycleOverdue = d.DisinfectionOverdue.Value,

                            Shelves = data.Where(a => a.MachineId == d.MachineId).GroupBy(a => a.LocationId).Select(a => new AerShelfLocationDataContract()
                            {
                                LocationId = a.Key,
                                Description = a.FirstOrDefault().LocationDescription,
                                Text = a.FirstOrDefault().LocationText,
                                Endoscopes = data.Where(b => b.LocationId == a.Key && b.ContainerInstanceId != null).Select(c => new EndoscopeDataContract()
                                {
                                    ContainerInstanceId = c.ContainerInstanceId,
                                    ContainerInstancePrimaryId = c.ContainerInstancePrimaryId,
                                    Linear1DBarcodeId = c.ContainerInstanceLinear1dBarcodeId,
                                    Datamatrix2DBarcodeId = c.ContainerInstanceDatamatrix2dBarcodeId,
                                    ContainerMasterName = c.ContainerMasterText,
                                    DateAddedToAer = c.AssignedToAerEventCreated != null ? DateTime.SpecifyKind(c.AssignedToAerEventCreated.Value, DateTimeKind.Utc) : (DateTime?)null,
                                    UserAdded = c.AssignedToAerEventUsersName,
                                    DeliveryPoint = c.DeliveryPointText,
                                }).ToList()
                            }).ToList()
                        });
                    }
                }

                return result;
            }
        }

        private MachineDetergentDataContract ConvertToMachineDetergentDataContractCollection(MachineDetergent machineDetergent)
        {
            return new MachineDetergentDataContract
            {
                MachineDetergentId = machineDetergent.MachineDetergentId,
                MachineId = machineDetergent.MachineId,
                UserId = machineDetergent.UserId,
                UserName = machineDetergent.User.UserName,
                DetergentInformation = machineDetergent.DetergentInformation,
                BatchInformation = machineDetergent.BatchInformation,
                ValidFrom = machineDetergent.ValidFrom
            };
        }

        private AerStatus GetStatusForAer(
            int? latestMachineEventTypeId,
            bool hasCurrentlyInProgressBatch,
            DateTime? currentlyInProgressBatchStarted,
            bool currentlyInProgressBatchHasCurrentlyAssignedTurnarounds,
            int? currentlyInProgressBatchCycleId)
        {
            var aerStatus = AerStatus.Ready;
            if (latestMachineEventTypeId == (int)MachineEventTypeIdentifier.UnAvailable)
            {
                aerStatus = AerStatus.OutOfService;
            }
            else
            {
                if (hasCurrentlyInProgressBatch)
                {
                    if (!currentlyInProgressBatchStarted.HasValue && currentlyInProgressBatchHasCurrentlyAssignedTurnarounds)
                    {
                        aerStatus = AerStatus.Loading;
                    }
                    else
                    {
                        if (currentlyInProgressBatchHasCurrentlyAssignedTurnarounds)
                        {
                            aerStatus = AerStatus.Washing;
                        }
                        else if (currentlyInProgressBatchStarted.HasValue)
                        {
                            if (currentlyInProgressBatchCycleId == (int)BatchCycleTypeIdentifier.AERDisinfection)
                            {
                                aerStatus = AerStatus.RunningDisinfectionCycle;
                            }
                            else if (currentlyInProgressBatchCycleId == (int)BatchCycleTypeIdentifier.AERTest)
                            {
                                aerStatus = AerStatus.RunningTestCycle;
                            }
                            else
                            {
                                aerStatus = AerStatus.Washing;
                            }
                        }
                    }
                }
            }

            return aerStatus;
        }

        private List<DataValueDataContract> GetFailureEventTypes(IUnitOfWork unitOfWork, int facilityId)
        {
            var helper = new ConfigurableListHelper(unitOfWork);

            var failureTypes = helper.GetFailureTypes(facilityId, TurnAroundEventTypeIdentifier.AerFailed);

            return failureTypes.Select(ftet => new DataValueDataContract { Id = ftet.FailureTypeId, Value = ftet.Text }).ToList();
        }

        #endregion
    }
}