using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// AutoclaveInStationService interface
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IAutoclaveInStationService
    /// </summary>
    public interface IAutoclaveInStationService
    {
        /// <summary>
        /// Inits the create new batch.
        /// </summary>
        /// <param name="machineId">The machine id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        string InitCreateNewBatch(int machineId);

        /// <summary>
        /// Calculates the previous batch.
        /// </summary>
        /// <param name="machineId">The machine id.</param>
        /// <param name="currentId">The current id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        string CalculatePreviousBatch(int machineId, string currentId);

        /// <summary>
        /// Calculates the next batch.
        /// </summary>
        /// <param name="machineId">The machine id.</param>
        /// <param name="currentId">The current id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        string CalculateNextBatch(int machineId, string currentId);

        /// <summary>
        /// Scans the into autoclave.
        /// </summary>
        /// <param name="turnaroundExternalId">The turnaround external id.</param>
        /// <param name="facilityId">The facility Id.</param>
        /// <param name="batchId">The batch id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        AutoclaveInStationData ScanIntoAutoclave(long turnaroundExternalId, short facilityId, int batchId, int stationId, int userId, byte processStationType);

        /// <summary>
        /// Selects the batch.
        /// </summary>
        /// <param name="machineId">The machine id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<BatchData> SelectBatch(int machineId);

        /// <summary>
        /// Fail Batch ScanSN
        /// </summary>
        /// <param name="externalId">The external id.</param>
        /// <param name="facilityId">The facility Id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        BatchData FailBatchScanSn(long externalId, short facilityId);

        /// <summary>
        /// Fail Batch Post Steam
        /// </summary>
        /// <param name="batchId">The batch id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        BatchData FailBatchPostSteam(int batchId, int stationId, int userId, byte processStationType);

        /// <summary>
        /// Fail Batch - PreSteam Without Reassign
        /// </summary>
        /// <param name="batchId">The batch id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        BatchData FailBatchPreSteamWithoutReassign(int batchId, int stationId, int userId, byte processStationType);

        /// <summary>
        /// Fail Batch - PreSteam With Reassign
        /// </summary>
        /// <param name="oldBatchId">The old batch id.</param>
        /// <param name="machineId">The machine id.</param>
        /// <param name="batchCycleId">The batch cycle id.</param>
        /// <param name="batchName">Name of the batch.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        BatchData FailBatchPreSteamWithReassign(int oldBatchId, int machineId, int batchCycleId, string batchName, int stationId, int userId, byte processStationType);

        /// <summary>
        /// Reassign batch - return batch data by scaned turnaround
        /// </summary>
        /// <param name="externalId">The external id.</param>
        /// <param name="facilityId">The facility Id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        BatchData RessignBatchScanSn(long externalId, short facilityId);

        /// <summary>
        /// Reassign a batch
        /// </summary>
        /// <param name="oldBatchId">The old batch id.</param>
        /// <param name="machineId">The machine id.</param>
        /// <param name="batchCycleId">The batch cycle id.</param>
        /// <param name="batchName">Name of the batch.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        BatchData ReassignBatch(int oldBatchId, int machineId, int batchCycleId, string batchName, int stationId, int userId, byte processStationType);

        /// <summary>
        /// Create a batch
        /// </summary>
        /// <param name="machineId">The machine id.</param>
        /// <param name="batchCycleId">The batch cycle id.</param>
        /// <param name="batchName">Name of the batch.</param>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        BatchData CreateAutoclaveBatch(int machineId, int batchCycleId, string batchName, int userId);

        /// <summary>
        /// Start a batch
        /// </summary>
        /// <param name="batchId">The batch id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        BatchData StartAutoclaveBatch(int batchId);

        /// <summary>
        /// Change a batch's cycle type
        /// </summary>
        /// <param name="batchId">The batch id.</param>
        /// <param name="batchCycleId">The batch cycle id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        BatchData ChangeAutoclaveCycleTypeForBatch(int batchId, int batchCycleId);

        /// <summary>
        /// Modify's a service requirements
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="serviceRequirementId">The service requirement id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        AutoclaveInStationData ChangeServiceRequirement(int turnaroundId, int serviceRequirementId, int stationId,
                                             int userId, byte processStationType);

        /// <summary>
        /// Addnote to turnaround
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="noteText">Thenote text.</param>
        /// <param name="stationTypes">The station types.</param>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        AutoclaveInStationData AddNote(int turnaroundId, string noteText, byte[] stationTypes, int userId);

        /// <summary>
        /// Reads all autoclave batches by machine.
        /// </summary>
        /// <param name="machineId">The machine id.</param>
        /// <param name="startDateTime">The start date time.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<BatchData> ReadAllAutoclaveBatchesByMachine(int machineId, DateTime startDateTime);

        /// <summary>
        /// Reads all turnarounds by batch.
        /// </summary>
        /// <param name="batchId">The batch id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<TurnaroundData> ReadAllTurnaroundsByBatch(int batchId);

        /// <summary>
        /// Reads the failed batches by facility.
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="startDateTime">The start date time.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<FailedBatchData> ReadFailedBatchesByFacility(short facilityId, DateTime startDateTime);

        /// <summary>
        /// Tests the specified turnaround external id.
        /// </summary>
        /// <param name="turnaroundExternalId">The turnaround external id.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        AutoclaveInStationData Test(long turnaroundExternalId, short facilityId, int stationId,
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
        AutoclaveInStationData RemoveItemFromBatchTag(int batchTagTurnaroundId, int containerInstanceId, int stationId,
                                             int userId, int batchId, byte processStationType);

        /// <summary>
        /// Associate Batch to DailyTestReport
        /// </summary>
        /// <param name="batchId"></param>
        void AssociateBatchToDailyTestReport(int batchId);

        /// <summary>
        /// Check Biological Indicator Required.
        /// </summary>
        /// <param name="batchId"></param>
        /// <param name="facilityId"></param>
        /// <param name="isStartBatch"></param>
        /// <returns></returns>
        bool CheckBiologicalIndicatorRequired(int batchId, int facilityId, bool isStartBatch);

        /// <summary>
        /// Biological Indicator Exist.
        /// </summary>
        /// <param name="batchId"></param>
        /// <param name="facilityId"></param>
        /// <param name="isStartBatch"></param>
        /// <returns></returns>
        BiologicalIndicatorTestData GetBiologicalIndicator(int batchId, int facilityId, bool isStartBatch);

        /// <summary>
        /// Is Biological Indicator Enabled.
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="machineId"></param>
        /// <param name="batchCycleId"></param>
        /// <returns></returns>
        bool IsBiologicalIndicatorEnabled(int facilityId, int machineId, int batchCycleId);

    }
}