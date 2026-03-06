using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class LazyWashHelper
    {
        /// <summary>
        /// ConvertTurnaroundToStationData operation
        /// </summary>
        public static WashStationData ConvertTurnaroundToStationData(IUnitOfWork workUnit, ITurnaround genericTurnaround)
        {
            IUtilityEventHandler utilityEventHandler = EventHandlerFactory.GetUtilityEventHandler(workUnit);

            if (genericTurnaround == null)
            {
                return null;
            }

            var turnaround = (Turnaround)genericTurnaround;

            ITurnaroundWH turnaroundWH = utilityEventHandler.ReadTurnaroundWhByTurnaround(turnaround.TurnaroundId);

            if (turnaroundWH == null)
                return null;

            var concTurnaroundWH = (TurnaroundWH)turnaroundWH;

            IList<DefectData> defects = ConvertDefectsToDefectsData(turnaround.ExistsDefects);
            var notes = new List<TurnaroundNoteData>();
            notes.AddRange(ConvertNotesToNotesData(turnaround.ExistsNotes, concTurnaroundWH.ContainerInstancePrimaryId, turnaroundWH.ContainerInstanceId));

            if ((turnaroundWH.ContainerMasterItemTypeId == (int)ItemTypeIdentifier.BatchTag) || (turnaroundWH.ContainerMasterItemTypeId == (int)ItemTypeIdentifier.ChildBatchTag) ||
                (turnaroundWH.ContainerMasterItemTypeId == (int)ItemTypeIdentifier.Carriage) || (turnaroundWH.ContainerMasterItemTypeId == (int)ItemTypeIdentifier.BaseCarriage))
            {
                if (turnaround != null)
                {
                    IList<ITurnaround> parentTurnarounds = utilityEventHandler.ReadChildTurnarounds(turnaround.TurnaroundId);

                    foreach (var parentTurnaround in parentTurnarounds)
                    {
                        ITurnaroundWH parentTurnaroundWH = utilityEventHandler.ReadTurnaroundWhByTurnaround(parentTurnaround.TurnaroundId);

                        if (parentTurnaroundWH != null)
                        {
                            var concParentTurnaroundWH = (TurnaroundWH)parentTurnaroundWH;

                            notes.AddRange(ConvertNotesToNotesData(parentTurnaround.ExistsNotes, concParentTurnaroundWH.ContainerInstancePrimaryId, parentTurnaroundWH.ContainerInstanceId));

                            IList<ITurnaround> childTurnarounds = utilityEventHandler.ReadChildTurnarounds(parentTurnaround.TurnaroundId);

                            foreach (var childTurnaround in childTurnarounds)
                            {
                                ITurnaroundWH childTurnaroundWH = utilityEventHandler.ReadTurnaroundWhByTurnaround(childTurnaround.TurnaroundId);

                                var concChildTurnaroundWH = (TurnaroundWH)childTurnaroundWH;

                                if (turnaroundWH != null)
                                {
                                    notes.AddRange(ConvertNotesToNotesData(childTurnaround.ExistsNotes, concChildTurnaroundWH.ContainerInstancePrimaryId, childTurnaroundWH.ContainerInstanceId));
                                }
                            }
                        }
                    }
                }
            }

            IList<ContainerMasterNoteData> itemNotes = ConvertItemNotesToContainerMasterNoteData(turnaround.ExistsItemNotes);

            var washStationData = new WashStationData(turnaroundWH.TurnaroundId,
                                        turnaroundWH.ContainerInstanceId == null ? 0 : (int)turnaroundWH.ContainerInstanceId,
                                        string.IsNullOrEmpty(concTurnaroundWH.ContainerInstancePrimaryId) ? turnaroundWH.ContainerMasterExternalId : concTurnaroundWH.ContainerInstancePrimaryId,
                                        turnaroundWH.ServiceRequirementId,
                                        turnaroundWH.ServiceRequirementName,
                                        turnaroundWH.ContainerMasterItemTypeId,
                                        turnaroundWH.ContainerMasterName,
                                        turnaroundWH.Expiry,
                                        defects,
                                        notes,
                                        itemNotes,
                                        turnaroundWH.StartEventTime == null
                                        ? DateTime.MinValue
                                        : (DateTime)turnaroundWH.StartEventTime,
                                        turnaroundWH.ContainerMasterItemType,
                                        turnaroundWH.NextEventName, turnaroundWH.TurnaroundExternalId)
                                        {
                                            ContainerMasterId = turnaroundWH.ContainerMasterId,
                                            BaseItemType = turnaroundWH.ContainerMasterBaseItemTypeId,
                                            NextEventTypeId = turnaroundWH.NextEventTypeId
                                        };

            return washStationData;
        }

        /// <summary>
        /// ConvertDefectToDefectData operation
        /// </summary>
        public static DefectData ConvertDefectToDefectData(IDefect defect)
        {
            return defect == null ? null : new DefectData(defect);
        }

        /// <summary>
        /// ConvertDefectsToDefectsData operation
        /// </summary>
        public static IList<DefectData> ConvertDefectsToDefectsData(IList<IDefect> defects)
        {
            return defects == null ? null : defects.Select(ConvertDefectToDefectData).ToList();
        }

        /// <summary>
        /// ConvertNoteToTurnaroundNoteData operation
        /// </summary>
        public static TurnaroundNoteData ConvertNoteToTurnaroundNoteData(ITurnaroundNote note)
        {
            return note == null ? null : new TurnaroundNoteData(note);
        }

        /// <summary>
        /// ConvertNotesToNotesData operation
        /// </summary>
        public static IList<TurnaroundNoteData> ConvertNotesToNotesData(IList<ITurnaroundNote> notes, string containerInstanceExternalId = null, int? containerInstanceId = null)
        {
            IList<TurnaroundNoteData> notesData = new List<TurnaroundNoteData>();

            if (notes != null)
            {
                notesData = notes.Select(ConvertNoteToTurnaroundNoteData).ToList();

                if (containerInstanceExternalId != null && containerInstanceId != null)
                {
                    foreach (var tnd in notesData)
                    {
                        tnd.ContainerInstancePrimaryId = containerInstanceExternalId;
                        tnd.ContainerInstanceId = containerInstanceId.Value;
                    }
                }
            }

            return notesData;
        }

        /// <summary>
        /// ConvertItemNoteToItemTurnaroundNoteData operation
        /// </summary>
        public static ContainerMasterNoteData ConvertItemNoteToItemTurnaroundNoteData(IContainerMasterNote itemNote)
        {
            return itemNote == null ? null : new ContainerMasterNoteData(itemNote);
        }

        /// <summary>
        /// ConvertItemNotesToContainerMasterNoteData operation
        /// </summary>
        public static IList<ContainerMasterNoteData> ConvertItemNotesToContainerMasterNoteData(
            IList<IContainerMasterNote> itemNotes)
        {
            return itemNotes == null ? null : itemNotes.Select(ConvertItemNoteToItemTurnaroundNoteData).ToList();
        }
    }
}