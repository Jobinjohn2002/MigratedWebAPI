using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ProductionEventType
    /// </summary>
    public class ProductionEventType
    {
        public ProductionEventType(int productionEventTypeId, string text, int displayOrder)
        {
            ProductionEventTypeId = productionEventTypeId;
            Text = text;
            DisplayOrder = displayOrder;
        }

        /// <summary>
        /// Gets or sets ProductionEventTypeId
        /// </summary>
        public int ProductionEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }
        public static IList<ProductionEventType> Data = new List<ProductionEventType>()
        {
            new ProductionEventType(11, "Load Trolley", 0),
            new ProductionEventType(1, "Available For Collection", 1),
            new ProductionEventType(2, "Collected", 2),
            new ProductionEventType(3, "Inbound", 3),
            new ProductionEventType(16, "Decontamination", 4),
            new ProductionEventType(4, "Wash", 5),
            new ProductionEventType(5, "Wash Released", 6),
            new ProductionEventType(6, "Tray Prioritisation", 7),
            new ProductionEventType(13, "Inspection And Assembly", 8),
            new ProductionEventType(7, "Quality Assurance", 9),
            new ProductionEventType(8, "Into Autoclave", 10),
            new ProductionEventType(9, "Out of Autoclave", 11),
            new ProductionEventType(10, "Dispatch", 12),
            new ProductionEventType(12, "Wash In", 5)
        };

        /// <summary>
        /// MatchRerouteEventToProductionEventType operation
        /// </summary>
        public static int MatchRerouteEventToProductionEventType(int reRouteEventTypeId, bool isWashRelease)
        {
            var productionEventTypeId = 0;
            if (isWashRelease)
            {
                switch ((TurnAroundEventTypeIdentifier)reRouteEventTypeId)
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
                            productionEventTypeId = (int)ProductionEventTypeIdentifier.WashIn;
                            break;
                        }
                }
            }

            switch ((TurnAroundEventTypeIdentifier)reRouteEventTypeId)
            {
                case TurnAroundEventTypeIdentifier.WashIn:
                    {
                        productionEventTypeId = (int)ProductionEventTypeIdentifier.WashIn;
                        break;
                    }
                case TurnAroundEventTypeIdentifier.AvailableForCollection:
                    {
                        productionEventTypeId = (int)ProductionEventTypeIdentifier.AvailableForCollection;
                        break;
                    }
                case TurnAroundEventTypeIdentifier.Collected:
                    {
                        productionEventTypeId = (int)ProductionEventTypeIdentifier.Collected;
                        break;
                    }
                case TurnAroundEventTypeIdentifier.Inbound:
                    {
                        productionEventTypeId = (int)ProductionEventTypeIdentifier.Inbound;
                        break;
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
                        productionEventTypeId = (int)ProductionEventTypeIdentifier.Wash;
                        break;
                    }
                case TurnAroundEventTypeIdentifier.WashRelease:
                    {
                        productionEventTypeId = (int)ProductionEventTypeIdentifier.WashReleased;
                        break;
                    }
                case TurnAroundEventTypeIdentifier.TrayPrioritisation:
                    {
                        productionEventTypeId = (int)ProductionEventTypeIdentifier.TrayPrioritisation;
                        break;
                    }
                case TurnAroundEventTypeIdentifier.QualityAssurance:
                case TurnAroundEventTypeIdentifier.FailedQualityAssurance:
                    {
                        productionEventTypeId = (int)ProductionEventTypeIdentifier.QualityAssurance;
                        break;
                    }
                case TurnAroundEventTypeIdentifier.IntoAutoclave:
                case TurnAroundEventTypeIdentifier.FailBatchPreSteamInjectionWithReassign:
                case TurnAroundEventTypeIdentifier.FailBatchPreSteamInjectionWithoutReassign:
                case TurnAroundEventTypeIdentifier.FailBatchPostSteamInjection:
                case TurnAroundEventTypeIdentifier.FailBatchPostNonSteamInjection:
                case TurnAroundEventTypeIdentifier.FailBatchPreNonSteamInjectionWithoutReassign:
                case TurnAroundEventTypeIdentifier.FailBatchPreNonSteamInjectionWithReassign:
                    {
                        productionEventTypeId = (int)ProductionEventTypeIdentifier.IntoAutoclave;
                        break;
                    }
                case TurnAroundEventTypeIdentifier.OutofAutoclave:
                case TurnAroundEventTypeIdentifier.BrokenPack:
                case TurnAroundEventTypeIdentifier.WetPack:
                    {
                        productionEventTypeId = (int)ProductionEventTypeIdentifier.OutOfAutoclave;
                        break;
                    }
                case TurnAroundEventTypeIdentifier.Dispatch:
                case TurnAroundEventTypeIdentifier.AddedToTrolley:
                case TurnAroundEventTypeIdentifier.RemovedFromTrolley:
                    {
                        productionEventTypeId = (int)ProductionEventTypeIdentifier.Dispatch;
                        break;
                    }
                case TurnAroundEventTypeIdentifier.LoadTrolleyEPOC:
                    {
                        productionEventTypeId = (int)ProductionEventTypeIdentifier.LoadTrolley;
                        break;
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
                        productionEventTypeId = (int)ProductionEventTypeIdentifier.InspectionAndAssembly;
                        break;
                    }
                case TurnAroundEventTypeIdentifier.DeconStart:
                case TurnAroundEventTypeIdentifier.DeconEnd:
                case TurnAroundEventTypeIdentifier.DeconCancel:
                    {
                        productionEventTypeId = (int)ProductionEventTypeIdentifier.Decontamination;
                        break;
                    }
            }

            return productionEventTypeId;
        }
    }
}
