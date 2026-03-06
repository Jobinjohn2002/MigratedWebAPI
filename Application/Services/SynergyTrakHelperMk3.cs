using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class SynergyTrakHelperMk3
    {
        private void ApplyEvent(TurnAroundEventTypeIdentifier applyEventType, ScanAssetDataContract scanDC, ScanDetails scanDetails, bool isAutomaticEvent = false)
        {
            var eventsToApply = new List<ApplyTurnaroundEventDetails>
            {
                new ApplyTurnaroundEventDetails()
                {
                    EventType = applyEventType,
                    IsAutomaticEvent = isAutomaticEvent,
                    BatchId = scanDC.BatchId,
                    RemoveFromParent = scanDC.IsRemoveFromParent
                }
            };

            ApplyEvent(eventsToApply, new List<ScanAssetDataContract>() { scanDC }, scanDetails, false);
        }

        /// <summary>
        /// ApplyEvent operation
        /// </summary>
        public void ApplyEvent(TurnAroundEventTypeIdentifier applyEventType, ScanDetails scanDetails, bool isAutomaticEvent = false)
        {
            var eventsToApply = new List<ApplyTurnaroundEventDetails>
            {
                new ApplyTurnaroundEventDetails()
                {
                    EventType = applyEventType,
                    IsAutomaticEvent = isAutomaticEvent
                }
            };

            ApplyEvent(eventsToApply, _synergyTrakData.ScanDcList, scanDetails, false);
        }

        /// <summary>
        /// ApplyEvent operation
        /// </summary>
        public void ApplyEvent(ApplyTurnaroundEventDetails eventToApply, ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            var eventsToApply = new List<ApplyTurnaroundEventDetails> { eventToApply };

            ApplyEvent(eventsToApply, new List<ScanAssetDataContract>() { scanDC }, scanDetails, false);
        }

        private void ApplyEvent(ApplyTurnaroundEventDetails eventToApply, ScanDetails scanDetails)
        {
            var eventsToApply = new List<ApplyTurnaroundEventDetails> { eventToApply };

            ApplyEvent(eventsToApply, _synergyTrakData.ScanDcList, scanDetails, false);
        }

        private void ApplyEvent(ApplyTurnaroundEventDetails eventDetails, List<ScanAssetDataContract> dataContracts, ScanDetails scanDetails)
        {
            var eventsToApply = new List<ApplyTurnaroundEventDetails> { eventDetails };

            ApplyEvent(eventsToApply, dataContracts, scanDetails, false);
        }

        /// <summary>
        /// ApplyEvent operation
        /// </summary>
        public void ApplyEvent(List<ApplyTurnaroundEventDetails> eventsToApply, ScanDetails scanDetails)
        {
            ApplyEvent(eventsToApply, _synergyTrakData.ScanDcList, scanDetails, false);
        }

        /// <summary>
        /// ApplyEvent operation
        /// </summary>
        public void ApplyEvent(List<ApplyTurnaroundEventDetails> eventsToApply, ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            ApplyEvent(eventsToApply, new List<ScanAssetDataContract>() { scanDC }, scanDetails, false);
        }

        private void ApplyEvent(List<ApplyTurnaroundEventDetails> eventsToApply, List<ScanAssetDataContract> dataContracts, ScanDetails scanDetails)
        {
            ApplyEvent(eventsToApply, dataContracts, scanDetails, false);
        }

        private void ApplyEvent(List<ApplyTurnaroundEventDetails> eventsToApply, List<ScanAssetDataContract> dataContracts, ScanDetails scanDetails, bool notificationsHandledExternally)
        {
            var notificationEngineHelper = new NotificationEngineHelper();
            using (var applyEvent = InstanceFactory.GetInstance<IApplyEvent>())
            {
                applyEvent.Setup(notificationEngineHelper.ProcessNotifications, _synergyTrakData.UserId, _synergyTrakData.FacilityId, _synergyTrakData.StationTypeId, _synergyTrakData.StationId, _synergyTrakData.QuarantineReasonId, _synergyTrakData.KeepBatchTagTogetherRequested, _synergyTrakData.FailureTypeId);
                applyEvent.ApplyEvents(eventsToApply, dataContracts, scanDetails, notificationsHandledExternally);
            }
        }

        /// <summary>
        /// AuditExceptionsPrint operation
        /// </summary>
        public void AuditExceptionsPrint(ScanDetails scanDetails, ScanAssetDataContract dataContract, string reportPath, int numberOfCopies)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var turnaroundRepository = TurnaroundRepository.New(workUnit);
                var turnaround = turnaroundRepository.Get(scanDetails.TurnaroundId.Value);

                var userRepository = UserRepository.New(workUnit);
                var user = userRepository.Get(scanDetails.UserId);

                if (turnaround != null && scanDetails?.Audit?.AuditId != null)
                {
                    var list = new List<Tuple<string, string>>
                    {
                        new Tuple<string, string>("S", user.SystemId.ToString()),
                        new Tuple<string, string>("TurnaroundId", turnaround.TurnaroundId.ToString()),
                        new Tuple<string, string>("AuditId", scanDetails.Audit.AuditId.ToString())
                    };

                    Reporting.CreatePDFReport(reportPath, list.ToArray(), scanDetails.LaserPrinter, scanDetails.IsNetworkPrinting, dataContract, numberOfCopies);
                }
            }
        }

        /// <summary>
        /// EpocTrolleyPrint operation
        /// </summary>
        public void EpocTrolleyPrint(ScanDetails scanDetails, ScanAssetDataContract dataContract, string reportPath, int numberOfCopies)
        {
            {
                var turnaroundRepository = TurnaroundRepository.New(workUnit);
                var turnaround = turnaroundRepository.Get(scanDetails.TurnaroundId.Value);
                var userRepository = UserRepository.New(workUnit);
                var user = userRepository.Get(scanDetails.UserId);

                if (turnaround != null)
                {
                    var list = new List<Tuple<string, string>>
                    {
                        new Tuple<string, string>("S", user.SystemId.ToString()),
                        new Tuple<string, string>("TurnaroundID", turnaround.TurnaroundId.ToString())
                    };

                    Reporting.CreatePDFReport(reportPath, list.ToArray(), scanDetails.LaserPrinter, scanDetails.IsNetworkPrinting, dataContract, numberOfCopies);
                }
            }
        }
    }
}