using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// NoteHelper
    /// </summary>
    public class NoteHelper
    {
        /// <summary>
        /// CreateListOfNoteStationTypeDataContract operation
        /// </summary>
        public List<NoteStationTypeDataContract> CreateListOfNoteStationTypeDataContract(ContainerMasterNote containerMasterNote)
        {
            List<NoteStationTypeDataContract> noteStationTypes = new List<NoteStationTypeDataContract>();

            foreach (var cmnst in containerMasterNote.ContainerMasterNoteStationType)
            {
                var station = new StationDataContract()
                {
                    Id = cmnst.StationType.StationTypeId,
                    Name = cmnst.StationType.Text,
                    DisplayOrder = cmnst.StationType.DisplayOrder
                };

                EventTypeDataContract eventType = null;

                if (cmnst.EventTypeId != null)
                {
                    eventType = new EventTypeDataContract()
                    {
                        EventTypeId = (int)cmnst.EventTypeId,
                        Text = cmnst.EventType?.Text
                    };
                }

                var noteStationTypeContract = new NoteStationTypeDataContract()
                {
                    StationType = station,
                    EventType = eventType
                };

                noteStationTypes.Add(noteStationTypeContract);
            }

            return noteStationTypes;
        }
        /// <summary>
        /// CreateListOfNoteStationTypeDataContract operation
        /// </summary>
        public List<NoteStationTypeDataContract> CreateListOfNoteStationTypeDataContract(ProcessingNote ProcessingNote)
        {
            List<NoteStationTypeDataContract> noteStationTypes = new List<NoteStationTypeDataContract>();

            foreach (var cmnst in ProcessingNote.ProcessingNoteStationType)
            {
                var station = new StationDataContract()
                {
                    Id = cmnst.StationType.StationTypeId,
                    Name = cmnst.StationType.Text,
                    DisplayOrder = cmnst.StationType.DisplayOrder
                };

                EventTypeDataContract eventType = null;

                if (cmnst.EventTypeId != null)
                {
                    eventType = new EventTypeDataContract()
                    {
                        EventTypeId = (int)cmnst.EventTypeId,
                        Text = cmnst.EventType?.Text
                    };
                }

                var noteStationTypeContract = new NoteStationTypeDataContract()
                {
                    StationType = station,
                    EventType = eventType
                };

                noteStationTypes.Add(noteStationTypeContract);
            }

            return noteStationTypes;
        }
    }
}