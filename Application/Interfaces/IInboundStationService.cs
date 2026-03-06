using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IInboundStationService
    /// </summary>
    public interface IInboundStationService
    {
        /// <summary>
        /// Scan into inbound
        /// </summary>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        InboundStationData ScanInstanceUsingFacilityId(int containerInstanceId, int userId, int stationId, byte processStationType, short facilityId, bool localPrintingEnabled = false);
       
        /// <summary>
        /// Archive turnaround
        /// </summary>
        /// <param name="turnaroundlId">The turnaroundl id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        InboundStationData ArchiveTurnaround(int turnaroundlId, int stationId, int userId,
                                             byte processStationType);

        /// <summary>
        /// Change service requirement
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="srId">The sr id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        InboundStationData ChangeServiceRequirement(int turnaroundId, int srId, int stationId, int userId,
                                                    byte processStationType);

        /// <summary>
        /// Adds the note.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="noteText">The note text.</param>
        /// <param name="stationTypes">The station types.</param>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        InboundStationData AddNote(int turnaroundId, string noteText, byte[] stationTypes, int userId);
    }
}