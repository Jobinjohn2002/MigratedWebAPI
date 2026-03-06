using System;
using System.Collections.Generic;
using System.Linq;
using SynergyApplicationFrameworkApi.Application.Services;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Stock
    /// </summary>
    public class Stock : BasicTurnaroundEvents
    {
        public Stock(SynergyTrakData data) : base(data)
        {
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.IntoPigeonHoleStock)]
        /// <summary>
        /// IntoPigeonHoleStock operation
        /// </summary>
        public void IntoPigeonHoleStock(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            var storagePointId = scanDC.StoragePointId;

            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var storagePointRepository = StoragePointRepository.New(workUnit);
                var storagePoint = storagePointId.HasValue ? storagePointRepository.Get(storagePointId.Value) : null;
                _data.StoragePointLocationId = storagePoint?.LocationId;
            }

            foreach (var saDc in _data.ScanDcList)
            {
                List<ApplyTurnaroundEventDetails> eventsToApply = new List<ApplyTurnaroundEventDetails>();
                if (saDc.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.LoadTrolleyEPOD)
                {
                    eventsToApply.Add(new ApplyTurnaroundEventDetails()
                    {
                        EventType = TurnAroundEventTypeIdentifier.AutomaticDelivery,
                        UseDeliveryNoteIdFromScanDc = true,
                        LocationId = scanDC.LocationId,
                        IsAutomaticEvent = true
                    });

                    saDc.StoragePointId = null;
                }

                if ((saDc.Asset.ContainerInstanceId.HasValue || _data.IntoPidgeonHoleStockExtras) && !saDc.HasChildren && saDc.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.Trolley)
                {
                    eventsToApply.Add(new ApplyTurnaroundEventDetails()
                    {
                        EventType = TurnAroundEventTypeIdentifier.IntoPigeonHoleStock,
                        ParentTurnaroundId = scanDetails.ParentTurnaroundId,
                        LocationId = _data.StoragePointLocationId,
                        UseDeliveryNoteIdFromScanDc = true,
                        RemoveFromParent = (scanDetails.BaseItemTypeId != (int)ItemTypeIdentifier.Trolley)
                    });

                    saDc.StoragePointId = storagePointId;
                }

                if (eventsToApply.Any())
                {
                    ApplyEvent(eventsToApply, saDc, scanDetails);
                }
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.OutOfPigeonHoleStock)]
        /// <summary>
        /// OutOfPigeonHoleStock operation
        /// </summary>
        public void OutOfPigeonHoleStock(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            ApplyEvent(new ApplyTurnaroundEventDetails { EventType = _data.EventTypeId, ParentTurnaroundId = scanDetails.ParentTurnaroundId, UseDeliveryNoteIdFromScanDc = true }, scanDetails);
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.OutOfStock)]
        /// <summary>
        /// OutOfStock operation
        /// </summary>
        public void OutOfStock(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.OutOfStock }, scanDetails);
        }
    }
}