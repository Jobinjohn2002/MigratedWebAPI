using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// INoteService
    /// </summary>
    public interface INoteService
    {
        /// <summary>
        /// Reads the item notes.
        /// </summary>
        /// <param name="containerMasterId">The container master id.</param>
        /// <param name="currentStationTypeId">The current station type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<ContainerMasterNoteData> ReadContainerMasterNotes(int containerMasterId, int currentStationTypeId);

        /// <summary>
        /// Reads the warnings.
        /// </summary>
        /// <param name="instanceId">The instance id.</param>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<WarningData> ReadWarnings(int? instanceId, int? turnaroundId);

        /// <summary>
        /// Show notes for turnaround
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="currentStationTypeId">Current Station's stationType Id</param>
        /// <returns>NotesData</returns>
        /// <remarks></remarks>
        IList<TurnaroundNoteData> ReadNotes(int turnaroundId, byte currentStationTypeId);

        /// <summary>
        /// Show notes for turnaround
        /// </summary>
        /// <param name="containerMasterId">The container master id.</param>
        /// <param name="currentStationTypeId">Current Station's stationType Id</param>
        /// <param name="itemNoteTypeId">The itemnote type id.</param>
        /// <returns>NotesData</returns>
        /// <remarks></remarks>
        IList<ContainerMasterNoteData> ReadItemNotes(int containerMasterId, int currentStationTypeId, int itemNoteTypeId);
    }
}

