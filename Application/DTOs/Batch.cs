using System;
using System.Collections.Generic;
using System.Linq;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static SynergyApplicationFrameworkApi.Application.DTOs.Constants;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Batch
    /// </summary>
    /// <remarks></remarks>
	public partial class Batch 
	{
        public IEnumerable<Turnaround> CurrentlyAssignedTurnarounds => this.TurnaroundEvent.Where(
                    te =>
                        te.Turnaround.CurrentTurnaroundEvent.TurnaroundEventId == te.TurnaroundEventId
                    ||
                    (
                        te.Turnaround.TurnaroundEvent.Where(e =>
                            e.EventTypeId == (int)TurnAroundEventTypeIdentifier.ChangedBatch &&
                            e.Created > e.Turnaround.CurrentTurnaroundEvent.TurnaroundEvent.Created
                        ).OrderByDescending(tte => tte.Created).FirstOrDefault()?.TurnaroundEventId == te.TurnaroundEventId
                    )
                )
                .Select(te => te.Turnaround).Distinct();
    }
}
		