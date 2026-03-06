using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class EventType
    {
        /// <summary>
        /// The number of turnarounds
        /// </summary>
        /// <summary>
        /// Gets or sets TurnaroundCount
        /// </summary>
        public int TurnaroundCount { get; set; }

        public int? ProductionEventTypeId(bool washReleaseEnabled)
        {
            if (washReleaseEnabled)
            {
                switch ((TurnAroundEventTypeIdentifier)EventTypeId)
                {
                    case TurnAroundEventTypeIdentifier.Wash:
                    case TurnAroundEventTypeIdentifier.WashIn:
                    case TurnAroundEventTypeIdentifier.PartWash:
                    case TurnAroundEventTypeIdentifier.AssignedToCarriage:
                    case TurnAroundEventTypeIdentifier.AssignToBatchTag:
                    case TurnAroundEventTypeIdentifier.RemovedFromCarriage:
                    case TurnAroundEventTypeIdentifier.RemoveFromBatchTag:
                    case TurnAroundEventTypeIdentifier.FailedWash:
                    case TurnAroundEventTypeIdentifier.RestartWash:
                        {
                            return (int)ProductionEventTypeIdentifier.WashIn;
                        }
                }
            }

            switch ((TurnAroundEventTypeIdentifier)EventTypeId)
            {
                case TurnAroundEventTypeIdentifier.WashIn:
                    {
                        return (int)ProductionEventTypeIdentifier.WashIn;
                    }
                case TurnAroundEventTypeIdentifier.AvailableForCollection:
                    {
                        return (int)ProductionEventTypeIdentifier.AvailableForCollection;
                    }
                case TurnAroundEventTypeIdentifier.Collected:
                    {
                        return (int)ProductionEventTypeIdentifier.Collected;
                    }
                case TurnAroundEventTypeIdentifier.Inbound:
                case TurnAroundEventTypeIdentifier.AutomaticStart:
                    {
                        return (int)ProductionEventTypeIdentifier.Inbound;
                    }
                case TurnAroundEventTypeIdentifier.Wash:
                case TurnAroundEventTypeIdentifier.AssigntoWashProcessTag:
                case TurnAroundEventTypeIdentifier.RemoveFromWashProcessTag:
                case TurnAroundEventTypeIdentifier.WashRequireRelease:
                case TurnAroundEventTypeIdentifier.FailedWash:
                case TurnAroundEventTypeIdentifier.PartWash:
                case TurnAroundEventTypeIdentifier.WashProcessCreated:
                case TurnAroundEventTypeIdentifier.RestartWash:
                    {
                        return (int)ProductionEventTypeIdentifier.Wash;
                    }
                case TurnAroundEventTypeIdentifier.WashRelease:
                    {
                        return (int)ProductionEventTypeIdentifier.WashReleased;
                    }
                case TurnAroundEventTypeIdentifier.TrayPrioritisation:
                    {
                        return (int)ProductionEventTypeIdentifier.TrayPrioritisation;
                    }
                case TurnAroundEventTypeIdentifier.QualityAssurance:
                case TurnAroundEventTypeIdentifier.FailedQualityAssurance:
                    {
                        return (int)ProductionEventTypeIdentifier.QualityAssurance;
                    }
                case TurnAroundEventTypeIdentifier.IntoAutoclave:
                case TurnAroundEventTypeIdentifier.FailBatchPreSteamInjectionWithReassign:
                case TurnAroundEventTypeIdentifier.FailBatchPreSteamInjectionWithoutReassign:
                case TurnAroundEventTypeIdentifier.FailBatchPostSteamInjection:
                case TurnAroundEventTypeIdentifier.FailBatchPostNonSteamInjection:
                case TurnAroundEventTypeIdentifier.FailBatchPreNonSteamInjectionWithoutReassign:
                case TurnAroundEventTypeIdentifier.FailBatchPreNonSteamInjectionWithReassign:
                    {
                        return (int)ProductionEventTypeIdentifier.IntoAutoclave;
                    }
                case TurnAroundEventTypeIdentifier.OutofAutoclave:
                case TurnAroundEventTypeIdentifier.BrokenPack:
                case TurnAroundEventTypeIdentifier.WetPack:
                    {
                        return (int)ProductionEventTypeIdentifier.OutOfAutoclave;
                    }
                case TurnAroundEventTypeIdentifier.Dispatch:
                case TurnAroundEventTypeIdentifier.AddedToTrolley:
                case TurnAroundEventTypeIdentifier.RemovedFromTrolley:
                    {
                        return (int)ProductionEventTypeIdentifier.Dispatch;
                    }
                case TurnAroundEventTypeIdentifier.LoadTrolleyEPOC:
                    {
                        return (int)ProductionEventTypeIdentifier.LoadTrolley;
                    }
                case TurnAroundEventTypeIdentifier.StartPacking:
                case TurnAroundEventTypeIdentifier.FinishPacking:
                case TurnAroundEventTypeIdentifier.CancelPacking:
                case TurnAroundEventTypeIdentifier.FailPacking:
                case TurnAroundEventTypeIdentifier.PackingProcessEnded:
                case TurnAroundEventTypeIdentifier.Reviewed:
                case TurnAroundEventTypeIdentifier.ReviewCancelled:
                case TurnAroundEventTypeIdentifier.ReviewNeeded:
                    {
                        return (int)ProductionEventTypeIdentifier.InspectionAndAssembly;
                    }
                case TurnAroundEventTypeIdentifier.DeconStart:
                case TurnAroundEventTypeIdentifier.DeconEnd:
                case TurnAroundEventTypeIdentifier.DeconCancel:
                    {
                        return (int)ProductionEventTypeIdentifier.Decontamination;
                    }
                case TurnAroundEventTypeIdentifier.IntoQuarantine:
                    {
                        return (int)ProductionEventTypeIdentifier.IntoQuarantine;
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
