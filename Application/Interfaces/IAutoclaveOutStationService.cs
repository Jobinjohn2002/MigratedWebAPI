using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IAutoclaveOutStationService
    /// </summary>
    public interface IAutoclaveOutStationService
    {
        List<BatchData> ReadStartedBatchesByFacility(int facilityId);
        IList<BatchData> ReadFailedBatchesByFacility(int facilityId);
        IList<TurnaroundData> ReadTurnaroundsByBatch(int batchId);

        /// <summary>
        /// Scan turnaround for fail turnaround
        /// </summary>
        /// <param name="turnaroundId">Guid of turnaround</param>
        /// <returns>AutoclaveOutStationData</returns>
        AutoclaveOutStationData ScanTurnaroundForFailTurnaround(int turnaroundId);

        /// <summary>
        /// Scan turnaround for fail batch
        /// </summary>
        /// <param name="turnaroundId">Guid of turnaround</param>
        /// <returns>AutoclaveOutStationData</returns>
        BatchData ScanTurnaroundForFailBatch(int turnaroundId);

        /// <summary>
        /// Scan turnaround for assigning item to batch
        /// </summary>
        /// <param name="turnaroundId">Guid of turnaround</param>
        /// <returns>AutoclaveOutStationData</returns>
        AutoclaveOutStationData ScanTurnaroundForAssignItemToBatch(int turnaroundId);

        /// <summary>
        /// Pass a turnaround to autoclave out
        /// </summary>
        /// <param name="turnaroundExternalId">turnaround external Id</param>
        /// <param name="userId">Guid of operator</param>
        /// <param name="stationId">Guid of station</param>
        /// <param name="processStationType"></param>
        /// <returns>AutoclaveOutStationData</returns>
        AutoclaveOutStationData PassTurnaround(long turnaroundExternalId, int userId, int stationId, byte processStationType);
        AutoclaveOutStationData PassTurnaroundWithDespatch(long turnaroundExternalId, int userId, int stationId,
                                                           byte processStationType);

        /// <summary>
        /// Fail a turnaround
        /// </summary>
        /// <param name="turnaroundExternalId">External Id of turnaround</param>
        /// <param name="userId">Guid of operator</param>
        /// <param name="stationId">Guid of station</param>
        /// <param name="reasonId">Id of reason</param>
        /// <param name="processStationType"></param>
        /// <returns>AutoclaveOutStationData</returns>
        AutoclaveOutStationData FailTurnaround(long turnaroundExternalId, int userId, int stationId, short reasonId, byte processStationType);

        /// <summary>
        /// Fail a passed turnaround
        /// </summary>
        /// <param name="turnaroundExternalId"></param>
        /// <param name="userId"></param>
        /// <param name="stationId"></param>
        /// <param name="reasonId"></param>
        /// <param name="processStationType"></param>
        /// <returns></returns>
        AutoclaveOutStationData FailPassedTurnaround(long turnaroundExternalId, int userId, int stationId, short reasonId,
                                               byte processStationType);

        /// <summary>
        /// Fail a whole batch for the same reason
        /// </summary>
        /// <param name="batchId">The batch's Guid</param>
        /// <param name="userId">Guid of operator</param>
        /// <param name="stationId">Guid of station</param>
        /// <param name="reasonId">Id of reason</param>
        /// <param name="processStationType"></param>
        /// <returns>AutoclaveOutStationData</returns>
        BatchData FailBatch(int batchId, int userId, int stationId, short reasonId, byte processStationType);

        /// <summary>
        /// Fail batch - scan sn
        /// </summary>
        /// <param name="externalId"></param>
        /// <param name="facilityId">The facility Id.</param>
        /// <returns></returns>
        BatchData FailBatchScanSN(long externalId, short facilityId);

        /// <summary>
        /// Add a item to batch
        /// </summary>
        /// <param name="turnaroundExternalId">ExternalId of turnaround</param>
        /// <param name="batchId">Guid of batch</param>
        /// <param name="userId">Guid of operator</param>
        /// <param name="stationId">Guid of station</param>
        /// <param name="processStationType"></param>
        /// <param name="approvedByUserId">Approved By User id</param>
        /// <returns>AutoclaveOutStationData</returns>
        AutoclaveOutStationData AssignItemToBatch(long turnaroundExternalId, int batchId, int userId, int stationId, byte processStationType, int? approvedByUserId = null);

        /// <summary>
        /// Load last batch that count equal num
        /// </summary>
        /// <param name="machineId"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        IList<BatchData> ReadLastBatchs(int machineId, int num);

        /// <summary>
        /// Load all turnarounds that have not been passed or failed
        /// </summary>
        /// <param name="batchId"></param>
        /// <returns></returns>
        IList<TurnaroundData> ReadAllUnpassedTurnaroundsByBatch(int? batchId);
        
        /// <summary>
        /// Gets the turnaround events list by turnaround id.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<TurnaroundEventListData> GetTurnaroundEventsListByTurnaroundId(int turnaroundId);

        /// <summary>
        /// Load last batch by batch cycles that count equal num
        /// </summary>
        /// <param name="machineId"></param>
        /// <param name="externalId"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        IList<BatchData> ReadLastBatchCycles(int machineId, int externalId, int num);

        /// <summary>
        /// Read Test Batches.
        /// </summary>
        /// <param name="machineId"></param>
        /// <returns></returns>
        IList<BatchData> ReadTestBatches(int machineId); 

        /// <summary>
        /// Validate Batch.
        /// </summary>
        /// <param name="turnaroundId"></param>
        /// <param name="batchId"></param>
        /// <returns></returns>
        MachineBatchData ValidateBatch(int turnaroundId, int batchId);

        /// <summary>
        /// Pass or Fail Autoclave Batch.
        /// </summary>
        /// <param name="machineBatchdata"></param>
        void PassFailAutoclaveBatch(MachineBatchData machineBatchdata);

        /// <summary>
        /// Into Quarantine.
        /// </summary>
        /// <param name="turnaroundId"></param>
        /// <param name="userId"></param>
        /// <param name="stationId"></param>
        /// <param name="processStationType"></param>
        /// <param name="quarantineReasonId"></param>
        void IntoQuarantine(int turnaroundId, int userId, int stationId, byte processStationType, short quarantineReasonId, int batchId);
    }
}