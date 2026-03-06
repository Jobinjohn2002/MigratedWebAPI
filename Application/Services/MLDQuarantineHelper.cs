using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class MLDQuarantineHelper
    {
        /// <summary>
        /// If we attempt to create a new turnaround of a draft tray, we will replace the intended start event with "AutomaticStart",
        /// with the intention of putting into quarantine afterwards with <see cref="CheckAutoQuarantineForDraft"/>.
        /// </summary>
        /// <summary>
        /// CheckSetScanToAutoQuarantineForDraft operation
        /// </summary>
        public static bool CheckSetScanToAutoQuarantineForDraft(SynergyTrakData mk3Data, ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (scanDC.Asset.QualityType == QualityTypeIdentifier.Draft && mk3Data.EventTypeId != TurnAroundEventTypeIdentifier.Inbound)
            {
                scanDC.EventTypeId = TurnAroundEventTypeIdentifier.AutomaticStart;
                mk3Data.EventTypeId = TurnAroundEventTypeIdentifier.AutomaticStart;
                scanDetails.Events.Clear();
                scanDetails.Events.Add(new ScanEventDataContract() { EventType = (int)TurnAroundEventTypeIdentifier.AutomaticStart });
             
                return true;
            }
            return false;
        }

        /// <summary>
        /// If we have a draft tray whose event type is AutomaticStart, we can assume that we need to put it directly into quarantine.
        /// </summary>
        /// <summary>
        /// CheckAutoQuarantineForDraft operation
        /// </summary>
        public static void CheckAutoQuarantineForDraft(SynergyTrakData mk3Data, ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (scanDC.Asset.QualityType == QualityTypeIdentifier.Draft && mk3Data.EventTypeId == TurnAroundEventTypeIdentifier.AutomaticStart)
            {
                new Quarantine(mk3Data).PutIntoQuarantine(scanDC, scanDetails, (short)QuarantineReasonIdentifier.ImportedDraft);
                scanDC.Warnings.Add(
                    new WarningDataContract() {
                        InternalMessage  = "DraftIntoQuarantine",
                        WarningOnly = true,
                        ContainerInstancePrimaryId=scanDetails.ExternalId,
                        ErrorCode = (int)ErrorCodes.DraftTrayAutoQuarantined}) ;
            }
        }

        /// <summary>
        /// If we scan a draft tray at Inbound, then we expect it to work slightly differently to the typical new turnaround behaviour, 
        /// as we wish to still successfully record the Inbound event (instead of it being replaced).
        /// </summary>
        /// <summary>
        /// CheckAutoQuarantineAfterInbound operation
        /// </summary>
        public static bool CheckAutoQuarantineAfterInbound(SynergyTrakData mk3Data, ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (scanDC.Asset.QualityType == QualityTypeIdentifier.Draft)
            {
                new Quarantine(mk3Data).PutIntoQuarantine(scanDC, scanDetails, (short)QuarantineReasonIdentifier.ImportedDraft);

                scanDC.Warnings.Add(
                    new WarningDataContract() { 
                        InternalMessage = "DraftIntoQuarantineInbound" ,
                        WarningOnly = true,
                        ContainerInstancePrimaryId = scanDetails.ExternalId,
                        ErrorCode = (int)ErrorCodes.DraftTrayAutoQuarantined
                    });
                return true;
            }

            return false;
        }

    }
}