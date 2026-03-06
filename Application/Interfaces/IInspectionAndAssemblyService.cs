using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// InspectionAndAssembly Service contract
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IInspectionAndAssemblyService
    /// </summary>
    public interface IInspectionAndAssemblyService
    {
        /// <summary>
        /// Reads the awaiting events.
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<TrayPrioritisationStationData> ReadInspectionAssemblyAwaitingEvents(short facilityId);

        /// <summary>
        /// Get All Components By ContainerMasterId.
        /// </summary>
        /// <param name="containerMasterId"></param>
        /// <param name="containerInstanceId"></param>
        /// <returns></returns>
        IList<ComponentListData> GetAllComponentsByContainerMasterId(int containerMasterId, int containerInstanceId);

        /// <summary>
        /// Scan Instance Using FacilityId.
        /// </summary>
        /// <param name="containerInstanceId"></param>
        /// <param name="stationId"></param>
        /// <param name="userId"></param>
        /// <param name="processStationType"></param>
        /// <param name="facilityId"></param>
        /// <param name="componentListData"></param>
        /// <returns></returns>
        TrayPrioritisationStationData ScanInstanceUsingFacilityId(int containerInstanceId, int stationId, int userId,
                                                                  byte processStationType, short facilityId,
                                                                  IList<ComponentListData> componentListData);

        #region Components List
        List<ComponentItem> GetComponentsList(int turnaroundId);

        #endregion

        #region CreateTurnaroundEvent
        InspectionAndAssemblyStationData CreateTurnaroundEvent(PackingTurnaroundEventData turnaroundEventData, IList<ComponentListData> componentListData, bool localPrintingEnabled = false);

        #endregion

        #region GetListItemsforInepectionAndAssembly

        /// <summary>
        /// Get List Items for InspectionAndAssembly.
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="stationId"></param>
        /// <returns></returns>
        List<TrayPrioritisationStationData> GetListItemsforInspectionAndAssembly(int facilityId, int stationId);        

        #endregion

        /// <summary>
        /// Read LastLive Turnaround By ItemInstance.
        /// </summary>
        /// <param name="itemInstanceId"></param>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        TurnaroundData ReadLastLiveTurnaroundByItemInstance(int itemInstanceId, short facilityId);

        #region Packing Failed Reason

        /// <summary>
        /// Get Fail Reasons for Packing Stations
        /// </summary>
        /// <returns></returns>
        List<FailureTypeItem> GetPackingFailReasons();        

        #endregion

        /// <summary>
        /// Read Quarantine Reasons.
        /// </summary>
        /// <returns></returns>
        IList<QuarantineReasonData> ReadQuarantineReasons();

        /// <summary>
        /// Validate File.
        /// </summary>
        /// <param name="containerInstanceId"></param>
        /// <param name="containerMasterDefinitionId"></param>
        /// <returns></returns>
        InspectionAndAssemblyStationData ValidateFile(int containerInstanceId, int containerMasterDefinitionId);

        /// <summary>
        /// Validate Printer.
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="processStationType"></param>
        /// <returns></returns>
        bool IsStationHasPrinter(int stationId, int processStationType);

        /// <summary>
        /// Validate Item Type has a valid workflow linked.
        /// </summary>
        /// <param name="itemTypeId"></param>
        /// <param name="fromEventId"></param>
        /// <param name="toEventId"></param>
        /// <returns></returns>
        bool ValidateItemTypeWorkFlow(int itemTypeId, int fromEventId, int toEventId);

        /// <summary>
        /// Check Independent Quality Assurance.
        /// </summary>
        /// <param name="containerInstanceId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool CheckIndependentQualityAssurance(int containerInstanceId, int userId);

        /// <summary>
        /// Read All Item Exception Reasons.
        /// </summary>
        /// <returns></returns>
        IList<GenericKeyValueData> ReadAllItemExceptionReasons();

        /// <summary>
        /// Verify User Speciality.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="containerInstanceId"></param>
        /// <returns></returns>
        bool VerifyUserSpeciality(int userId, int containerInstanceId);

        /// <summary>
        /// Update ItemExceptions Reason.
        /// </summary>
        /// <param name="componentListData"></param>
        /// <param name="turnaroundId"></param>
        /// <param name="containerInstanceId"></param>
        void UpdateItemExceptionsReason(IList<ComponentListData> componentListData, int turnaroundId, int containerInstanceId);  
    }
}
