using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// INotesDatabaseHelper
    /// </summary>
    public interface INotesDatabaseHelper : IDisposable
    {
        List<NoteDataContract> GetContainerMasterNotes(int turnaroundId, string containerInstancePrimaryId, int containerMasterId, int stationTypeId, TurnAroundEventTypeIdentifier eventTypeId, string containerMasterName, int containerMasterDefinitionId);
        List<NoteDataContract> GetTurnaroundNotes(long turnaroundId, int stationTypeId, string containerInstancePrimaryId, string containerMasterName);
    }

    public sealed class NotesDatabaseHelper
    {
        /// <summary>
        /// GetTurnaroundNotes operation
        /// </summary>
        public List<NoteDataContract> GetTurnaroundNotes(long turnaroundId, int stationTypeId, string containerInstancePrimaryId, string containerMasterName)
        {
            using (var workUnit = InstanceFactory.GetInstance<IUnitOfWork>())
            { 
                var turnaroundNoteRepository = TurnaroundNoteRepository.New(workUnit);

                var notes = turnaroundNoteRepository
                    .All()
                    .Where(p => p.TurnaroundId == turnaroundId && p.TurnaroundNoteStationType.Any(tnst => tnst.StationType.StationTypeId == stationTypeId))
                    .Select(n => new
                    {
                        n.TurnaroundNoteId,
                        n.Text
                    })
                    .ToList();

                return notes.Select(x=> new NoteDataContract
                {
                    TurnaroundId  = (int)turnaroundId,
                    ContainerInstancePrimaryId = containerInstancePrimaryId,
                    Id = x.TurnaroundNoteId,
                    Text = x.Text,
                    ContainerMasterName = containerMasterName
                }).ToList();
            }
        }

        /// <summary>
        /// GetContainerMasterNotes operation
        /// </summary>
        public List<NoteDataContract> GetContainerMasterNotes(int turnaroundId, string containerInstancePrimaryId, int containerMasterId, int stationTypeId, TurnAroundEventTypeIdentifier eventTypeId, string containerMasterName, int containerMasterDefinitionId)
        {
            {
                var containerMasterNoteRepository = ContainerMasterNoteRepository.New(workUnit);

                var processingNoteRepository = new ProcessingNoteRepository(workUnit);

                var timeBasedNotesData = processingNoteRepository.GetAllNotesByContainerMasterDefinitionAndStationType(containerMasterDefinitionId, stationTypeId, eventTypeId, false);
                List<NoteDataContract> timeBasedNotes = new List<NoteDataContract>();
                List<NoteDataContract> revisionNotes = new List<NoteDataContract>();

                foreach (var x in timeBasedNotesData)
                { 
                    var note = new NoteDataContract
                    {
                        TurnaroundId = turnaroundId,
                        ContainerInstancePrimaryId = containerInstancePrimaryId,
                        Id = x.ProcessingNoteId,
                        Text = x.Text,
                        Type = x.ProcessingNoteTypeId,
                        ContainerMasterName = containerMasterName,
                        ActiveFrom = DateTime.SpecifyKind(x.ActiveFrom, DateTimeKind.Utc),
                        ExpiryDate = x.Expiry == null? (DateTime?)null :DateTime.SpecifyKind((DateTime)x.Expiry, DateTimeKind.Utc),
                        ProcessNoteType = ProcessNoteType.TimeBased
                    };

                    timeBasedNotes.Add(note);
                }

                var revisionNotesData = containerMasterNoteRepository.GetAllNotesByContainerMasterAndStationType(containerMasterId, stationTypeId, eventTypeId);

                foreach (var x in revisionNotesData)
                {
                    var note = new NoteDataContract
                    {
                        TurnaroundId = turnaroundId,
                        ContainerInstancePrimaryId = containerInstancePrimaryId,
                        Id = x.ContainerMasterNoteId,
                        Text = x.Text,
                        Type = x.ContainerMasterNoteTypeId,
                        ContainerMasterName = containerMasterName,
                        ActiveFrom = x.ContainerMasterNoteAudit.Any() ? DateTime.SpecifyKind(x.ContainerMasterNoteAudit.FirstOrDefault().ActiveFrom, DateTimeKind.Utc) : (DateTime?)null,
                        ProcessNoteType = ProcessNoteType.Revision

                    };
                    revisionNotes.Add(note);
                 }

                revisionNotes.AddRange(timeBasedNotes);
                return revisionNotes;
            }
        }

        /// <summary>
        /// Dispose operation
        /// </summary>
        public void Dispose()
        {

        }
    }
}
