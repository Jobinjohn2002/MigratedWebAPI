using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// WashStationService interface
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IWashStationService
    /// </summary>
    public interface IWashStationService
    {
        TurnaroundData ReadLastTurnaroundByInstanceAndFacilityId(string instanceExternalId, short facilityId);
        TurnaroundData ReadLastTurnaround(string instanceExternalId, short facilityId);

        /// <summary>
        /// Reads the batch tags.
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<WashStationData> ReadUnreleasedBatchTags(short facilityId);

        /// <summary>
        /// Reads the carriages.
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<WashStationData> ReadUnreleasedCarriages(short facilityId);

        /// <summary>
        /// Creates the carriage.
        /// </summary>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        WashStationData CreateCarriage(int containerInstanceId, int stationId, int userId, byte processStationType);

        /// <summary>
        /// Assigns the item to wash process tag.
        /// </summary>
        /// <param name="carriageTurnaroundId">The process tag turnaround uid.</param>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        WashStationData AssignItemToCarriage(int carriageTurnaroundId, int containerInstanceId, int stationId, int userId, byte processStationType);

        /// <summary>
        /// Removes the item from the wash process tag.
        /// </summary>
        /// <param name="carriageTurnaroundId">The carriage turnaround id.</param>
        /// <param name="containerInstanceId">The instance Guid.</param>
        /// <param name="stationId">The station uid.</param>
        /// <param name="userId">The user uid.</param>
        /// <param name="batchId">The batch uid.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// -- return type was StationData before void
        /// <remarks></remarks>
        WashStationData RemoveItemFromCarriage(int carriageTurnaroundId, int containerInstanceId, int stationId, int userId, int? batchId, byte processStationType);

        /// <summary>
        /// Gets or creates batch tag turnaround.
        /// </summary>
        /// <param name="containerInstanceId"></param>
        /// <param name="stationId"></param>
        /// <param name="userId"></param>
        /// <param name="externalId"></param>
        /// <param name="processStationType"></param>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        WashStationData GetBatchTagTurnaround(int containerInstanceId, int stationId, int userId, string externalId, byte processStationType, short facilityId);

        /// <summary>
        /// Fail Batch ScanSN
        /// </summary>
        /// <param name="turnaroundExternalId">A turnaround externalId.</param>
        /// <param name="facilityId">The facility Id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        CarriageData GetCarriageDataFromChildTurnaround(long turnaroundExternalId, short facilityId);

        /// <summary>
        /// Fails the Cassette.
        /// </summary>
        /// <param name="carriageTurnaroundId">The cassette turnaround external id.</param>
        /// <param name="stationId">The station uid.</param>
        /// <param name="userId">The user uid.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <param name="facilityId">The facility Id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        void FailCarriage(int carriageTurnaroundId, int stationId, int userId, byte processStationType, short facilityId);

        /// <summary>
        /// Fails the children of a batch. Also detaches carriage from it's children.
        /// </summary>
        /// <param name="batchId"></param>
        /// <param name="stationId"></param>
        /// <param name="userId"></param>
        /// <param name="processStationType"></param>
        /// <param name="facilityId"></param>
        void FailBatch(int batchId, int stationId, int userId, byte processStationType, short facilityId);
        void ArchiveCarriage(int carriageTurnaroundId, int stationId, int userId, byte processStationType, short facilityId);
        WashStationData ScanInstanceUsingFacilityId(int containerInstanceId, int stationId, int userId, int batchId, byte processStationType, short facilityId);
        WashStationData ScanCarriage(int containerInstanceId, int stationId, int userId, int batchId, byte processStationType, short facilityId);

        /// <summary>
        /// Reprints the barcode.
        /// </summary>
        /// <param name="instanceId">The instance id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        WashStationData ReprintBarcode(int instanceId, int stationId, int userId, byte processStationType, bool returnPDFData, bool localPrintingEnabled = false);

        /// <summary>
        /// This changes the external id back to what it was
        /// </summary>
        /// <param name="containerInstanceId">The instance id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <param name="externalId">External Id to change to.</param>
        /// <returns></returns>
        /// <remarks></remarks>                 
        void RevertExternalIdNameChange(int containerInstanceId, int stationId, int userId, byte processStationType, string externalId);

        /// <summary>
        /// Fails the instance.
        /// </summary>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <param name="washReleaseRequired">if set to <c>true</c> [wash release required].</param>
        /// <returns></returns>
        /// <remarks></remarks>
        WashStationData FailInstance(int containerInstanceId, int stationId, int userId, byte processStationType,
                                     bool washReleaseRequired);

        /// <summary>
        /// Logs the defect.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="serviceReportNo">The service report no.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="defectClassificationId">The defect classification id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        WashStationData LogDefect(int turnaroundId, string serviceReportNo, int userId, int defectClassificationId,
                                  int stationId, byte processStationType);

        /// <summary>
        /// Create a batch
        /// </summary>
        /// <param name="machineId">The machine id.</param>
        /// <param name="batchName">Name of the batch.</param>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        BatchData CreateWashBatch(int machineId, string batchName, int userId);

        /// <summary>
        /// validate wash batch
        /// </summary>
        /// <param name="machineId">The machine id.</param>
        /// <param name="batchName">Name of the batch.</param>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        bool ValidateWashBatch(int machineId, string batchName, int userId);

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
        WashStationData ChangeServiceRequirement(int turnaroundId, int srId, int stationId, int userId,
                                                 byte processStationType);

        /// <summary>
        /// Assigns the item to batch tag.
        /// </summary>
        /// <param name="batchTagTurnaroundId">The batch tag turnaround uid.</param>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="batchId">The batch id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        WashStationData AssignItemToBatchTag(int batchTagTurnaroundId, int containerInstanceId, int stationId,
                                             int userId, int batchId, byte processStationType);

        /// <summary>
        /// Assigns the item to wash process tag.
        /// </summary>
        /// <param name="processTagTurnaroundId">The process tag turnaround uid.</param>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        WashStationData AssignItemToWashProcessTag(int processTagTurnaroundId, int containerInstanceId, int stationId,
                                                   int userId, byte processStationType);

        /// <summary>
        /// Starts the wash batch.
        /// </summary>
        /// <param name="batchId">The batch id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        BatchData StartWashBatch(int batchId);

        /// <summary>
        /// Starts the wash batch tag.
        /// </summary>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="batchId">The batch id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        WashStationData StartWashBatchTag(int containerInstanceId, int batchId, int stationId, int userId,
                                          byte processStationType);

        /// <summary>
        /// Archives the turnaround.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        WashStationData ArchiveTurnaround(int turnaroundId, int stationId, int userId, byte processStationType);

        /// <summary>
        /// Adds the note.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="noteText">The note text.</param>
        /// <param name="stationTypes">The station types.</param>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        WashStationData AddNote(int turnaroundId, string noteText, byte[] stationTypes, int userId);

        /// <summary>
        /// Releases the wash.
        /// </summary>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        ReleaseWashStationData ReleaseWash(int containerInstanceId, int stationId, int userId,
                                           byte processStationType, int batchID);

        /// <summary>
        /// Creates the wash process tag.
        /// </summary>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        WashStationData CreateWashProcessTag(int containerInstanceId, int stationId, int userId,
                                             byte processStationType);

        /// <summary>
        /// Reads the unreleased process tags.
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<WashStationData> ReadUnreleasedProcessTags(short facilityId);

        /// <summary>
        /// Reads the child turnarounds.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<WashStationData> ReadChildTurnarounds(int turnaroundId);

        /// <summary>
        /// Reads the turnaround.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        WashStationData ReadTurnaround(int turnaroundId);

        /// <summary>
        /// Changes the wash process tag batch.
        /// </summary>
        /// <param name="batchId">The batch id.</param>
        /// <param name="machineId">The machine id.</param>
        /// <param name="batchExternalId">The batch external id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        bool ChangeWashProcessTagBatch(int batchId, int machineId, string batchExternalId);

        /// <summary>
        /// Scans the batch tag.
        /// </summary>
        /// <param name="processTagTurnaroundId">The process tag turnaround uid.</param>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        WashStationData ScanBatchTag(int processTagTurnaroundId, int containerInstanceId, int stationId, int userId,
                                     byte processStationType);

        /// <summary>
        /// Assigns the item to batch tag for wash process tag.
        /// </summary>
        /// <param name="batchTagTurnaroundId">The batch tag turnaround id.</param>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        WashStationData AssignItemToBatchTagForWashProcessTag(int batchTagTurnaroundId, int containerInstanceId,
                                                              int stationId, int userId, byte processStationType);
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
        WashStationData RemoveItemFromBatchTag(int batchTagTurnaroundId, int containerInstanceId, int stationId,
                                             int userId, int? batchId, byte processStationType);

        /// <summary>
        /// Removes the item from the wash process tag.
        /// </summary>
        /// <param name="processTagTurnaroundId">The process tag turnaround id.</param>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="batchId">The batch id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        WashStationData RemoveItemFromProcessTag(int processTagTurnaroundId, int containerInstanceId, int stationId,
                                             int userId, int? batchId, byte processStationType);

        /// <summary>
        /// Read Quarantined Instances.
        /// </summary>
        /// <param name="carriageTurnaroundId"></param>
        /// <returns></returns>
        CarriageBatchData ReadQuarantinedInstances(int carriageTurnaroundId);

        /// <summary>
        /// Is AssignToCarriage Next Event.
        /// </summary>
        /// <param name="itemTypeId"></param>
        /// <param name="parentItemTypeId"></param>
        /// <param name="fromEventTypeId"></param>
        /// <returns></returns>
        bool IsAssignToCarriageNextEvent(short itemTypeId, short? parentItemTypeId, short? fromEventTypeId); 
    }
}