using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// QualityAssuranceStationService interface
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IQualityAssuranceStationService
    /// </summary>
    public interface IQualityAssuranceStationService
    {
        #region QualityAssurance Operations

        /// <summary>
        /// Add extra(s), and return all of these extras' turnarounds.
        /// </summary>
        /// <param name="itemId">Extra's Item Uid</param>
        /// <param name="deliveryPointId">Delivery Point Uid</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">Operator Uid</param>
        /// <param name="serviceRequirementId">The service requirement id.</param>
        /// <param name="batchTagTurnaroundId">The batch tag turnaround uid.</param>
        /// <param name="quantity">Quantity of Extras</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <param name="eventTypeIdentifier">Event type identifier.</param>
        /// <param name="extraItemIntoStock">Indicates whether we want the QA label for an "Extra" to show the delivery point or the default stock location.</param>
        /// <returns>QualityAssuranceStationData</returns>
        /// <remarks></remarks>
        OperationResponseContract AddExtra(int itemId, int deliveryPointId, int stationId,
                                           int userId, int serviceRequirementId, int? batchTagTurnaroundId,
                                           int quantity, byte processStationType, int eventTypeIdentifier, bool extraItemIntoStock = false, bool localPrintingEnabled = false);

        /// <summary>
        /// Pass QA for one turnaround
        /// </summary>
        /// <param name="containerInstanceId">itemInstance's Guid</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">Operator Uid</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns>QualityAssuranceStationData</returns>
        /// <remarks></remarks>
        QualityAssuranceStationData Scan(int containerInstanceId, int stationId, int userId, byte processStationType);

        /// <summary>
        /// Pass QA for one turnaround
        /// </summary>
        /// <param name="containerInstanceId">itemInstance's Guid</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">Operator Uid</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <param name="facilityId">Facility Id</param>
        /// <returns>QualityAssuranceStationData</returns>
        /// <remarks></remarks>
        QualityAssuranceStationData ScanUsingFacilityId(int containerInstanceId, int stationId, int userId, byte processStationType, short facilityId, bool localPrintingEnabled = false);
        
        /// <summary>
        /// Reprint QA Lable
        /// </summary>
        /// <param name="turnaroundExternalId">Turnaround's external Id</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">Operator's Uid</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns>QualityAssuranceStationData</returns>
        /// <remarks></remarks>
        QualityAssuranceStationData Reprint(long turnaroundExternalId, int stationId, int userId,
                                            byte processStationType, bool localPrintingEnabled = false);

        /// <summary>
        /// Reprint QA Lable By Instance Id
        /// </summary>
        /// <param name="containerInstanceExternalId">Instance external Id</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">Operator's Uid</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns>QualityAssuranceStationData</returns>
        /// <remarks></remarks>
        QualityAssuranceStationData ReprintByInstanceId(string containerInstanceExternalId, int stationId,
                                                        int userId, byte processStationType, bool localPrintingEnabled = false);

        /// <summary>
        /// Fail an Item
        /// </summary>
        /// <param name="containerInstanceId">containerInstance's Guid</param>
        /// <param name="failureTypeId">The failure type id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">Operator's Uid</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns>QualityAssuranceStationData</returns>
        /// <remarks></remarks>
        QualityAssuranceStationData FailItem(int containerInstanceId, byte failureTypeId, int stationId, int userId,
                                             byte processStationType);

        /// <summary>
        /// Modify's a service requirements
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="serviceRequirementId">The service requirement id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user uid.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        QualityAssuranceStationData ChangeServiceRequirement(int turnaroundId, int serviceRequirementId, int stationId,
                                                             int userId, byte processStationType);

        /// <summary>
        /// Add anote to a turnaround
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="noteText">The notetext.</param>
        /// <param name="stationTypes">The station types.</param>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        QualityAssuranceStationData AddNote(int turnaroundId, string noteText, byte[] stationTypes, int userId);

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
        QualityAssuranceStationData RemoveItemFromBatchTag(int batchTagTurnaroundId, int containerInstanceId, int stationId,
                                             int userId, int batchId, byte processStationType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="turnaroundId"></param>
        /// <param name="printLabelandTrayFrontsheet"></param>
        /// <returns></returns>
        OperationResponseContract PrintLabelandTrayListFrontSheet(int turnaroundId, bool printLabelandTrayFrontsheet, int stationId, int userId, bool localPrintingEnabled = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerMasterId"></param>
        /// <returns></returns>
        bool HasDefaultLocation(int containerMasterId);

        #endregion
    }
}