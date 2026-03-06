using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum EventTypeStatus : short
    {
        InProcess = 0,
        Quarantine = 10,
        AwaitingDispatch = 20,
        Dispatched = 30,
        Stock = 40,
        OnOrder = 50,
        Expired = 60,
        AutomaticDelivery = 70,
        InTransit = 80,
        RemovedFromProduction = 100,
        New = -1 // dummy value to handle container instances that have no turnarounds. T6612 Indy
    }

    public static class EventTypeExtensions
    {
        private static readonly KnownTurnaroundEventType[] EventTypesToExcludeFacilityName = new KnownTurnaroundEventType[]
        {
             KnownTurnaroundEventType.DeliveryNotePrint,
             KnownTurnaroundEventType.LoadTrolleyEPOD,
             KnownTurnaroundEventType.RemovedFromDryingCabinetWet,
             KnownTurnaroundEventType.RemovedFromDryingCabinetDry,
             KnownTurnaroundEventType.VacuumPacked,
             KnownTurnaroundEventType.VacuumPackedWet,
             KnownTurnaroundEventType.VacuumPackedDry,
             KnownTurnaroundEventType.ManualProofofDelivery,
             KnownTurnaroundEventType.Delivered,
             KnownTurnaroundEventType.IntoPigeonHoleStock,
             KnownTurnaroundEventType.OutOfPigeonHoleStock,
             KnownTurnaroundEventType.RemovedFromOrder,
             KnownTurnaroundEventType.AutomaticDelivery,
             KnownTurnaroundEventType.Archived,
             KnownTurnaroundEventType.AddedToOrder,
             KnownTurnaroundEventType.OrderShipped,
             KnownTurnaroundEventType.LoadTrolleyEPOC,
             KnownTurnaroundEventType.LoadTrolleyEPOD,
             KnownTurnaroundEventType.Collected,
             KnownTurnaroundEventType.AutomaticCollection,
             KnownTurnaroundEventType.AvailableForCollection,
             KnownTurnaroundEventType.RemovedFromDryingCabinetExpired,
             KnownTurnaroundEventType.InTransit,
             KnownTurnaroundEventType.CancelTransit,
             KnownTurnaroundEventType.OfflineTransit,
             KnownTurnaroundEventType.OfflineTransitCancelled
        };

        public static int[] EventTypesToExcludeFacilityList
        {
            get
            {
                return EventTypesToExcludeFacilityName.Select(x => (int)x).ToArray();
            }
        }

        /// <summary>
        /// ToStatus operation
        /// </summary>
        public static EventTypeStatus ToStatus(short eventTypeID)
        {
            if (!Enum.IsDefined(typeof(KnownTurnaroundEventType), eventTypeID))
                return EventTypeStatus.InProcess;

            return ToStatus((KnownTurnaroundEventType)eventTypeID);
        }

        /// <summary>
        /// IsEPOC operation
        /// </summary>
        public static bool IsEPOC(short eventTypeID)
        {
            if (!Enum.IsDefined(typeof(KnownTurnaroundEventType), eventTypeID))
                return false;

            return IsEpoc((KnownTurnaroundEventType)eventTypeID);
        }

        /// <summary>
        /// IsEPOC operation
        /// </summary>
        public static bool IsEPOC(this EventType eventType)
        {
            if (eventType == null || !Enum.IsDefined(typeof(KnownTurnaroundEventType), eventType.EventTypeId))
                return false;

            return IsEPOC(eventType.EventTypeId);
        }

        /// <summary>
        /// IsEpoc operation
        /// </summary>
        public static bool IsEpoc(KnownTurnaroundEventType eventType)
        {
            switch (eventType)
            {
                case KnownTurnaroundEventType.LoadTrolleyEPOC:
                case KnownTurnaroundEventType.LoadTrolleyEPOD:
                case KnownTurnaroundEventType.Collected:
                case KnownTurnaroundEventType.AutomaticCollection:
                case KnownTurnaroundEventType.AvailableForCollection:
                    return true;

                default:
                    return false;
            }
        }

        private static EventTypeStatus ToStatus(KnownTurnaroundEventType eventType)
        {
            var status = EventTypeStatus.InProcess;

            switch (eventType)
            {
                case KnownTurnaroundEventType.Dispatch:
                case KnownTurnaroundEventType.RemovedFromDeliveryNote:
                case KnownTurnaroundEventType.IntoDryingCabinet:
                case KnownTurnaroundEventType.AddedToTrolley:
                case KnownTurnaroundEventType.RemovedFromTrolley:
                    status = EventTypeStatus.AwaitingDispatch;
                    break;

                case KnownTurnaroundEventType.CancelTransit:
                case KnownTurnaroundEventType.OfflineTransitCancelled:
                case KnownTurnaroundEventType.DeliveryNotePrint:
                case KnownTurnaroundEventType.LoadTrolleyEPOD:
                case KnownTurnaroundEventType.RemovedFromDryingCabinetWet:
                case KnownTurnaroundEventType.RemovedFromDryingCabinetDry:
                case KnownTurnaroundEventType.VacuumPacked:
                case KnownTurnaroundEventType.VacuumPackedWet:
                case KnownTurnaroundEventType.VacuumPackedDry:
                    status = EventTypeStatus.Dispatched;
                    break;

                case KnownTurnaroundEventType.IntoQuarantine:
                    status = EventTypeStatus.Quarantine;
                    break;

                case KnownTurnaroundEventType.ManualProofofDelivery:
                case KnownTurnaroundEventType.Delivered:
                case KnownTurnaroundEventType.IntoPigeonHoleStock:
                case KnownTurnaroundEventType.OutOfPigeonHoleStock:
                case KnownTurnaroundEventType.RemovedFromOrder:
                    status = EventTypeStatus.Stock;
                    break;

                case KnownTurnaroundEventType.New:
                    status = EventTypeStatus.New;
                    break;

                case KnownTurnaroundEventType.Archived:
                    status = EventTypeStatus.RemovedFromProduction;
                    break;

                case KnownTurnaroundEventType.AddedToOrder:
                case KnownTurnaroundEventType.OrderShipped:
                    status = EventTypeStatus.OnOrder;
                    break;

                case KnownTurnaroundEventType.RemovedFromDryingCabinetExpired:
                    status = EventTypeStatus.Expired;
                    break;

                case KnownTurnaroundEventType.AutomaticDelivery:
                    status = EventTypeStatus.AutomaticDelivery;
                    break;

                case KnownTurnaroundEventType.InTransit:
                case KnownTurnaroundEventType.OfflineTransit:
                    status = EventTypeStatus.InTransit;
                    break;
            }

            return status;
        }

        /// <summary>
        /// ToStatus operation
        /// </summary>
        public static EventTypeStatus ToStatus(this EventType eventType)
        {
            const EventTypeStatus status = EventTypeStatus.InProcess;

            if (eventType == null || !Enum.IsDefined(typeof(KnownTurnaroundEventType), eventType.EventTypeId))
                return status;

            return ToStatus((KnownTurnaroundEventType)(eventType.EventTypeId));
        }

        /// <summary>
        /// GetEventTypesForStatus operation
        /// </summary>
        public static List<KnownTurnaroundEventType> GetEventTypesForStatus(EventTypeStatus status)
        {
            List<KnownTurnaroundEventType> events = new List<KnownTurnaroundEventType>();

            switch (status)
            {
                case EventTypeStatus.InProcess:
                    events = new List<KnownTurnaroundEventType>{
                        KnownTurnaroundEventType.Unknown,
                        KnownTurnaroundEventType.Inbound,
                        KnownTurnaroundEventType.Wash,
                        KnownTurnaroundEventType.TrayPrioritisation,
                        KnownTurnaroundEventType.PackingFinished,
                        KnownTurnaroundEventType.QualityAssurance,
                        KnownTurnaroundEventType.IntoAutoclave,
                        KnownTurnaroundEventType.OutofAutoclave,
                        KnownTurnaroundEventType.ReprintTrayList,
                        KnownTurnaroundEventType.FailedAutoclave,
                        KnownTurnaroundEventType.PackingStarted,
                        KnownTurnaroundEventType.IntoStock,
                        KnownTurnaroundEventType.OutOfStock,
                        KnownTurnaroundEventType.InboundWithIncorrectSpecification,
                        KnownTurnaroundEventType.PassWarning,
                        KnownTurnaroundEventType.OutOfQuarantine,
                        KnownTurnaroundEventType.Addedtosummary,
                        KnownTurnaroundEventType.FailedWash,
                        KnownTurnaroundEventType.FailedQualityAssurance,
                        KnownTurnaroundEventType.OverrideCooldown,
                        KnownTurnaroundEventType.FacilityOpen,
                        KnownTurnaroundEventType.FacilityClose,
                        KnownTurnaroundEventType.AvailableForCollection,
                        KnownTurnaroundEventType.Collected,
                        KnownTurnaroundEventType.Inspection,
                        KnownTurnaroundEventType.Rewash,
                        KnownTurnaroundEventType.Repair,
                        KnownTurnaroundEventType.ToBeCondemned,
                        KnownTurnaroundEventType.SendForReinspection,
                        KnownTurnaroundEventType.AssistedInspection,
                        KnownTurnaroundEventType.Respot,
                        KnownTurnaroundEventType.OnOrder,
                        KnownTurnaroundEventType.NonSteamSterilisation,
                        KnownTurnaroundEventType.LoadTrolleyEPOC,
                        KnownTurnaroundEventType.ReturnFromQuarantine,
                        KnownTurnaroundEventType.Transfer,
                        KnownTurnaroundEventType.ServiceRequirementChange,
                        KnownTurnaroundEventType.ReprintLabel,
                        KnownTurnaroundEventType.EndPacking,
                        KnownTurnaroundEventType.PackingCancelled,
                        KnownTurnaroundEventType.QuarantineOverride,
                        KnownTurnaroundEventType.IntoWash,
                        KnownTurnaroundEventType.WetPack,
                        KnownTurnaroundEventType.BrokenPack,
                        KnownTurnaroundEventType.MissingInstrument,
                        KnownTurnaroundEventType.ReceiveStock,
                        KnownTurnaroundEventType.IssuedtoEndUser,
                        KnownTurnaroundEventType.ReturnedfromEndUser,
                        KnownTurnaroundEventType.UNPack,
                        KnownTurnaroundEventType.PrintDecontaminationCertificate,
                        KnownTurnaroundEventType.CustomerDefectRaised,
                        KnownTurnaroundEventType.CustomerDefectResponded,
                        KnownTurnaroundEventType.CustomerDefectClosed,
                        KnownTurnaroundEventType.CustomerDefectReopen,
                        KnownTurnaroundEventType.ConfirmedAsSterile,
                        KnownTurnaroundEventType.AcknowledgeNote,
                        KnownTurnaroundEventType.IndependentSecondCheckRequired,
                        KnownTurnaroundEventType.RemovedFromBatch,
                        KnownTurnaroundEventType.FailBatchPreSteamInjectionWithReassign,
                        KnownTurnaroundEventType.FailBatchPostSteamInjection,
                        KnownTurnaroundEventType.FailBatchPreSteamInjectionWithoutReassign,
                        KnownTurnaroundEventType.ReassignBatch,
                        KnownTurnaroundEventType.WashProcessCreated,
                        KnownTurnaroundEventType.AssigntoWashProcessTag,
                        KnownTurnaroundEventType.WashRequireRelease,
                        KnownTurnaroundEventType.WashRelease,
                        KnownTurnaroundEventType.LegacyInstanceBarcodeReplaced,
                        KnownTurnaroundEventType.FailedWashReleaseRequired,
                        KnownTurnaroundEventType.FailedPacking,
                        KnownTurnaroundEventType.ReprintInstanceBarcode,
                        KnownTurnaroundEventType.PartWash,
                        KnownTurnaroundEventType.ReprintedDeliveryNote,
                        KnownTurnaroundEventType.AssignToBatchTag,
                        KnownTurnaroundEventType.RemoveFromBatchTag,
                        KnownTurnaroundEventType.RemovedFromInvoice,
                        KnownTurnaroundEventType.BatchTagCreated,
                        KnownTurnaroundEventType.RemoveFromWashProcessTag,
                        KnownTurnaroundEventType.AutomaticCollection,
                        KnownTurnaroundEventType.AutomaticInbound,
                        KnownTurnaroundEventType.EndTrayPrioritisation,
                        KnownTurnaroundEventType.Packing,
                        KnownTurnaroundEventType.RewashStickyResidue,
                        KnownTurnaroundEventType.RewashStain,
                        KnownTurnaroundEventType.AssignedToCarriage,
                        KnownTurnaroundEventType.RemovedFromCarriage,
                        KnownTurnaroundEventType.WashIn,
                        KnownTurnaroundEventType.ChangedBatch,
                        KnownTurnaroundEventType.BiologicalIndicatorFailed,
                        KnownTurnaroundEventType.RerouteToQuarantine,
                        KnownTurnaroundEventType.RerouteToWash,
                        KnownTurnaroundEventType.RerouteToTrayPrioritisation,
                        KnownTurnaroundEventType.RerouteToInspectionAndAssembly,
                        KnownTurnaroundEventType.RerouteToQualityAssurance,
                        KnownTurnaroundEventType.RerouteToIntoAutoclave,
                        KnownTurnaroundEventType.RerouteToDispatch,
                        KnownTurnaroundEventType.AddedToTransferNote,
                        KnownTurnaroundEventType.RemovedFromTransferNote,
                        KnownTurnaroundEventType.FacilityTransferOutbound,
                        KnownTurnaroundEventType.FacilityTransferInbound,
                        KnownTurnaroundEventType.AddToSurgicalProcedure,
                        KnownTurnaroundEventType.RemovedFromSurgicalProcedure,
                        KnownTurnaroundEventType.AutomaticStart,
                        KnownTurnaroundEventType.WeightRecordedPreWash,
                        KnownTurnaroundEventType.WeightRecordedPostWash,
                        KnownTurnaroundEventType.SpecificationChanged,
                        KnownTurnaroundEventType.BiologicalIndicatorIncubationFailure,
                        KnownTurnaroundEventType.DispatchImmediateUse,
                        KnownTurnaroundEventType.OfflineCollected,
                        KnownTurnaroundEventType.OfflineDelivered,
                        KnownTurnaroundEventType.FailWashIn,
                        KnownTurnaroundEventType.BillingPoint,
                        KnownTurnaroundEventType.PreAerDeconTaskSuccess,
                        KnownTurnaroundEventType.PreAerDeconTaskFailure,
                        KnownTurnaroundEventType.AssignedToAer,
                        KnownTurnaroundEventType.RemovedFromAer,
                        KnownTurnaroundEventType.AerStart,
                        KnownTurnaroundEventType.AerPassed,
                        KnownTurnaroundEventType.AerFailed,
                        KnownTurnaroundEventType.RemovedFromDryingCabinetAutomatic,
                        KnownTurnaroundEventType.FailedBatchPreNonSteamInjection,
                        KnownTurnaroundEventType.FailedBatchPostNonSteamInjection,
                        KnownTurnaroundEventType.FailedBatchPreNonSteamInjectionWithoutReassign,
                        KnownTurnaroundEventType.TrolleyStarted,
                        KnownTurnaroundEventType.TrolleyStopped
                    };
                    break;

                case EventTypeStatus.Quarantine:
                    events = new List<KnownTurnaroundEventType>{
                        KnownTurnaroundEventType.IntoQuarantine
                    };
                    break;

                case EventTypeStatus.AwaitingDispatch:
                    events = new List<KnownTurnaroundEventType>{
                        KnownTurnaroundEventType.Dispatch,
                        KnownTurnaroundEventType.RemovedFromDeliveryNote,
                        KnownTurnaroundEventType.IntoDryingCabinet,
                        KnownTurnaroundEventType.AddedToTrolley,
                        KnownTurnaroundEventType.RemovedFromTrolley
                    };
                    break;

                case EventTypeStatus.Dispatched:
                    events = new List<KnownTurnaroundEventType>{
                        KnownTurnaroundEventType.CancelTransit,
                        KnownTurnaroundEventType.OfflineTransitCancelled,
                        KnownTurnaroundEventType.DeliveryNotePrint,
                        KnownTurnaroundEventType.LoadTrolleyEPOD,
                        KnownTurnaroundEventType.RemovedFromDryingCabinetWet,
                        KnownTurnaroundEventType.RemovedFromDryingCabinetDry,
                        KnownTurnaroundEventType.VacuumPacked,
                        KnownTurnaroundEventType.VacuumPackedWet,
                        KnownTurnaroundEventType.VacuumPackedDry
                    };
                    break;

                case EventTypeStatus.Stock:
                    events = new List<KnownTurnaroundEventType>{
                        KnownTurnaroundEventType.ManualProofofDelivery,
                        KnownTurnaroundEventType.Delivered,
                        KnownTurnaroundEventType.IntoPigeonHoleStock,
                        KnownTurnaroundEventType.OutOfPigeonHoleStock,
                        KnownTurnaroundEventType.RemovedFromOrder
                    };
                    break;

                case EventTypeStatus.OnOrder:
                    events = new List<KnownTurnaroundEventType>{
                        KnownTurnaroundEventType.AddedToOrder,
                        KnownTurnaroundEventType.OrderShipped
                    };
                    break;

                case EventTypeStatus.Expired:
                    events = new List<KnownTurnaroundEventType>{
                        KnownTurnaroundEventType.RemovedFromDryingCabinetExpired,
                    };
                    break;

                case EventTypeStatus.RemovedFromProduction:
                    events = new List<KnownTurnaroundEventType>{
                        KnownTurnaroundEventType.Archived
                    };
                    break;

                case EventTypeStatus.New:
                    events = new List<KnownTurnaroundEventType>{
                        KnownTurnaroundEventType.New
                    };
                    break;

                case EventTypeStatus.AutomaticDelivery:
                    events = new List<KnownTurnaroundEventType>{
                        KnownTurnaroundEventType.AutomaticDelivery
                    };
                    break;

                case EventTypeStatus.InTransit:
                    events = new List<KnownTurnaroundEventType>{
                        KnownTurnaroundEventType.InTransit,
                        KnownTurnaroundEventType.OfflineTransit
                    };
                    break;

                default:
                    break;
            }

            return events;
        }
    }
}
