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
    /// IDespatchStationService
    /// </summary>
    public interface IDespatchStationService
    {
        /// <summary>
        /// Scan trolley to assign deliverynote to it
        /// </summary>
        /// <param name="trolleyInstanceContainerInstanceId">Trolley's instance Guid</param>
        /// <param name="stationId">Station's Uid</param>
        /// <param name="userId">Operator's Uid</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns>DespatchStationData</returns>
        /// <remarks></remarks>
        DespatchStationData ScanTrolleyToAssignDeliveryNote(int trolleyInstanceContainerInstanceId, int stationId, int userId, byte processStationType);

        /// <summary>
        /// Print DeliveryNote
        /// </summary>
        /// <param name="deliveryNoteId">Turnaround's Uid</param>
        /// <param name="stationId">station's Uid</param>
        /// <param name="userId">Operator's Uid</param>
        /// <param name="trolleyTurnaroundId">The trolley turnaround id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <param name="isRePrint"></param>
        /// <returns>successful</returns>
        /// <remarks></remarks>
        DeliveryNotePrintData PrintDeliveryNote(int deliveryNoteId, int stationId, int userId, int? trolleyTurnaroundId, byte processStationType, bool isRePrint, bool localPrintingEnabled = false);

        /// <summary>
        /// print all delivery notes
        /// </summary>
        /// <param name="facilityId">Facility Uid</param>
        /// <param name="stationId">Station Uid</param>
        /// <param name="userId">Operator Uid</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns>succeful</returns>
        /// <remarks></remarks>
        bool PrintAllDeliveryNote(short facilityId, int stationId, int userId, byte processStationType);

        /// <summary>
        /// Loads a list of turnarounds that need delivery notes printing
        /// </summary>
        /// <param name="facility"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<DeliveryNoteData> ReadUnprintedDeliveryNotes(short facility);

        /// <summary>
        /// Loads all turnarounds assigned to a deliverynote
        /// </summary>
        /// <param name="deliveryNoteId">deliveryNoteId</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<DespatchStationData> ReadDeliveryNoteDetailTurnarounds(int deliveryNoteId);

        /// <summary>
        /// Despatch turnaround
        /// </summary>
        /// <param name="turnaroundExternalId">turnaround's external id</param>
        /// <param name="userId">operator's Uid</param>
        /// <param name="stationId">station's Uid</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns>DespatchStationData</returns>
        /// <remarks></remarks>
        DespatchStationData ScanTurnaround(long turnaroundExternalId, int userId, int stationId, byte processStationType);

        /// <summary>
        /// Scan stock item
        /// </summary>
        /// <param name="turnaroundExternalId">The turnaround external id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="deliveryPointId">The delivery point id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns>DespatchStationData</returns>
        /// <remarks></remarks>
        DespatchStationData ScanStockTurnaround(long turnaroundExternalId, int userId, int stationId,
                                                int deliveryPointId, byte processStationType);

        /// <summary>
        /// Load DelivertNote by date
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="deliveryPointId">The delivery point id.</param>
        /// <returns>DespatchStationData</returns>
        /// <remarks></remarks>
        IList<DeliveryNoteData> ReadDeliveryNoteByDate(DateTime date, int deliveryPointId);

        /// <summary>
        /// Archive a turnaround
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        DespatchStationData ArchiveTurnaround(int turnaroundId, int stationId, int userId,
                                              byte processStationType);

        /// <summary>
        /// Load basic detail of DN
        /// </summary>
        /// <param name="deliveryNoteId">The deliverynote id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        DeliveryNoteData ReadDeliveryNoteDetail(int deliveryNoteId);

        /// <summary>
        /// Load basic detail of DN
        /// </summary>
        /// <param name="turnaroundExternalId">The turnaround external id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        bool RemoveTurnaroundFromDeliveryNote(long turnaroundExternalId, int stationId, int userId, byte processStationType);

        /// <summary>
        /// Check if turnaround is on an order and is at status picked
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        bool IsTurnaroundOnOrderAndPicked(int turnaroundId);
        bool CanOrderBeDispatched(int turnaroundId);
        List<OrderLinesData> GetAllTurnaroundsOnOrder(int turnaroundId);
        void ChangeOrderStatus(int orderid, int status, int userId);

        /// <summary>
        /// Checks if a turnaround is orderable or not
        /// </summary>
        /// <param name="externalId">the external id of the turnaround</param>
        bool IsTurnaroundOrderable(long externalId);
    }
}