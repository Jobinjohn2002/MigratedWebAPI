using SynergyApplicationFrameworkApi.Application.DTOs.Endoscopy;
using SynergyApplicationFrameworkApi.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SynergyApplicationFrameworkApi.Application.DTOs;
using SynergyApplicationFrameworkApi.Core.Models;
using SynergyApplicationFrameworkApi.Framework;
using SynergyApplicationFrameworkApi.Data.Contracts;
using SynergyApplicationFrameworkApi.Data.Repositories;
using SynergyApplicationFrameworkApi.Core.Enums;
using SynergyApplicationFrameworkApi.Application.Helpers;
using SynergyApplicationFrameworkApi.Application.Contracts;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Endoscopy
    /// </summary>
    public class Endoscopy : TurnaroundEvents
    {
        private new EndoscopyDeconTasksData _data => (EndoscopyDeconTasksData)base._data;

        public Endoscopy(SynergyTrakData data) : base(data)
        {
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.PreAerDeconTaskSuccess)]
        /// <summary>
        /// PreAerDeconTaskSuccess operation
        /// </summary>
        public void PreAerDeconTaskSuccess(ScanAssetDataContract scanAssetDataContract, EndoscopyDeconTaskScanDetails endoscopyDeconTaskScanDetails)
        {
            CreatePreAerDeconTaskEvent(scanAssetDataContract, endoscopyDeconTaskScanDetails, BatchStatusIdentifier.Passed, TurnAroundEventTypeIdentifier.PreAerDeconTaskSuccess);
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.PreAerDeconTaskFailure)]
        /// <summary>
        /// PreAerDeconTaskFailure operation
        /// </summary>
        public void PreAerDeconTaskFailure(ScanAssetDataContract scanAssetDataContract, EndoscopyDeconTaskScanDetails endoscopyDeconTaskScanDetails)
        {
            CreatePreAerDeconTaskEvent(scanAssetDataContract, endoscopyDeconTaskScanDetails, BatchStatusIdentifier.Failed, TurnAroundEventTypeIdentifier.PreAerDeconTaskFailure);
        }

        private (int? BatchId, int? ErrorCode) GetOrCreateAvailableBatch(IUnitOfWork workUnit, ScanDetails scanDetails, string batchName, bool validateBatchNotStarted, BatchCycleTypeIdentifier? batchCycleType = null)
        {
            var batchRepository = new BatchRepository(workUnit);
            var lastBatch = batchRepository.GetLastBatchByMachineId(scanDetails.MachineId.Value);

            BatchCreatedDataContract newBatch = null;

            if (lastBatch != null && lastBatch.BatchStatusId == (int)BatchStatusIdentifier.InProgress)
            {
                if (validateBatchNotStarted && lastBatch.Started.HasValue)
                {
                    return (null, (int)ErrorCodes.AerBatchAlreadyStarted);
                }
                else
                {
                    return (lastBatch.BatchId, null);
                }
            }
            else
            {
                BatchHelper batchHelper = new BatchHelper();
                CreateBatchRequestDataContract createBatchDC = new CreateBatchRequestDataContract()
                {
                    MachineId = scanDetails.MachineId.Value,
                    UserId = scanDetails.UserId,
                    FacilityId = scanDetails.FacilityId,
                    CreateBatchTime = DateTime.UtcNow,
                    BatchCycleId = (int?)batchCycleType
                };

                createBatchDC.BatchName = batchName;

                newBatch = batchHelper.Create(createBatchDC, true);

                return (newBatch.BatchId, newBatch.ErrorCode);
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.AssignedToAer)]
        /// <summary>
        /// AssignedToAer operation
        /// </summary>
        public void AssignedToAer(ScanAssetDataContract scanAssetDataContract, ScanDetailsBatchRequestDataContract scanDetails)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var batchResult = GetOrCreateAvailableBatch(workUnit, scanDetails, scanDetails.BatchName, true, BatchCycleTypeIdentifier.AERStandard);

                scanAssetDataContract.ErrorCode = batchResult.ErrorCode;
                scanDetails.BatchId = batchResult.BatchId;

                if (scanAssetDataContract.ErrorCode != null)
                {
                    return;
                }

                var containerInstanceRepository = new ContainerInstanceRepository(workUnit);

                if (scanAssetDataContract.ErrorCode == null)
                {
                    ContainerInstance scope = null;
                    if (scanDetails.InstanceId != null)
                    {
                        scope = containerInstanceRepository.Get(scanDetails.InstanceId.Value);
                    }
                    else
                    {
                        scope = containerInstanceRepository.PreSearchContainerInstance(scanDetails.ExternalId, scanDetails.FacilityId, false).FirstOrDefault();
                    }

                    if (scope != null)
                    {
                        scope.CurrentLocationId = scanDetails.StationLocationId;

                        var eventsToApply = new ApplyTurnaroundEventDetails
                        {
                            EventType = TurnAroundEventTypeIdentifier.AssignedToAer,
                            BatchId = scanDetails.BatchId
                        };

                        ApplyEvent(eventsToApply, scanAssetDataContract, scanDetails);
                    }
                }

                workUnit.Save();
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.RemovedFromAer)]
        /// <summary>
        /// RemovedFromAer operation
        /// </summary>
        public void RemovedFromAer(ScanAssetDataContract scanAssetDataContract, ScanDetails scanDetails)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var batchRepository = new BatchRepository(workUnit);
                var containerInstanceRepository = new ContainerInstanceRepository(workUnit);
                var scope = containerInstanceRepository.Get(scanDetails.InstanceId.Value);

                var lastBatch = batchRepository.GetLastBatchByMachineId(scanDetails.MachineId.Value);
                if (lastBatch.CurrentlyAssignedTurnarounds.Any(t => t.TurnaroundId == scope.CurrentTurnaround.TurnaroundId))
                {
                    if (lastBatch.Started.HasValue)
                    {
                        scanAssetDataContract.ErrorCode = (int)ErrorCodes.AerBatchAlreadyStarted;
                    }
                }
                else
                {
                    scanAssetDataContract.ErrorCode = (int)ErrorCodes.TurnaroundNotPartOfABatch;
                }

                var eventsToApply = new ApplyTurnaroundEventDetails
                {
                    EventType = TurnAroundEventTypeIdentifier.RemovedFromAer
                };

                if (scanAssetDataContract.ErrorCode == null)
                {
                    ApplyEvent(eventsToApply, scanAssetDataContract, scanDetails);
                }

                if (scanAssetDataContract.ErrorCode == null)
                {
                    scope.CurrentLocationId = scanDetails.StationLocationId;
                }

                workUnit.Save();
            }
        }

        private void CreatePreAerDeconTaskEvent(ScanAssetDataContract scanAssetDataContract, EndoscopyDeconTaskScanDetails endoscopyDeconTaskScanDetails, BatchStatusIdentifier batchStatusIdentifier, TurnAroundEventTypeIdentifier eventType)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var batchRepository = new BatchRepository(workUnit);

                var newBatch = BatchFactory.CreateEntity(workUnit,
                    externalId: endoscopyDeconTaskScanDetails.Created.Value.Ticks.ToString(),
                    created: endoscopyDeconTaskScanDetails.Created.Value,
                    started: endoscopyDeconTaskScanDetails.Created.Value,
                    createdUserId: endoscopyDeconTaskScanDetails.UserId,
                    batchStatusId: (int)batchStatusIdentifier
                );

                newBatch.BatchDecontaminationTask = new List<BatchDecontaminationTask>
                {
                    BatchDecontaminationTaskFactory.CreateEntity(workUnit,
                        decontaminationTaskId: endoscopyDeconTaskScanDetails.DeconTaskId,
                        turnaroundId: endoscopyDeconTaskScanDetails.TurnaroundId.Value,
                        userId: endoscopyDeconTaskScanDetails.UserId
                    )
                };

                if (eventType == TurnAroundEventTypeIdentifier.PreAerDeconTaskFailure)
                {
                    newBatch.Failed = endoscopyDeconTaskScanDetails.Created.Value;
                    newBatch.FailedUserId = endoscopyDeconTaskScanDetails.UserId;

                    newBatch.FailedBatch = new List<FailedBatch>
                    {
                        FailedBatchFactory.CreateEntity(workUnit,
                            createdUserId: endoscopyDeconTaskScanDetails.UserId,
                            failureTypeId: (byte)endoscopyDeconTaskScanDetails.FailureTypeId.Value,
                            created: endoscopyDeconTaskScanDetails.Created.Value,
                            text: endoscopyDeconTaskScanDetails.FailureText
                        )
                    };
                }
                else
                {
                    newBatch.BatchReleasedUserId = endoscopyDeconTaskScanDetails.UserId;
                    newBatch.DateChecked = endoscopyDeconTaskScanDetails.Created.Value;
                }

                batchRepository.Add(newBatch);
                workUnit.Save();

                endoscopyDeconTaskScanDetails.BatchId = newBatch.BatchId;

                var eventsToApply = new ApplyTurnaroundEventDetails
                {
                    EventType = eventType,
                    BatchId = newBatch.BatchId,
                    RetrospectiveCreatedDate = endoscopyDeconTaskScanDetails.Created.Value
                };

                ApplyEvent(eventsToApply, scanAssetDataContract, endoscopyDeconTaskScanDetails);
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.AerStart)]
        /// <summary>
        /// AerStart operation
        /// </summary>
        public void AerStart(ScanAssetDataContract scanAssetDataContract, ScanDetails scanDetails)
        {
            var eventsToApply = new ApplyTurnaroundEventDetails
            {
                EventType = TurnAroundEventTypeIdentifier.AerStart,
                BatchId = scanDetails.BatchId
            };

            var scanDcList = CreateScanAssetDataContractsForAerBatch(scanDetails.BatchId.Value);
            ApplyEvent(eventsToApply, scanDcList, scanDetails);
            scanAssetDataContract.ChildItems.AddRange(scanDcList);
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.AerFailed)]
        /// <summary>
        /// AerFailed operation
        /// </summary>
        public void AerFailed(ScanAssetDataContract scanAssetDataContract, ScanDetails scanDetails)
        {
            var eventsToApply = new ApplyTurnaroundEventDetails
            {
                EventType = TurnAroundEventTypeIdentifier.AerFailed,
                BatchId = scanDetails.BatchId
            };

            var scanDcList = CreateScanAssetDataContractsForAerBatch(scanDetails.BatchId.Value);
            var turnaroundEventMapping = ApplyEvent(eventsToApply, scanDcList, scanDetails, true);
            scanAssetDataContract.ChildItems.AddRange(scanDcList);
            if (scanAssetDataContract.ErrorCode == null)
            {
                using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                {
                    var containerInstanceRepository = new ContainerInstanceRepository(workUnit);

                    foreach (var dc in scanDcList)
                    {
                        var container = containerInstanceRepository.GetContainerInstanceByTurnaround(dc.TurnaroundId.Value);
                        container.CurrentLocationId = scanDetails.StationLocationId;
                    }

                    workUnit.Save();
                }
                ProcessNotifications(turnaroundEventMapping, scanDetails);
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.AerPassed)]
        /// <summary>
        /// AerPassed operation
        /// </summary>
        public void AerPassed(ScanAssetDataContract scanAssetDataContract, ScanDetails scanDetails)
        {
            var eventsToApply = new List<ApplyTurnaroundEventDetails>();

            eventsToApply.Add(new ApplyTurnaroundEventDetails
            {
                EventType = TurnAroundEventTypeIdentifier.AerPassed,
                BatchId = scanDetails.BatchId
            });

            eventsToApply.Add(new ApplyTurnaroundEventDetails
            {
                EventType = TurnAroundEventTypeIdentifier.BillingPoint,
                BatchId = scanDetails.BatchId
            });

            var scanDcList = CreateScanAssetDataContractsForAerBatch(scanDetails.BatchId.Value);
            var turnaroundEventMapping = ApplyEvent(eventsToApply, scanDcList, scanDetails, true);
            scanAssetDataContract.ChildItems.AddRange(scanDcList);
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var containerInstanceRepository = new ContainerInstanceRepository(workUnit);

                foreach (var dc in scanDcList)
                {
                    if (dc.ErrorCode == null)
                    {
                        var container = containerInstanceRepository.GetContainerInstanceByTurnaround(dc.TurnaroundId.Value);
                        container.CurrentLocationId = scanDetails.StationLocationId;
                        workUnit.Save();
                        SterileExpiryHelper.UpdateSterileExpiry(dc.TurnaroundId.Value, TurnAroundEventTypeIdentifier.AerPassed);
                    }
                }
            }
            ProcessNotifications(turnaroundEventMapping, scanDetails);
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.ChangedBatch)]
        /// <summary>
        /// ChangeCycleNumber operation
        /// </summary>
        public void ChangeCycleNumber(ScanAssetDataContract scanAssetDataContract, ScanDetails scanDetails)
        {
            var eventsToApply = new ApplyTurnaroundEventDetails
            {
                EventType = TurnAroundEventTypeIdentifier.ChangedBatch,
                BatchId = scanDetails.BatchId
            };

            ApplyEvent(eventsToApply, scanAssetDataContract, scanDetails);
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.IntoDryingCabinet)]
        /// <summary>
        /// IntoDryingCabinet operation
        /// </summary>
        public void IntoDryingCabinet(ScanAssetDataContract scanAssetDataContract, EndoscopeStorageScanDetails scanDetails)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var containerInstanceRepository = new ContainerInstanceRepository(workUnit);

                var containerSearchResult = new List<ContainerInstance>();
                if (scanDetails.InstanceId != null)
                {
                    containerSearchResult.Add(containerInstanceRepository.PreSearchContainerInstance(scanDetails.InstanceId.Value, scanDetails.FacilityId));
                }
                else
                {
                    containerSearchResult.AddRange(containerInstanceRepository.PreSearchContainerInstance(scanDetails.ExternalId, scanDetails.FacilityId, false));
                }
                if (containerSearchResult.Count == 1 && containerSearchResult.First().CurrentTurnaround?.SterileExpiryDate != null && containerSearchResult.First().CurrentTurnaround.SterileExpiryDate <= DateTime.UtcNow)
                {
                    scanAssetDataContract.ErrorCode = (int)ErrorCodes.SterileExpiryExceeded;
                }
            }

            var eventsToApply = new ApplyTurnaroundEventDetails
            {
                EventType = TurnAroundEventTypeIdentifier.IntoDryingCabinet
            };

            var turnaroundEventMapping = new List<TurnaroundEventComplete>();

            if (scanAssetDataContract.ErrorCode == null)
            {
                turnaroundEventMapping = ApplyEvent(eventsToApply, scanAssetDataContract, scanDetails, true);
            }

            if (scanAssetDataContract.ErrorCode == null)
            {
                using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                {
                    var containerInstanceRepository = new ContainerInstanceRepository(workUnit);
                    var container = containerInstanceRepository.GetContainerInstanceByTurnaround(scanAssetDataContract.TurnaroundId.Value);
                    var turnaround = ((ContainerInstance)container).CurrentTurnaround;

                    turnaround.SterileExpiryDate = null;
                    turnaround.TurnaroundWH.ToList().ForEach(twh => twh.SterileExpiryDate = turnaround.SterileExpiryDate);

                    container.CurrentLocationId = scanDetails.StorageLocationId;
                    workUnit.Save();
                }
                ProcessNotifications(turnaroundEventMapping, scanDetails);
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.RemovedFromDryingCabinetDry)]
        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.RemovedFromDryingCabinetWet)]
        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.RemovedFromDryingCabinetExpired)]
        /// <summary>
        /// RemovedFromDryingCabinet operation
        /// </summary>
        public void RemovedFromDryingCabinet(ScanAssetDataContract scanAssetDataContract, ScanDetails scanDetails)
        {
            var eventType = (TurnAroundEventTypeIdentifier)scanDetails.Events.FirstOrDefault().EventType;

            var eventsToApply = new ApplyTurnaroundEventDetails
            {
                EventType = eventType
            };

            var turnaroundEventMapping = ApplyEvent(eventsToApply, scanAssetDataContract, scanDetails, true);

            if (scanAssetDataContract.ErrorCode == null)
            {
                var relaxedProcessing = FacilitySettings.EndoscopeRemovedWetRelaxedExpiryRules((short)scanAssetDataContract.FacilityId);
                if (eventType == TurnAroundEventTypeIdentifier.RemovedFromDryingCabinetWet && !relaxedProcessing)
                {
                    var startingPoint = scanAssetDataContract.TurnaroundEvents.Where(e => e.EventTypeId == (int)TurnAroundEventTypeIdentifier.AerPassed).OrderByDescending(e => e.Created).First().Created;

                    SterileExpiryHelper.UpdateSterileExpiry(scanAssetDataContract.TurnaroundId.Value, eventType, startingPoint);
                }
                else
                {
                    SterileExpiryHelper.UpdateSterileExpiry(scanAssetDataContract.TurnaroundId.Value, eventType);
                }
                ProcessNotifications(turnaroundEventMapping, scanDetails);
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.VacuumPackedDry)]
        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.VacuumPackedWet)]
        /// <summary>
        /// VacuumPacked operation
        /// </summary>
        public void VacuumPacked(ScanAssetDataContract scanAssetDataContract, ScanDetails scanDetails)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var batchResult = GetOrCreateAvailableBatch(workUnit, scanDetails, null, false);

                scanAssetDataContract.ErrorCode = batchResult.ErrorCode;
                scanDetails.BatchId = batchResult.BatchId;

                if (scanAssetDataContract.ErrorCode != null)
                {
                    return;
                }

                ContainerInstance container;

                var containerInstanceRepository = new ContainerInstanceRepository(workUnit);
                if (scanDetails.InstanceId != null)
                {
                    container = containerInstanceRepository.Get(scanDetails.InstanceId.Value);
                }
                else
                {
                    container = containerInstanceRepository.PreSearchContainerInstance(scanDetails.ExternalId, scanDetails.FacilityId, false).FirstOrDefault();
                }
                var machineRepository = new MachineRepository(workUnit);
                var machine = machineRepository.Get(scanDetails.MachineId.Value);

                if (machine == null || machine.MachineTypeId != (byte)MachineTypeIdentifier.VacuumPacker)
                {
                    scanAssetDataContract.ErrorCode = (int)ErrorCodes.MachineTypeMismatch;
                    return;
                }

                var eventType = (TurnAroundEventTypeIdentifier)scanDetails.Events.FirstOrDefault().EventType;

                var machineVacuumPackDryEnabled = MachineSettings.EndoscopeSterileExpiryVacuumPackedDryMinutes(machine.MachineId).HasValue;
                var machineVacuumPackWetEnabled = MachineSettings.EndoscopeSterileExpiryVacuumPackedWetMinutes(machine.MachineId).HasValue;

                if ((eventType == TurnAroundEventTypeIdentifier.VacuumPackedWet && !machineVacuumPackWetEnabled) ||
                    (eventType == TurnAroundEventTypeIdentifier.VacuumPackedDry && !machineVacuumPackDryEnabled))
                {
                    scanAssetDataContract.ErrorCode = (int)ErrorCodes.MachineTypeMismatch;
                    return;
                }

                var eventsToApply = new ApplyTurnaroundEventDetails
                {
                    EventType = eventType,
                    BatchId = scanDetails.BatchId
                };

                var turnaroundEventMapping = ApplyEvent(eventsToApply, scanAssetDataContract, scanDetails, true);

                if (scanAssetDataContract.ErrorCode == null)
                {
                    SterileExpiryHelper.UpdateSterileExpiry(scanAssetDataContract.TurnaroundId.Value, eventType, machineId: scanDetails.MachineId);
                    var batchRepository = new BatchRepository(workUnit);
                    var batch = batchRepository.Get(scanDetails.BatchId.Value);

                    batch.BatchStatusId = (int)BatchStatusIdentifier.Passed;
                    batch.BatchReleasedUserId = scanDetails.UserId;
                    batch.DateChecked = DateTime.UtcNow;

                    workUnit.Save();
                    ProcessNotifications(turnaroundEventMapping, scanDetails);
                }
            }
        }

        private List<ScanAssetDataContract> CreateScanAssetDataContractsForAerBatch(int batchId)
        {
            var scanDcList = new List<ScanAssetDataContract>();
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var batchRepository = new BatchRepository(workUnit);
                var batch = batchRepository.Get(batchId);

                foreach (var turnaround in batch.CurrentlyAssignedTurnarounds)
                {
                    var containerInstance = turnaround.ContainerInstance;
                    var containerMaster = turnaround.ContainerMaster;

                    scanDcList.Add(new ScanAssetDataContract()
                    {
                        TurnaroundId = turnaround.TurnaroundId,
                        Asset = new AssetDetailsDataContract
                        {
                            ContainerInstanceId = containerInstance.ContainerInstanceId,
                            ContainerInstancePrimaryId = containerInstance.PrimaryId,
                            ContainerInstanceCreated = containerInstance.Created,
                            TurnaroundWarningCount = containerInstance.TurnaroundWarningCount,
                            ContainerMasterDefinitionId = containerMaster.ContainerMasterDefinitionId,
                            ContainerMasterName = containerMaster.Text,
                            ContainerMasterId = containerMaster.ContainerMasterId,
                            ContainerMasterExternalId = containerMaster.ExternalId,
                            IsContainerMasterArchived = containerMaster.Archived.HasValue,
                            IsContainerInstanceArchived = containerInstance.Archived.HasValue,
                            ItemTypeId = containerMaster.ItemTypeId,
                            ItemTypeText = containerMaster.ItemType.Text,
                            BaseItemTypeId = containerMaster.ItemType.ParentItemTypeId ?? containerMaster.ItemTypeId,
                            TrackIndividualInstruments = containerMaster.TrackIndividualInstruments,
                            MachineTypeId = containerMaster.MachineTypeId,
                            Linear1DBarcodeId = containerInstance.Linear1dBarcodeId,
                            Datamatrix2DBarcodeId = containerInstance.Datamatrix2dBarcodeId,
                            FacilityId = turnaround.FacilityId,
                            IsIdentifiable = containerInstance.IsIdentifiable,
                            CustomerDefinitionId = containerMaster.ContainerMasterDefinition.CustomerDefinitionId
                        },
                        DeliveryPtId = containerInstance.DeliveryPointId,
                        FacilityId = turnaround.FacilityId,
                        LastProcessEventTypeId = (TurnAroundEventTypeIdentifier)containerInstance.CurrentTurnaround.CurrentTurnaroundEvent.EventTypeId,
                        TurnaroundEvents = new List<DataContracts.TurnaroundEventDataContract>(),
                        LocationId = containerInstance.CurrentLocationId,
                        StartTurnaroundEventId = turnaround.StartEventId,
                        StartEventTime = turnaround.TurnaroundWH.First().StartEventTime,
                        Expiry = turnaround.Expiry
                    });
                }
            }

            return scanDcList;
        }

        private void ProcessNotifications(List<TurnaroundEventComplete> turnaroundmappings, ScanDetails scanDetails)
        {
            var notificationHelper = new NotificationEngineHelper();
            foreach (var ted in turnaroundmappings)
            {
                foreach (var tec in ted.Events)
                {
                    if (tec.TurnaroundEvent != null)
                    {
                        if (ted.DataContract.NotificationTypesFired == null)
                        {
                            ted.DataContract.NotificationTypesFired = notificationHelper.ProcessNotifications(ted.DataContract, scanDetails, tec.TurnaroundEvent);
                        }
                        else
                        {
                            ted.DataContract.NotificationTypesFired.AddRange(notificationHelper.ProcessNotifications(ted.DataContract, scanDetails, tec.TurnaroundEvent));
                        }
                    }
                }
            }
        }
    }
}