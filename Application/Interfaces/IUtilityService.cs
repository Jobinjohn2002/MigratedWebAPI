using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SynergyApplicationFrameworkApi.Application.Models;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IUtilityService
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IUtilityService
    /// </summary>
    public interface IUtilityService
    {
        /// <summary>
        /// Load all delivery points by customer
        /// </summary>
        /// <param name="customerDefinitionId">Customer's Uid</param>
        /// <returns>DeliveryPointsData</returns>
        /// <remarks></remarks>
        IList<DeliveryPointData> ReadDeliveryPoints(int customerDefinitionId);
        IList<FacilitySettingDataContract> ReadSettingsByFacilityId(short facilityId);

        /// <summary>
        /// Load all delivery points by customer with search term
        /// </summary>
        /// <param name="customerDefinitionId">Customer's Uid</param>
        /// <param name="searchTerm">The search term.</param>
        /// <returns>DeliveryPointsData</returns>
        /// <remarks></remarks>
        IList<DeliveryPointData> ReadDeliveryPoints(int customerDefinitionId, string searchTerm);

        /// <summary>
        /// Load Delivery Point by Uid
        /// </summary>
        /// <param name="deliveryPointId">The delivery point uid.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        DeliveryPointData ReadDeliveryPoint(int deliveryPointId);

        /// <summary>
        /// Read all Defect Classification
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<DefectClassificationData> ReadDefectClassification();

        /// <summary>
        /// Load all customers by facility
        /// </summary>
        /// <param name="facilityId">Facilities Uid</param>
        /// <returns>LoadFaciltiesCustomers</returns>
        /// <remarks></remarks>
        IList<CustomerData> ReadCustomers(short facilityId);

        /// <summary>
        /// Load all customers by facility with search term
        /// </summary>
        /// <param name="facilityId">Facilities Uid</param>
        /// <param name="searchTerm">The search term.</param>
        /// <returns>LoadFaciltiesCustomers</returns>
        /// <remarks></remarks>
        IList<CustomerData> ReadCustomers(short facilityId, string searchTerm);

        /// <summary>
        /// Loads all service requirements by customer
        /// </summary>
        /// <param name="customerId">The customer uid.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<ServiceRequirementData> ReadServiceRequirements(int customerId);

        /// <summary>
        /// Loads the type of the service requirements by item.
        /// </summary>
        /// <param name="customerId">The customer uid.</param>
        /// <param name="itemTypeId">The item type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<ServiceRequirementData> ReadServiceRequirementsByItemType(int customerId, short itemTypeId);

        /// <summary>
        /// Reads the service requirements by item type and sr definition.
        /// </summary>
        /// <param name="serviceRequirementDefintion">The service requirement defintion.</param>
        /// <param name="itemTypeId">The item type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<ServiceRequirementData> ReadServiceRequirementsByItemTypeAndSrDefinition(int serviceRequirementDefintion,
                                                                                       short itemTypeId);
        /// <summary>
        /// Load a turnaround
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        TurnaroundData ReadTurnaround(int turnaroundId);
        /// <summary>
        /// Load a turnaround by turnaround uid and facility.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        TurnaroundData ReadTurnaround(int turnaroundId, short facilityId);
        /// <summary>
        /// Load a turnaround by external id and facility.
        /// </summary>
        /// <param name="turnaroundExternalId">The turnaround external id.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        TurnaroundData ReadTurnaround(long turnaroundExternalId, short facilityId);

        /// <summary>
        /// Loads all notes by facility
        /// </summary>
        /// <param name="facilityId">The facility uid.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<FacilityNoteData> ReadFacilityNotes(short facilityId);

        /// <summary>
        /// Reads the facility.
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        FacilityData ReadFacility(short facilityId);

        /// <summary>
        /// Loads a list of extras by delivery point
        /// </summary>
        /// <param name="deliveryPointId">The delivery point uid.</param>
        /// <param name="customerDefinitionId">Customer definition id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<ExtrasDataContract> ReadExtras(int deliveryPointId, int customerDefinitionId);

        /// <summary>
        /// Loads a list of extras by delivery point
        /// </summary>
        /// <param name="facilityId">The facility id</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<ContainerMasterData> ReadExtrasForDisposables(int facilityId);

        /// <summary>
        /// Loads the service requirement.
        /// </summary>
        /// <param name="serviceRequirementId">The service requirement uid.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        ServiceRequirementData ReadServiceRequirement(int serviceRequirementId);

        /// <summary>
        /// Load a container Instance
        /// </summary>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        ContainerInstanceData ReadContainerInstance(int containerInstanceId);

        /// <summary>
        /// Scans a users badge
        /// </summary>
        /// <param name="badgeNumber">The badge number.</param>
        /// <param name="stationId">The station id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        UserData ScanUserBadgeNumber(string badgeNumber, int stationId);

        /// <summary>
        /// Load a batch
        /// </summary>
        /// <param name="batchId">The batch id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        BatchData ReadBatch(int? batchId);

        /// <summary>
        /// Load turnarounds in a batch
        /// </summary>
        /// <param name="batchId">The batch id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<TurnaroundData> ReadTurnaroundsByBatch(int batchId);

        /// <summary>
        /// Read station by NT Logon
        /// </summary>
        /// <param name="ntLogon">The nt logon.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        StationData ReadStationByNtLogon(string ntLogon);

        /// <summary>
        /// Get all time zones.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<TimeZonesData> ReadAllTimeZones();

        /// <summary>
        /// Gets the type of the instance item base.
        /// </summary>
        /// <param name="instanceId">The instance id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        ItemTypeData ReadInstanceItemBaseType(int instanceId);

        /// <summary>
        /// Gets the type of the instance item.
        /// </summary>
        /// <param name="instanceId">The instance id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        ItemTypeData ReadInstanceItemType(int instanceId);

        /// <summary>
        /// Archives the turnaround.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user uid.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        TurnaroundData ArchiveTurnaround(int turnaroundId, int stationId, int userId, byte processStationType);

        /// <summary>
        /// Gets the type of the turnaround item.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        ItemTypeData ReadTurnaroundItemType(int turnaroundId);

        /// <summary>
        /// Gets the base type of the turnaround item.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        ItemTypeData ReadTurnaroundItemBaseType(int turnaroundId);

        /// <summary>
        /// Reads the possible station types.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="eventTypeId">The event type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<StationTypeData> ReadPossibleStationTypes(int turnaroundId, int eventTypeId);

        /// <summary>
        /// Reads the last process event.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        TurnaroundEventData ReadLastProcessEvent(int turnaroundId);

        /// <summary>
        /// Reads the current turnaround by instance.
        /// </summary>
        /// <param name="instanceExtId">The instance ext id.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        TurnaroundData ReadCurrentTurnaroundByInstance(string instanceExtId, short facilityId);

        /// <summary>
        /// Loads the type of the station.
        /// </summary>
        /// <param name="stationTypeId">The station type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        StationTypeData ReadStationType(byte stationTypeId);

        /// <summary>
        /// Pres the search container instance.
        /// </summary>
        /// <param name="extId">The ext id.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="stationid">The station id.</param>
        /// <param name="userid">The user id.</param>
        /// <param name="stationtype">The station type.</param>
        /// <param name="isEnquiry"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<PreSearchContainerInstanceData> PreSearchContainerInstance(string extId, short facilityId, int stationId, int userid, byte stationtype, bool isEnquiry);

        /// <summary>
        /// Legacies the barcode replaced.
        /// </summary>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        bool LegacyBarcodeReplaced(int containerInstanceId, int stationId, int userId, byte processStationType);

        /// <summary>
        /// Reads the next events.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<EventTypeData> ReadNextEvents(int turnaroundId);

        /// <summary>
        /// Reads the next events by category.
        /// </summary>
        /// <param name="turnaroundExtId">The turnaround ext id.</param>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<EventTypeData> ReadNextEventsByCategory(long turnaroundExtId, short facilityId, EventTypeCategoryIdentifier category);

        /// <summary>
        /// Acknowledges thenote.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="stationId">The station id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="processStationType">Type of the process station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        bool AcknowledgeNote(int turnaroundId, int stationId, int userId, byte processStationType);

        /// <summary>
        /// Reads the failure types.
        /// </summary>
        /// <param name="eventTypeId">The event type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<FailureTypeData> ReadFailureTypes(short eventTypeId);

        /// <summary>
        /// Reads the awaiting events.
        /// </summary>
        /// <param name="stationTypeId">The station type id.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="stationId">The station id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<PriorityScreenData> ReadAwaitingEvents(int stationTypeId, short facilityId, int stationId);

        /// <summary>
        /// Reads the last live turnaround by instance.
        /// </summary>
        /// <param name="instanceExternalId">The instance external id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        TurnaroundData ReadLastLiveTurnaroundByInstanceAndFacilityId(string instanceExternalId, short facilityId);

        /// <summary>
        /// Reads the last live turnaround by instance.
        /// </summary>
        /// <param name="instanceExternalId">The instance external id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        WashStationData GetLastLiveTurnaroundByInstanceAndFacilityId(string instanceExternalId, short facilityId);

        /// <summary>
        /// Reads the batch cycle.
        /// </summary>
        /// <param name="cycleTypeId">The cycle type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        BatchCycleData ReadBatchCycle(int cycleTypeId);
        
        
        /// <summary>
        /// Reads the turnaroundevents for .
        /// </summary>
        /// <param name="cycleTypeId">The cycle type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        BatchData ReadBatchData(int batchId);

        /// <summary>
        /// Returns the target time for processing a certain turnaround.
        /// </summary>
        /// <param name="containerInstanceId">The container instance id</param>
        /// <param name="stationTypeId">The ID of the station type they are working on</param>
        /// <returns></returns>
        TargetTimeData GetTargetTime(int containerInstanceId, int stationTypeId);

        /// <summary>
        /// Gets the user's overall performance in the current shift
        /// </summary>
        /// <param name="userId">The ID of the user</param>
        /// <param name="stationTypeId">The id of the station type they are working on</param>
        /// <returns></returns>
        UserPerformanceData GetUserPerformanceData(int userId, int stationTypeId);

        /// <summary>
        /// ReadLastLiveTurnaroundByInstanceId
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        WashStationData ReadLastLiveTurnaroundByInstanceId(int instanceId);

        /// <summary>
        /// Read Current Turnaround By InstanceId
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        TurnaroundData ReadCurrentTurnaroundByInstanceId(int instanceId, short facilityId);
    }
}