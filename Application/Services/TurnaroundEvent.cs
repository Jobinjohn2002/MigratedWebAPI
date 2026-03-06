using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class TurnaroundEventExtensions
    {
        /// <summary>
        /// OrderByTimeThenEvent operation
        /// </summary>
        public static IQueryable<TurnaroundEvent> OrderByTimeThenEvent(IEnumerable<TurnaroundEvent> turnaroundEvents)
        {
            var turnaroundEventReOrder = turnaroundEvents.OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId);
            return turnaroundEventReOrder.AsQueryable();

        }

        /// <summary>
        /// AdditionalInformation operation
        /// </summary>
        public static string AdditionalInformation(this TurnaroundEvent turnaroundEvent, ITranslator translator)
        {
            var additionalDetail = string.Empty;

            if (turnaroundEvent.Batch != null)
            {
                switch (turnaroundEvent.EventTypeId)
                {
                    case (int)TurnAroundEventTypeIdentifier.PreAerDeconTaskFailure:
                        return string.Format(translator.GetText("pages", "services.turnaround.details", "Failed Task"), turnaroundEvent.Batch.BatchDecontaminationTask.First().DecontaminationTask.Text);

                    case (int)TurnAroundEventTypeIdentifier.PreAerDeconTaskSuccess:
                        return string.Format(translator.GetText("pages", "services.turnaround.details", "Passed Task"), turnaroundEvent.Batch.BatchDecontaminationTask.First().DecontaminationTask.Text);
                }

                if (turnaroundEvent.Batch.BatchCycleId == null)
                {
                    return $"{translator.GetTerm("Batch")}: {turnaroundEvent.Batch.ExternalId}";
                }
               
                var additionalText = $"{translator.GetTerm("Batch")}: {turnaroundEvent.Batch.ExternalId}, {translator.GetText("Batch Cycle")}: {turnaroundEvent.Batch.BatchCycle.Text}";

                if (turnaroundEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoAutoclave)
                {
                    var batch = turnaroundEvent.Batch;

                    if (batch.BatchStatusId == (int)BatchStatusIdentifier.InProgress && batch.Started.HasValue)
                    {
                        additionalText += ", " + string.Format(translator.GetText("pages", "services.turnaround.details", "BatchStarted"), batch.Started.Value.ToLocalShortDateTime());
                    }

                    else if (batch.BatchStatusId == (int)BatchStatusIdentifier.Passed && batch.DateChecked.HasValue)
                    {
                        additionalText += ", " + string.Format(translator.GetText("pages", "services.turnaround.details", "BatchPassed"), batch.DateChecked.Value.ToLocalShortDateTime());
                    }

                    else if (batch.BatchStatusId == (int)BatchStatusIdentifier.Failed && batch.Failed.HasValue)
                    {
                        additionalText += ", " + string.Format(translator.GetText("pages", "services.turnaround.details", "BatchFailed"), batch.Failed.Value.ToLocalShortDateTime());
                    }                  
                }

                return additionalText;
            }

            if ((turnaroundEvent.EventTypeId == (short)KnownTurnaroundEventType.IntoPigeonHoleStock ||
                 turnaroundEvent.EventTypeId == (short)KnownTurnaroundEventType.RemovedFromOrder) &&
                turnaroundEvent.Location != null)
            {
                return translator.GetTerm("Location") + ": " + turnaroundEvent.Location.Text;
            }

            if (turnaroundEvent.QuarantineReason != null)
            {
                return translator.GetText("entities", "dbo.QuarantineReason", turnaroundEvent.QuarantineReason.Text);
            }

            if (turnaroundEvent.EventTypeId == (short)TurnAroundEventTypeIdentifier.IntoDryingCabinet)
            {
                if (turnaroundEvent.Location != null && turnaroundEvent.Location.Leaf != null)
                {
                    var dryingCabinetName = turnaroundEvent.Location.Leaf.Tree.Machines.FirstOrDefault()?.Text;
                    var locationName = turnaroundEvent.Location.Leaf.Tree.Machines.FirstOrDefault()?.Locations.FirstOrDefault()?.Text;

                    return string.Format("{0}\\{1}", locationName, dryingCabinetName);
                }
            }

            return additionalDetail;
        }
    }
}