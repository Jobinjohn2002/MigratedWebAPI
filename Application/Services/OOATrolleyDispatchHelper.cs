using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// OOATrolleyDispatchHelper
    /// </summary>
    public class OOATrolleyDispatchHelper
    {
        /// <summary>
        /// DoesOutOfAutoclaveEventNeedToBeApplied operation
        /// </summary>
        public bool DoesOutOfAutoclaveEventNeedToBeApplied(short facilityId, long turnaroundExternalId)
        {
            using (var workUnit = InstanceFactory.GetInstance<IUnitOfWork>())
            {
                var turnaroundRepository = TurnaroundRepository.New(workUnit);
                var workflowRepository = WorkflowRepository.New(workUnit);
                var turnaround = turnaroundRepository.GetTurnaroundByExternalIdAndFacility(turnaroundExternalId, facilityId);

                var lastProcessEvent = turnaround.TurnaroundEvent.OrderByDescending(y=>y.Created).ThenByDescending(y=>y.TurnaroundEventId).FirstOrDefault(te => te.EventType.ProcessEvent);
                
                var nextWorkflow = workflowRepository.ReadWorkflow(lastProcessEvent?.EventTypeId, (int)TurnAroundEventTypeIdentifier.OutofAutoclave, turnaround.ContainerMaster.ItemTypeId, facilityId, turnaround.ContainerMasterId, turnaround.DeliveryPointId);
                return nextWorkflow != null;
            }
        }

        /// <summary>
        /// PassItemOutOfAutoclave operation
        /// </summary>
        public TrolleyDispatchTrolleyDataContract PassItemOutOfAutoclave(TrolleyDispatchTrolleyDataContract dataContract, TrolleyDispatchScanTurnaroundScanDetails scanDetails, Turnaround turnaround, ISynergyTrakHelper synergyTrakHelper)
        {
            scanDetails.Events.Add(new ScanEventDataContract { EventType = (int)TurnAroundEventTypeIdentifier.OutofAutoclave });

            using (var applyEvent = InstanceFactory.GetInstance<IApplyEvent>())
            {
                using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                {
                    dataContract.FacilityId = scanDetails.FacilityId;
                    dataContract.UserId = scanDetails.UserId;
                    dataContract.TurnaroundExternalId = (long)turnaround.ExternalId;
                    dataContract.LastProcessEventTypeId = (TurnAroundEventTypeIdentifier)turnaround.CurrentTurnaroundEvent.EventTypeId;
                    dataContract.TurnaroundId = turnaround.TurnaroundId;
                    dataContract.DeliveryPtId = turnaround.DeliveryPointId;
                    dataContract.Expiry = turnaround.Expiry;
                    dataContract.Asset = new AssetDetailsDataContract
                    {
                        ItemTypeId = turnaround.ContainerMaster.ItemTypeId,
                        ContainerMasterId = turnaround.ContainerMasterId
                    };
                    dataContract.TurnaroundEvents = new List<DataContracts.TurnaroundEventDataContract>();

                    synergyTrakHelper.SynergyTrakData.EventTypeId = TurnAroundEventTypeIdentifier.OutofAutoclave;
                    synergyTrakHelper.SynergyTrakData.StationId = scanDetails.StationId;
                    synergyTrakHelper.SynergyTrakData.StationTypeId = scanDetails.StationTypeId;
                    synergyTrakHelper.SynergyTrakData.UserId = scanDetails.UserId;
                    synergyTrakHelper.SynergyTrakData.FacilityId = scanDetails.FacilityId;

                    applyEvent.Setup(synergyTrakHelper.SynergyTrakData);
                    applyEvent.ApplyEvents(new List<TurnaroundProcessing.Models.ApplyTurnaroundEventDetails> { new TurnaroundProcessing.Models.ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.OutofAutoclave, BatchId = scanDetails.BatchId } },
                    new List<ScanAssetDataContract> { dataContract }, scanDetails, true);

                    NotificationEngineHelper notificationEngineHelper = new NotificationEngineHelper();

                    ITurnaroundEvent turnaroundEvent = TurnaroundEventFactory.CreateEntity(workUnit);
                    var lastOOAEvent = turnaround.TurnaroundEvent.LastOrDefault(
                                te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.OutofAutoclave || te.EventTypeId == (int)TurnAroundEventTypeIdentifier.RetrospectiveOutOfAutoclaveApproval);
                    turnaroundEvent.TurnaroundEventId = lastOOAEvent?.TurnaroundEventId ?? 0;
                    var res = notificationEngineHelper.ProcessNotifications(dataContract, scanDetails, turnaroundEvent);
                    return dataContract;
                }
            }
        }
    }
}