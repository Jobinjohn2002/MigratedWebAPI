using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Carriage
    /// </summary>
    public class Carriage : BasicTurnaroundEvents
    {
        public Carriage(SynergyTrakData data) : base(data)
        {
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.RemovedFromCarriage)]
        /// <summary>
        /// RemoveFrom operation
        /// </summary>
        public void RemoveFrom(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            Parallel.ForEach(_data.ScanDcList, dc => ApplyEvent(ApplyTurnaroundEventDetails.Create(TurnAroundEventTypeIdentifier.RemovedFromCarriage, (dc.TurnaroundId == scanDC.TurnaroundId)), dc, scanDetails));
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.AssignedToCarriage)]
        /// <summary>
        /// AssignedTo operation
        /// </summary>
        public void AssignedTo(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            int? newParentTurnaroundId = scanDetails.ParentTurnaroundId;

            CheckAutomaticCollection(scanDC, scanDetails);

            if ((newParentTurnaroundId.HasValue) && (scanDC.TurnaroundId.HasValue)) // New parent.
            {
                ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.AssignedToCarriage, ParentTurnaroundId = newParentTurnaroundId.Value, RetrospectiveProcessStationTypeId = scanDetails.RetrospectiveProcessStationTypeId }, scanDC, scanDetails);

                if ((scanDC.ChildItems != null) && (scanDC.ChildItems.Count > 0))
                {
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.AssignedToCarriage },
                               _data.ScanDcList.Where(s => s.ParentTurnaroundId == scanDC.TurnaroundId).ToList(), scanDetails);
                }

                if (scanDC.TurnaroundId.HasValue)
                {
                    using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                    {
                        var turnaroundAr = TurnaroundAssignedRepository.New(workUnit);
                        var taAlreadyExists = turnaroundAr.Repository.Find(ta => (ta.TurnaroundParentId == newParentTurnaroundId.Value) &&
                                                                                 (ta.TurnaroundChildId == scanDC.TurnaroundId.Value)).FirstOrDefault();
                        if (taAlreadyExists == null)
                        {
                            turnaroundAr.Add(TurnaroundAssignedFactory.CreateEntity(workUnit,
                                turnaroundParentId: newParentTurnaroundId.Value,
                                turnaroundChildId: scanDC.TurnaroundId.Value
                            ));
                            turnaroundAr.Save();
                        }
                    }
                }
            }
            else
            {
                scanDC.ErrorCode = (int)ErrorCodes.NoParentTurnaroundId;
            }

            if (scanDC.Defects.Count > 0)
            {
                ApplyEvent(ApplyTurnaroundEventDetails.Create(TurnAroundEventTypeIdentifier.RemovedFromCarriage, true), scanDC, scanDetails);

                var quarantine = new Quarantine(_data);
                quarantine.PutIntoQuarantine(scanDC, scanDetails, (short)QuarantineReasonIdentifier.ServiceReportRaised);
            }
        }

        /// <summary>
        /// ValidateAssignToCarriage operation
        /// </summary>
        public bool ValidateAssignToCarriage(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            {
                ItemTypeIdentifier itemType = (ItemTypeIdentifier)scanDC.Asset.ItemTypeId;

                if (_data.EventTypeId == TurnAroundEventTypeIdentifier.AssignedToCarriage)
                {
                    CheckIfAlreadyAssigned(scanDC, scanDetails);
                }

                if (!scanDC.ErrorCode.HasValue) // Do some more validation
                {
                    if ((itemType == ItemTypeIdentifier.Carriage) || (itemType == ItemTypeIdentifier.BaseCarriage))
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.NoCarriagesOnACarriage;
                    }
                    else if (itemType == ItemTypeIdentifier.Trolley)
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.NoTrolleysOnACarriage;
                    }
                }

                if (!scanDC.ErrorCode.HasValue)
                {
                    ValidateAddToCarriageForProcessing(scanDC, scanDetails, workUnit);
                }
            }

            return !scanDC.ErrorCode.HasValue;
        }

        private static void ValidateAddToCarriageForProcessing(ScanAssetDataContract scanDC, ScanDetails scanDetails, IUnitOfWork workUnit)
        {
            var turnaroundRepository = TurnaroundRepository.New(workUnit);

            var carriageTurnaround = scanDetails.ParentTurnaroundId == null
                ? null
                : turnaroundRepository.Get(scanDetails.ParentTurnaroundId.Value);
            if (carriageTurnaround == null)
            {
                scanDC.ErrorCode = (int)ErrorCodes.NoParentTurnaroundId;
                return;
            }

            if (!scanDC.ErrorCode.HasValue)
            {
                ValidateCarriageMachineType(scanDC, carriageTurnaround);
            }
        }

        private static void ValidateCarriageMachineType(ScanAssetDataContract scanDC, Turnaround carriageTurnaround)
        {
            if (carriageTurnaround.ContainerMaster.MachineTypeId == scanDC.Asset.MachineTypeId)
            {
                return;
            }

            scanDC.ErrorCode = (int)ErrorCodes.MachineTypeMismatch;
            scanDC.Message = carriageTurnaround.ContainerMaster.MachineType.Text;
        }

        /// <summary>
        /// ValidateForCarriageCreated operation
        /// </summary>
        public static void ValidateForCarriageCreated(ScanAssetDataContract scannedAssetData)
        {
            var validMachineTypes = new[] { (int)MachineTypeIdentifier.Washer, (int)MachineTypeIdentifier.Post1997Washer };

            if (scannedAssetData.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.BaseCarriage)
            {
                scannedAssetData.ErrorCode = (int)ErrorCodes.ScannedWrongItemType;
            }
            else if (!validMachineTypes.Contains(scannedAssetData.Asset.MachineTypeId))
            {
                scannedAssetData.ErrorCode = (int)ErrorCodes.CarriagesCanOnlyBeUsedInAWasher;
                scannedAssetData.Message = ((MachineTypeIdentifier)scannedAssetData.Asset.MachineTypeId).ToString();
            }
        }
    }
}