using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IMachineService
    /// </summary>
    /// <summary>
    /// IMachineService
    /// </summary>
    public interface IMachineService
    {
        /// <summary>
        /// Loads a list of machines
        /// </summary>
        /// <param name="stationId">Station Uid</param>
        /// <param name="machineType">Machine Type Id</param>
        IList<MachineData> ReadMachinesByStation(int stationId, byte machineType);

        /// <summary>
        /// Loads a list of all machines
        /// </summary>
        /// <param name="stationId">Station Uid</param>
        /// <param name="isSteriliser">if set to <c>true</c> [is steriliser].</param>
        IList<MachineData> ReadAllMachinesByStation(int stationId, bool isSteriliser);

        /// <summary>
        /// Loads a list of machine types
        /// </summary>
        /// <param name="stationId">The station id.</param>
        /// <param name="isSteriliser">if set to <c>true</c> [is steriliser].</param>
        IList<MachineTypeData> ReadMachineTypesByStation(int stationId, bool isSteriliser);

        /// <summary>
        /// Loads a list of service requirements
        /// </summary>
        /// <param name="machineTypeId">The machine type id.</param>
        IList<MachineEventReasonData> ReadMachineEventReasons(byte machineTypeId);

        /// <summary>
        /// Loads a machine by Uid
        /// </summary>
        /// <param name="machineId">The machine id.</param>
        MachineData ReadMachine(int machineId);

        /// <summary>
        /// Makes the machine unavailable.
        /// </summary>
        /// <param name="machineId">The machine id.</param>
        /// <param name="userId">The user uid.</param>
        /// <param name="reasonId">The reason id.</param>
        /// <param name="stationId">The station id.</param>
        MachineData MakeMachineUnavailable(int machineId, int userId, byte reasonId, int stationId);

        /// <summary>
        /// Makes the machine available.
        /// </summary>
        /// <param name="machineId">The machine id.</param>
        /// <param name="userId">The user uid.</param>
        /// <param name="stationId">The station id.</param>
        MachineData MakeMachineAvailable(int machineId, int userId, int stationId);
        /// <summary>
        /// Reads the item notes.
        /// </summary>
        /// <param name="containerMasterId">The container master id.</param>
        /// <param name="currentStationTypeId">The current station type id.</param>
        IList<ContainerMasterNoteData> ReadContainerMasterNotes(int containerMasterId, int currentStationTypeId);

        /// <summary>
        /// Reads the item notes.
        /// </summary>
        /// <param name="containerMasterDefinitionId">The container master definition id.</param>
        /// <param name="currentStationTypeId">The current station type id.</param>
        IList<ContainerMasterNoteData> ReadContainerMasterNotesByMasterId(int containerMasterDefinitionId, int currentStationTypeId);

        /// <summary>
        /// Reads the container master notes by turnaround id.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="currentStationTypeId">The current station type id.</param>
        IList<ContainerMasterNoteData> ReadContainerMasterNotesByTurnaroundId(int turnaroundId, short facilityId, int currentStationTypeId);

        /// <summary>
        /// Reads the container master notes by turnaround id.
        /// </summary>
        /// <param name="turnaroundExternalId">The turnaround external id.</param>
        /// <param name="currentStationTypeId">The current station type id.</param>
        IList<ContainerMasterNoteData> ReadContainerMasterNotesByTurnaroundExternalId(long turnaroundExternalId, short facilityId, int currentStationTypeId);

        /// <summary>
        /// Reads the warnings.
        /// </summary>
        /// <param name="instanceId">The instance id.</param>
        /// <param name="turnaroundId">The turnaround id.</param>
        IList<WarningData> ReadWarnings(int? instanceId, int? turnaroundId);

        /// <summary>
        /// Show notes for turnaround
        /// </summary>
        /// <param name="containerMasterId">The container master id.</param>
        /// <param name="currentStationTypeId">Current Station's stationType Id</param>
        /// <param name="itemNoteTypeId">The itemnote type id.</param>
        /// <returns>NotesData</returns>
        IList<MachineEventTypeData> ReadMachineStatus();

        /// <summary>
        /// To retrieve all Biological Indicator Test Status
        /// </summary>
        IList<BiologicalIndicatorTestStatusData> ReadAllBiologicalIndicatorStatus();

        /// <summary>
        /// To retrieve Biological Indicator Test by Batch Id
        /// </summary>
        /// <param name="batchId"></param>
        BiologicalIndicatorTestData ReadBiologicalIndicatorTestByBatch(int batchId);

        /// <summary>
        /// Create Biological Indicator Test.
        /// </summary>
        /// <param name="biologicalIndicatorTestData"></param>
        OperationResponseContract CreateBiologicalIndicatorTest(BiologicalIndicatorTestData biologicalIndicatorTestData);

        /// <summary>
        /// To retrieve Cycle Parameter by Batch Id
        /// </summary>
        /// <param name="batchId"></param>
        CycleParameterData ReadCycleParameterByBatch(int batchId);

        /// <summary>
        /// Updates the Cycle Parameters.
        /// </summary>
        /// <param name="cycleParameterData">The Cycle Parameters parameter.</param>
        OperationResponseContract UpdateCycleParameter(CycleParameterData cycleParameterData);

        /// <summary>
        /// Reads the Read Batch Comments.
        /// </summary>
        /// <param name="batchId">The batch Id.</param>
        IList<CommentData> ReadBatchComments(int batchId);

        /// <summary>
        /// Reads the batch data.
        /// </summary>
        /// <param name="batchId">The batch Id.</param>
        BatchData ReadBatch(int batchId);

        /// <summary>
        /// Create a comment for a batch
        /// </summary>
        /// <param name="batchId">The batch id to create the comment against</param>
        /// <param name="createdBy">the UserId of the user creating the comment</param>
        /// <param name="text">The comment text</param>
        BatchData CreateBatchComment(int batchId, int createdBy, string text);

        /// <summary>
        /// Save the cycleParameter and Biological Indicator Test Reports of batch.
        /// </summary>
        /// <param name="cycleParameterData"></param>
        /// <param name="biologicalIndicatorTestData"></param>
        OperationResponseContract SaveBatchDetails(CycleParameterData cycleParameterData);

        /// <summary>
        /// Get Batch Comments Count
        /// </summary>
        /// <param name="batchID"></param>
        int GetBatchCommentsCount(int batchID);

        /// <summary>
        /// Get Batch Turnaround Count
        /// </summary>
        /// <param name="batchID"></param>
        /// <param name="facilityID"></param>
        int GetBatchTurnaroundCount(int batchID, int facilityID);
    }
}

