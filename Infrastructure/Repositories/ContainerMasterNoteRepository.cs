using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    public partial class ContainerMasterNoteRepository
    {
        /// <summary>
        /// Gets the specified container masternote id.
        /// </summary>
        /// <param name="containerMasterNoteId">The container masternote id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// Get operation
        /// </summary>
        public ContainerMasterNote Get(int containerMasterNoteId)
        {
            return
                Repository.Find(
                    containerMasterNote => containerMasterNote.ContainerMasterNoteId == containerMasterNoteId).
                    FirstOrDefault();
        }

        /// <summary>
        /// Gets all by container master.
        /// </summary>
        /// <param name="containerMasterId">The container master id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetAllByContainerMaster operation
        /// </summary>
        public IQueryable<ContainerMasterNote> GetAllByContainerMaster(int containerMasterId) => Repository.Find(n =>n.ContainerMasterId == containerMasterId);

        /// <summary>
        /// Gets the type of all notes by item master and station.
        /// </summary>
        /// <param name="containerMasterId">The container master id.</param>
        /// <param name="stationTypeId">The station type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetAllNotesByContainerMasterAndStationType operation
        /// </summary>
        public IQueryable<ContainerMasterNote> GetAllNotesByContainerMasterAndStationType(int containerMasterId, int stationTypeId, TurnAroundEventTypeIdentifier? eventTypeId = null)
        {
            return
                Repository.Find(n => n.ContainerMasterId == containerMasterId && 
                    n.ContainerMasterNoteStationType.Any(cmnst => cmnst.StationType.StationTypeId == stationTypeId && (cmnst.EventTypeId == null || cmnst.EventTypeId == (short?)eventTypeId)));
        }

        /// <summary>
        /// Gets the type of all notes by item master and station.
        /// </summary>
        /// <param name="containerMasterId">The container master id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetContainerMasterNotesByContainerMasterId operation
        /// </summary>
        public IQueryable<ContainerMasterNote> GetContainerMasterNotesByContainerMasterId(int containerMasterId)
        {
            return Repository.Find(n => n.ContainerMasterId == containerMasterId);
        }
    }
}