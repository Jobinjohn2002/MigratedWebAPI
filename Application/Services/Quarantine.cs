using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Quarantine
    /// </summary>
    public class Quarantine : BasicTurnaroundEvents
    {
        public Quarantine(SynergyTrakData data) : base(data)
        {
        }

        /// <summary>
        /// PutIntoQuarantine operation
        /// </summary>
        public void PutIntoQuarantine(ScanAssetDataContract scanDC, ScanDetails scanDetails, short quarantineReasonId)
        {
            if (_data.EventTypeId == TurnAroundEventTypeIdentifier.DeconStart || scanDC.IsDeconEndRequired)
            {
                ApplyEvent(ApplyTurnaroundEventDetails.Create(TurnAroundEventTypeIdentifier.DeconCancel, true), scanDC, scanDetails);
            }
            if (scanDC.IsParentABatchTag)
            {
                var bt = new BatchTag(_data);
                bt.RemoveFrom(scanDC, scanDetails);
            }

            if (scanDC.IsParentACarriage)
            {
                var carriage = new Carriage(_data);
                carriage.RemoveFrom(scanDC, scanDetails);
            }

            _data.QuarantineReasonId = quarantineReasonId;

            SetInstanceQuarantineReasons(scanDC.Asset.ContainerInstanceId, (short)scanDC.LastProcessEventTypeId, quarantineReasonId);

            ApplyEvent(ApplyTurnaroundEventDetails.Create(TurnAroundEventTypeIdentifier.IntoQuarantine, true), scanDC, scanDetails);
        }

        private void SetMultipleInstanceQuarantineReasons(List<int> containerInstanceIds, short? eventTypeId, short? quarantineReasonId)
        {
            if (containerInstanceIds != null)
            {
                using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                {
                    var containerRepository = ContainerInstanceRepository.New(workUnit);

                    var instanceList = containerRepository.GetMultiple(containerInstanceIds);

                    foreach (var instance in instanceList)
                    {
                        instance.QuarantineEventTypeId = eventTypeId;
                        instance.QuarantineReasonId = quarantineReasonId;
                    }

                    containerRepository.Save();
                }
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.IntoQuarantine)]
        /// <summary>
        /// IntoQuarantine operation
        /// </summary>
        public void IntoQuarantine(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (scanDetails.Data.HasValue)
            {
                IntoQuarantine(scanDC, scanDetails, scanDetails.Data.Value, scanDetails.StringData);
            }
            else if (scanDetails.QuarantineReasonId.HasValue)
            {
                PutIntoQuarantine(scanDC, scanDetails, (short)scanDetails.QuarantineReasonId);
            }
        }

        private void IntoQuarantine(ScanAssetDataContract scanDC, ScanDetails scanDetails, int defectClassificationId, string serviceReportName)
        {
            var now = DateTime.UtcNow;

            {
                var stationTypeRepository = StationTypeRepository.New(workUnit);
                var stationType = stationTypeRepository.Get((byte)_data.StationTypeId);

                var userRepository = UserRepository.New(workUnit);
                var user = userRepository.Get(scanDC.UserId);

                if ((stationType != null) && (user != null))
                {
                    var newDefect = DefectFactory.CreateEntity(workUnit,
                        raised: now,
                        reportingDepartment: stationType.Text,
                        deliveryPointId: scanDC.DeliveryPtId,
                        reporterUserName: $"{user.FirstName}.{user.Surname}",
                        reporterUserPosition: string.Empty,
                        defectStatusId: (byte)DefectStatusIdentifier.New,
                        defectSeverityId: (byte)DefectSeverityIdentifier.MinorFault,
                        defectClassificationId: (byte)defectClassificationId,
                        itemName: string.Empty,
                        containerInstanceId: scanDC.Asset.ContainerInstanceId,
                        turnaroundId: scanDC.TurnaroundId,
                        generalFaultCount: 0,
                        otherDetails: string.Empty,
                        received: now,
                        immediateAction: string.Empty,
                        immediateActionUserId: null,
                        immediateActionDate: now,
                        longTermAction: string.Empty,
                        longTermActionUserId: null,
                        longTermActionDate: now,
                        signedForTrustUserName: string.Empty,
                        signedForSynergyUserId: null,
                        reviewUserId: null,
                        reviewed: null,
                        defectResponsibilityId: (byte)DefectResponsibilityIdentifier.AwaitingResponsibility,
                        createdUserId: user.UserId,
                        legacyId: null,
                        legacyFacilityOrigin: null,
                        legacyImported: null,
                        externalId: serviceReportName,
                        reviewInformation: string.Empty);

                    var defectRepository = DefectRepository.New(workUnit);
                    defectRepository.Add(newDefect);
                    defectRepository.Save();

                    var auditItem = DefectAuditHistoryFactory.CreateEntity(workUnit,
                        fromValue: string.Empty,
                        toValue: string.Empty,
                        field: "Newly Created",
                        created: newDefect.Raised,
                        createdUserId: newDefect.CreatedUserId,
                        defectId: newDefect.DefectId
                    );

                    var defectAuditHistoryRepository = DefectAuditHistoryRepository.New(workUnit);

                    defectAuditHistoryRepository.Add(auditItem);
                    defectAuditHistoryRepository.Save();
                }
            }

            scanDC.IsInQuarantine = true;

            if (scanDC.IsParentACarriage)
            {
                ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.RemovedFromCarriage, RemoveFromParent = true, ParentTurnaroundId = scanDC.ParentTurnaroundId }, scanDetails);
            }
            else if (scanDC.IsParentABatchTag)
            {
                var bt = new BatchTag(_data);
                bt.RemoveFrom(scanDC, scanDetails);
            }

            PutIntoQuarantine(scanDC, scanDetails, (short)QuarantineReasonIdentifier.ServiceReportRaised);
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.OutOfQuarantine)]
        /// <summary>
        /// OutOfQuarantine operation
        /// </summary>
        public void OutOfQuarantine(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (scanDC.TurnaroundId.HasValue)
            {
                var serviceRequirementExpiryRepository = new ServiceRequirementExpiryRepository();
                SetInstanceQuarantineReasons(scanDC.Asset.ContainerInstanceId, null, null);
                scanDC.Expiry = serviceRequirementExpiryRepository.ReadExpiryOutOfQuarantine(scanDC.ServiceRequirementId, scanDC.TurnaroundId.Value).Expiry;

                if (scanDetails.ReQuarantineAfterWash)
                {
                    {
                        var defectRepository = DefectRepository.New(workUnit);
                        var defects = defectRepository.GetOpenDefects(scanDC.TurnaroundId.Value);
                        foreach (var defect in defects)
                        {
                            defect.QuarantineAfterWash = true;
                        }

                        workUnit.Save();
                    }
                }
            }

            ApplyEvent(new ApplyTurnaroundEventDetails { EventType = _data.EventTypeId, ParentTurnaroundId = scanDetails.ParentTurnaroundId }, scanDetails);
        }
    }
}