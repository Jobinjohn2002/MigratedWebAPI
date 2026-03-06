using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Utility service event handler
    /// </summary>
    public sealed class UtilityEventHandler : EventHandlerBase, IUtilityEventHandler
    {
        /// <summary>
        /// Gets or sets IsRemoveFromBatchTagApplied
        /// </summary>
        public bool IsRemoveFromBatchTagApplied { get; set; }
        /// <summary>
        /// Gets or sets IsRemoveFromCarriageApplied
        /// </summary>
        public bool IsRemoveFromCarriageApplied { get; set; }

        /// <summary>
        /// Gets or sets ChildDefects
        /// </summary>
        public static List<DefectDc> ChildDefects { get; set; } = new List<DefectDc>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilityEventHandler"/> class.
        /// </summary>
        /// <param name="workUnit">The work unit.</param>
        internal UtilityEventHandler(IUnitOfWork workUnit)
            : base(workUnit)
        {
            IsRemoveFromBatchTagApplied = false;
            IsRemoveFromCarriageApplied = false;
        }

        /// <summary>
        /// Loads customers delivery points
        /// </summary>
        /// <param name="customerDefinitionId"></param>
        /// <returns>List of Delivery Points</returns>
        /// <summary>
        /// ReadDeliveryPoints operation
        /// </summary>
        public IList<IDeliveryPoint> ReadDeliveryPoints(int customerDefinitionId)
        {
            var deliveryPointDataAdapter = DataAdapterFactory.GetDeliveryPointDataAdapter(OperativeWorkUnit);

            var deliveryPoints = deliveryPointDataAdapter.GetDeliveryPointsByCustomerDefinitionId(customerDefinitionId).ToList();
            return deliveryPoints;
        }

        /// <summary>
        /// Loads the facility notes.
        /// </summary>
        /// <param name="facilityId">The facility uid.</param>
        /// <summary>
        /// ReadFacilityNotes operation
        /// </summary>
        public IList<IFacilityNote> ReadFacilityNotes(short facilityId)
        {
            var facilityNoteDataAdapter = DataAdapterFactory.GetFacilityNoteDataAdapter(OperativeWorkUnit);
            return facilityNoteDataAdapter.GetFacilityNotesByFacility(facilityId).ToList();
        }

        /// <summary>
        /// Loads a list of machine event reason
        /// </summary>
        /// <param name="machineTypeId">The machine type id.</param>
        /// <returns>List of Machine Event Reasons</returns>
        /// <summary>
        /// ReadMachineEventReasons operation
        /// </summary>
        public IList<IMachineEventReason> ReadMachineEventReasons(byte machineTypeId)
        {
            var machineEventReasonDataAdapter = DataAdapterFactory.GetMachineEventReasonDataAdapter(OperativeWorkUnit);
            var machineEventReasonsList = machineEventReasonDataAdapter.GetAllMachineEventReason(machineTypeId).ToList();
            return machineEventReasonsList;
        }

        /// <summary>
        /// Loads a list of machine
        /// </summary>
        /// <param name="stationId">Station's int</param>
        /// <param name="machineType">Machine Type's Id</param>
        /// <returns>List of Machines</returns>
        /// <summary>
        /// ReadMachinesByStation operation
        /// </summary>
        public IList<IMachine> ReadMachinesByStation(int stationId, byte machineType)
        {
            var stationDataAdapter = DataAdapterFactory.GetStationDataAdapter(OperativeWorkUnit);
            var station = (Station)ValidateStation(stationId);
            var machinesList = stationDataAdapter.GetAllMachinesByStation(station.StationId, machineType).ToList();
            return machinesList;
        }

        /// <summary>
        /// load all machines assigned to station
        /// </summary>
        /// <param name="stationId">Station's int</param>
        /// <param name="isSteriliser">if set to <c>true</c> [is steriliser].</param>
        /// <returns>List of Machines</returns>
        /// <summary>
        /// ReadAllMachinesByStation operation
        /// </summary>
        public IList<IMachine> ReadAllMachinesByStation(int stationId, bool isSteriliser)
        {
            var stationDataAdapter = DataAdapterFactory.GetStationDataAdapter(OperativeWorkUnit);
            var station = (Station)ValidateStation(stationId);
            var machinesList = stationDataAdapter.GetAllMachinesByStation(station.StationId, isSteriliser).ToList();
            return machinesList;
        }

        /// <summary>
        /// Load machine
        /// </summary>
        /// <param name="machineId">Machine Uid</param>
        /// <returns>IMachine</returns>
        /// <summary>
        /// ReadMachine operation
        /// </summary>
        public IMachine ReadMachine(int machineId)
        {
            var machine = ValidateMachine(machineId);
            return machine;
        }

        /// <summary>
        /// Load Machine Types by Station
        /// </summary>
        /// <param name="stationId">Station Uid</param>
        /// <param name="isSteriliser">if set to <c>true</c> [is steriliser].</param>
        /// <returns>Machine Types List</returns>
        /// <summary>
        /// ReadMachineTypesByStation operation
        /// </summary>
        public IList<IMachineType> ReadMachineTypesByStation(int stationId, bool isSteriliser)
        {
            var station = ValidateStation(stationId);
            var stationDataAdapter = DataAdapterFactory.GetStationDataAdapter(OperativeWorkUnit);
            var machineTypes = stationDataAdapter.GetAllMachineTypesByStation(station.StationId, isSteriliser).ToList();
            return machineTypes.ToList();
        }

        /// <summary>
        /// Get item's base type
        /// </summary>
        /// <param name="itemTypeId">Child item type id</param>
        /// <returns>Item Base Type</returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadBaseTypeByItemType operation
        /// </summary>
        public IItemType ReadBaseTypeByItemType(short itemTypeId)
        {
            var itemTypeDataAdapter = DataAdapterFactory.GetItemTypeDataAdapter(OperativeWorkUnit);
            return itemTypeDataAdapter.GetBaseTypeByItemType(itemTypeId);
        }

        /// <summary>
        /// Checks the validity of a station
        /// </summary>
        /// <param name="stationId">Station's int</param>
        /// <returns>IStation</returns>
        /// <summary>
        /// ValidateStation operation
        /// </summary>
        public IStation ValidateStation(int stationId)
        {
            var stationDataAdapter = DataAdapterFactory.GetStationDataAdapter(OperativeWorkUnit);
            var station = stationDataAdapter.GetStation(stationId);
            if (station == null)
            {
                throw new Exception();
            }
            return station;
        }

        /// <summary>
        /// Checks for a valid user
        /// </summary>
        /// <param name="userId">User's int</param>
        /// <returns>IUser</returns>
        /// <summary>
        /// ValidateUser operation
        /// </summary>
        public User ValidateUser(int userId)
        {
            var userDataAdapter = DataAdapterFactory.GetUserDataAdapter(OperativeWorkUnit);
            var user = userDataAdapter.GetUser(userId);
            if (user == null)
            {
                throw new Exception();
            }
            return user;
        }

        /// <summary>
        /// ValidateTurnaround operation
        /// </summary>
        public ITurnaround ValidateTurnaround(long turnaroundExternalId, short facilityId)
        {
            var turnaroundDataAdapter = DataAdapterFactory.GetTurnaroundDataAdapter(OperativeWorkUnit);
            var turnaround = turnaroundDataAdapter.GetTurnaroundUsingFacilityId(turnaroundExternalId, facilityId);
            if (turnaround == null || turnaround.FacilityId != facilityId)
            {
                var facilityDataAdapter = DataAdapterFactory.GetFacilityDataAdapter(OperativeWorkUnit);
                var facility = facilityDataAdapter.GetFacility(facilityId);
                var associatedFacilities = facilityDataAdapter.ReadAssociatedFacilitiesByFacility(facilityId).Select(af => af.FacilityId);

                using (var repository = new PathwayRepository())
                {
                    var alternativeFacilities = repository.Container.MultiFacilityProcessHandShake.Where(hs => hs.RequestingFacilityId == facilityId && hs.MultiFacilityProcessingId != null).Select(mfp => mfp.MultiFacilityProcessing).Select(f => f.AlternateProcessingFacilityId);

                    if ((turnaround.FacilityId != facility.FacilityId
                        && !associatedFacilities.Contains(turnaround.FacilityId)) && !alternativeFacilities.Contains(turnaround.FacilityId))
                    {
                        throw new Exception();
                    }
                }
            }
            return turnaround;
        }

        /// <summary>
        /// Checks the validity of a turnaround
        /// </summary>
        /// <param name="turnaroundId">Turnaround's int</param>
        /// <returns>ITurnaround</returns>
        /// <summary>
        /// ValidateTurnaround operation
        /// </summary>
        public ITurnaround ValidateTurnaround(int turnaroundId)
        {
            var turnaroundDataAdapter = DataAdapterFactory.GetTurnaroundDataAdapter(OperativeWorkUnit);
            var turnaround = turnaroundDataAdapter.GetTurnaround(turnaroundId);
            if (turnaround == null)
            {
                throw new Exception();
            }
            return turnaround;
        }

        /// <summary>
        /// ValidateTurnaround operation
        /// </summary>
        public ITurnaround ValidateTurnaround(int turnaroundId, short facilityId)
        {
            var turnaroundDataAdapter = DataAdapterFactory.GetTurnaroundDataAdapter(OperativeWorkUnit);
            var turnaround = turnaroundDataAdapter.GetTurnaroundByTurnaroundIdAndFacilityId(turnaroundId, facilityId);
            if (turnaround == null || turnaround.FacilityId != facilityId)
            {
                var facilityDataAdapter = DataAdapterFactory.GetFacilityDataAdapter(OperativeWorkUnit);
                var facility = facilityDataAdapter.GetFacility(facilityId);
                var associatedFacilities = facilityDataAdapter.ReadAssociatedFacilitiesByFacility(facilityId).Select(af => af.FacilityId);

                {
                    var alternativeFacilities = repository.Container.MultiFacilityProcessHandShake.Where(hs => hs.RequestingFacilityId == facilityId && hs.MultiFacilityProcessingId != null).Select(mfp => mfp.MultiFacilityProcessing).Select(f => f.AlternateProcessingFacilityId);

                    if ((turnaround.FacilityId != facility.FacilityId
                        && !associatedFacilities.Contains(turnaround.FacilityId)) && !alternativeFacilities.Contains(turnaround.FacilityId))
                    {
                        throw new Exception();
                    }
                }
            }
            return turnaround;
        }

        /// <summary>
        /// Checks the validity of a facility
        /// </summary>
        /// <param name="facilityId">Facility's int</param>
        /// <returns>IFacility</returns>
        /// <summary>
        /// ValidateFacility operation
        /// </summary>
        public IFacility ValidateFacility(short facilityId)
        {
            var facilityDataAdapter = DataAdapterFactory.GetFacilityDataAdapter(OperativeWorkUnit);
            var facility = (Facility)facilityDataAdapter.GetFacility(facilityId);

            if (facility == null)
            {
                throw new Exception();
            }

            return facility;
        }

        /// <summary>
        /// Checks the validity of a customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>ICustomer</returns>
        /// <summary>
        /// ValidateCustomer operation
        /// </summary>
        public ICustomer ValidateCustomer(int customerId)
        {
            var customerDataAdapter = DataAdapterFactory.GetCustomerDataAdapter(OperativeWorkUnit);
            var customer = customerDataAdapter.GetCustomer(customerId);
            if (customer == null)
            {
                throw new Exception();
            }
            return customer;
        }

        /// <summary>
        /// Checks the validity of a machine
        /// </summary>
        /// <param name="machineId">Machine's int</param>
        /// <returns>IMachine</returns>
        /// <summary>
        /// ValidateMachine operation
        /// </summary>
        public IMachine ValidateMachine(int machineId)
        {
            var machineDataAdapter = DataAdapterFactory.GetMachineDataAdapter(OperativeWorkUnit);
            var machine = machineDataAdapter.GetMachine(machineId);
            if (machine == null)
            {
                throw new Exception();
            }
            return machine;
        }

        /// <summary>
        /// Checks the validity of an item
        /// </summary>
        /// <param name="itemId">Item's int</param>
        /// <returns>IItemMaster</returns>
        /// <summary>
        /// ValidateItemMaster operation
        /// </summary>
        public ItemMaster ValidateItemMaster(int itemId)
        {
            var itemMasterDataAdapter = DataAdapterFactory.GetItemMasterDataAdapter(OperativeWorkUnit);
            var item = itemMasterDataAdapter.GetItemMaster(itemId);
            if (item == null)
            {
                throw new Exception();
            }
            return item;
        }

        /// <summary>
        /// Checks the validity of a delivery point
        /// </summary>
        /// <param name="deliveryPointId">Delivery Point's int</param>
        /// <returns>IDeliveryPoint</returns>
        /// <summary>
        /// ValidateDeliveryPoint operation
        /// </summary>
        public IDeliveryPoint ValidateDeliveryPoint(int? deliveryPointId)
        {
            var deliveryPointDataAdapter = DataAdapterFactory.GetDeliveryPointDataAdapter(OperativeWorkUnit);
            if (deliveryPointId == null)
            {
                throw new Exception();
            }
            var deliveryPoint = deliveryPointDataAdapter.GetDeliveryPoint((int)deliveryPointId);
            if (deliveryPoint == null)
            {
                throw new Exception();
            }
            return deliveryPoint;
        }

        /// <summary>
        /// Checks the validity of a Defect Classification
        /// </summary>
        /// <param name="defectClassificationId">Defect Classification's int</param>
        /// <returns>IDefectClassification</returns>
        /// <summary>
        /// ValidateDefectClassification operation
        /// </summary>
        public IDefectClassification ValidateDefectClassification(int? defectClassificationId)
        {
            var defectClassificationDataAdapter = DataAdapterFactory.GetDefectClassificationDataAdapter(OperativeWorkUnit);
            if (defectClassificationId == null)
            {
                throw new Exception();
            }
            var defectClassificaton = defectClassificationDataAdapter.GetDefectClassification((byte)defectClassificationId);
            if (defectClassificaton == null)
            {
                throw new Exception();
            }
            return defectClassificaton;
        }

        /// <summary>
        /// Checks the validity of a station type
        /// </summary>
        /// <param name="stationTypeId">Station Type's Id</param>
        /// <returns>IStationType</returns>
        /// <summary>
        /// ValidateStationType operation
        /// </summary>
        public IStationType ValidateStationType(byte stationTypeId)
        {
            var stationTypeDataAdapter = DataAdapterFactory.GetStationTypeDataAdapter(OperativeWorkUnit);
            var stationType = stationTypeDataAdapter.GetStationType(stationTypeId);
            if (stationType == null)
            {
                throw new Exception();
            }
            return stationType;
        }

        /// <summary>
        /// Checks the validity of a batch
        /// </summary>
        /// <param name="batchId">Batch's int</param>
        /// <returns>IBatch</returns>
        /// <summary>
        /// ValidateBatch operation
        /// </summary>
        public IBatch ValidateBatch(int batchId)
        {
            var batchDataAdapter = DataAdapterFactory.GetBatchDataAdapter(OperativeWorkUnit);
            var batch = batchDataAdapter.GetBatch(batchId);
            if (batch == null)
            {
                throw new Exception();
            }
            return batch;
        }

        /// <summary>
        /// Check the validity of a container instance
        /// </summary>
        /// <param name="instanceId">Container Instance' int</param>
        /// <returns>IContainerInstance</returns>
        /// <summary>
        /// ValidateContainerInstance operation
        /// </summary>
        public ContainerInstance ValidateContainerInstance(int instanceId)
        {
            var containerInstanceDataAdapter = DataAdapterFactory.GetContainerInstanceDataAdapter(OperativeWorkUnit);
            var containerInstance = containerInstanceDataAdapter.GetContainerInstance(instanceId);
            if (containerInstance == null)
            {
                throw new Exception();
            }
            return containerInstance;
        }

        /// <summary>
        /// Pres the search container instance.
        /// </summary>
        /// <param name="extId">The ext id.</param>
        /// <param name="facilityId">The facility uid.</param>
        /// <summary>
        /// PreSearchContainerInstance operation
        /// </summary>
        public IList<IContainerInstance> PreSearchContainerInstance(string extId, short facilityId)
        {
            var containerInstanceDataAdapter = DataAdapterFactory.GetContainerInstanceDataAdapter(OperativeWorkUnit);
            var facilityDataAdapter = DataAdapterFactory.GetFacilityDataAdapter(OperativeWorkUnit);
            var allAssociatedFacilities = facilityDataAdapter.ReadAssociatedFacilitiesByFacility(facilityId);

            if ((extId.StartsWith("8004", StringComparison.InvariantCulture) && extId.ToUpper(CultureInfo.CurrentCulture).Contains("SYR")) || extId.StartsWith("]d2", StringComparison.InvariantCultureIgnoreCase) || extId.StartsWith("d2", StringComparison.InvariantCultureIgnoreCase))
            {
                extId = extId.Substring(extId.ToUpper(CultureInfo.CurrentCulture).IndexOf("SYR", 1, StringComparison.Ordinal) + 3, extId.Length - extId.ToUpper(CultureInfo.CurrentCulture).IndexOf("SYR", 1, StringComparison.Ordinal) - 3);
            }

            var containerInstanceList = containerInstanceDataAdapter.PreSearchContainerInstance(extId, facilityId).ToList();
            foreach (var associatedFacility in allAssociatedFacilities)
            {
                var associatedFacilityContainerInstances = containerInstanceDataAdapter.PreSearchContainerInstance(extId, associatedFacility.FacilityId).ToList();
                if (associatedFacilityContainerInstances.Count > 0)
                {
                    containerInstanceList.AddRange(associatedFacilityContainerInstances);
                }
            }

            return containerInstanceList.Distinct().ToList();
        }

        /// <summary>
        /// Check the validity of a container master
        /// </summary>
        /// <param name="masterId">Container Master'int</param>
        /// <returns>IContainerMaster</returns>
        /// <summary>
        /// ValidateContainerMaster operation
        /// </summary>
        public IContainerMaster ValidateContainerMaster(int masterId)
        {
            var containerMasterDataAdapter = DataAdapterFactory.GetContainerMasterDataAdapter(OperativeWorkUnit);
            var master = containerMasterDataAdapter.GetContainerMaster(masterId);
            if (master == null)
            {
                throw new Exception();
            }
            return master;
        }

        /// <summary>
        /// Check the validity of a container master by definition uid
        /// </summary>
        /// <param name="definitionId">Definition Uid</param>
        /// <summary>
        /// ValidateContainerMasterByDefinitionId operation
        /// </summary>
        public IContainerMaster ValidateContainerMasterByDefinitionId(int definitionId)
        {
            var containerMasterDataAdapter = DataAdapterFactory.GetContainerMasterDataAdapter(OperativeWorkUnit);
            var master = containerMasterDataAdapter.GetActiveContainerMasterBydefinitionId(definitionId);
            if (master == null)
            {
                throw new Exception();
            }
            return master;
        }

        /// <summary>
        /// Checks the validity of a machine event reason
        /// </summary>
        /// <param name="indexId">Machine Event Reason's Id</param>
        /// <returns>IMachineEventReason</returns>
        /// <summary>
        /// ValidateMachineEventReason operation
        /// </summary>
        public IMachineEventReason ValidateMachineEventReason(byte indexId)
        {
            var machineEventReasonDataAdapter = DataAdapterFactory.GetMachineEventReasonDataAdapter(OperativeWorkUnit);
            var machineEventReason = machineEventReasonDataAdapter.GetMachineEventReason(indexId);
            if (machineEventReason == null)
            {
                throw new Exception();
            }
            return machineEventReason;
        }

        /// <summary>
        /// Checks the validity of a defect
        /// </summary>
        /// <param name="defectId">Defect's int</param>
        /// <returns>IDefect</returns>
        /// <summary>
        /// ValidateDefect operation
        /// </summary>
        public IDefect ValidateDefect(int defectId)
        {
            var defectDataAdapter = DataAdapterFactory.GetDefectDataAdapter(OperativeWorkUnit);
            var defect = defectDataAdapter.GetDefect(defectId);
            if (defect == null)
            {
                throw new Exception();
            }
            return defect;
        }

        /// <summary>
        /// Checks the validity of a customer defect
        /// </summary>
        /// <param name="customerDefectId">customer Defect's int</param>
        /// <returns>IDefect</returns>
        /// <summary>
        /// ValidateCustomerDefect operation
        /// </summary>
        public ICustomerDefect ValidateCustomerDefect(int customerDefectId)
        {
            var defectDataAdapter = DataAdapterFactory.GetCustomerDefectDataAdapter(OperativeWorkUnit);
            var defect = defectDataAdapter.GetCustomerDefect(customerDefectId);
            if (defect == null)
            {
                throw new Exception();
            }
            return defect;
        }

        /// <summary>
        /// Validates the deliverynote.
        /// </summary>
        /// <param name="deliveryNoteId">The deliverynote Id.</param>
        /// <summary>
        /// ValidateDeliveryNote operation
        /// </summary>
        public IDeliveryNote ValidateDeliveryNote(int deliveryNoteId)
        {
            var deliveryNoteDataAdapter = DataAdapterFactory.GetDeliveryNoteDataAdapter(OperativeWorkUnit);
            var deliveryNote = deliveryNoteDataAdapter.GetDeliveryNote(deliveryNoteId);
            if (deliveryNote == null)
            {
                throw new Exception();
            }
            return deliveryNote;
        }

        /// <summary>
        /// Validates the role.
        /// </summary>
        /// <param name="roleId">The role uid.</param>
        /// <summary>
        /// ValidateRole operation
        /// </summary>
        public IRole ValidateRole(short roleId)
        {
            var roleDataAdapter = DataAdapterFactory.GetRoleDataAdapter(OperativeWorkUnit);
            var role = roleDataAdapter.GetRole(roleId);
            if (role == null)
            {
                throw new Exception();
            }
            return role;
        }

        /// <summary>
        /// Validates the permission.
        /// </summary>
        /// <param name="permissionId">The permission id.</param>
        /// <summary>
        /// ValidatePermission operation
        /// </summary>
        public IPermission ValidatePermission(short permissionId)
        {
            var permissionDataAdapter = DataAdapterFactory.GetPermissionDataAdapter(OperativeWorkUnit);
            var permission = permissionDataAdapter.GetPermission(permissionId);
            if (permission == null)
            {
                throw new Exception();
            }
            return permission;
        }

        /// <summary>
        /// Validates the speciality.
        /// </summary>
        /// <param name="specialityId">The speciality id.</param>
        /// <summary>
        /// ValidateSpeciality operation
        /// </summary>
        public ISpeciality ValidateSpeciality(short specialityId)
        {
            var specialityDataAdapter = DataAdapterFactory.GetSpecialityDataAdapter(OperativeWorkUnit);
            var speciality = specialityDataAdapter.GetSpeciality(specialityId);
            if (speciality == null)
            {
                throw new Exception();
            }
            return speciality;
        }

        /// <summary>
        /// Validates the item complexity.
        /// </summary>
        /// <param name="itemComplexityId">The item complexity id.</param>
        /// <summary>
        /// ValidateComplexity operation
        /// </summary>
        public IComplexity ValidateComplexity(short itemComplexityId)
        {
            var complexityDataAdapter = DataAdapterFactory.GetComplexityDataAdapter(OperativeWorkUnit);
            var complexity = complexityDataAdapter.GetComplexity(itemComplexityId);
            if (complexity == null)
            {
                throw new Exception();
            }
            return complexity;
        }

        /// <summary>
        /// Get printer by user and printer type
        /// </summary>
        /// <param name="userId">User's Uid</param>
        /// <param name="printerType">Printer Type</param>
        /// <returns>Printer</returns>
        /// <summary>
        /// ReadPrinterByUserAndPrinterType operation
        /// </summary>
        public IPrinter ReadPrinterByUserAndPrinterType(int userId, PrinterTypeIdentifier printerType, UserCultureData userCultureData, bool localPrintingEnabled = false)
        {
            var userPrinterDataAdapter = DataAdapterFactory.GetUserPrinterDataAdapter(OperativeWorkUnit);
            var userPrinter = (UserPrinter)userPrinterDataAdapter.GetUserPrinterByStationAndPrinterType(userId, (int)printerType);
            if (userPrinter == null || userPrinter.Printer == null)
            {
                if (localPrintingEnabled)
                {
                    var printer = UserPrinterFactory.CreateEntity(OperativeWorkUnit);
                    printer.Printer = PrinterFactory.CreateEntity(OperativeWorkUnit, text: "Local Printing");
                    userPrinter = printer;
                }
                else
                {
                    var errorMessage = "Error: User printer of type " + Enum.GetName(typeof(PrinterTypeIdentifier), printerType) + " not found and local printing not enabled.";
                    
                    throw new PathwayException("0", errorMessage);
                }
            }
            return userPrinter.Printer;
        }

        /// <summary>
        /// Gets administrative station using facility
        /// </summary>
        /// <param name="facilityId"></param>
        /// <summary>
        /// ReadAdminStationByFacility operation
        /// </summary>
        public IStation ReadAdminStationByFacility(int facilityId)
        {
            var stationDataAdapter = DataAdapterFactory.GetStationDataAdapter(OperativeWorkUnit);
            var station = stationDataAdapter.ReadAdminStationByFacility(facilityId);
            return station;
        }

        /// <summary>
        /// Reads the associated station types.
        /// </summary>
        /// <param name="stationId">The station uid.</param>
        /// <summary>
        /// ReadAssociatedStationTypes operation
        /// </summary>
        public IList<IStationType> ReadAssociatedStationTypes(int stationId)
        {
            var stationDataAdapter = DataAdapterFactory.GetStationDataAdapter(OperativeWorkUnit);
            var stationTypes = stationDataAdapter.ReadAssociatedStationTypes(stationId).ToList();
            return stationTypes;
        }
        /// <summary>
        /// CreateNonProcessTurnaroundEvent operation
        /// </summary>
        public void CreateNonProcessTurnaroundEvent(int turnaroundId, TurnAroundEventTypeIdentifier turnAroundEventTypeIdentifier, IStation station, int userId)
        {
            var eventTypeDataAdapter = DataAdapterFactory.GetEventTypeDataAdapter(OperativeWorkUnit);
            var turnaroundEventDataAdapter = DataAdapterFactory.GetTurnaroundEventDataAdapter(OperativeWorkUnit);

            var eventType = eventTypeDataAdapter.GetEventType((short)turnAroundEventTypeIdentifier);
            if (!eventType.ProcessEvent)
            {
                var newTurnaroundEvent = TurnaroundEventFactory.CreateEntity(OperativeWorkUnit,
                   created: ReadLocalStationDateTime(DateTime.UtcNow),
                   eventTypeId: (short)turnAroundEventTypeIdentifier,
                   turnaroundId: turnaroundId,
                   stationId: station.StationId,
                   locationId: station.LocationId,
                   createdUserId: userId,
                   batchId: null,
                   processStationTypeId: station.StationTypeId,
                   workflowId: null,
                   quarantineReasonId: null,
                   pinRequestReasonId: null
               );

                turnaroundEventDataAdapter.CreateTurnaroundEvent(newTurnaroundEvent);
            }
        }

        /// <summary>
        /// Updates the item details.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="userId">The user uid.</param>
        /// <summary>
        /// UpdateItemDetails operation
        /// </summary>
        public int UpdateItemDetails(ContainerMaster item, int userId)
        {
            var containerMasterDataAdapter = DataAdapterFactory.GetContainerMasterDataAdapter(OperativeWorkUnit);

            RetireLastRevisionItem(item);

            var lastRevisionItem =
                containerMasterDataAdapter.GetActiveContainerMasterBydefinitionId(item.ContainerMasterDefinitionId);

            var newRevision = lastRevisionItem.Revision + 1;

            item.Revision = (short)newRevision;
            item.ItemStatusId = (int)ItemStatusTypeIdentifier.Active;
            item.Created = DateTime.UtcNow;
            item.CreatedUserId = userId;
            item.ContainerMasterDefinitionId = lastRevisionItem.ContainerMasterDefinitionId;

            var newItemUid = containerMasterDataAdapter.CreateContainerMaster(item);
            return newItemUid;
        }

        /// <summary>
        /// Retires the last revision item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <summary>
        /// RetireLastRevisionItem operation
        /// </summary>
        public void RetireLastRevisionItem(ContainerMaster item)
        {
            var containerMasterDataAdapter = DataAdapterFactory.GetContainerMasterDataAdapter(OperativeWorkUnit);
            var lastRevisionItem = containerMasterDataAdapter.GetActiveContainerMasterBydefinitionId(item.ContainerMasterDefinitionId);
            lastRevisionItem.ItemStatusId = (int)ItemStatusTypeIdentifier.Retired;
            containerMasterDataAdapter.UpdateContainerMaster(lastRevisionItem);
        }

        /// <summary>
        /// Adds the delivery points for item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="deliveryPoints">The delivery points.</param>
        /// <summary>
        /// AddDeliveryPointsForItem operation
        /// </summary>
        public void AddDeliveryPointsForItem(ContainerMaster item, int[] deliveryPoints)
        {
            if (deliveryPoints == null || deliveryPoints.Length == 0)
            {
                return;
            }
            var containerMasterDataAdapter = DataAdapterFactory.GetContainerMasterDataAdapter(OperativeWorkUnit);

            foreach (var deliveryPointId in deliveryPoints)
            {
                var deliveryPoint = (DeliveryPoint)ValidateDeliveryPoint(deliveryPointId);

                ((ContainerMaster)item).DeliveryPoints.Add(deliveryPoint);
            }

            containerMasterDataAdapter.UpdateContainerMaster(item);
        }

        /// <summary>
        /// Adds the components for item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="components">The components.</param>
        /// <summary>
        /// AddComponentsForItem operation
        /// </summary>
        public void AddComponentsForItem(ContainerMaster item, IList<IContainerContent> components)
        {
            if (components == null || components.Count == 0)
            {
                return;
            }
            var containerContentDataAdapter = DataAdapterFactory.GetContainerContentDataAdapter(OperativeWorkUnit);
            var containerMasterDataAdapter = DataAdapterFactory.GetContainerMasterDataAdapter(OperativeWorkUnit);

            foreach (var component in components)
            {
                var containerContents = ContainerContentFactory.CreateEntity(OperativeWorkUnit,
                    containerMasterId: item.ContainerMasterId,
                    itemMasterDefinitionId: component.ItemMasterDefinitionId,
                    quantity: component.Quantity,
                    position: component.Position,
                    componentListPrint: component.ComponentListPrint
                );

                containerContentDataAdapter.CreateContainerContent(containerContents);
            }
            var ipoh = CalculateIPOHForItem(components);
            item.IPOH = ipoh;
            containerMasterDataAdapter.UpdateContainerMaster(item);
        }

        /// <summary>
        /// Adds the item notes for item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="itemNotes">The item noteses.</param>
        /// <summary>
        /// AddItemNotesForItem operation
        /// </summary>
        public void AddItemNotesForItem(ContainerMaster item, IList<ContainerMasterNote> itemNotes)
        {
            if (itemNotes == null || itemNotes.Count == 0)
            {
                return;
            }
            var containerMasterNoteDataAdapter = DataAdapterFactory.GetContainerMasterNoteDataAdapter(OperativeWorkUnit);
            foreach (var notes in itemNotes)
            {

                var note = ContainerMasterNoteFactory.CreateEntity(OperativeWorkUnit, text: notes.Text, containerMasterNoteTypeId: (byte)notes.ContainerMasterNoteId, containerMasterId: item.ContainerMasterId);
                containerMasterNoteDataAdapter.CreateContainerMasterNote(note);
            }
        }

        /// <summary>
        /// Adds the warnings for item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="warnings">The warnings.</param>
        /// <summary>
        /// AddWarningsForItem operation
        /// </summary>
        public void AddWarningsForItem(ContainerMaster item, IList<Warning> warnings)
        {
            if (warnings == null || warnings.Count == 0)
            {
                return;
            }
            var warningDataAdapter = DataAdapterFactory.GetWarningDataAdapter(OperativeWorkUnit);

            foreach (var war in warnings)
            {
                var warning = WarningFactory.CreateEntity(OperativeWorkUnit,
                    text: war.Text,
                    maximumTurnarounds: war.MaximumTurnarounds,
                    maximumDays: war.MaximumDays,
                    turnaroundLeadIn: war.TurnaroundLeadIn,
                    warningOnly: war.WarningOnly,
                    created: war.Created,
                    containerMasterId: item.ContainerMasterId
                );
                warningDataAdapter.CreateWarning(warning);
            }
        }

        /// <summary>
        /// Calculates the IPOH for item.
        /// </summary>
        /// <param name="components">The components.</param>
        /// <summary>
        /// CalculateIPOHForItem operation
        /// </summary>
        public int CalculateIPOHForItem(IList<IContainerContent> components)
        {
            var itemMasterDataApapter = DataAdapterFactory.GetItemMasterDataAdapter(OperativeWorkUnit);
            var itemTypeDataAdapter = DataAdapterFactory.GetItemTypeDataAdapter(OperativeWorkUnit);
            var containerContenet = components.Where(containerContent => containerContent.ItemMasterDefinitionId.GetValueOrDefault() > 0).AsEnumerable();

            return containerContenet.Select(containerContent => itemMasterDataApapter.GetActiveIItemMasterByDefinitionId(containerContent.ItemMasterDefinitionId.GetValueOrDefault())).Select(itemMaster => itemTypeDataAdapter.GetItemType(itemMaster.ItemTypeId)).Count(itemType => !CheckItemTypeFeatures(itemType.ItemTypeFeatures, ItemTypeFeatureIdentifiers.IPOHCount));
        }

        /// <summary>
        /// Gets the lastest component.
        /// </summary>
        /// <param name="containerContents">The container contents.</param>
        private ItemMaster GetLastestComponent(IContainerContent containerContents)
        {
            var itemMasterDataAdapter = DataAdapterFactory.GetItemMasterDataAdapter(OperativeWorkUnit);
            var lastestItemMaster = itemMasterDataAdapter.GetActiveIItemMasterByDefinitionId(containerContents.ItemMasterDefinitionId.GetValueOrDefault());
            return lastestItemMaster;
        }

        /// <summary>
        /// Gets all components by item.
        /// </summary>
        /// <param name="itemId">The item uid.</param>
        /// <summary>
        /// GetAllComponentsByItem operation
        /// </summary>
        public IList<ItemMaster> GetAllComponentsByItem(int itemId)
        {
            var ContainerContentDataAdapter = DataAdapterFactory.GetContainerContentDataAdapter(OperativeWorkUnit);
            var components = ContainerContentDataAdapter.ReadContainerContentsByContainerMaster(itemId);
            return components.Select(GetLastestComponent).ToList();
        }

        /// <summary>
        /// Updates the component details.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <param name="userId">The user uid.</param>
        /// <summary>
        /// UpdateComponentDetails operation
        /// </summary>
        public int UpdateComponentDetails(ItemMaster component, int userId)
        {
            var itemMasterDataAdapter = DataAdapterFactory.GetItemMasterDataAdapter(OperativeWorkUnit);

            RetireLastRevisionComponent(component);

            var lastRevisionComponent = itemMasterDataAdapter.GetActiveIItemMasterByDefinitionId(component.ItemMasterDefinitionId);

            var newRevision = lastRevisionComponent.Revision + 1;

            component.Revision = newRevision;
            component.ItemStatusId = (int)ItemStatusTypeIdentifier.Active;
            component.Created = DateTime.UtcNow;
            component.CreatedUserId = userId;
            component.ItemMasterDefinitionId = lastRevisionComponent.ItemMasterDefinitionId;

            var newComponentUid = itemMasterDataAdapter.CreateItemMaster(component);
            return newComponentUid;
        }

        /// <summary>
        /// Retires the last revision component.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <summary>
        /// RetireLastRevisionComponent operation
        /// </summary>
        public void RetireLastRevisionComponent(ItemMaster component)
        {
            var itemMasterDataAdapter = DataAdapterFactory.GetItemMasterDataAdapter(OperativeWorkUnit);
            var lastRevisionComponent = itemMasterDataAdapter.GetActiveIItemMasterByDefinitionId(component.ItemMasterDefinitionId);
            lastRevisionComponent.ItemStatusId = (int)ItemStatusTypeIdentifier.Retired;
            itemMasterDataAdapter.UpdateItemMaster(lastRevisionComponent);
        }

        /// <summary>
        /// Adds the item notes for component.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <param name="itemNoteses">The item noteses.</param>
        /// <summary>
        /// AddItemNotesForComponent operation
        /// </summary>
        public void AddItemNotesForComponent(ItemMaster component, IList<ContainerMasterNote> itemNoteses)
        {
            if (itemNoteses == null || itemNoteses.Count == 0)
            {
                return;
            }
            var containerMasterNoteDataAdapter = DataAdapterFactory.GetContainerMasterNoteDataAdapter(OperativeWorkUnit);
            foreach (var itemNotes in itemNoteses)
            {
                var note = ContainerMasterNoteFactory.CreateEntity(OperativeWorkUnit,
                   text: itemNotes.Text,
                   containerMasterNoteTypeId: itemNotes.ContainerMasterNoteTypeId,
                   itemMasterId: component.ItemMasterDefinitionId);
                containerMasterNoteDataAdapter.CreateContainerMasterNote(note);
            }
        }

        /// <summary>
        /// Adds the warnings for component.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <param name="warnings">The warnings.</param>
        /// <summary>
        /// AddWarningsForComponent operation
        /// </summary>
        public void AddWarningsForComponent(ItemMaster component, IList<Warning> warnings)
        {
            if (warnings == null || warnings.Count == 0)
            {
                return;
            }
            var warningDataAdapter = DataAdapterFactory.GetWarningDataAdapter(OperativeWorkUnit);

            foreach (var war in warnings)
            {
                var warning = WarningFactory.CreateEntity(OperativeWorkUnit,
                    text: war.Text,
                    maximumTurnarounds: war.MaximumTurnarounds,
                    maximumDays: war.MaximumDays,
                    turnaroundLeadIn: war.TurnaroundLeadIn,
                    warningOnly: war.WarningOnly,
                    created: war.Created,
                    itemMasterId: component.ItemMasterDefinitionId);
                warningDataAdapter.CreateWarning(warning);
            }
        }

        /// <summary>
        /// Checks the item type features.
        /// </summary>
        /// <param name="itemTypeFeatures">The item type features.</param>
        /// <param name="feature">The feature.</param>
        /// <summary>
        /// CheckItemTypeFeatures operation
        /// </summary>
        public bool CheckItemTypeFeatures(byte itemTypeFeatures, ItemTypeFeatureIdentifiers feature)
        {
            var convertedFeatures = (ItemTypeFeatureIdentifiers)itemTypeFeatures;
            if ((convertedFeatures & feature) == feature)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Retires the last revision customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <summary>
        /// RetireLastRevisionCustomer operation
        /// </summary>
        public void RetireLastRevisionCustomer(Customer customer)
        {
            var customerDataAdapter = DataAdapterFactory.GetCustomerDataAdapter(OperativeWorkUnit);
            var lastRevisionCustomer = customerDataAdapter.GetActiveOneByDefinitionId(customer.CustomerDefinitionId);
            if (lastRevisionCustomer.CustomerStatusId == (int)CustomerStatusTypeIdentifier.Stop || customer.CustomerStatusId == (int)CustomerStatusTypeIdentifier.Stop)
            {
                lastRevisionCustomer.CustomerStatusId = (int)CustomerStatusTypeIdentifier.RetiredOnStop;
            }
            else
            {
                lastRevisionCustomer.CustomerStatusId = (int)CustomerStatusTypeIdentifier.Retired;
            }
            customerDataAdapter.UpdateCustomer(lastRevisionCustomer);
        }

        /// <summary>
        /// get turnaround's item type
        /// </summary>
        /// <param name="turnaroundId">The turnaround uid.</param>
        /// <summary>
        /// ReadTurnaroundItemType operation
        /// </summary>
        public IItemType ReadTurnaroundItemType(int turnaroundId)
        {
            var itemTypeDataAdapter = DataAdapterFactory.GetItemTypeDataAdapter(OperativeWorkUnit);
            var turnaround = (Turnaround)ValidateTurnaround(turnaroundId);

            var itemType = ItemTypeFactory.CreateEntity(OperativeWorkUnit);
            if (turnaround.ContainerInstance?.ContainerMasterDefinition?.ContainerMasters.OrderByDescending(cm => cm.Revision).
                FirstOrDefault() != null)
            {
                var item =
                    turnaround.ContainerInstance.ContainerMasterDefinition.ContainerMasters.
                        OrderByDescending(cm => cm.Revision).FirstOrDefault();

                if (item != null)
                {
                    itemType = (ItemType)itemTypeDataAdapter.GetItemType(item.ItemTypeId);
                }
            }
            else if (turnaround.ContainerMaster != null)
            {
                var item =
                    turnaround.ContainerMaster;
                itemType = (ItemType)itemTypeDataAdapter.GetItemType(item.ItemTypeId);
            }
            return itemType;
        }

        /// <summary>
        /// change machine status,pass in machineId, availability status and reason
        /// </summary>
        /// <param name="machineId">machine int</param>
        /// <param name="userId">user id</param>
        /// <param name="reasonId">reason id</param>
        /// <param name="stationId">station uid</param>
        /// <summary>
        /// MakeMachineUnavailable operation
        /// </summary>
        public IMachine MakeMachineUnavailable(int machineId, int userId, byte reasonId, int stationId)
        {
            var machineEventDataAdapter = DataAdapterFactory.GetMachineEventDataAdapter(OperativeWorkUnit);
            var machineDataAdapter = DataAdapterFactory.GetMachineDataAdapter(OperativeWorkUnit);

            var machine = ValidateMachine(machineId);
            var user = ValidateUser(userId);
            var station = ValidateStation(stationId);
            ValidateMachineEventReason(reasonId);

            var me = MachineEventFactory.CreateEntity(OperativeWorkUnit,
                machineId: machine.MachineId,
                machineEventReasonId: reasonId,
                created: DateTime.UtcNow,
                machineEventTypeId: (byte)MachineEventTypeIdentifier.UnAvailable,
                stationId: station.StationId,
                createdUserId: user.UserId);

            machineEventDataAdapter.CreateMachineEvent(me);
            return machineDataAdapter.GetMachine(machineId);
        }

        /// <summary>
        /// make machine available
        /// </summary>
        /// <param name="machineId">machine</param>
        /// <param name="userId">user Uid</param>
        /// <param name="stationId">station Uid</param>
        /// <summary>
        /// MakeMachineAvailable operation
        /// </summary>
        public IMachine MakeMachineAvailable(int machineId, int userId, int stationId)
        {
            var machineEventDataAdapter = DataAdapterFactory.GetMachineEventDataAdapter(OperativeWorkUnit);
            var machineDataAdapter = DataAdapterFactory.GetMachineDataAdapter(OperativeWorkUnit);

            var machine = ValidateMachine(machineId);
            var user = ValidateUser(userId);
            var station = ValidateStation(stationId);

            var me = MachineEventFactory.CreateEntity(OperativeWorkUnit,
                 machineId: machine.MachineId,
                 created: DateTime.UtcNow,
                 machineEventTypeId: (byte)MachineEventTypeIdentifier.Available,
                 stationId: station.StationId,
                 createdUserId: user.UserId);

            machineEventDataAdapter.CreateMachineEvent(me);
            return machineDataAdapter.GetMachine(machineId);
        }

        /// <summary>
        /// Method to get event type using station type
        /// </summary>
        /// <param name="stationTypeId"></param>
        /// <summary>
        /// GetEventTypeByStationAndEventId operation
        /// </summary>
        public IEventType GetEventTypeByStationAndEventId(int stationTypeId, int? eventTypeId)
        {
            var eventTypeDataAdapter = DataAdapterFactory.GetEventTypeDataAdapter(OperativeWorkUnit);
            return eventTypeDataAdapter.ReadPreferredEventTypeByStationTypeAndEventType((short)stationTypeId, eventTypeId);
        }

        /// <summary>
        /// Read last process event
        /// </summary>
        /// <param name="turnaroundId">The turnaround uid.</param>
        /// <summary>
        /// ReadLastProcessEvent operation
        /// </summary>
        public ITurnaroundEvent ReadLastProcessEvent(int turnaroundId)
        {
            var turnaroundEventDataAdapter = DataAdapterFactory.GetTurnaroundEventDataAdapter(OperativeWorkUnit);
            var turnaround = ValidateTurnaround(turnaroundId);

            return turnaroundEventDataAdapter.GetLastProcessEventByTurnaroundId(turnaround.TurnaroundId);
        }

        /// <summary>
        /// Reads the last live turnaround by instance.
        /// </summary>
        /// <param name="containerInstancePrimaryId">The instance primary id.</param>
        /// <summary>
        /// ReadLastLiveTurnaroundByInstance operation
        /// </summary>
        public ITurnaround ReadLastLiveTurnaroundByInstance(string containerInstancePrimaryId, short facilityId)
        {
            var containerInstanceDataAdapter = DataAdapterFactory.GetContainerInstanceDataAdapter(OperativeWorkUnit);
            var lastTurnaround = containerInstanceDataAdapter.ReadLastLiveTurnaroundByInstance(containerInstancePrimaryId, facilityId);
            return lastTurnaround;
        }

        /// <summary>
        /// Reads the local station date time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        private DateTime ReadLocalStationDateTime(DateTime dateTime)
        {
            return dateTime;
        }

        /// <summary>
        /// Reads the turnaround WH by turnaround.
        /// </summary>
        /// <param name="turnaroundId">The turnaround uid.</param>
        /// <summary>
        /// ReadTurnaroundWhByTurnaround operation
        /// </summary>
        public ITurnaroundWH ReadTurnaroundWhByTurnaround(int turnaroundId)
        {
            var turnaroundWhDataAdapter = DataAdapterFactory.GetTurnaroundWHDataAdapter(OperativeWorkUnit);
            var turnaroundWh = turnaroundWhDataAdapter.ReadTurnaroundWHByTurnaround(turnaroundId);
            return turnaroundWh;
        }

        /// <summary>
        /// Reads the child turnarounds.
        /// </summary>
        /// <param name="turnaroundId">The turnaround uid.</param>
        /// <summary>
        /// ReadChildTurnarounds operation
        /// </summary>
        public IList<ITurnaround> ReadChildTurnarounds(int turnaroundId)
        {
            var turnaroundDataAdapter = DataAdapterFactory.GetTurnaroundDataAdapter(OperativeWorkUnit);
            var turnaroundWhs = turnaroundDataAdapter.ReadChildTurnarounds(turnaroundId).ToList();
            return turnaroundWhs;
        }
    }
}
