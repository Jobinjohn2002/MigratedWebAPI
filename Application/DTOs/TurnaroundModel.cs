using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum TurnaroundActionFeedback
    {
        None = 0,
        IntoStockSuccess = 1,
        IntoStockError = 2,
        UsageExists = 3,
        UsageSuccess = 4
    }

    public enum TurnaroundModelTab
    {
        Details = 0,
        Tracking = 1,
        Usage = 2
    }

    /// <summary>
    /// TurnaroundModel
    /// </summary>
    public class TurnaroundModel
    {
        public TurnaroundModel()
        {
            EditUsage = new TurnaroundUsageModel();
        }

        /// <summary>
        /// Gets or sets Turnaround
        /// </summary>
        public Turnaround Turnaround { get; set; }

        /// <summary>
        /// Gets or sets SelectedTab
        /// </summary>
        public TurnaroundModelTab SelectedTab { get; set; }

        /// <summary>
        /// Gets or sets StoragePoints
        /// </summary>
        public List<StoragePoint> StoragePoints { get; set; }

        /// <summary>
        /// Gets or sets AvailableForIntoStock
        /// </summary>
        public bool AvailableForIntoStock { get; set; }

        /// <summary>
        /// Gets or sets EditUsage
        /// </summary>
        public TurnaroundUsageModel EditUsage { get; set; }

        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public TurnaroundActionFeedback Confirmation { get; set; }

        /// <summary>
        /// Gets or sets StoragePointsDropDownItems
        /// </summary>
        public List<GroupedListItem> StoragePointsDropDownItems { get; set; }

        /// <summary>
        /// Gets or sets IsProcessEvent
        /// </summary>
        public bool IsProcessEvent { get; set; }

        /// <summary>
        /// Gets or sets canRaiseServiceReport
        /// </summary>
        public bool canRaiseServiceReport { get; set; }

        /// <summary>
        /// Gets or sets Defects
        /// </summary>
        public List<Defect> Defects { get; set; }

        /// <summary>
        /// Gets or sets CustomerDefects
        /// </summary>
        public List<CustomerDefect> CustomerDefects { get; set; }

        /// <summary>
        /// Gets or sets isBestPractice
        /// </summary>
        public bool isBestPractice { get; set; }

        /// <summary>
        /// Gets or sets CanSearchSimilar
        /// </summary>
        public bool CanSearchSimilar { get; set; }

        /// <summary>
        /// GetStatus operation
        /// </summary>
        public string GetStatus(ITranslator translator)
        {
            const string group = "enum";
            const string section = "EventTypeStatus";

            if (Turnaround == null)
                return translator.GetText(group, section, "null");

            var latest = TurnaroundEventExtensions.OrderByTimeThenEvent(Turnaround.TurnaroundEvents.Where(t => t.EventType.ProcessEvent)).FirstOrDefault();

            if (latest == null)
                return translator.GetText(group, section, "null");

            if (latest.EventType.ToStatus().ToString() == EventTypeStatus.InProcess.ToString())
                IsProcessEvent = true;

            if (latest.EventType.ToStatus().ToString() == EventTypeStatus.Dispatched.ToString()
                || latest.EventType.ToStatus().ToString() == EventTypeStatus.Stock.ToString()
                || latest.EventType.ToStatus().ToString() == EventTypeStatus.InTransit.ToString()
                || latest.EventType.ToStatus().ToString() == EventTypeStatus.AutomaticDelivery.ToString())
                canRaiseServiceReport = true;

            return translator.GetText(group, section, latest.EventType.ToStatus().ToString("G"));
        }

        /// <summary>
        /// GetCurrentStockLocationName operation
        /// </summary>
        public string GetCurrentStockLocationName(ITranslator translator)
        {
            if (Turnaround == null)
                return string.Empty;

            var latest = TurnaroundEventExtensions.OrderByTimeThenEvent(Turnaround.TurnaroundEvents.Where(t => t.EventType.ProcessEvent)).FirstOrDefault();

            if (latest == null)
                return string.Empty;

            if ((KnownTurnaroundEventType)latest.EventType.EventTypeId != KnownTurnaroundEventType.IntoPigeonHoleStock)
                return string.Empty;

            return " - " + translator.GetTerm("Location") + ": " + latest.Location?.Text;
        }

        /// <summary>
        /// Gets or sets SurgicalProcedures
        /// </summary>
        public List<SurgicalProcedure> SurgicalProcedures { get; set; }

        /// <summary>
        /// Gets or sets Orders
        /// </summary>
        public List<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets MaintenanceReports
        /// </summary>
        public List<MaintenanceReport> MaintenanceReports { get; set; }

        /// <summary>
        /// Gets or sets HasBiologicalIndicator
        /// </summary>
        public bool HasBiologicalIndicator { get; set; }

        public bool? BiologicalIndicatorResult { get; set; }

        public List<ItemComponentModel> ItemComponentList {get; set;}
    }
}