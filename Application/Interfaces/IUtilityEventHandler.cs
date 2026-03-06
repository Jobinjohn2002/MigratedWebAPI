using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// UtilityEventHandler interface
    /// </summary>
    /// <summary>
    /// IUtilityEventHandler
    /// </summary>
    public interface IUtilityEventHandler
    {
        bool IsRemoveFromBatchTagApplied
        {
            get;
            set;
        }

        bool IsRemoveFromCarriageApplied
        {
            get;
            set;
        }

        /// <summary>
        /// Retires the last revision customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        void RetireLastRevisionCustomer(Customer customer);

        /// <summary>
        /// Loads customers delivery points
        /// </summary>
        /// <param name="customerDefinitionId">The customer definition id.</param>
        /// <returns>List of Delivery Points</returns>
        IList<IDeliveryPoint> ReadDeliveryPoints(int customerDefinitionId);

        /// <summary>
        /// load all facility notes from specific facility
        /// </summary>
        /// <param name="faciltyId">Facility's int</param>
        /// <returns>List of Facility Notes</returns>
        IList<IFacilityNote> ReadFacilityNotes(short faciltyId);

        /// <summary>
        /// Loads a list of machine event reason
        /// </summary>
        /// <param name="machineTypeId">The machine type id.</param>
        /// <returns>List of Machine Event Reasons</returns>
        IList<IMachineEventReason> ReadMachineEventReasons(byte machineTypeId);

        /// <summary>
        /// Loads a list of machines
        /// </summary>
        /// <param name="stationId">Station's int</param>
        /// <param name="machineType">Machine Type's Id</param>
        /// <returns>List of Machines</returns>
        IList<IMachine> ReadMachinesByStation(int stationId, byte machineType);

        /// <summary>
        /// Loads a list of all machines
        /// </summary>
        /// <param name="stationId">Station's int</param>
        /// <param name="isSteriliser">if set to <c>true</c> [is steriliser].</param>
        /// <returns>List of Machines</returns>
        IList<IMachine> ReadAllMachinesByStation(int stationId, bool isSteriliser);

        /// <summary>
        /// Load Machine Types by Station
        /// </summary>
        /// <param name="stationId">Station Uid</param>
        /// <param name="isSteriliser">if set to <c>true</c> [is steriliser].</param>
        /// <returns>Machine Types List</returns>
        IList<IMachineType> ReadMachineTypesByStation(int stationId, bool isSteriliser);

        /// <summary>
        /// Load Machine by Uid
        /// </summary>
        /// <param name="machineId">Machine Uid</param>
        /// <returns>IMachine</returns>
        IMachine ReadMachine(int machineId);

        /// <summary>
        /// Get item's base type
        /// </summary>
        /// <param name="itemTypeId">Child item type id</param>
        /// <returns>Item Base Type</returns>
        IItemType ReadBaseTypeByItemType(short itemTypeId);

        /// <summary>
        /// Checks the validity of a station
        /// </summary>
        /// <param name="stationId">Station's int</param>
        /// <returns>IStation</returns>
        IStation ValidateStation(int stationId);

        /// <summary>
        /// Checks for a valid user
        /// </summary>
        /// <param name="userId">User's int</param>
        /// <returns>IUser</returns>
        User ValidateUser(int userId);

        /// <summary>
        /// Checks the validity of a turnaround
        /// </summary>
        /// <param name="turnaroundId">Turnaround's int</param>
        /// <returns>ITurnaround</returns>
        ITurnaround ValidateTurnaround(int turnaroundId);

        /// <summary>
        /// Validates the turnaround.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="facilityId">The facility id.</param>
        ITurnaround ValidateTurnaround(int turnaroundId, short facilityId);

        /// <summary>
        /// Validates the turnaround.
        /// </summary>
        /// <param name="turnaroundExternalId">The turnaround external id.</param>
        /// <param name="facilityId">The facility id.</param>
        ITurnaround ValidateTurnaround(long turnaroundExternalId, short facilityId);

        /// <summary>
        /// Checks the validity of a facility
        /// </summary>
        /// <param name="facilityId">Facility's int</param>
        /// <returns>IFacility</returns>
        IFacility ValidateFacility(short facilityId);

        /// <summary>
        /// Checks the validity of a customer
        /// </summary>
        /// <param name="customerId">Customer's int</param>
        /// <returns>ICustomer</returns>
        ICustomer ValidateCustomer(int customerId);

        /// <summary>
        /// Checks the validity of a machine
        /// </summary>
        /// <param name="machineId">Machine's int</param>
        /// <returns>IMachine</returns>
        IMachine ValidateMachine(int machineId);

        /// <summary>
        /// Checks the validity of an item
        /// </summary>
        /// <param name="itemId">Item's int</param>
        /// <returns>IItemMaster</returns>
        ItemMaster ValidateItemMaster(int itemId);

        /// <summary>
        /// Checks the validity of a delivery point
        /// </summary>
        /// <param name="deliveryPointId">Delivery Point's int</param>
        /// <returns>IDeliveryPoint</returns>
        IDeliveryPoint ValidateDeliveryPoint(int? deliveryPointId);

        /// <summary>
        /// Checks the validity of a Defect Classification
        /// </summary>
        /// <param name="defectClassificationId">Defect Classification's int</param>
        /// <returns>IDefectClassification</returns>
        IDefectClassification ValidateDefectClassification(int? defectClassificationId);

        /// <summary>
        /// Checks the validity of a station type
        /// </summary>
        /// <param name="stationTypeId">Station Type's Id</param>
        /// <returns>IStationType</returns>
        IStationType ValidateStationType(byte stationTypeId);

        /// <summary>
        /// Checks the validity of a batch
        /// </summary>
        /// <param name="batchId">Batch's int</param>
        /// <returns>IBatch</returns>
        IBatch ValidateBatch(int batchId);

        /// <summary>
        /// Checks the validity of a machine event reason
        /// </summary>
        /// <param name="indexId">Machine Event Reason's Id</param>
        /// <returns>IMachineEventReason</returns>
        IMachineEventReason ValidateMachineEventReason(byte indexId);

        /// <summary>
        /// Checks the validity of a defect
        /// </summary>
        /// <param name="defectId">Defect's int</param>
        /// <returns>IDefect</returns>
        IDefect ValidateDefect(int defectId);

        /// <summary>
        /// Checks the validity of a customer defect
        /// </summary>
        /// <param name="customerDefectId">customer Defect's int</param>
        /// <returns>IDefect</returns>
        ICustomerDefect ValidateCustomerDefect(int customerDefectId);

        /// <summary>
        /// Check the validity of a container instance by ExternalId
        /// </summary>
        /// <param name="instanceId">The instance id.</param>
        ContainerInstance ValidateContainerInstance(int instanceId);

        /// <summary>
        /// Pres the search container instance.
        /// </summary>
        /// <param name="extId">The ext id.</param>
        /// <param name="facilityId">The facility id.</param>
        IList<IContainerInstance> PreSearchContainerInstance(string extId, short facilityId);

        /// <summary>
        /// Check the validity of a container master
        /// </summary>
        /// <param name="masterId">Container Master'int</param>
        /// <returns>IContainerMaster</returns>
        IContainerMaster ValidateContainerMaster(int masterId);

        /// <summary>
        /// Check the validity of a container master by definition uid
        /// </summary>
        /// <param name="definitionId">Definition Uid</param>
        IContainerMaster ValidateContainerMasterByDefinitionId(int definitionId);

        /// <summary>
        /// Validate Deliverynote
        /// </summary>
        /// <param name="deliveryNoteId">The delivery note id.</param>
        IDeliveryNote ValidateDeliveryNote(int deliveryNoteId);

        /// <summary>
        /// Validate Role
        /// </summary>
        /// <param name="roleId">The role id.</param>
        IRole ValidateRole(short roleId);

        /// <summary>
        /// Validates the permission.
        /// </summary>
        /// <param name="permissionId">The permission id.</param>
        IPermission ValidatePermission(short permissionId);

        /// <summary>
        /// Validate Speciality
        /// </summary>
        /// <param name="specialityId">The speciality id.</param>
        ISpeciality ValidateSpeciality(short specialityId);

        /// <summary>
        /// Validate complexity
        /// </summary>
        /// <param name="complexityId">The complexity id.</param>
        IComplexity ValidateComplexity(short complexityId);

        /// <summary>
        /// Gets administrative station using facility
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        IStation ReadAdminStationByFacility(int facilityId);

        /// <summary>
        /// Reads the associated station types.
        /// </summary>
        /// <param name="stationId">The station id.</param>
        IList<IStationType> ReadAssociatedStationTypes(int stationId);

        /// <summary>
        /// Get printer by user and printer type
        /// </summary>
        /// <param name="userId">User's Uid</param>
        /// <param name="printerType">Printer Type</param>
        /// <returns>Printer</returns>
        IPrinter ReadPrinterByUserAndPrinterType(int userId, PrinterTypeIdentifier printerType, UserCultureData userCultureData, bool localPrintingEnabled = false);

        /// <summary>
        /// Add Delivery Points For Item
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="deliveryPoints">The delivery points.</param>
        void AddDeliveryPointsForItem(ContainerMaster item, int[] deliveryPoints);

        /// <summary>
        /// Add Components For Item
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="components">The components.</param>
        void AddComponentsForItem(ContainerMaster item, IList<IContainerContent> components);

        /// <summary>
        /// Add Item Notes For Item
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="itemNotes">The item notes.</param>
        void AddItemNotesForItem(ContainerMaster item, IList<ContainerMasterNote> itemNotes);

        /// <summary>
        /// Add Warnings For Item
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="warnings">The warnings.</param>
        void AddWarningsForItem(ContainerMaster item, IList<Warning> warnings);

        /// <summary>
        /// Retire Last Revision Item
        /// </summary>
        /// <param name="item">The item.</param>
        void RetireLastRevisionItem(ContainerMaster item);

        /// <summary>
        /// Update Item Details
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="userId">The user id.</param>
        int UpdateItemDetails(ContainerMaster item, int userId);

        /// <summary>
        /// Update Component Details
        /// </summary>
        /// <param name="component">The component.</param>
        /// <param name="userId">The user id.</param>
        int UpdateComponentDetails(ItemMaster component, int userId);

        /// <summary>
        /// Retire Last Revision Component
        /// </summary>
        /// <param name="component">The component.</param>
        void RetireLastRevisionComponent(ItemMaster component);

        /// Adds the item notes for component.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <param name="itemNotes">The item notes.</param>
        void AddItemNotesForComponent(ItemMaster component, IList<ContainerMasterNote> itemNotes);

        /// <summary>
        /// Add Warnings For Component
        /// </summary>
        /// <param name="component">The component.</param>
        /// <param name="warnings">The warnings.</param>
        void AddWarningsForComponent(ItemMaster component, IList<Warning> warnings);

        /// <summary>
        /// Check Item Type Features
        /// </summary>
        /// <param name="itemTypeFeatures">The item type features.</param>
        /// <param name="feature">The feature.</param>
        bool CheckItemTypeFeatures(byte itemTypeFeatures, ItemTypeFeatureIdentifiers feature);

        /// <summary>
        /// Get turnaround item type
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        IItemType ReadTurnaroundItemType(int turnaroundId);

        /// <summary>
        /// change machine status to Unavailable
        /// </summary>
        /// <param name="machineId">machine int</param>
        /// <param name="userId">user id</param>
        /// <param name="reasonId">reason id</param>
        /// <param name="stationId">The station id.</param>
        IMachine MakeMachineUnavailable(int machineId, int userId, byte reasonId, int stationId);

        /// <summary>
        /// change machine status to Unavailable
        /// </summary>
        /// <param name="machineId">machine</param>
        /// <param name="userId">user Uid</param>
        /// <param name="stationId">station Uid</param>
        IMachine MakeMachineAvailable(int machineId, int userId, int stationId);

        /// <summary>
        /// Read Last Process event
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        ITurnaroundEvent ReadLastProcessEvent(int turnaroundId);

        /// <summary>
        /// Reads the last live turnaround by instance.
        /// </summary>
        /// <param name="instanceExternalId">The instance external id.</param>
        /// <param name="facilityId">The facility id.</param>
        ITurnaround ReadLastLiveTurnaroundByInstance(string containerInstancePrimaryId, short facilityId);

        /// <summary>
        /// Reads the turnaround wh by turnaround.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        ITurnaroundWH ReadTurnaroundWhByTurnaround(int turnaroundId);

        /// <summary>
        /// Reads the child turnarounds.
        /// </summary>
        /// <param name="turnaroundId">The turnaround uid.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<ITurnaround> ReadChildTurnarounds(int turnaroundId);

        /// <summary>
        /// Gets all components by item.
        /// </summary>
        /// <param name="itemId">The item id.</param>
        IList<ItemMaster> GetAllComponentsByItem(int itemId);

        /// <summary>
        /// Method to get event type using station type
        /// </summary>
        /// <param name="stationTypeId">The station type id.</param>
        IEventType GetEventTypeByStationAndEventId(int stationTypeId, int? eventTypeId);

        /// <summary>
        /// Creates a non process turnaround event
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="turnAroundEventTypeIdentifier"></param>
        /// <param name="station"></param>
        /// <param name="userId"></param>
        void CreateNonProcessTurnaroundEvent(int instanceId, TurnAroundEventTypeIdentifier turnAroundEventTypeIdentifier, IStation station, int userId);
    }
}
