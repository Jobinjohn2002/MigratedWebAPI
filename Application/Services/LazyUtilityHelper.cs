using System;
using System.Collections.Generic;
using System.Linq;
using SynergyApplicationFrameworkApi.Entities;
using SynergyApplicationFrameworkApi.DataContracts;
using SynergyApplicationFrameworkApi.Domain;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class LazyUtilityHelper
    {
        /// <summary>
        /// ConvertCustomerToCustomerData operation
        /// </summary>
        public static CustomerData? ConvertCustomerToCustomerData(ICustomer? customer)
        {
            return customer == null ? null : new CustomerData(customer);
        }

        /// <summary>
        /// ConvertCustomerListToCustomersData operation
        /// </summary>
        public static IList<CustomerData>? ConvertCustomerListToCustomersData(IList<ICustomer>? customers)
        {
            if (customers == null)
            {
                return null;
            }
            IList<CustomerData> customerDataList = customers.Select(ConvertCustomerToCustomerData).ToList();
            return customerDataList;
        }

        /// <summary>
        /// ConvertDeliveryPointToDeliveryPointData operation
        /// </summary>
        public static DeliveryPointData? ConvertDeliveryPointToDeliveryPointData(IDeliveryPoint? deliveryPoint)
        {
            if (deliveryPoint == null)
            {
                return null;
            }
            return new DeliveryPointData(deliveryPoint);
        }

        /// <summary>
        /// ConvertDeliveryPointsListToDeliveryPointsData operation
        /// </summary>
        public static IList<DeliveryPointData>? ConvertDeliveryPointsListToDeliveryPointsData(
            IList<IDeliveryPoint>? deliveryPoints)
        {
            if (deliveryPoints == null)
            {
                return null;
            }
            IList<DeliveryPointData> customerDataList =
                deliveryPoints.Select(ConvertDeliveryPointToDeliveryPointData).ToList();
            return customerDataList;
        }

        /// <summary>
        /// ConvertServiceRequirementToServiceRequirementData operation
        /// </summary>
        public static ServiceRequirementData? ConvertServiceRequirementToServiceRequirementData(
            IServiceRequirement? serviceRequirement)
        {
            return serviceRequirement == null ? null : new ServiceRequirementData(serviceRequirement);
        }

        /// <summary>
        /// ConvertServiceRequirementListToServiceRequirementsData operation
        /// </summary>
        public static IList<ServiceRequirementData>? ConvertServiceRequirementListToServiceRequirementsData(
            IList<IServiceRequirement>? serviceRequirements)
        {
            if (serviceRequirements == null)
            {
                return null;
            }
            IList<ServiceRequirementData> serviceRequirementList =
                serviceRequirements.Select(serviceRequirement => new ServiceRequirementData(serviceRequirement)).
                    ToList();
            return serviceRequirementList;
        }

        /// <summary>
        /// ConvertFacilityNoteToFacilityNoteData operation
        /// </summary>
        public static FacilityNoteData? ConvertFacilityNoteToFacilityNoteData(IFacilityNote? facilityNote)
        {
            if (facilityNote == null)
            {
                return null;
            }
            return new FacilityNoteData(facilityNote);
        }

        /// <summary>
        /// ConvertContainerMasterToContainerMasterData operation
        /// </summary>
        public static ContainerMasterData? ConvertContainerMasterToContainerMasterData(IContainerMaster? containerMaster)
        {
            if (containerMaster == null)
            {
                return null;
            }
            return new ContainerMasterData(containerMaster);
        }

        /// <summary>
        /// ConvertEventTypeToEventTypeData operation
        /// </summary>
        public static EventTypeData? ConvertEventTypeToEventTypeData(IEventType? eventType)
        {
            if (eventType == null)
            {
                return null;
            }
            return new EventTypeData(eventType);
        }

        /// <summary>
        /// ConvertEventTypesToEventTypesData operation
        /// </summary>
        public static IList<EventTypeData>? ConvertEventTypesToEventTypesData(IList<IEventType>? eventTypes)
        {
            if (eventTypes == null)
            {
                return null;
            }
            IList<EventTypeData> eventTypeDatas = eventTypes.Select(ConvertEventTypeToEventTypeData).ToList();
            return eventTypeDatas;
        }

        /// <summary>
        /// ConvertMachineToMachineData operation
        /// </summary>
        public static MachineData? ConvertMachineToMachineData(IMachine? machine)
        {
            return machine == null ? null : new MachineData(machine);
        }

        /// <summary>
        /// ConvertMachineToMachineData operation
        /// </summary>
        public static MachineData? ConvertMachineToMachineData(IMachine? machine, MachineEventData? machineEvent)
        {
            return machine == null ? null : new MachineData(machine, machineEvent);
        }

        /// <summary>
        /// ConvertMachineListToMachinesData operation
        /// </summary>
        public static IList<MachineData>? ConvertMachineListToMachinesData(IList<IMachine>? machines)
        {
            if (machines == null)
            {
                return null;
            }
            IList<MachineData> machineDataList = machines.Select(ConvertMachineToMachineData).ToList();
            return machineDataList;
        }

        /// <summary>
        /// ConvertMachineEventTypeToMachineEventTypeData operation
        /// </summary>
        public static MachineEventTypeData? ConvertMachineEventTypeToMachineEventTypeData(
            IMachineEventType? machineEventType)
        {
            return machineEventType == null ? null : new MachineEventTypeData(machineEventType);
        }

        /// <summary>
        /// ConvertMachineEventTypeListToMachineEventTypesData operation
        /// </summary>
        public static IList<MachineEventTypeData>? ConvertMachineEventTypeListToMachineEventTypesData(
            IList<IMachineEventType>? machineEventTypes)
        {
            if (machineEventTypes == null)
            {
                return null;
            }
            IList<MachineEventTypeData> machineEventTypeDataList =
                machineEventTypes.Select(ConvertMachineEventTypeToMachineEventTypeData).ToList();
            return machineEventTypeDataList;
        }

        /// <summary>
        /// ConvertMachineEventToMachineEventData operation
        /// </summary>
        public static MachineEventData? ConvertMachineEventToMachineEventData(IMachineEvent? machineEvent)
        {
            return machineEvent == null ? null : new MachineEventData(machineEvent);
        }

        /// <summary>
        /// ConvertMachineEventToMachineEventData operation
        /// </summary>
        public static MachineEventData? ConvertMachineEventToMachineEventData(IMachineEvent? machineEvent,
                                                                             MachineEventTypeData? machineEventTypeData)
        {
            return machineEvent == null ? null : new MachineEventData(machineEvent, machineEventTypeData);
        }

        /// <summary>
        /// ConvertMachineEventListToMachineEventsData operation
        /// </summary>
        public static IList<MachineEventData>? ConvertMachineEventListToMachineEventsData(
            IList<IMachineEvent>? machineEvents)
        {
            if (machineEvents == null)
            {
                return null;
            }
            IList<MachineEventData> machineEventDataList =
                machineEvents.Select(ConvertMachineEventToMachineEventData).ToList();
            return machineEventDataList;
        }

        /// <summary>
        /// ConvertMachineTypeToMachineTypeData operation
        /// </summary>
        public static MachineTypeData? ConvertMachineTypeToMachineTypeData(IMachineType? machineType)
        {
            return machineType == null ? null : new MachineTypeData(machineType);
        }

        /// <summary>
        /// ConvertMachineTypeListToMachineTypesData operation
        /// </summary>
        public static IList<MachineTypeData>? ConvertMachineTypeListToMachineTypesData(IList<IMachineType>? machineTypes)
        {
            if (machineTypes == null)
            {
                return null;
            }
            IList<MachineTypeData> machineTypeDataList =
                machineTypes.Select(ConvertMachineTypeToMachineTypeData).ToList();
            return machineTypeDataList;
        }

        /// <summary>
        /// ConvertBatchCycleToBatchCycleData operation
        /// </summary>
        public static BatchCycleData? ConvertBatchCycleToBatchCycleData(IBatchCycle? batchCycle)
        {
            return batchCycle == null ? null : new BatchCycleData(batchCycle);
        }

        /// <summary>
        /// ConvertBatchCycleListToBatchCyclesData operation
        /// </summary>
        public static IList<BatchCycleData>? ConvertBatchCycleListToBatchCyclesData(IList<IBatchCycle>? batchCycles)
        {
            if (batchCycles == null)
            {
                return null;
            }
            IList<BatchCycleData> batchCycleDataList = batchCycles.Select(ConvertBatchCycleToBatchCycleData).ToList();
            return batchCycleDataList;
        }

        /// <summary>
        /// ConvertMachineEventReasonToMachineEventReasonData operation
        /// </summary>
        public static MachineEventReasonData? ConvertMachineEventReasonToMachineEventReasonData(
            IMachineEventReason? machineEventReason)
        {
            return machineEventReason == null ? null : new MachineEventReasonData(machineEventReason);
        }

        /// <summary>
        /// ConvertMachineEventReasonListToMachineEventReasonsData operation
        /// </summary>
        public static IList<MachineEventReasonData>? ConvertMachineEventReasonListToMachineEventReasonsData(
            IList<IMachineEventReason>? machineEventReasons)
        {
            if (machineEventReasons == null)
            {
                return null;
            }
            IList<MachineEventReasonData> machineEventReasonDataList =
                machineEventReasons.Select(ConvertMachineEventReasonToMachineEventReasonData).ToList();
            return machineEventReasonDataList;
        }

        /// <summary>
        /// ConvertBatchToBatchData operation
        /// </summary>
        public static BatchData? ConvertBatchToBatchData(IBatch? batch)
        {
            if (batch != null)
            {
                var b = batch as Batch;
                BatchCycle? batcyCycle;
                string batchCycleName = string.Empty;
                if (b != null)
                {
                    batcyCycle = b.BatchCycle;
                    if (batcyCycle != null)
                    {
                        batchCycleName = batcyCycle.Text;
                    }
                }
                return new BatchData(batch, batchCycleName);
            }
            return null;
        }

        /// <summary>
        /// ConvertNoteToTurnaroundNoteData operation
        /// </summary>
        public static TurnaroundNoteData? ConvertNoteToTurnaroundNoteData(ITurnaroundNote? note)
        {
            return note == null ? null : new TurnaroundNoteData(note);
        }

        /// <summary>
        /// ConvertNotesToNotesData operation
        /// </summary>
        public static IList<TurnaroundNoteData>? ConvertNotesToNotesData(IList<ITurnaroundNote>? notes)
        {
            if (notes == null)
            {
                return null;
            }
            IList<TurnaroundNoteData> notesDataList = notes.Select(ConvertNoteToTurnaroundNoteData).ToList();
            return notesDataList;
        }

        /// <summary>
        /// ConvertItemNoteToItemTurnaroundNoteData operation
        /// </summary>
        public static ContainerMasterNoteData? ConvertItemNoteToItemTurnaroundNoteData(IContainerMasterNote? itemNote)
        {
            return itemNote == null ? null : new ContainerMasterNoteData(itemNote);
        }

        /// <summary>
        /// ConvertItemNotesToContainerMasterNoteData operation
        /// </summary>
        public static IList<ContainerMasterNoteData>? ConvertItemNotesToContainerMasterNoteData(
            IList<IContainerMasterNote>? itemNotes)
        {
            if (itemNotes == null)
            {
                return null;
            }
            IList<ContainerMasterNoteData> ContainerMasterNoteDataList =
                itemNotes.Select(ConvertItemNoteToItemTurnaroundNoteData).ToList();
            return ContainerMasterNoteDataList;
        }

        /// <summary>
        /// ConvertWarningToWarningData operation
        /// </summary>
        public static WarningData? ConvertWarningToWarningData(IWarning? warning)
        {
            return warning == null ? null : new WarningData(warning);
        }

        /// <summary>
        /// ConvertWarningsToWarningsData operation
        /// </summary>
        public static IList<WarningData>? ConvertWarningsToWarningsData(IList<IWarning>? warnings)
        {
            if (warnings == null)
            {
                return null;
            }
            IList<WarningData> warningDataList = warnings.Select(ConvertWarningToWarningData).ToList();
            return warningDataList;
        }

        /// <summary>
        /// ConvertTurnaroundToTurnaroundData operation
        /// </summary>
        public static TurnaroundData? ConvertTurnaroundToTurnaroundData(IUnitOfWork workUnit,
                                                                       ITurnaround? genericTurnaround)
        {
            IUtilityEventHandler utilityEventHandler = EventHandlerFactory.GetUtilityEventHandler(workUnit);
            if (genericTurnaround == null)
            {
                return null;
            }
            var turnaround = (Turnaround)genericTurnaround;
            ITurnaroundWH? genericTurnaroundWH = utilityEventHandler.ReadTurnaroundWhByTurnaround(turnaround.TurnaroundId);

            var turnaroundWH = (TurnaroundWH?)genericTurnaroundWH;

            TurnaroundData? turnaroundData = null;

            if (turnaroundWH != null)
            {
                turnaroundData = new TurnaroundData(turnaround, turnaroundWH.ContainerInstancePrimaryId,
                                                        turnaroundWH.ContainerMasterName,
                                                        turnaroundWH.ServiceRequirementName,
                                                        turnaroundWH.ContainerMasterItemTypeId,
                                                        turnaroundWH.ContainerMasterItemType, (int?)turnaroundWH.LastEventTypeId, (int?)turnaroundWH.NextEventTypeId, turnaroundWH.ContainerMasterDefinitionId, turnaroundWH.NextEventName);
                if (turnaround.TurnaroundEvent != null)
                {
                    turnaroundData.LastProcessEventTypeId = turnaround.TurnaroundEvent.Where(i => i.EventType.ProcessEvent).OrderByDescending(j => j.TurnaroundEventId).Take(1).FirstOrDefault()?.EventTypeId;
                }
            }
            return turnaroundData;
        }

        /// <summary>
        /// ConvertTurnaroundsToTurnaroundsData operation
        /// </summary>
        public static IList<TurnaroundData>? ConvertTurnaroundsToTurnaroundsData(IUnitOfWork workUnit,
                                                                                IList<ITurnaround>? turnarounds)
        {
            if (turnarounds == null)
            {
                return null;
            }
            IList<TurnaroundData> turnaroundsDataList =
              turnarounds.Select(ts => ConvertTurnaroundToTurnaroundData(workUnit, ts)).Where(i => i != null).ToList();

            return turnaroundsDataList;
        }

        /// <summary>
        /// ConvertTurnaroundEventToTurnaroundEventData operation
        /// </summary>
        public static TurnaroundEventData? ConvertTurnaroundEventToTurnaroundEventData(ITurnaroundEvent? turnaroundEvent)
        {
            return turnaroundEvent == null ? null : new TurnaroundEventData(turnaroundEvent);
        }

        /// <summary>
        /// ConvertTurnaroundEventsToTurnaroundEventsData operation
        /// </summary>
        public static IList<TurnaroundEventData>? ConvertTurnaroundEventsToTurnaroundEventsData(
            IList<ITurnaroundEvent>? turnaroundEvents)
        {
            if (turnaroundEvents == null)
            {
                return null;
            }
            IList<TurnaroundEventData> turnaroundEventsDataList =
                turnaroundEvents.Select(ConvertTurnaroundEventToTurnaroundEventData).ToList();
            return turnaroundEventsDataList;
        }

        /// <summary>
        /// ConvertUserToUserData operation
        /// </summary>
        public static UserData? ConvertUserToUserData(IUser? user)
        {
            if (user == null)
            {
                return null;
            }
            List<short> facilities = ((User)user).UserFacility.Where(uf => uf.Selected).Select(uf => uf.FacilityId).ToList();
            IList<Role> userrole = ((User)user).UserRole.Select(r => r.Role).Where(r => r.Archived == null).ToList();

            return new UserData(user, facilities, ConvertRolesToRoleData(userrole));
        }

        /// <summary>
        /// ConvertPermissionToPermissionData operation
        /// </summary>
        public static RolePermissionData? ConvertPermissionToPermissionData(RolePermission? rolePermission)
        {
            return rolePermission == null ? null : new RolePermissionData(rolePermission);
        }

        /// <summary>
        /// ConvertRolePermissionToRolePermissionData operation
        /// </summary>
        public static IList<RolePermissionData>? ConvertRolePermissionToRolePermissionData(IList<RolePermission>? rolePermissions)
        {
            if (rolePermissions == null)
            {
                return null;
            }
            IList<RolePermissionData> rolePermissionData = rolePermissions.Select(ConvertPermissionToPermissionData).ToList();
            return rolePermissionData;
        }

        /// <summary>
        /// ConvertRoleToRoleData operation
        /// </summary>
        public static RoleData? ConvertRoleToRoleData(Role? role)
        {
            return role == null ? null : new RoleData(role);
        }

        /// <summary>
        /// ConvertRolesToRoleData operation
        /// </summary>
        public static IList<RoleData>? ConvertRolesToRoleData(IList<Role>? roles)
        {
            if (roles == null)
            {
                return null;
            }
            IList<RoleData> stationTypeDatas = roles.Select(ConvertRoleToRoleData).ToList();
            return stationTypeDatas;
        }

        /// <summary>
        /// ConvertStationToStationData operation
        /// </summary>
        public static StationData? ConvertStationToStationData(IStation? station)
        {
            return station == null ? null : new StationData(station);
        }

        /// <summary>
        /// ConvertStationToStationData operation
        /// </summary>
        public static StationData? ConvertStationToStationData(IStation? station, IStationType? stationType,
                                                              IList<IStationType>? associatedStationTypes)
        {
            return station == null ? null : new StationData(station, stationType, associatedStationTypes);
        }

        /// <summary>
        /// ConvertStationTypeToStationTypeData operation
        /// </summary>
        public static StationTypeData? ConvertStationTypeToStationTypeData(IStationType? stationType)
        {
            return stationType == null ? null : new StationTypeData(stationType);
        }

        /// <summary>
        /// ConvertStationTypesToStationTypesData operation
        /// </summary>
        public static IList<StationTypeData>? ConvertStationTypesToStationTypesData(IList<IStationType>? stationTypes)
        {
            if (stationTypes == null)
            {
                return null;
            }
            IList<StationTypeData> stationTypeDatas = stationTypes.Select(ConvertStationTypeToStationTypeData).ToList();
            return stationTypeDatas;
        }

        /// <summary>
        /// ConvertItemTypeToItemTypeData operation
        /// </summary>
        public static ItemTypeData? ConvertItemTypeToItemTypeData(IItemType? itemType)
        {
            return itemType == null ? null : new ItemTypeData(itemType);
        }

        /// <summary>
        /// ConvertItemTypesToItemTypesData operation
        /// </summary>
        public static IList<ItemTypeData>? ConvertItemTypesToItemTypesData(IList<IItemType>? itemTypes)
        {
            if (itemTypes == null)
            {
                return null;
            }
            IList<ItemTypeData> itemTypeDatas = itemTypes.Select(ConvertItemTypeToItemTypeData).ToList();
            return itemTypeDatas;
        }

        /// <summary>
        /// ConvertMachineToStationData operation
        /// </summary>
        public static MachineData? ConvertMachineToStationData(IMachine? genericMachine)
        {
            if (genericMachine != null)
            {
                var machine = (Machine)genericMachine;
                return new MachineData(machine);
            }
            return null;
        }

        /// <summary>
        /// ConvertDefectClassificationToDefectClassificationData operation
        /// </summary>
        public static DefectClassificationData? ConvertDefectClassificationToDefectClassificationData(
            IDefectClassification? defectClassification)
        {
            return defectClassification == null ? null : new DefectClassificationData(defectClassification);
        }

        /// <summary>
        /// ConvertDefectClassificationsToDefectClassificationsData operation
        /// </summary>
        public static IList<DefectClassificationData>? ConvertDefectClassificationsToDefectClassificationsData(
            IList<IDefectClassification>? defectClassifications)
        {
            if (defectClassifications == null)
            {
                return null;
            }
            IList<DefectClassificationData> defectClassificationDatas =
                defectClassifications.Select(ConvertDefectClassificationToDefectClassificationData).ToList();
            return defectClassificationDatas;
        }

        /// <summary>
        /// ConvertFailureTypeToFailureTypeData operation
        /// </summary>
        public static FailureTypeData? ConvertFailureTypeToFailureTypeData(IFailureType? failureType)
        {
            return failureType == null ? null : new FailureTypeData(failureType);
        }

        /// <summary>
        /// ConvertFailureTypesToFailureTypesData operation
        /// </summary>
        public static IList<FailureTypeData>? ConvertFailureTypesToFailureTypesData(IList<IFailureType>? failureTypes)
        {
            if (failureTypes == null)
            {
                return null;
            }
            IList<FailureTypeData> failureTypeDatas = failureTypes.Select(ConvertFailureTypeToFailureTypeData).ToList();
            return failureTypeDatas;
        }

        /// <summary>
        /// ConvertTurnaroundWHToPriorityScreenData operation
        /// </summary>
        public static PriorityScreenData? ConvertTurnaroundWHToPriorityScreenData(ITurnaroundWH? turnaroundWH)
        {
            if (turnaroundWH == null)
            {
                return null;
            }

            var concTurnaroundWH = (TurnaroundWH)turnaroundWH;

            int minutesRemain = 0;

            DateTime now = DateTime.UtcNow;

            TimeSpan ts = turnaroundWH.Expiry - now;
            minutesRemain = ts.Days * 3600 + ts.Hours * 60 + ts.Minutes;

            var psStationData = new PriorityScreenData(concTurnaroundWH.TurnaroundId,
                                                       concTurnaroundWH.TurnaroundExternalId,
                                                       concTurnaroundWH.ContainerInstanceId ?? 0,
                                                       concTurnaroundWH.ContainerInstancePrimaryId,
                                                       concTurnaroundWH.ServiceRequirementId,
                                                       concTurnaroundWH.ServiceRequirementName,
                                                       concTurnaroundWH.ContainerMasterId,
                                                       concTurnaroundWH.ContainerMasterName,
                                                       concTurnaroundWH.Expiry,
                                                       null,
                                                       null,
                                                       null,
                                                       concTurnaroundWH.StartEventTime == null
                                                           ? DateTime.MinValue
                                                           : (DateTime)concTurnaroundWH.StartEventTime,
                                                       concTurnaroundWH.ContainerMasterItemTypeId,
                                                       concTurnaroundWH.ContainerMasterItemType,
                                                       concTurnaroundWH.CustomerDefinitionId,
                                                       concTurnaroundWH.CustomerName,
                                                       concTurnaroundWH.DeliveryPointId,
                                                       concTurnaroundWH.DeliveryPointName,
                                                       minutesRemain);

            return psStationData;
        }

        /// <summary>
        /// ConvertTurnaroundWHsToPriorityScreenData operation
        /// </summary>
        public static IList<PriorityScreenData>? ConvertTurnaroundWHsToPriorityScreenData(
            IList<TurnaroundWH>? turnaroundWHs)
        {
            return turnaroundWHs == null ? null : turnaroundWHs.Select(ConvertTurnaroundWHToPriorityScreenData).ToList();
        }

        #region BiologicalIndicatorTest

        /// <summary>
        /// ConvertBiologicalIndicatorTestToDataContract operation
        /// </summary>
        public static BiologicalIndicatorTestData? ConvertBiologicalIndicatorTestToDataContract(IBiologicalIndicatorTest? genericBiologicalIndicatorTest)
        {
            if (genericBiologicalIndicatorTest == null)
            {
                return null;
            }
            var data = new BiologicalIndicatorTestData(genericBiologicalIndicatorTest);
            var generic = genericBiologicalIndicatorTest as BiologicalIndicatorTest;
            if (generic != null)
            {
                data.BiologicalIndicatorTestStatusText = generic.BiologicalIndicatorTestStatus.Text;
                if (generic.Batch != null)
                    data.BatchStatusId = generic.Batch.BatchStatusId;
                if (generic.TestedUserId.GetValueOrDefault() > 0)
                    data.TestedBy = string.Format("{0} {1}", generic.User1.FirstName, generic.User1.Surname);
                if (data.ReviewedUserId.GetValueOrDefault() > 0)
                {
                    string name = string.Format("{0} {1}", generic.User.FirstName, generic.User.Surname);
                    data.ReviewdBy = name;
                }
            }
            return data;
        }

        #endregion

        /// <summary>
        /// ConvertTargetTimeToTargetTimeData operation
        /// </summary>
        public static TargetTimeData? ConvertTargetTimeToTargetTimeData(TargetTime? targetTime)
        {
            TargetTimeData? targetTimeData = null;
            if (targetTime != null)
            {
                targetTimeData = new TargetTimeData
                {
                    TargetTimeIncreaseinSeconds = targetTime.TargetTimeIncreaseinSeconds,
                    TargetTimeinSeconds = targetTime.TargetTimeinSeconds
                };
            }
            return targetTimeData;
        }

        /// <summary>
        /// ConvertUserPerformanceToUserPerformanceData operation
        /// </summary>
        public static UserPerformanceData? ConvertUserPerformanceToUserPerformanceData(UserPerformance? userPerformance)
        {
            UserPerformanceData? userPerformanceData = null;
            if (userPerformance != null)
            {
                userPerformanceData = new UserPerformanceData
                {
                    PercentageIPOHVariance = userPerformance.PercentageIPOHVariance
                };
            }
            return userPerformanceData;
        }

    }
}