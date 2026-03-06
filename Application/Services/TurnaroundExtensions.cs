using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class TurnaroundExtensions
    {
        /// <summary>
        /// CanMoveIntoStock operation
        /// </summary>
        public static bool CanMoveIntoStock(this Turnaround turnaround)
        {
            if (turnaround.ContainerInstance == null)
                return false;
            var latestTurnaround = turnaround.ContainerInstance.Turnarounds
                .OrderByDescending(a => a.Created)
                .FirstOrDefault();
            if (latestTurnaround != null && latestTurnaround.TurnaroundId != turnaround.TurnaroundId)
                return false;
            var processEvents = turnaround.TurnaroundEvents
                .ToList();
            if (processEvents.Any(te => te.EventType.IsArchiveEvent))
                return false;
            var currentProcessEvent = processEvents
                .Where(te => te.EventType.ProcessEvent)
                .OrderByDescending(te => te.Created)
                .ThenByDescending(te => te.TurnaroundEventId)
                .FirstOrDefault();

            if (currentProcessEvent != null && currentProcessEvent.WorkflowId == null && !currentProcessEvent.EventType.IsEndEvent)
            { 
                    return false;
            }
            var validItemTypes = new List<short> { (short)KnownItemType.Tray, (short)KnownItemType.Supplementary, (short)KnownItemType.LoanTray, (short)KnownItemType.Endoscopy };
            return
                validItemTypes.Contains(turnaround.ContainerMaster.ItemTypeId) ||
                validItemTypes.Contains(turnaround.ContainerMaster.ItemType.ParentItemTypeId.GetValueOrDefault());
        }
    }
}
