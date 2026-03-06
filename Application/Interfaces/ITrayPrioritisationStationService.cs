using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// TP Service contract
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// ITrayPrioritisationStationService
    /// </summary>
    public interface ITrayPrioritisationStationService
    {
        #region TrayPrioritisation Operations

        /// <summary>
        /// Scans the instance.
        /// </summary>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        TrayPrioritisationStationData ScanInstance(int containerInstanceId, int stationId, int userId,
                                                   byte processStationType);

        /// <summary>
        /// Scans the instance.
        /// </summary>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        TrayPrioritisationStationData ScanInstanceUsingFacilityId(int containerInstanceId, int stationId, int userId, byte processStationType, short facilityId, bool localPrintingEnabled = false);

        
        /// <summary>
        /// Reprints the specified turnaround uid.
        /// </summary>
        /// <param name="turnaroundId">The turnaround uid.</param>
        /// <param name="stationId">The station uid.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        OperationResponseContract Reprint(int turnaroundId, int stationId, int userId, byte processStationType, bool localPrintingEnabled = false);

        /// <summary>
        /// Reads the awaiting events.
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<TrayPrioritisationStationData> ReadAwaitingEvents(short facilityId,int stationId);

        /// <summary>
        /// Starts the packing.
        /// </summary>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        TrayPrioritisationStationData StartPacking(int containerInstanceId, int stationId, int userId,
                                                   byte processStationType);

        /// <summary>
        /// Fails the packing.
        /// </summary>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        TrayPrioritisationStationData FailPacking(int containerInstanceId, int stationId, int userId,
                                                  byte processStationType);

        /// <summary>
        /// Packings the specified container instance id.
        /// </summary>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        TrayPrioritisationStationData Packing(int containerInstanceId, int stationId, int userId,
                                              byte processStationType);

        /// <summary>
        /// Packs the individual instrument.
        /// </summary>
        /// <param name="iite">The iite.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        int PackIndividualInstrument(IndividualInstrumentTrackingEventContract iite);

        /// <summary>
        /// Uns the pack individual instrument.
        /// </summary>
        /// <param name="iite">The iite.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        int UnPackIndividualInstrument(IndividualInstrumentTrackingEventContract iite);

        /// <summary>
        /// Reads the individual instruments by instance.
        /// </summary>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="lastTurnaroundEventId">The last turnaround event uid.</param>
        /// <param name="isContinue">if set to <c>true</c> [is continue].</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<ItemMasterData> ReadIndividualInstrumentsByInstance(int containerInstanceId, int lastTurnaroundEventId,
                                                                  bool isContinue);

        /// <summary>
        /// Finishes the individual instrument track for item exception.
        /// </summary>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="exceptionalIite">The exceptional iite.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        TrayPrioritisationStationData FinishIndividualInstrumentTrackForItemException(int containerInstanceId,
                                                                                    IList<IndividualInstrumentTrackingEventContract> exceptionalIite, 
                                                                                    int stationId,
                                                                                    int userId, byte processStationType);

        /// <summary>
        /// Removes the item from batch tag.
        /// </summary>
        /// <param name="batchTagTurnaroundId">The batch tag turnaround uid.</param>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="batchId">The batch id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        TrayPrioritisationStationData RemoveItemFromBatchTag(int batchTagTurnaroundId, int containerInstanceId, int stationId,
                                             int userId, int batchId, byte processStationType);
        #endregion
    }
}