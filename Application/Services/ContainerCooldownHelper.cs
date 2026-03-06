using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// ContainerCooldownHelper
    /// </summary>
    public class ContainerCooldownHelper
    {
        /// <summary>
        /// ValidateContainerMasterCoolingTime operation
        /// </summary>
        public bool ValidateContainerMasterCoolingTime(ScanDetails scanDetails, ScanAssetDataContract dataContract)
        {
            if (scanDetails.TurnaroundExternalId.HasValue)
            {
                using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                {
                    var turnaroundRepository = new TurnaroundRepository(workUnit);
                    var turnaround = turnaroundRepository.GetTurnaroundByExternalIdAndFacility(scanDetails.TurnaroundExternalId.Value, scanDetails.FacilityId);

                    if (scanDetails.ContainerMasterCoolingTimeApprovedOverride)
                    {
                        var facilityRepository = new FacilityRepository(workUnit);
                        var facility = facilityRepository.Get(scanDetails.FacilityId);

                        ApplyContainerMasterCooldownOverrideEvents(dataContract, scanDetails, turnaround, facility.OverrideCooldownContainer);
                        return true;                        
                    }

                    var batch = turnaround.TurnaroundEvent.OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).FirstOrDefault(te => te.EventType.ProcessEvent)?.Batch ??
                        turnaround.TurnaroundEvent.FirstOrDefault(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoAutoclave)?.Batch;

                    var containerMasterRepository = new ContainerMasterRepository(workUnit);
                    var containerMaster = containerMasterRepository.Get(turnaround.ContainerMasterId);

                    if (batch != null && containerMaster != null && containerMaster.CoolingTime.HasValue)
                    {
                        if (batch.DateChecked.HasValue && batch.BatchStatusId == (int)BatchStatusIdentifier.Passed && containerMaster.CoolingTime > 0)
                        {
                            var batchPassedtime = batch.DateChecked.Value;
                            var cooldownOverrideEvent = turnaround.TurnaroundEvent.OrderByDescending(te => te.Created).FirstOrDefault(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.AutoclaveCooldownOverride);
                            if (cooldownOverrideEvent != null && cooldownOverrideEvent?.Created > batchPassedtime)
                                return true;

                            var remainingTime = batchPassedtime.AddMinutes(containerMaster.CoolingTime.Value) - DateTime.UtcNow;

                            if (remainingTime.Ticks > 0)
                            {
                                dataContract.RemainingContainerMasterCoolingTime = (int)Math.Ceiling(remainingTime.TotalMinutes);
                                dataContract.ErrorCode = (int)ErrorCodes.ContainerCooldownInProcess;
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// ApplyContainerMasterCooldownOverrideEvents operation
        /// </summary>
        public void ApplyContainerMasterCooldownOverrideEvents(ScanAssetDataContract dataContract, ScanDetails scanDetails, Turnaround turnaround, bool facilityCooldownOverrideEnabled)
        {
            scanDetails.Events.Add(new ScanEventDataContract { EventType = (int)TurnAroundEventTypeIdentifier.AutoclaveCooldownOverride });

            using (var applyEvent = InstanceFactory.GetInstance<IApplyEvent>())
            {
                dataContract.FacilityId = scanDetails.FacilityId;
                dataContract.UserId = scanDetails.UserId;
                dataContract.TurnaroundExternalId = turnaround.ExternalId;
                dataContract.LastProcessEventTypeId = (TurnAroundEventTypeIdentifier)turnaround.CurrentTurnaroundEvent.EventTypeId;
                dataContract.TurnaroundId = turnaround.TurnaroundId;
                dataContract.DeliveryPtId = turnaround.DeliveryPointId;
                dataContract.Expiry = turnaround.Expiry;

                if(dataContract.Asset == null)
                {
                    dataContract.Asset = new AssetDetailsDataContract();
                }

                dataContract.Asset.ItemTypeId = turnaround.ContainerMaster.ItemTypeId;
                dataContract.Asset.ContainerMasterId = turnaround.ContainerMasterId;
                dataContract.TurnaroundEvents = new List<DataContracts.TurnaroundEventDataContract>();

                SynergyTrakData synergyTrakData = new SynergyTrakData();
                synergyTrakData.EventTypeId = TurnAroundEventTypeIdentifier.AutoclaveCooldownOverride;
                synergyTrakData.StationId = scanDetails.StationId;
                synergyTrakData.StationTypeId = scanDetails.StationTypeId;
                synergyTrakData.UserId = scanDetails.UserId;
                synergyTrakData.FacilityId = scanDetails.FacilityId;

                applyEvent.Setup(synergyTrakData);
                applyEvent.ApplyEvents(new List<TurnaroundProcessing.Models.ApplyTurnaroundEventDetails> { new TurnaroundProcessing.Models.ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.AutoclaveCooldownOverride, BatchId = scanDetails.BatchId } },
                new List<ScanAssetDataContract> { dataContract }, scanDetails, true);
                if (!facilityCooldownOverrideEnabled && scanDetails.SupervisorApprovalUserId.HasValue)
                {
                    scanDetails.Events.Add(new ScanEventDataContract { EventType = (int)TurnAroundEventTypeIdentifier.SupervisorApproval });
                    dataContract.FacilityId = scanDetails.FacilityId;
                    dataContract.UserId = scanDetails.SupervisorApprovalUserId.Value;
                    dataContract.TurnaroundEvents = new List<DataContracts.TurnaroundEventDataContract>();

                    synergyTrakData.EventTypeId = TurnAroundEventTypeIdentifier.SupervisorApproval;
                    synergyTrakData.StationId = scanDetails.StationId;
                    synergyTrakData.StationTypeId = scanDetails.StationTypeId;
                    synergyTrakData.UserId = scanDetails.SupervisorApprovalUserId.Value;
                    synergyTrakData.FacilityId = scanDetails.FacilityId;

                    applyEvent.Setup(synergyTrakData);
                    applyEvent.ApplyEvents(new List<TurnaroundProcessing.Models.ApplyTurnaroundEventDetails> { new TurnaroundProcessing.Models.ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.SupervisorApproval, BatchId = scanDetails.BatchId } },
                    new List<ScanAssetDataContract> { dataContract }, scanDetails, true);

                }
                dataContract.UserId = scanDetails.UserId;
            }
        }
    }
}