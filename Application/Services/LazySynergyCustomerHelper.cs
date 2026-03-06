using SynergyApplicationFrameworkApi.Application.DTOs.Interfaces.Operative;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public static class LazySynergyCustomerHelper
    {
        #region delivery notes

        /// <summary>
        /// Converts the deliverynote to data contract.
        /// </summary>
        /// <param name="genericDeliveryNote">The generic deliverynote.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertDeliveryNoteToDataContract operation
        /// </summary>
        public static DeliveryNoteData ConvertDeliveryNoteToDataContract(IDeliveryNote genericDeliveryNote)
        {
            if (genericDeliveryNote == null)
                return null;
            var deliveryNote = (DeliveryNote)genericDeliveryNote;
            var dnData = new DeliveryNoteData(genericDeliveryNote)
                             {
                                 DeliveryPointName = deliveryNote.DeliveryPoint.Text,
                                 FacilityName = deliveryNote.Facility.Text
                             };
            Customer customer =
                deliveryNote.DeliveryPoint.CustomerDefinition.Customer.OrderByDescending(c => c.Revision).
                    FirstOrDefault();
            dnData.CustomerId = customer.CustomerId;
            dnData.CustomerName = customer.Text;
            return dnData;
        }

        /// <summary>
        /// Converts the delivery notes to data contract.
        /// </summary>
        /// <param name="genericDeliveryNotes">The generic delivery notes.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertDeliveryNotesToDataContract operation
        /// </summary>
        public static IList<DeliveryNoteData> ConvertDeliveryNotesToDataContract(
            IList<IDeliveryNote> genericDeliveryNotes)
        {
            List<DeliveryNoteData> list = genericDeliveryNotes.Select(ConvertDeliveryNoteToDataContract).ToList();
            return list;
        }

        #endregion delivery notes

        #region customer

        /// <summary>
        /// Converts the customer to data contract.
        /// </summary>
        /// <param name="genericCustomer">The generic customer.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertCustomerToDataContract operation
        /// </summary>
        public static CustomerData ConvertCustomerToDataContract(ICustomer genericCustomer)
        {
            if (genericCustomer == null)
            {
                return null;
            }
            var c = (Customer)genericCustomer;
            var customerData = new CustomerData(c) { Text = c.Text };
            return customerData;
        }

        /// <summary>
        /// Converts the customers to data contract.
        /// </summary>
        /// <param name="genericCustomers">The generic customers.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// 
        /// <summary>
        /// ConvertCustomersToDataContract operation
        /// </summary>
        public static IList<CustomerData> ConvertCustomersToDataContract(IList<ICustomer> genericCustomers)
        {
            return genericCustomers?.Select(ConvertCustomerToDataContract).ToList();
        }

        #endregion customer

        #region address

        /// <summary>
        /// ConvertAddressToDataContract operation
        /// </summary>
        public static AddressData ConvertAddressToDataContract(IAddress genericAddress)
        {
            if (genericAddress == null)
            {
                return null;
            }
            var c = (Address)genericAddress;
            var addressData = new AddressData(c) { AddressId = c.AddressId };
            return addressData;
        }

        /// <summary>
        /// ConvertAddressToDataContract operation
        /// </summary>
        public static IList<AddressData> ConvertAddressToDataContract(IList<IAddress> genericAddress)
        {
            return genericAddress?.Select(ConvertAddressToDataContract).ToList();
        }
        #endregion address

        #region delivery point

        /// <summary>
        /// Converts the delivery point to data contract.
        /// </summary>
        /// <param name="genericDeliveryPoint">The generic delivery point.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertDeliveryPointToDataContract operation
        /// </summary>
        public static DeliveryPointData ConvertDeliveryPointToDataContract(IDeliveryPoint genericDeliveryPoint)
        {
            if (genericDeliveryPoint == null)
            {
                return null;
            }
            return new DeliveryPointData(genericDeliveryPoint) { DeliveryPointName = ((DeliveryPoint)genericDeliveryPoint).Text };
        }

        /// <summary>
        /// Converts the delivery point to data contract.
        /// </summary>
        /// <param name="genericDeliveryPoints">The generic delivery point.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertDeliveryPointsToDataContract operation
        /// </summary>
        public static IList<DeliveryPointData> ConvertDeliveryPointsToDataContract(
            IList<IDeliveryPoint> genericDeliveryPoints)
        {
            return genericDeliveryPoints.Select(ConvertDeliveryPointToDataContract).ToList();
        }

        #endregion delivery point

        #region missing item

        /// <summary>
        /// Converts the missing item to data contract.
        /// </summary>
        /// <param name="missItem">The miss item.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertMissingItemToDataContract operation
        /// </summary>
        public static MissingItemData ConvertMissingItemToDataContract(IMissingItem missItem)
        {
            if (missItem == null)
            {
                return null;
            }
            return new MissingItemData(missItem);
        }

        /// <summary>
        /// Converts the missing items to data contract.
        /// </summary>
        /// <param name="missingItems">The missing items.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertMissingItemsToDataContract operation
        /// </summary>
        public static IList<MissingItemData> ConvertMissingItemsToDataContract(IList<IMissingItem> missingItems)
        {
            List<MissingItemData> list = missingItems.Select(ConvertMissingItemToDataContract).ToList();
            return list;
        }

        #endregion missing item

        #region container instance

        /// <summary>
        /// Converts the container instance to data contract.
        /// </summary>
        /// <param name="genericContainerInstance">The generic container instance.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertContainerInstanceToDataContract operation
        /// </summary>
        public static ContainerInstanceData ConvertContainerInstanceToDataContract(
            IContainerInstance genericContainerInstance)
        {
            if (genericContainerInstance == null)
            {
                return null;
            }
            var containerInstance = (ContainerInstance)genericContainerInstance;
            var ciData = new ContainerInstanceData(genericContainerInstance);
            ItemType item =
                containerInstance.ContainerMasterDefinition.ContainerMasters.Where(ci => ci.ItemStatusId == 1).
                    FirstOrDefault().ItemType;
            ciData.ItemTypeId = item.ItemTypeId;
            ciData.ItemTypeName = item.Text;
            ciData.BaseItemTypeId = item.ParentItemTypeId;
            ciData.BaseItemTypeName = item.ParentItemType == null ? string.Empty : item.ParentItemType.Text;
            Turnaround turnaround = containerInstance.Turnaround.OrderByDescending(t => t.Created).Where(
                t => ((t.LastEvent == null || t.LastEvent.Workflow == null) ? true : t.LastEvent.Workflow.IsEnd != true))
                .OrderByDescending(
                    t => t.ContainerInstanceId).FirstOrDefault();
            if (turnaround != null)
            {
                ciData.LastTurnaroundId = turnaround.TurnaroundId;
                ciData.LastEventTypeId = turnaround.LastEvent == null ? (int?)null : turnaround.LastEvent.EventTypeId;
                ciData.LastEventTypeName = turnaround.LastEvent == null ? string.Empty : turnaround.LastEvent.EventType.Text;
            }
            else
            {
                ciData.LastTurnaroundId = null;
                ciData.LastEventTypeId = null;
                ciData.LastEventTypeName = string.Empty;
            }

            return ciData;
        }

        /// <summary>
        /// Converts the container instances to data contract.
        /// </summary>
        /// <param name="genericContainerInstances">The generic container instances.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertContainerInstancesToDataContract operation
        /// </summary>
        public static IList<ContainerInstanceData> ConvertContainerInstancesToDataContract(
            IList<IContainerInstance> genericContainerInstances)
        {
            if (genericContainerInstances == null)
            {
                return null;
            }
            return genericContainerInstances.Select(ConvertContainerInstanceToDataContract).ToList();
        }

        #endregion container instance

        #region machine

        /// <summary>
        /// Converts the machine to data contract.
        /// </summary>
        /// <param name="genericMachine">The generic machine.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertMachineToDataContract operation
        /// </summary>
        public static MachineData ConvertMachineToDataContract(IMachine genericMachine)
        {
            return genericMachine == null ? null : new MachineData(genericMachine);
        }

        /// <summary>
        /// Converts the machine event to data.
        /// </summary>
        /// <param name="machineEvent">The machine event.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertMachineEventToData operation
        /// </summary>
        public static MachineEventData ConvertMachineEventToData(IMachineEvent machineEvent)
        {
            return new MachineEventData(machineEvent);
        }

        /// <summary>
        /// Converts the machine events to data.
        /// </summary>
        /// <param name="machineEvents">The machine events.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertMachineEventsToData operation
        /// </summary>
        public static IList<MachineEventData> ConvertMachineEventsToData(IList<IMachineEvent> machineEvents)
        {
            return machineEvents.Select(ConvertMachineEventToData).ToList();
        }

        /// <summary>
        /// Converts the machine type to data.
        /// </summary>
        /// <param name="machineType">Type of the machine.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertMachineTypeToData operation
        /// </summary>
        public static MachineTypeData ConvertMachineTypeToData(IMachineType machineType)
        {
            return machineType == null ? null : new MachineTypeData(machineType);
        }

        #endregion machine

        #region station

        /// <summary>
        /// Converts the station to data contract.
        /// </summary>
        /// <param name="genericStation">The generic station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertStationToDataContract operation
        /// </summary>
        public static StationData ConvertStationToDataContract(IStation genericStation)
        {
            if (genericStation == null)
            {
                return null;
            }
            return new StationData(genericStation);
        }

        /// <summary>
        /// Converts the stations to data.
        /// </summary>
        /// <param name="stations">The stations.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertStationsToData operation
        /// </summary>
        public static IList<StationData> ConvertStationsToData(IList<IStation> stations)
        {
            return stations.Select(ConvertStationToDataContract).ToList();
        }

        /// <summary>
        /// Converts the station type category to data.
        /// </summary>
        /// <param name="stationTypeCategory">The station type category.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertStationTypeCategoryToData operation
        /// </summary>
        public static StationTypeCategoryData ConvertStationTypeCategoryToData(IStationTypeCategory stationTypeCategory)
        {
            return new StationTypeCategoryData(stationTypeCategory);
        }

        /// <summary>
        /// Converts the station type categories to data.
        /// </summary>
        /// <param name="stationTypeCategories">The station type categories.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertStationTypeCategoriesToData operation
        /// </summary>
        public static IList<StationTypeCategoryData> ConvertStationTypeCategoriesToData(
            IList<IStationTypeCategory> stationTypeCategories)
        {
            return stationTypeCategories.Select(ConvertStationTypeCategoryToData).ToList();
        }

        #endregion station

        #region defect

        /// <summary>
        /// Converts the defect to data contract.
        /// </summary>
        /// <param name="genericDefect">The generic defect.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertDefectToDataContract operation
        /// </summary>
        public static DefectData ConvertDefectToDataContract(IDefect genericDefect)
        {
            if (genericDefect == null)
            {
                return null;
            }
            var defectModel = (Defect)genericDefect;
            var defectData = new DefectData(genericDefect);
            Customer customer =
                defectModel.DeliveryPoint.CustomerDefinition.Customer.Where(
                    c => (c.CustomerStatusId == 1 || c.CustomerStatusId == 2)).FirstOrDefault();
            defectData.CustomerId = customer.CustomerId;
            defectData.CustomerName = customer.Text;
            defectData.DeliveryPointName = defectModel.DeliveryPoint.Text;
            defectData.ClassificationName = defectModel.DefectClassification.Text;
            defectData.SeverityName = defectModel.DefectSeverity.Text;
            defectData.DefectStatusName = defectModel.DefectStatus.Text;
            defectData.TurnaroundExternalId = defectModel.TurnaroundId == null
                                                  ? (long?)null
                                                  : defectModel.Turnaround.ExternalId;
            return defectData;
        }

        /// <summary>
        /// Converts the defects to data.
        /// </summary>
        /// <param name="defects">The defects.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertDefectsToData operation
        /// </summary>
        public static IList<DefectData> ConvertDefectsToData(IList<IDefect> defects)
        {
            return defects.Select(ConvertDefectToDataContract).ToList();
        }

        /// <summary>
        /// Converts the defect classification to data.
        /// </summary>
        /// <param name="defectClassification">The defect classification.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertDefectClassificationToData operation
        /// </summary>
        public static DefectClassificationData ConvertDefectClassificationToData(
            IDefectClassification defectClassification)
        {
            return defectClassification == null ? null : new DefectClassificationData(defectClassification);
        }

        /// <summary>
        /// Converts the defect classifications to data.
        /// </summary>
        /// <param name="defectClassifications">The defect classifications.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertDefectClassificationsToData operation
        /// </summary>
        public static IList<DefectClassificationData> ConvertDefectClassificationsToData(
            IList<IDefectClassification> defectClassifications)
        {
            return defectClassifications == null
                       ? null
                       : defectClassifications.Select(ConvertDefectClassificationToData).ToList();
        }

        /// <summary>
        /// Converts the defec severity to data.
        /// </summary>
        /// <param name="defectServerity">The defect serverity.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertDefecSeverityToData operation
        /// </summary>
        public static DefectSeverityData ConvertDefecSeverityToData(IDefectSeverity defectServerity)
        {
            return defectServerity == null ? null : new DefectSeverityData(defectServerity);
        }

        /// <summary>
        /// Converts the defec severities to data.
        /// </summary>
        /// <param name="defectServerities">The defect serverities.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertDefecSeveritiesToData operation
        /// </summary>
        public static IList<DefectSeverityData> ConvertDefecSeveritiesToData(IList<IDefectSeverity> defectServerities)
        {
            return defectServerities == null
                       ? null
                       : defectServerities.Select(ConvertDefecSeverityToData).ToList();
        }

        #endregion defect

        #region Facility

        /// <summary>
        /// Converts the facility to data contract.
        /// </summary>
        /// <param name="genericFacility">The generic facility.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertFacilityToDataContract operation
        /// </summary>
        public static FacilityData ConvertFacilityToDataContract(IFacility genericFacility)
        {
            FacilityData facilityData = null;
            if (genericFacility != null)
            {
                var facility = (Facility)genericFacility;
                facilityData = new FacilityData(facility);
            }
            return facilityData;
        }

        /// <summary>
        /// Converts the facilities to data.
        /// </summary>
        /// <param name="facilities">The facilities.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertFacilitiesToData operation
        /// </summary>
        public static IList<FacilityData> ConvertFacilitiesToData(IList<IFacility> facilities)
        {
            return facilities.Select(ConvertFacilityToDataContract).ToList();
        }

        /// <summary>
        /// Converts the facility notes to datas.
        /// </summary>
        /// <param name="facilityNotes">The facility notes.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertFacilityNotesToDatas operation
        /// </summary>
        public static IList<FacilityNoteData> ConvertFacilityNotesToDatas(IList<IFacilityNote> facilityNotes)
        {
            return facilityNotes.Count() != 0
                       ? facilityNotes.Select(genericNote => new FacilityNoteData(genericNote)).ToList()
                       : null;
        }

        /// <summary>
        /// Converts the facility next event text to data.
        /// </summary>

        /// <summary>
        /// Converts the facility next event texts to data.
        /// </summary>

        #endregion

        #region FacilitItemType

        /// <summary>
        /// Converts the facility item type to data contract.
        /// </summary>
        /// <param name="genericFacilityItemType">Type of the generic facility item.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertFacilityItemTypeToDataContract operation
        /// </summary>
        public static FacilityItemTypeData ConvertFacilityItemTypeToDataContract(
            IFacilityItemType genericFacilityItemType)
        {
            if (genericFacilityItemType == null)
                return null;
            else
            {
                var facilityItemType = (FacilityItemType)genericFacilityItemType;
                var facilityItemTypeData = new FacilityItemTypeData(facilityItemType);
                facilityItemTypeData.ItemTypeName = facilityItemType.ItemType.Text;
                return facilityItemTypeData;
            }
        }

        /// <summary>
        /// Converts the facility item types to data.
        /// </summary>
        /// <param name="facilityItemTypes">The facility item types.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertFacilityItemTypesToData operation
        /// </summary>
        public static IList<FacilityItemTypeData> ConvertFacilityItemTypesToData(
            IList<IFacilityItemType> facilityItemTypes)
        {
            return facilityItemTypes.Select(ConvertFacilityItemTypeToDataContract).ToList();
        }

        /// <summary>
        /// Converts the facility item types to data.
        /// </summary>
        /// <param name="facilityItemTypes">The facility item types.</param>
        /// <param name="itemTypes">The item types.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertFacilityItemTypesToData operation
        /// </summary>
        public static IList<FacilityItemTypeData> ConvertFacilityItemTypesToData(
            IList<IFacilityItemType> facilityItemTypes, IList<IGenericKeyValue> itemTypes)
        {
            IList<FacilityItemTypeData> facilityItemData = new List<FacilityItemTypeData>();
            foreach (IFacilityItemType facItem in facilityItemTypes)
            {
                facilityItemData.Add(new FacilityItemTypeData(facItem.FacilityId, facItem.ItemTypeId,
                                                              itemTypes.Single(
                                                                  d => Convert.ToInt32(d.Id) == facItem.ItemTypeId).Name));
            }

            return facilityItemTypes.Select(ConvertFacilityItemTypeToDataContract).ToList();
        }

        #endregion

        #region UserPrinter

        /// <summary>
        /// Converts the user printer to data contract.
        /// </summary>
        /// <param name="userPrinter">The user printer.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserPrinterToDataContract operation
        /// </summary>
        public static UserPrinterData ConvertUserPrinterToDataContract(IUserPrinter userPrinter)
        {
            if (userPrinter == null)
            {
                return null;
            }
            return new UserPrinterData(userPrinter);
        }

        /// <summary>
        /// Converts the user printer list to data contract.
        /// </summary>
        /// <param name="userPrinters">The user printers.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserPrinterListToDataContract operation
        /// </summary>
        public static IList<UserPrinterData> ConvertUserPrinterListToDataContract(IList<IUserPrinter> userPrinters)
        {
            return userPrinters.Select(ConvertUserPrinterToDataContract).ToList();
        }

        #endregion UserPrinter

        #region UserItemComplexity

        /// <summary>
        /// Converts the user item complexitiy to data contract.
        /// </summary>
        /// <param name="userItemComplexity">The user item complexity.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserItemComplexityToDataContract operation
        /// </summary>
        public static UserComplexityData ConvertUserItemComplexityToDataContract(IUserComplexity userItemComplexity)
        {
            if (userItemComplexity == null)
            {
                return null;
            }
            return new UserComplexityData(userItemComplexity);
        }

        /// <summary>
        /// Converts the user complexity list to data contract.
        /// </summary>
        /// <param name="userItemComplexities">The user item complexities.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserItemComplexityListToDataContract operation
        /// </summary>
        public static IList<UserComplexityData> ConvertUserItemComplexityListToDataContract(
            IList<IUserComplexity> userItemComplexities)
        {
            return userItemComplexities.Select(ConvertUserItemComplexityToDataContract).ToList();
        }

        #endregion UserItemComplexitiy

        #region itemType

        /// <summary>
        /// Converts the item type to item type data.
        /// </summary>
        /// <param name="itemType">Type of the item.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertItemTypeToItemTypeData operation
        /// </summary>
        public static ItemTypeData ConvertItemTypeToItemTypeData(IItemType itemType)
        {
            if (itemType == null)
            {
                return null;
            }
            return new ItemTypeData(itemType);
        }

        /// <summary>
        /// Converts the item type list to item types data.
        /// </summary>
        /// <param name="itemTypes">The item types.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertItemTypeListToItemTypesData operation
        /// </summary>
        public static IList<ItemTypeData> ConvertItemTypeListToItemTypesData(IList<IItemType> itemTypes)
        {
            IList<ItemTypeData> itemTypeDataList =
                itemTypes.Select(ConvertItemTypeToItemTypeData).ToList();
            return itemTypeDataList;
        }

        #endregion itemType

        #region category

        /// <summary>
        /// Converts the category to category data.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertCategoryToCategoryData operation
        /// </summary>
        public static CategoryData ConvertCategoryToCategoryData(ICategory category)
        {
            if (category == null)
            {
                return null;
            }
            return new CategoryData(category);
        }

        /// <summary>
        /// Converts the category list to categories data.
        /// </summary>
        /// <param name="caregories">The caregories.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertCategoryListToCategoriesData operation
        /// </summary>
        public static IList<CategoryData> ConvertCategoryListToCategoriesData(IList<ICategory> caregories)
        {
            IList<CategoryData> categoryDataList =
                caregories.Select(ConvertCategoryToCategoryData).ToList();
            return categoryDataList;
        }

        #endregion category

        #region speciality

        /// <summary>
        /// Converts the speciality to speciality data.
        /// </summary>
        /// <param name="speciality">The speciality.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertSpecialityToSpecialityData operation
        /// </summary>
        public static SpecialityData ConvertSpecialityToSpecialityData(ISpeciality speciality)
        {
            if (speciality == null)
            {
                return null;
            }
            return new SpecialityData(speciality);
        }

        /// <summary>
        /// Converts the speciality list to specialities data.
        /// </summary>
        /// <param name="specialities">The specialities.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertSpecialityListToSpecialitiesData operation
        /// </summary>
        public static IList<SpecialityData> ConvertSpecialityListToSpecialitiesData(IList<ISpeciality> specialities)
        {
            IList<SpecialityData> specialityList =
                specialities.Select(ConvertSpecialityToSpecialityData).ToList();
            return specialityList;
        }

        #endregion speciality

        #region itemComplexity

        /// <summary>
        /// Converts the item complexity to item complexity data.
        /// </summary>
        /// <param name="complexity">The complexity.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertItemComplexityToItemComplexityData operation
        /// </summary>
        public static ComplexityData ConvertItemComplexityToItemComplexityData(IComplexity complexity)
        {
            if (complexity == null)
            {
                return null;
            }
            return new ComplexityData(complexity);
        }

        /// <summary>
        /// Converts the item complexity list to item complexities data.
        /// </summary>
        /// <param name="complexities">The complexities.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertComplexityListToComplexitiesData operation
        /// </summary>
        public static IList<ComplexityData> ConvertComplexityListToComplexitiesData(IList<IComplexity> complexities)
        {
            IList<ComplexityData> complexityList =
                complexities.Select(ConvertItemComplexityToItemComplexityData).ToList();
            return complexityList;
        }

        #endregion speciality

        #region turnaround

        /// <summary>
        /// 
        /// </summary>
        /// <param name="turnarounds"></param>
        /// <returns></returns>
        /// <summary>
        /// ConvertTurnaroundListToTurnaroundResultData operation
        /// </summary>
        public static IList<TurnaroundData> ConvertTurnaroundListToTurnaroundResultData(IList<ReadTurnaroundsByStoragePoint_Result> turnarounds)
        {
            IList<TurnaroundData> turnaroundDataList =
                turnarounds.Select(ConvertTurnaroundToTurnaroundResultData).ToList();
            return turnaroundDataList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="turnaround"></param>
        /// <returns></returns>
        /// <summary>
        /// ConvertTurnaroundToTurnaroundResultData operation
        /// </summary>
        public static TurnaroundData ConvertTurnaroundToTurnaroundResultData(ReadTurnaroundsByStoragePoint_Result turnaround)
        {
            if (turnaround == null) return null;
            var turnaroundData = new TurnaroundData();
            turnaroundData.TurnaroundId = turnaround.TurnaroundId;
            turnaroundData.ExternalId = long.Parse(turnaround.TurnaroundExternalId);
            turnaroundData.ContainerMasterId = turnaround.ContainerMasterId;
            turnaroundData.MasterExternalId = turnaround.ContainerMasterExternalId;
            turnaroundData.ContainerInstanceId = turnaround.ContainerInstanceId;
            turnaroundData.MasterName = turnaround.Name;
            turnaroundData.DeliveryPointName = turnaround.DeliveryPointName;
            turnaroundData.LastEventEventTypeName = turnaround.LastEvent;
            turnaroundData.LastEventCreatedDate = turnaround.LastEventDate;
            turnaroundData.ContainerInstanceExternalId = turnaround.ContainerInstanceExternalId;
            return turnaroundData;
        }

        /// <summary>
        /// Converts the turnaround to turnaround data.
        /// </summary>
        /// <param name="turnaround">The turnaround.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertTurnaroundToTurnaroundData operation
        /// </summary>
        public static TurnaroundData ConvertTurnaroundToTurnaroundData(ITurnaround turnaround)
        {
            if (turnaround == null)
            {
                return null;
            }

            var genericTurnaround = (Turnaround)turnaround;
            var turnaroundData = new TurnaroundData(turnaround);
            var tae =
                genericTurnaround.TurnaroundEvent.Where(
                    te => te.EventTypeId == (short)TurnAroundEventTypeIdentifier.IntoAutoclave).OrderByDescending(
                        te => te.Created).FirstOrDefault();
            var lastTurnAroundEvent = genericTurnaround.TurnaroundEvent.OrderByDescending(t => t.Created).FirstOrDefault();
            var firstEvent = genericTurnaround.TurnaroundEvent.OrderBy(t => t.Created).FirstOrDefault();
            if (firstEvent != null)
                turnaroundData.Created = firstEvent.Created;
            turnaroundData.LastBatchOfAutoclave = tae == null ? string.Empty : tae.Batch == null ? string.Empty : tae.Batch.ExternalId;
            ContainerMaster containerMaster = genericTurnaround.ContainerMaster;
            ContainerInstance containerInstance = genericTurnaround.ContainerInstance;
            TurnaroundEvent lasteEvent = genericTurnaround.LastEvent;
            turnaroundData.InstanceExternalId = containerInstance == null ? string.Empty : containerInstance.ExternalId;
            turnaroundData.MasterExternalId = containerMaster.ExternalId;
            turnaroundData.ContainerMasterDefinitionId = containerMaster.ContainerMasterDefinitionId;
            turnaroundData.MasterName = containerMaster.Text;
            turnaroundData.ItemType = containerMaster.ItemType.Text;
            turnaroundData.ItemTypeId = containerMaster.ItemType.ItemTypeId;
            turnaroundData.FacilityEmailAddress = ((Pathway.Data.Models.Operative.Turnaround)turnaround).Facility.Address != null ? ((Pathway.Data.Models.Operative.Turnaround)turnaround).Facility.Address.ContactEmail : string.Empty;

            turnaroundData.LastEventCreatedDate = lastTurnAroundEvent == null ? (DateTime?)null : lastTurnAroundEvent.Created;
            turnaroundData.LastEventEventTypeName = lastTurnAroundEvent == null ? string.Empty : lastTurnAroundEvent.EventType.Text;
            turnaroundData.LastEventEventTypeId = lastTurnAroundEvent == null ? (int?)null : lastTurnAroundEvent.EventTypeId;
            turnaroundData.LastEventId = lastTurnAroundEvent == null ? (int?)null : lastTurnAroundEvent.TurnaroundEventId;
            turnaroundData.Status = lastTurnAroundEvent == null ? (int?)null : lastTurnAroundEvent.EventType.ProcessLocation ?? 0;

            turnaroundData.CustomerDefinitionId = genericTurnaround.CustomerDefinitionId;
            turnaroundData.DeliveryPointName = genericTurnaround.DeliveryPoint.Text;
            turnaroundData.DeliveryNoteExternalId = genericTurnaround.DeliveryNote == null ? (int?)null : genericTurnaround.DeliveryNote.ExternalId;
            turnaroundData.ServiceRequirementText = genericTurnaround.ServiceRequirement.Text;
            var childTurnarounds = genericTurnaround.ChildTurnaround;  //On database,some parent turnaround id is its turnaround id.
            turnaroundData.ChildTurnarounds = childTurnarounds.Count == 0
                                                  ? null
                                                  : childTurnarounds.Select(ConvertTurnaroundToTurnaroundData).ToList();
            return turnaroundData;
        }

        /// <summary>
        /// Converts the turnaround to turnaround data.
        /// </summary>
        /// <param name="turnaround">The turnaround.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertTurnaroundToProcessEventTurnaroundData operation
        /// </summary>
        public static TurnaroundData ConvertTurnaroundToProcessEventTurnaroundData(ITurnaround turnaround)
        {
            if (turnaround == null)
            {
                return null;
            }
            var genericTurnaround = (Turnaround)turnaround;
            var turnaroundData = new TurnaroundData(turnaround);
            turnaroundData = ConvertTurnaroundToTurnaroundData(turnaround);
            var lastTurnAroundEvent = genericTurnaround.TurnaroundEvent.Where(a => a.EventType.ProcessEvent != false).OrderByDescending(t => t.Created).FirstOrDefault();
            turnaroundData.LastEventCreatedDate = lastTurnAroundEvent == null ? (DateTime?)null : lastTurnAroundEvent.Created;
            turnaroundData.LastEventEventTypeName = lastTurnAroundEvent == null ? string.Empty : lastTurnAroundEvent.EventType.Text;
            turnaroundData.LastEventEventTypeId = lastTurnAroundEvent == null ? (int?)null : lastTurnAroundEvent.EventTypeId;
            turnaroundData.LastEventId = lastTurnAroundEvent == null ? (int?)null : lastTurnAroundEvent.TurnaroundEventId;
            turnaroundData.Status = lastTurnAroundEvent == null ? (int?)null : lastTurnAroundEvent.EventType.ProcessLocation ?? 0;
            return turnaroundData;
        }

        /// <summary>
        /// Converts the turnaround list to turnarounds data.
        /// </summary>
        /// <param name="turnarounds">The turnarounds.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertTurnaroundListToTurnaroundsData operation
        /// </summary>
        public static IList<TurnaroundData> ConvertTurnaroundListToTurnaroundsData(IList<ITurnaround> turnarounds)
        {
            IList<TurnaroundData> turnaroundDataList =
                turnarounds.Select(ConvertTurnaroundToTurnaroundData).OrderByDescending(t => t.Created).ToList();
            return turnaroundDataList;
        }

        /// <summary>
        /// Converts the turnaround list to turnarounds data.
        /// </summary>
        /// <param name="turnarounds">The turnarounds.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertReadTurnaroundsByItemSearchToTurnaroundsData operation
        /// </summary>
        public static IList<TurnaroundData> ConvertReadTurnaroundsByItemSearchToTurnaroundsData(IList<ReadTurnaroundsByItemSearch_Result> turnarounds_Results)
        {
            IList<TurnaroundData> turnaroundDataList =
                turnarounds_Results.Select(ConvertTurnaroundSearchResultToTurnaroundData).ToList();
            return turnaroundDataList;
        }

        /// <summary>
        /// ConvertTurnaroundSearchResultToTurnaroundData operation
        /// </summary>
        public static TurnaroundData ConvertTurnaroundSearchResultToTurnaroundData(ReadTurnaroundsByItemSearch_Result result)
        {
            if (result == null)
            {
                return null;
            }

            TurnaroundData turnaroundData = new TurnaroundData()
            {
                TurnaroundId = result.TurnaroundId,
                ExternalId = (long)result.TurnaroundExternalId,
                ContainerInstanceId = result.InstanceId,
                InstanceExternalId = result.InstanceRef,
                ContainerMasterId = result.MasterId,
                ContainerMasterText = result.MasterRef,
                MasterName = result.MasterName,
                ContainerMasterItemTypeText = result.MasterType,
                DeliveryPointName = result.DeliveryPoint,
                DeliveryPointId = result.DeliveryPointId,
                ContainerMasterDefinitionId = result.ContainerMasterDefinitionId.GetValueOrDefault(),
                StatusDetails = result.Status,
            };

            return turnaroundData;
        }

        #endregion turnaruond

        #region turnaroundEvent

        /// <summary>
        /// Converts the turnaround event to turnaround event data.
        /// </summary>
        /// <param name="turnaroundEvent">The turnaround event.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertTurnaroundEventToTurnaroundEventData operation
        /// </summary>
        public static TurnaroundEventData ConvertTurnaroundEventToTurnaroundEventData(ITurnaroundEvent turnaroundEvent)
        {
            if (turnaroundEvent == null)
            {
                return null;
            }
            var te = (TurnaroundEvent)turnaroundEvent;
            var turnaroundEventData = new TurnaroundEventData(turnaroundEvent);
            turnaroundEventData.StationName = te.Station.Text;
            turnaroundEventData.EventTypeName = te.EventType.Text;
            return turnaroundEventData;
        }

        /// <summary>
        /// Converts the turnaround event list to turnaround events data.
        /// </summary>
        /// <param name="turnaroundEvents">The turnaround events.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertTurnaroundEventListToTurnaroundEventsData operation
        /// </summary>
        public static IList<TurnaroundEventData> ConvertTurnaroundEventListToTurnaroundEventsData(
            IList<ITurnaroundEvent> turnaroundEvents)
        {
            IList<TurnaroundEventData> turnaroundEventDataList = turnaroundEvents == null
                                                                     ? null
                                                                     : turnaroundEvents.Select(
                                                                         ConvertTurnaroundEventToTurnaroundEventData)
                                                                           .ToList();
            return turnaroundEventDataList;
        }

        /// <summary>
        /// Converts the turnaround event to turnaround event data.
        /// </summary>
        /// <param name="turnaroundEvent">The turnaround event.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertTurnaroundEventListDataToTurnaroundEventData operation
        /// </summary>
        public static TurnaroundEventData ConvertTurnaroundEventListDataToTurnaroundEventData(ITurnaroundEventList turnaroundEventListData)
        {
            if (turnaroundEventListData == null)
            {
                return null;
            }
            var turnaroundEventData = new TurnaroundEventData(turnaroundEventListData.TurnaroundEventId,
                                                                turnaroundEventListData.BatchId,
                                                                turnaroundEventListData.CreatedUserId,
                                                                turnaroundEventListData.TurnaroundEventTypeId,
                                                                null,
                                                                new byte(),
                                                                0,
                                                                0,
                                                                null,
                                                                turnaroundEventListData.Created,
                                                                null,
                                                                null,
                                                                null,
                                                                null, null, null,null, null);
            turnaroundEventData.EventTypeName = turnaroundEventListData.TurnaroundEventType;
            return turnaroundEventData;
        }

        /// <summary>
        /// Converts the turnaround event list to turnaround events data.
        /// </summary>
        /// <param name="turnaroundEvents">The turnaround events.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertTurnaroundEventDataListToTurnaroundEventsData operation
        /// </summary>
        public static IList<TurnaroundEventData> ConvertTurnaroundEventDataListToTurnaroundEventsData(
            IList<ITurnaroundEventList> turnaroundEventListData)
        {
            IList<TurnaroundEventData> turnaroundEventDataList = turnaroundEventListData == null
                                                                     ? null
                                                                     : turnaroundEventListData.Select(
                                                                         ConvertTurnaroundEventListDataToTurnaroundEventData)
                                                                           .ToList();
            return turnaroundEventDataList;
        }

        #endregion turnaroundEvent

        #region itemMaster

        /// <summary>
        /// Converts the item master to item master data.
        /// </summary>
        /// <param name="itemMaster">The item master.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertItemMasterToItemMasterData operation
        /// </summary>
        public static ItemMasterData ConvertItemMasterToItemMasterData(IItemMaster itemMaster)
        {
            if (itemMaster == null)
            {
                return null;
            }
            var masterData = new ItemMasterData(itemMaster);

            return masterData;
        }

        /// <summary>
        /// Converts the item master list to item masters data.
        /// </summary>
        /// <param name="itemMasters">The item masters.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertItemMasterListToItemMastersData operation
        /// </summary>
        public static IList<ItemMasterData> ConvertItemMasterListToItemMastersData(IList<IItemMaster> itemMasters)
        {
            IList<ItemMasterData> itemMasterDatas =
                itemMasters.Select(ConvertItemMasterToItemMasterData).ToList();
            return itemMasterDatas;
        }

        #endregion itemMaster

        #region user

        /// <summary>
        /// Converts the user to user data.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserToUserData operation
        /// </summary>
        public static UserData ConvertUserToUserData(IUser user)
        {
            if (user == null)
            {
                return null;
            }
            return new UserData(user);
        }

        /// <summary>
        /// Converts the user to user data.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="userExtendedProperty">The user extended property.</param>
        /// <param name="userFacility">The user facilities.</param>
        /// <param name="roles">The roles.</param>
        /// <param name="userPermissionsList">The user permissions list.</param>
        /// <param name="userPrinters">The user printers.</param>
        /// <param name="userItemComplexities">The user item complexities.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserToUserData operation
        /// </summary>
        public static UserData ConvertUserToUserData(IUser user, IUserExtendedProperty userExtendedProperty,
                                                     IList<IUserFacility> userFacility, IList<IRole> roles,
                                                     IList<IUserPrinter> userPrinters,
                                                     IList<IUserComplexity> userItemComplexities)
        {
            if (user == null)
            {
                return null;
            }
            return new UserData(user,
                                ConvertUserFacilityListToUserFacilityData(userFacility),
                                ConvertRoleListToRolesData(roles),
                                ConvertUserPrinterListToDataContract(userPrinters),
                                ConvertUserItemComplexityListToDataContract(userItemComplexities));
        }

        /// <summary>
        /// Converts the user list to users data.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserListToUsersData operation
        /// </summary>
        public static IList<UserData> ConvertUserListToUsersData(IList<IUser> users)
        {
            IList<UserData> usersData =
                users.Select(ConvertUserToUserData).ToList();
            return usersData;
        }

        /// <summary>
        /// Converts the user facility to user facility data.
        /// </summary>
        /// <param name="userFacility">The user facility.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserFacilityToUserFacilityData operation
        /// </summary>
        public static UserFacilityData ConvertUserFacilityToUserFacilityData(IUserFacility userFacility)
        {
            if (userFacility == null)
            {
                return null;
            }
            return new UserFacilityData(userFacility);
        }

        /// <summary>
        /// Converts the user facility to user facility data.
        /// </summary>
        /// <param name="userFacility">The user facility.</param>
        /// <param name="facilityName">Name of the facility.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserFacilityToUserFacilityData operation
        /// </summary>
        public static UserFacilityData ConvertUserFacilityToUserFacilityData(IUserFacility userFacility,
                                                                             string facilityName)
        {
            if (userFacility == null)
            {
                return null;
            }
            return new UserFacilityData(userFacility, facilityName);
        }

        /// <summary>
        /// Converts the user facility list to user facility data.
        /// </summary>
        /// <param name="userFacilityList">The user facility list.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserFacilityListToUserFacilityData operation
        /// </summary>
        public static IList<UserFacilityData> ConvertUserFacilityListToUserFacilityData(
            IList<IUserFacility> userFacilityList)
        {
            IList<UserFacilityData> userFacilityDatas =
                userFacilityList.Select(ConvertUserFacilityToUserFacilityData).ToList();
            return userFacilityDatas;
        }

        #endregion user

        #region role

        /// <summary>
        /// Converts the role to role data.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertRoleToRoleData operation
        /// </summary>
        public static RoleData ConvertRoleToRoleData(IRole role)
        {
            if (role == null)
            {
                return null;
            }
            return new RoleData(role);
        }

        /// <summary>
        /// Converts the role list to roles data.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertRoleListToRolesData operation
        /// </summary>
        public static IList<RoleData> ConvertRoleListToRolesData(IList<IRole> roles)
        {
            IList<RoleData> roleDatas =
                roles.Select(ConvertRoleToRoleData).ToList();
            return roleDatas;
        }

        #endregion role

        #region containerMaster

        /// <summary>
        /// Converts the container master to container master data.
        /// </summary>
        /// <param name="containerMaster">The container master.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertContainerMasterToContainerMasterData operation
        /// </summary>
        public static ContainerMasterData ConvertContainerMasterToContainerMasterData(IContainerMaster containerMaster)
        {
            if (containerMaster == null)
            {
                return null;
            }
            return new ContainerMasterData(containerMaster);
        }

        /// <summary>
        /// Converts the container master list to container masters data.
        /// </summary>
        /// <param name="containerMasters">The container masters.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertContainerMasterListToContainerMastersData operation
        /// </summary>
        public static IList<ContainerMasterData> ConvertContainerMasterListToContainerMastersData(
            IList<IContainerMaster> containerMasters)
        {
            IList<ContainerMasterData> containerMastersData =
                containerMasters.Select(ConvertContainerMasterToContainerMasterData).ToList();
            return containerMastersData;
        }

        #endregion containerMaster

        #region location

        /// <summary>
        /// Converts the location working hours to data.
        /// </summary>
        /// <param name="genericLocationWorkingHours">The generic location working hours.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        ///// <summary>
        ///// Converts the location working hourses to data.
        ///// </summary>
        ///// <param name="locationWorkingHourses">The location working hourses.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        ///// <summary>
        ///// Converts the location to data.
        ///// </summary>
        ///// <param name="location">The location.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        /// <summary>
        /// Converts the address to data.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertAddressToData operation
        /// </summary>
        public static AddressData ConvertAddressToData(IAddress address)
        {
            return address == null ? null : new AddressData(address);
        }

        /// <summary>
        /// Converts the locations to data.
        /// </summary>
        /// <param name="locations">The locations.</param>
        /// <returns></returns>
        /// <remarks></remarks>

        #endregion

        #region Printer

        /// <summary>
        /// Converts the printer to data.
        /// </summary>
        /// <param name="printer">The printer.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertPrinterToData operation
        /// </summary>
        public static PrinterData ConvertPrinterToData(IPrinter printer)
        {
            return new PrinterData(printer);
        }

        /// <summary>
        /// Converts the printers to data.
        /// </summary>
        /// <param name="printers">The printers.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertPrintersToData operation
        /// </summary>
        public static IList<PrinterData> ConvertPrintersToData(IList<IPrinter> printers)
        {
            return printers.Select(ConvertPrinterToData).ToList();
        }

        /// <summary>
        /// Converts the printer type to data.
        /// </summary>
        /// <param name="printerType">Type of the printer.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertPrinterTypeToData operation
        /// </summary>
        public static PrinterTypeData ConvertPrinterTypeToData(IPrinterType printerType)
        {
            var pt = (PrinterType)printerType;
            var ptd = new PrinterTypeData(pt);

            return ptd;
        }

        /// <summary>
        /// Converts the printer types to data.
        /// </summary>
        /// <param name="printerTypes">The printer types.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertPrinterTypesToData operation
        /// </summary>
        public static IList<PrinterTypeData> ConvertPrinterTypesToData(IList<IPrinterType> printerTypes)
        {
            return printerTypes.Select(ConvertPrinterTypeToData).ToList();
        }

        #endregion

        #region stationType

        /// <summary>
        /// Converts the station type to data contract.
        /// </summary>
        /// <param name="genericStationType">Type of the generic station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertStationTypeToDataContract operation
        /// </summary>
        public static StationTypeData ConvertStationTypeToDataContract(IStationType genericStationType)
        {
            if (genericStationType == null)
            {
                return null;
            }
            return new StationTypeData(genericStationType);
        }

        /// <summary>
        /// Converts the station types to data.
        /// </summary>
        /// <param name="stationTypes">The station types.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertStationTypesToData operation
        /// </summary>
        public static IList<StationTypeData> ConvertStationTypesToData(IList<IStationType> stationTypes)
        {
            return stationTypes.Select(ConvertStationTypeToDataContract).ToList();
        }

        #endregion station

        #region

        /// <summary>
        /// Converts the station to data.
        /// </summary>
        /// <param name="station">The station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertStationToData operation
        /// </summary>
        public static StationData ConvertStationToData(IStation station)
        {
            if (station == null)
                return null;
            var s = (Station)station;
            var stationData = new StationData(station)
                                  {
                                      FacilityName = s.Facility.Text
                                  };
            return stationData;
        }

        #endregion

        #region Batch

        /// <summary>
        /// Converts the batch to data.
        /// </summary>
        /// <param name="batch">The batch.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertBatchToData operation
        /// </summary>
        public static BatchData ConvertBatchToData(IBatch batch)
        {
            return new BatchData(batch);
        }

        /// <summary>
        /// Converts the batchs to data.
        /// </summary>
        /// <param name="batchs">The batchs.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertBatchsToData operation
        /// </summary>
        public static IList<BatchData> ConvertBatchsToData(IList<IBatch> batchs)
        {
            return batchs.Select(ConvertBatchToData).ToList();
        }

        #endregion

        #region CustomerGroup

        /// <summary>
        /// Converts the customer group to data.
        /// </summary>
        /// <param name="customerGroup">The customer group.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertCustomerGroupToData operation
        /// </summary>
        public static CustomerGroupData ConvertCustomerGroupToData(ICustomerGroup customerGroup)
        {
            return new CustomerGroupData(customerGroup);
        }

        /// <summary>
        /// Converts the customer groups to data.
        /// </summary>
        /// <param name="customerGroups">The customer groups.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertCustomerGroupsToData operation
        /// </summary>
        public static IList<CustomerGroupData> ConvertCustomerGroupsToData(IList<ICustomerGroup> customerGroups)
        {
            return customerGroups.Select(ConvertCustomerGroupToData).ToList();
        }

        #endregion

        #region GenericKeyValue

        /// <summary>
        /// Converts the generic key value to data.
        /// </summary>
        /// <param name="genericKeyValue">The generic key value.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertGenericKeyValueToData operation
        /// </summary>
        public static GenericKeyValueData ConvertGenericKeyValueToData(IGenericKeyValue genericKeyValue)
        {
            return genericKeyValue == null ? null : new GenericKeyValueData(genericKeyValue);
        }

        /// <summary>
        /// Converts the generic key values to data.
        /// </summary>
        /// <param name="genericKeyValues">The generic key values.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertGenericKeyValuesToData operation
        /// </summary>
        public static IList<GenericKeyValueData> ConvertGenericKeyValuesToData(IList<IGenericKeyValue> genericKeyValues)
        {
            return genericKeyValues.Select(ConvertGenericKeyValueToData).ToList();
        }

        #endregion

        #region GenericKeyValueAssociated

        /// <summary>
        /// Converts the generic key value associated to data.
        /// </summary>
        /// <param name="genericKeyValueAssociated">The generic key value associated.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertGenericKeyValueAssociatedToData operation
        /// </summary>
        public static GenericKeyValueAssociatedData ConvertGenericKeyValueAssociatedToData(
            IGenericKeyValueAssociated genericKeyValueAssociated)
        {
            return genericKeyValueAssociated == null
                       ? null
                       : new GenericKeyValueAssociatedData(genericKeyValueAssociated);
        }

        /// <summary>
        /// Converts the generic key value associateds to data.
        /// </summary>
        /// <param name="genericKeyValueAssociateds">The generic key value associateds.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertGenericKeyValueAssociatedsToData operation
        /// </summary>
        public static IList<GenericKeyValueAssociatedData> ConvertGenericKeyValueAssociatedsToData(
            IList<IGenericKeyValueAssociated> genericKeyValueAssociateds)
        {
            return genericKeyValueAssociateds.Select(ConvertGenericKeyValueAssociatedToData).ToList();
        }

        #endregion

        #region ProductionStationDetail

        /// <summary>
        /// Converts the production station detail to data.
        /// </summary>
        /// <param name="productionStationDetail">The production station detail.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertProductionStationDetailToData operation
        /// </summary>
        public static ProductionStationDetailData ConvertProductionStationDetailToData(
            IProductionStationDetail productionStationDetail)
        {
            var productionStationDetailData = productionStationDetail == null
                                                                          ? null
                                                                          : new ProductionStationDetailData(
                                                                                productionStationDetail.StationId,
                                                                                productionStationDetail.StationName,
                                                                                productionStationDetail.ItemsAtStation,
                                                                                productionStationDetail.IsOverdue,
                                                                                productionStationDetail.Information);

            if (productionStationDetailData != null)
            {
                productionStationDetailData.ServiceRequirementDetails =
                    ConvertServiceRequirementDetailsToData(productionStationDetail.ServiceRequirements);
            }
            return productionStationDetailData;
        }

        /// <summary>
        /// Converts the production station details to data.
        /// </summary>
        /// <param name="productionStationDetails">The production station details.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertProductionStationDetailsToData operation
        /// </summary>
        public static IList<ProductionStationDetailData> ConvertProductionStationDetailsToData(
            IList<IProductionStationDetail> productionStationDetails)
        {
            return productionStationDetails.Select(ConvertProductionStationDetailToData).ToList();
        }

        /// <summary>
        /// Converts the production item to data.
        /// </summary>
        /// <param name="productionItem">The production item.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertProductionItemToData operation
        /// </summary>
        public static ProductionItemData ConvertProductionItemToData(IProductionItem productionItem)
        {
            return productionItem == null
                       ? null
                       : new ProductionItemData(productionItem.TurnaroundId,
                                                productionItem.InstanceId,
                                                productionItem.ContainerInstanceExternalId,
                                                productionItem.ItemName,
                                                productionItem.CustomerId,
                                                productionItem.CustomerName,
                                                productionItem.StationExpiry,
                                                productionItem.TimeAtLocation,
                                                productionItem.ExpiryTime,
                                                productionItem.ServiceRequirementId,
                                                productionItem.ServiceRequirementName,
                                                productionItem.Bookmark);
        }

        /// <summary>
        /// Converts the production items to data.
        /// </summary>
        /// <param name="productionItems">The production items.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertProductionItemsToData operation
        /// </summary>
        public static IList<ProductionItemData> ConvertProductionItemsToData(IList<IProductionItem> productionItems)
        {
            return productionItems.Select(ConvertProductionItemToData).ToList();
        }

        /// <summary>
        /// Converts the production item type to data.
        /// </summary>
        /// <param name="productionItemType">Type of the production item.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertProductionItemTypeToData operation
        /// </summary>
        public static ProductionItemTypeData ConvertProductionItemTypeToData(IProductionItemType productionItemType)
        {
            var pItemType = (ProductionItemType)productionItemType;
            var pit = new ProductionItemTypeData(pItemType.ItemTypeId,
                pItemType.ItemTypeName,
                pItemType.Count) {ProductionStations = ConvertProductionStationsToData(pItemType.ProductionStations)};
            return pit;
        }

        /// <summary>
        /// Converts the production item types to data.
        /// </summary>
        /// <param name="productionItemTypes">The production item types.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertProductionItemTypesToData operation
        /// </summary>
        public static IList<ProductionItemTypeData> ConvertProductionItemTypesToData(
            IList<IProductionItemType> productionItemTypes)
        {
            return productionItemTypes.Select(ConvertProductionItemTypeToData).ToList();
        }

        /// <summary>
        /// Converts the production station to data.
        /// </summary>
        /// <param name="productionStation">The production station.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertProductionStationToData operation
        /// </summary>
        public static ProductionStationData ConvertProductionStationToData(IProductionStation productionStation)
        {
            return productionStation == null
                       ? null
                       : new ProductionStationData(productionStation.StationId,
                                                   productionStation.StationName,
                                                   productionStation.Count);
        }

        /// <summary>
        /// Converts the production stations to data.
        /// </summary>
        /// <param name="productionStations">The production stations.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertProductionStationsToData operation
        /// </summary>
        public static IList<ProductionStationData> ConvertProductionStationsToData(
            IList<IProductionStation> productionStations)
        {
            return productionStations.Select(ConvertProductionStationToData).ToList();
        }

        #endregion

        #region ServicerequirementDetail

        /// <summary>
        /// Converts the service requirement detail to data.
        /// </summary>
        /// <param name="serviceRequirementDetail">The service requirement detail.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertServiceRequirementDetailToData operation
        /// </summary>
        public static ServiceRequirementDetailData ConvertServiceRequirementDetailToData(
            IServiceRequirementDetail serviceRequirementDetail)
        {
            return serviceRequirementDetail == null
                       ? null
                       : new ServiceRequirementDetailData(serviceRequirementDetail.ServiceRequirementId,
                                                          serviceRequirementDetail.ServiceRequirementName,
                                                          serviceRequirementDetail.Items,
                                                          serviceRequirementDetail.ItemsOverdue);
        }

        /// <summary>
        /// Converts the service requirement details to data.
        /// </summary>
        /// <param name="serviceRequirementDetails">The service requirement details.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertServiceRequirementDetailsToData operation
        /// </summary>
        public static IList<ServiceRequirementDetailData> ConvertServiceRequirementDetailsToData(
            IList<IServiceRequirementDetail> serviceRequirementDetails)
        {
            return serviceRequirementDetails.Select(ConvertServiceRequirementDetailToData).ToList();
        }

        #endregion

        #region MasterCollection

        /// <summary>
        /// Converts the master collection to data.
        /// </summary>
        /// <param name="masterCollection">The master collection.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertMasterCollectionToData operation
        /// </summary>
        public static MasterCollectionData ConvertMasterCollectionToData(IMasterCollection masterCollection)
        {
            return masterCollection == null
                       ? null
                       : new MasterCollectionData(masterCollection);
        }

        /// <summary>
        /// Converts the master collections to data.
        /// </summary>
        /// <param name="masterCollections">The master collections.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertMasterCollectionsToData operation
        /// </summary>
        public static IList<MasterCollectionData> ConvertMasterCollectionsToData(
            IList<IMasterCollection> masterCollections)
        {
            return masterCollections.Select(ConvertMasterCollectionToData).ToList();
        }

        #endregion

        #region InstanceCollection

        /// <summary>
        /// Converts the instance colletion to data.
        /// </summary>
        /// <param name="instanceCollection">The instance collection.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertInstanceColletionToData operation
        /// </summary>
        public static InstanceCollectionData ConvertInstanceColletionToData(IInstanceCollection instanceCollection)
        {
            return instanceCollection == null ? null : new InstanceCollectionData(instanceCollection);
        }

        /// <summary>
        /// Converts the instance collections to data.
        /// </summary>
        /// <param name="instanceCollections">The instance collections.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertInstanceCollectionsToData operation
        /// </summary>
        public static IList<InstanceCollectionData> ConvertInstanceCollectionsToData(
            IList<IInstanceCollection> instanceCollections)
        {
            return instanceCollections.Select(ConvertInstanceColletionToData).ToList();
        }

        #endregion

        #region ContainerContents

        /// <summary>
        /// Converts the container contents to data.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertContainerContentsToData operation
        /// </summary>
        public static ContainerContentData ConvertContainerContentsToData(IContainerContent contents)
        {
            if (contents == null)
                return null;
            var containerContents = (ContainerContent)contents;
            var data = new ContainerContentData(contents);
            ItemMaster itemMaster =
                containerContents.ItemMasterDefinition.ItemMaster.OrderByDescending(i => i.Revision).FirstOrDefault();
            data.ContainerMasterId = containerContents.ContainerMaster.ContainerMasterId;
            data.ContainerMasterName = containerContents.ContainerMaster.Text;
            data.ItemMasterId = itemMaster.ItemMasterId;
            data.ItemMasterName = itemMaster.Text;
            return data;
        }

        /// <summary>
        /// Converts the container contentses to data.
        /// </summary>
        /// <param name="contentses">The contentses.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertContainerContentsesToData operation
        /// </summary>
        public static IList<ContainerContentData> ConvertContainerContentsesToData(IList<IContainerContent> contentses)
        {
            return contentses.Select(ConvertContainerContentsToData).ToList();
        }

        #endregion ContainerMaster

        #region StoragePoint

        /// <summary>
        /// Converts the storage point to data.
        /// </summary>
        /// <param name="storagePoint">The storage point.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertStoragePointToData operation
        /// </summary>
        public static StoragePointData ConvertStoragePointToData(IStoragePoint storagePoint)
        {
            if (storagePoint == null)
                return null;
            var spData = new StoragePointData(storagePoint);
            var sp = (StoragePoint)storagePoint;
            var customer =
                sp.CustomerDefinition.Customer.Where(
                    c => c.CustomerStatusId == (byte)CustomerStatusTypeIdentifier.Active).FirstOrDefault();
            spData.CustomerId = customer == null ? 0 : customer.CustomerId;
            spData.CusomterName = customer == null ? string.Empty : customer.Text;
            return spData;
        }

        /// <summary>
        /// Converts the storage points to data.
        /// </summary>
        /// <param name="storagePoints">The storage points.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertStoragePointsToData operation
        /// </summary>
        public static IList<StoragePointData> ConvertStoragePointsToData(IList<IStoragePoint> storagePoints)
        {
            return storagePoints == null ? null : storagePoints.Select(ConvertStoragePointToData).ToList();
        }

        #endregion

        #region CustomerDefect

        /// <summary>
        /// ConvertCustomerDefectToContract operation
        /// </summary>
        public static CustomerDefectData ConvertCustomerDefectToContract(ReadPagedCustomerDefects_Result customerDefect)
        {
            if (customerDefect == null)
            {
                return null;
            }
            else
            {
                var defectData = new CustomerDefectData
                {
                    CustomerDefectId = (int)customerDefect.DefectId,
                    ExternalId = customerDefect.ExternalId,
                    ItemName = customerDefect.ItemName,
                    TurnaroundExternalId = Convert.ToInt64(customerDefect.SerialNumber),
                    Created = (DateTime)customerDefect.Raised,
                };
                return defectData;
            }
        }

        /// <summary>
        /// Converts the customer defect to data.
        /// </summary>
        /// <param name="customerDefect">The customer defect.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertCustomerDefectToData operation
        /// </summary>
        public static CustomerDefectData ConvertCustomerDefectToData(ICustomerDefect customerDefect)
        {
            if (customerDefect == null)
            {
                return null;
            }

            var customreDefectData = new CustomerDefectData(customerDefect);
            var defect = (CustomerDefect)customerDefect;
            ContainerInstance containerInstance = defect.Turnaround.ContainerInstance;
            ContainerMaster containerMaster = defect.Turnaround.ContainerMaster;
            if (containerInstance != null)
            {
                customreDefectData.InstanceId = containerInstance.ContainerInstanceId;
                customreDefectData.InstanceExternalId = containerInstance.ExternalId;
            }
            customreDefectData.ItemId = containerMaster.ContainerMasterId;
            customreDefectData.ItemName = containerMaster.Text;
            customreDefectData.CreatedUser = defect.User.UserName;
            customreDefectData.DeliveryPoint = defect.Turnaround.DeliveryPoint.Text;
            customreDefectData.Status = defect.CustomerDefectStatus.Text;
            customreDefectData.TurnaroundExternalId = defect.Turnaround.ExternalId;
            customreDefectData.CustomerDefectReasons =
                ConvertCustomerDefectReasonsToData(defect.CustomerDefectReasons.ToList<ICustomerDefectReason>());
            return customreDefectData;
        }

        /// <summary>
        /// Converts the customer defects to data.
        /// </summary>
        /// <param name="customerDefects">The customer defects.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertCustomerDefectsToData operation
        /// </summary>
        public static IList<CustomerDefectData> ConvertCustomerDefectsToData(IList<ICustomerDefect> customerDefects)
        {
            return customerDefects == null ? null : customerDefects.Select(ConvertCustomerDefectToData).ToList();
        }

        /// <summary>
        /// ConvertCustomerDefectsToContract operation
        /// </summary>
        public static IList<CustomerDefectData> ConvertCustomerDefectsToContract(IList<ReadPagedCustomerDefects_Result> customerDefects)
        {
            return customerDefects == null ? null : customerDefects.Select(ConvertCustomerDefectToContract).ToList();
        }

        #endregion

        #region CustomerDefectStatus

        /// <summary>
        /// Converts the customer defect status to data.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertCustomerDefectStatusToData operation
        /// </summary>
        public static CustomerDefectStatusData ConvertCustomerDefectStatusToData(ICustomerDefectStatus status)
        {
            return status == null ? null : new CustomerDefectStatusData(status);
        }

        /// <summary>
        /// Converts the customer defect statuses to data.
        /// </summary>
        /// <param name="statuses">The statuses.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertCustomerDefectStatusesToData operation
        /// </summary>
        public static IList<CustomerDefectStatusData> ConvertCustomerDefectStatusesToData(
            IList<ICustomerDefectStatus> statuses)
        {
            return statuses?.Select(ConvertCustomerDefectStatusToData).ToList();
        }

        #endregion CustomerDefectStauts

        #region CustomerDefectReason

        /// <summary>
        /// Converts the customer defect reason to data.
        /// </summary>
        /// <param name="reason">The reason.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertCustomerDefectReasonToData operation
        /// </summary>
        public static CustomerDefectReasonData ConvertCustomerDefectReasonToData(ICustomerDefectReason reason)
        {
            return reason == null ? null : new CustomerDefectReasonData(reason);
        }

        /// <summary>
        /// Converts the customer defect reasons to data.
        /// </summary>
        /// <param name="reasons">The reasons.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertCustomerDefectReasonsToData operation
        /// </summary>
        public static IList<CustomerDefectReasonData> ConvertCustomerDefectReasonsToData(
            IList<ICustomerDefectReason> reasons)
        {
            return reasons?.Select(ConvertCustomerDefectReasonToData).ToList();
        }

        #endregion CustomerDefectStauts

        #region ChangeControlNote

        /// <summary>
        /// Converts the change controlnote to data.
        /// </summary>
        /// <param name="changeControlNote">The change controlnote.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertChangeControlNoteToData operation
        /// </summary>
        public static ChangeControlNoteData ConvertChangeControlNoteToData(IChangeControlNote changeControlNote)
        {
            if (changeControlNote == null)
                return null;
            var genericChangeControlNote = (ChangeControlNote)changeControlNote;
            var ccn = new ChangeControlNoteData(genericChangeControlNote)
                          {
                          };
            return ccn;
        }

        #endregion

        #region SCSearch

        /// <summary>
        /// Converts the SC search summary to data.
        /// </summary>
        /// <param name="scSearchSummary">The sc search summary.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertScSearchSummaryToData operation
        /// </summary>
        public static SCSearchSummaryData ConvertScSearchSummaryToData(ISCSearchSummary scSearchSummary)
        {
            return scSearchSummary == null ? null : new SCSearchSummaryData(scSearchSummary);
        }

        /// <summary>
        /// Converts the omni search defect detail data.
        /// </summary>
        /// <param name="omniSearchDefectsDetail">The omni search defects detail.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchDefectDetailData operation
        /// </summary>
        public static OmniSearchDefectsDetailData ConvertOmniSearchDefectDetailData(
            IOmniSearchDefectsDetail omniSearchDefectsDetail)
        {
            return omniSearchDefectsDetail == null
                       ? null
                       : new OmniSearchDefectsDetailData(omniSearchDefectsDetail.CustomerName,
                                                         omniSearchDefectsDetail.CustomerId,
                                                         omniSearchDefectsDetail.CustomerStatusId,
                                                         omniSearchDefectsDetail.DefectClassification,
                                                         omniSearchDefectsDetail.DefectSeverity,
                                                         omniSearchDefectsDetail.DefectStatus,
                                                         omniSearchDefectsDetail.DefectId,
                                                         omniSearchDefectsDetail.DeliveryPointName,
                                                         omniSearchDefectsDetail.DeliveryPointId,
                                                         omniSearchDefectsDetail.LegacyInternalId,
                                                         omniSearchDefectsDetail.LegacyExternalId,
                                                         omniSearchDefectsDetail.Raised,
                                                         omniSearchDefectsDetail.ReportingDepartment,
                                                         omniSearchDefectsDetail.ReportingUserName,
                                                         omniSearchDefectsDetail.ReportingUserPosition,
                                                         omniSearchDefectsDetail.TurnaroundId,
                                                         omniSearchDefectsDetail.TurnaroundExternalId,
                                                         omniSearchDefectsDetail.DefectType);
        }

        /// <summary>
        /// Converts the omni search defect details data.
        /// </summary>
        /// <param name="omniSearchDefectsDetails">The omni search defects details.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchDefectDetailsData operation
        /// </summary>
        public static IList<OmniSearchDefectsDetailData> ConvertOmniSearchDefectDetailsData(
            IList<IOmniSearchDefectsDetail> omniSearchDefectsDetails)
        {
            return omniSearchDefectsDetails?.Select(ConvertOmniSearchDefectDetailData).ToList();
        }

        /// <summary>
        /// Converts the omni search delivery notes detail to data.
        /// </summary>
        /// <param name="omniSearchDeliveryNotesDetail">The omni search delivery notes detail.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchDeliveryNotesDetailToData operation
        /// </summary>
        public static OmniSearchDeliveryNotesDetailData ConvertOmniSearchDeliveryNotesDetailToData(
            IOmniSearchDeliveryNotesDetail omniSearchDeliveryNotesDetail)
        {
            return omniSearchDeliveryNotesDetail == null
                       ? null
                       : new OmniSearchDeliveryNotesDetailData(omniSearchDeliveryNotesDetail.DeliveryNoteId,
                                                               omniSearchDeliveryNotesDetail.PrintedUserId,
                                                               omniSearchDeliveryNotesDetail.UserName,
                                                               omniSearchDeliveryNotesDetail.ExternalId,
                                                               omniSearchDeliveryNotesDetail.LegacyId,
                                                               omniSearchDeliveryNotesDetail.FacilityId,
                                                               omniSearchDeliveryNotesDetail.FacilityName,
                                                               omniSearchDeliveryNotesDetail.CustomerId,
                                                               omniSearchDeliveryNotesDetail.CustomerStatusId,
                                                               omniSearchDeliveryNotesDetail.CustomerName,
                                                               omniSearchDeliveryNotesDetail.DeliveryPointId,
                                                               omniSearchDeliveryNotesDetail.DeliveryPointName,
                                                               omniSearchDeliveryNotesDetail.PrintStatus,
                                                               omniSearchDeliveryNotesDetail.CreateDate, omniSearchDeliveryNotesDetail.PrintedDate);
        }

        /// <summary>
        /// Converts the omni search delivery notes details to data.
        /// </summary>
        /// <param name="omniSearchDeliveryNotesDetails">The omni search delivery notes details.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchDeliveryNotesDetailsToData operation
        /// </summary>
        public static IList<OmniSearchDeliveryNotesDetailData> ConvertOmniSearchDeliveryNotesDetailsToData(
            IList<IOmniSearchDeliveryNotesDetail> omniSearchDeliveryNotesDetails)
        {
            return omniSearchDeliveryNotesDetails?.Select(ConvertOmniSearchDeliveryNotesDetailToData).ToList();
        }

        /// <summary>
        /// Converts the omni search instance detail to data.
        /// </summary>
        /// <param name="omniSearchInstanceDetail">The omni search instance detail.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchInstanceDetailToData operation
        /// </summary>
        public static OmniSearchInstanceDetailData ConvertOmniSearchInstanceDetailToData(
            IOmniSearchInstanceDetail omniSearchInstanceDetail)
        {
            return omniSearchInstanceDetail == null
                       ? null
                       : new OmniSearchInstanceDetailData(omniSearchInstanceDetail.InstanceId,
                                                          omniSearchInstanceDetail.DeliveryPoint,
                                                          omniSearchInstanceDetail.Customer,
                                                          omniSearchInstanceDetail.LegacyInternalId,
                                                          omniSearchInstanceDetail.LegacyExternalId,
                                                          omniSearchInstanceDetail.ExternalId,
                                                          omniSearchInstanceDetail.SuperType,
                                                          omniSearchInstanceDetail.ItemUid,
                                                          omniSearchInstanceDetail.ItemName,
                                                          omniSearchInstanceDetail.ItemTypeId,
                                                          omniSearchInstanceDetail.ItemTypeName,
                                                          omniSearchInstanceDetail.TurnaroundCount,
                                                          omniSearchInstanceDetail.ServiceRequirement);
        }

        /// <summary>
        /// Converts the omni search instance details to data.
        /// </summary>
        /// <param name="omniSearchInstanceDetails">The omni search instance details.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchInstanceDetailsToData operation
        /// </summary>
        public static IList<OmniSearchInstanceDetailData> ConvertOmniSearchInstanceDetailsToData(
            IList<IOmniSearchInstanceDetail> omniSearchInstanceDetails)
        {
            return omniSearchInstanceDetails?.Select(ConvertOmniSearchInstanceDetailToData).ToList();
        }

        /// <summary>
        /// Converts the omni search item detail to data.
        /// </summary>
        /// <param name="omniSearchItemDetail">The omni search item detail.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchItemDetailToData operation
        /// </summary>
        public static OmniSearchItemDetailData ConvertOmniSearchItemDetailToData(
            IOmniSearchItemDetail omniSearchItemDetail)
        {
            return omniSearchItemDetail == null
                       ? null
                       : new OmniSearchItemDetailData(omniSearchItemDetail.MasterId,
                                                      omniSearchItemDetail.MasterSubtype,
                                                      omniSearchItemDetail.Name,
                                                      omniSearchItemDetail.LegacyInternalId,
                                                      omniSearchItemDetail.LegacyExternalId,
                                                      omniSearchItemDetail.ExternalId,
                                                      omniSearchItemDetail.Status,
                                                      omniSearchItemDetail.ItemType,
                                                      omniSearchItemDetail.BaseType,
                                                      omniSearchItemDetail.NumberOfInstance, omniSearchItemDetail.MasterType, omniSearchItemDetail.CustomerName);
        }

        /// <summary>
        /// Converts the omni search item details to data.
        /// </summary>
        /// <param name="omniSearchItemDetails">The omni search item details.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchItemDetailsToData operation
        /// </summary>
        public static IList<OmniSearchItemDetailData> ConvertOmniSearchItemDetailsToData(
            IList<IOmniSearchItemDetail> omniSearchItemDetails)
        {
            return omniSearchItemDetails?.Select(ConvertOmniSearchItemDetailToData).ToList();
        }

        /// <summary>
        /// Converts the omni search turnaround detail to data.
        /// </summary>
        /// <param name="omniSearchTurnaroundDetail">The omni search turnaround detail.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchTurnaroundDetailToData operation
        /// </summary>
        public static OmniSearchTurnaroundDetailData ConvertOmniSearchTurnaroundDetailToData(
            IOmniSearchTurnaroundDetail omniSearchTurnaroundDetail)
        {
            return omniSearchTurnaroundDetail == null
                       ? null
                       : new OmniSearchTurnaroundDetailData(omniSearchTurnaroundDetail.TurnaroundId,
                                                            omniSearchTurnaroundDetail.CreatedDate,
                                                            omniSearchTurnaroundDetail.ServiceRequirementId,
                                                            omniSearchTurnaroundDetail.ServicerequirementName,
                                                            omniSearchTurnaroundDetail.DeliveryPointId,
                                                            omniSearchTurnaroundDetail.DeliveryPointName,
                                                            omniSearchTurnaroundDetail.CustomerId,
                                                            omniSearchTurnaroundDetail.CustomerName,
                                                            omniSearchTurnaroundDetail.ItemId,
                                                            omniSearchTurnaroundDetail.ItemExternalId,
                                                            omniSearchTurnaroundDetail.ItemName,
                                                            omniSearchTurnaroundDetail.InstanceId,
                                                            omniSearchTurnaroundDetail.InstanceExternalId,
                                                            omniSearchTurnaroundDetail.DeliveryNoteId,
                                                            omniSearchTurnaroundDetail.Expiry,
                                                            omniSearchTurnaroundDetail.LegacyInternalId,
                                                            omniSearchTurnaroundDetail.ExternalId,
                                                            omniSearchTurnaroundDetail.LastEvent,
                                                            omniSearchTurnaroundDetail.LastEventDate);
        }

        /// <summary>
        /// Converts the omni search loansets detail to data.
        /// </summary>
        /// <param name="omniSearchLoanSetsDetail">The omni search loansets detail.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchLoanSetsDetailToData operation
        /// </summary>
        public static OmniSearchLoanSetsDetailData ConvertOmniSearchLoanSetsDetailToData(
            IOmniSearchLoanSetsDetail omniSearchLoanSetsDetail)
        {
            return omniSearchLoanSetsDetail == null
                       ? null
                       : new OmniSearchLoanSetsDetailData(omniSearchLoanSetsDetail.LoanSetId,
                                                            omniSearchLoanSetsDetail.ExternalId,
                                                            omniSearchLoanSetsDetail.DeliveryDate,
                                                            omniSearchLoanSetsDetail.NoOfTrays,
                                                            omniSearchLoanSetsDetail.LoanSupplier,
                                                            omniSearchLoanSetsDetail.Consignment,
                                                            omniSearchLoanSetsDetail.NextProcedureDate,
                                                            omniSearchLoanSetsDetail.ReturnDate,
                                                            (LoanSetStatusTypeIdentifier)omniSearchLoanSetsDetail.LoanStatusId);
        }
        /// <summary>
        /// Converts the omni search turnaround details to data.
        /// </summary>
        /// <param name="omniSearchTurnaroundDetails">The omni search turnaround details.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchTurnaroundDetailsToData operation
        /// </summary>
        public static IList<OmniSearchTurnaroundDetailData> ConvertOmniSearchTurnaroundDetailsToData(
            IList<IOmniSearchTurnaroundDetail> omniSearchTurnaroundDetails)
        {
            return omniSearchTurnaroundDetails?.Select(ConvertOmniSearchTurnaroundDetailToData).ToList();
        }

        /// <summary>
        /// Converts the omni search turnaround details to data.
        /// </summary>
        /// <param name="omniSearchLoanSetsDetails">The omni search turnaround details.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertOmniSearchLoanSetsDetailsToData operation
        /// </summary>
        public static IList<OmniSearchLoanSetsDetailData> ConvertOmniSearchLoanSetsDetailsToData(
            IList<IOmniSearchLoanSetsDetail> omniSearchLoanSetsDetails)
        {
            return omniSearchLoanSetsDetails?.Select(ConvertOmniSearchLoanSetsDetailToData).ToList();
        }
        /// <summary>
        /// Converts the SC search to data.
        /// </summary>
        /// <param name="scSearch">The sc search.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertScSearchToData operation
        /// </summary>
        public static SCSearchData ConvertScSearchToData(ISCSearch scSearch)
        {
            return scSearch == null
                       ? null
                       : new SCSearchData
                             {
                                 Defects = ConvertOmniSearchDefectDetailsData(scSearch.Defects),
                                 DeliveryNotes = ConvertOmniSearchDeliveryNotesDetailsToData(scSearch.DeliveryNotes),
                                 Instances = ConvertOmniSearchInstanceDetailsToData(scSearch.Instances),
                                 Items = ConvertOmniSearchItemDetailsToData(scSearch.Items),
                                 Instruments = ConvertOmniSearchItemDetailsToData(scSearch.Instruments),
                                 LoanSets = ConvertOmniSearchLoanSetsDetailsToData(scSearch.LoanSets),
                                 Turnarounds = ConvertOmniSearchTurnaroundDetailsToData(scSearch.Turnarounds)
                             };
        }

        /// <summary>
        /// Converts the SC search to data.
        /// </summary>
        /// <param name="scSearch">The sc search.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertDefectsSearchReportToContract operation
        /// </summary>
        public static IList<DefectData> ConvertDefectsSearchReportToContract(IList<ReadSCSearchDefectReport_Result> scSearch)
        {
            return scSearch.Select(ConvertDefectToContract).ToList();
        }

        /// <summary>
        /// ConvertDefectToContract operation
        /// </summary>
        public static DefectData ConvertDefectToContract(ReadSCSearchDefectReport_Result genericDefect)
        {
            if (genericDefect == null) return null;
            else
            {
                var defectData = new DefectData
                {
                    DefectId = (int)genericDefect.DefectId,
                    ExternalId = genericDefect.ExternalId,
                    TurnaroundId = genericDefect.TurnaroundId,
                    TurnaroundExternalId = genericDefect.TurnaroundExternalId,
                    Raised = genericDefect.Raised,
                    ReportingDepartment = genericDefect.ReportingDepartment,
                    ReporterUserName = genericDefect.ReporterUserName,
                    DefectTypeName = genericDefect.ResultType
                };
                return defectData;
            }
        }
        /// <summary>
        /// Converts the SC search customer defects to data.
        /// </summary>
        /// <param name="defects">The defects.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertScSearchCustomerDefectsToData operation
        /// </summary>
        public static IList<SCSearchCustomerDefectData> ConvertScSearchCustomerDefectsToData(
            IList<ISCSearchCustomerDefect> defects)
        {
            return defects?.Select(d => new SCSearchCustomerDefectData(d)).ToList();
        }

        #endregion

        #region ReportCategory

        /// <summary>
        /// Converts the report categories to data.
        /// </summary>
        /// <param name="reportCategories">The report categories.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertReportCategoriesToData operation
        /// </summary>
        public static IList<ReportCategoryData> ConvertReportCategoriesToData(IList<IReportCategory> reportCategories)
        {
            if (reportCategories == null)
                return null;
            return reportCategories.Select(ConvertReportCategoryToData).ToList();
        }

        /// <summary>
        /// Converts the report category to data.
        /// </summary>
        /// <param name="reportCategory">The report category.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertReportCategoryToData operation
        /// </summary>
        public static ReportCategoryData ConvertReportCategoryToData(IReportCategory reportCategory)
        {
            if (reportCategory == null)
                return null;
            var category = new ReportCategoryData(reportCategory);
            var rptCategory = (ReportCategory)reportCategory;
            if (rptCategory.ChildReportCategories != null && rptCategory.ChildReportCategories.Count > 0)
            {
                category.ChildReportCategories =
                    ConvertReportCategoriesToData(rptCategory.ChildReportCategories.ToList<IReportCategory>());
            }
            if (rptCategory.Report != null && rptCategory.Report.Count > 0)
            {
                category.Reports = ConvertReportsToData(rptCategory.Report.ToList<IReport>());
            }
            return category;
        }

        /// <summary>
        /// ConvertReportCategoriesToData operation
        /// </summary>
        public static IList<ReportCategoryData> ConvertReportCategoriesToData(IList<IReportCategory> reportCategories, IList<IUserReport> userReports)
        {
            if (reportCategories == null)
                return null;
            var reportCategoryDatas = new List<ReportCategoryData>();
            if (userReports == null)
            {
                foreach (ReportCategory reportCategory in reportCategories)
                {
                    var reportCategoryData = new ReportCategoryData(reportCategory);
                    ConvertReportCategoriesToData(reportCategory.ChildReportCategories.Where(crc => crc.IsLive).ToList<IReportCategory>(), userReports);
                    reportCategoryDatas.Add(reportCategoryData);
                }
                return reportCategoryDatas;
            }

            foreach (ReportCategory reportCategory in reportCategories)
            {
                var reports = new List<ReportData>();
                foreach (Report report in reportCategory.Report.Where(r => r.IsLive))
                {
                    reports.Add(new ReportData(report));
                }
                var reportCategoryData = new ReportCategoryData(reportCategory)
                                             {
                                                 Reports = reports
                                             };

                ConvertReportCategoriesToData(reportCategory.ChildReportCategories.Where(crc => crc.IsLive).ToList<IReportCategory>(), userReports);
                reportCategoryDatas.Add(reportCategoryData);
            }
            return reportCategoryDatas;
        }

        #endregion

        #region Report

        /// <summary>
        /// Converts the facility notes to datas.
        /// </summary>
        /// <param name="reports">The reports.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertReportsToData operation
        /// </summary>
        public static IList<ReportData> ConvertReportsToData(IList<IReport> reports)
        {
            return reports?.Select(ConvertReportToData).ToList();
        }

        /// <summary>
        /// Converts the report to data.
        /// </summary>
        /// <param name="report">The report.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertReportToData operation
        /// </summary>
        public static ReportData ConvertReportToData(IReport report)
        {
            if (report == null)
                return null;
            var rpt = (Report)report;
            var rptData = new ReportData(rpt)
                              {
                                  ReportCategoryName = rpt.ReportCategory.Text
                              };

            return rptData;
        }

        #endregion

        #region QuarantineReason
        /// <summary>
        /// ConvertQuarantineReasonToData operation
        /// </summary>
        public static QuarantineReasonData ConvertQuarantineReasonToData(IQuarantineReason quarantineReason)
        {
            return quarantineReason == null ? null : new QuarantineReasonData(quarantineReason);
        }

        /// <summary>
        /// ConvertQuarantineReasonsToData operation
        /// </summary>
        public static IList<QuarantineReasonData> ConvertQuarantineReasonsToData(IList<IQuarantineReason> quarantineReasons)
        {
            return quarantineReasons?.Select(ConvertQuarantineReasonToData).ToList();
        }
        #endregion

        #region Component
        /// <summary>
        /// ConvertComponentToData operation
        /// </summary>
        public static ComponentDetailData ConvertComponentToData(IComponentDetail componentDetail)
        {
            return componentDetail == null ? null : new ComponentDetailData(componentDetail);
        }

        /// <summary>
        /// ConvertComponentsToData operation
        /// </summary>
        public static IList<ComponentDetailData> ConvertComponentsToData(IList<IComponentDetail> componentDetails)
        {
            return componentDetails?.Select(ConvertComponentToData).ToList();
        }
        #endregion
        
        #region AbandonReason
        /// <summary>
        /// ConvertAbandonReasonToData operation
        /// </summary>
        public static AbandonReasonData ConvertAbandonReasonToData(IAbandonReason abandonReason)
        {
            return abandonReason == null ? null : new AbandonReasonData(abandonReason);
        }

        /// <summary>
        /// ConvertAbandonReasonsToData operation
        /// </summary>
        public static IList<AbandonReasonData> ConvertAbandonReasonsToData(IList<IAbandonReason> abandonReasons)
        {
            return abandonReasons?.Select(ConvertAbandonReasonToData).ToList();
        }
        #endregion

        #region ToEntity: MachineData

        /// <summary>
        /// Converts the machine data to entity.
        /// </summary>
        /// <param name="machineData">The machine data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertMachineDataToEntity operation
        /// </summary>
        public static IMachine ConvertMachineDataToEntity(MachineData machineData)
        {
            if (machineData == null)
            {
                return null;
            }
            return new Machine(machineData.MachineId, machineData.ArchivedUserId, machineData.FacilityId,
                               machineData.MachineTypeId, machineData.BatchPrefix, machineData.Text,
                               machineData.RunningTime, machineData.Archived, machineData.LegacyId,
                               machineData.LegacyFacilityOrigin, machineData.LegacyImported, machineData.CoolDownPeriod, null, machineData.IsSteam);
        }

        /// <summary>
        /// Converts the machines data to entity.
        /// </summary>
        /// <param name="machineDatas">The machine datas.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertMachinesDataToEntity operation
        /// </summary>
        public static IList<IMachine> ConvertMachinesDataToEntity(IList<MachineData> machineDatas)
        {
            return machineDatas.Select(ConvertMachineDataToEntity).ToList();
        }

        #endregion ToEntity: MachineData

        #region ToEntity: BatchCycleData

        /// <summary>
        /// Converts the batch cycle data to entity.
        /// </summary>
        /// <param name="batchCycleData">The batch cycle data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertBatchCycleDataToEntity operation
        /// </summary>
        public static IBatchCycle ConvertBatchCycleDataToEntity(BatchCycleData batchCycleData)
        {
            if (batchCycleData == null)
            {
                return null;
            }
            return new BatchCycle(batchCycleData.BatchCycleId, batchCycleData.MachineTypeId, batchCycleData.Text,
                                  batchCycleData.IsChargeable, batchCycleData.Order, batchCycleData.LegacyFacilityOrigin,
                                  batchCycleData.LegacyImported);
        }

        /// <summary>
        /// Converts the batch cycles data to entity.
        /// </summary>
        /// <param name="batchCyclesData">The batch cycles data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertBatchCyclesDataToEntity operation
        /// </summary>
        public static IList<IBatchCycle> ConvertBatchCyclesDataToEntity(IList<BatchCycleData> batchCyclesData)
        {
            return batchCyclesData.Select(ConvertBatchCycleDataToEntity).ToList();
        }

        #endregion ToEntity: BatchCycleData

        #region ToEntity: StationData

        /// <summary>
        /// Converts the station data to entity.
        /// </summary>
        /// <param name="stationData">The station data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertStationDataToEntity operation
        /// </summary>
        public static IStation ConvertStationDataToEntity(StationData stationData)
        {
            if (stationData == null)
            {
                return null;
            }
            return new Station(stationData.StationId, stationData.ArchivedUserId, stationData.FacilityId,
                               stationData.StationTypeId,
                               stationData.NTLogon, stationData.Text, stationData.Archived, stationData.Culture,
                               stationData.ShowDirectoratesAtDispatch,
                               stationData.ShowReleaseBatches, stationData.ShowPrioritisation, stationData.LegacyId,
                               stationData.LegacyFacilityOrigin, stationData.LegacyImported, stationData.PinRequestReasonId,
                               stationData.PerformanceDial, stationData.CountdownTimer, stationData.LocationId);
        }

        /// <summary>
        /// Converts the station printer data to entity.
        /// </summary>
        /// <param name="stationPrinterData">The station printer data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertStationPrinterDataToEntity operation
        /// </summary>
        public static IStationPrinter ConvertStationPrinterDataToEntity(StationPrinterData stationPrinterData)
        {
            if (stationPrinterData == null)
            {
                return null;
            }
            return new StationPrinter(stationPrinterData.StationPrinterId,
                                      stationPrinterData.StationId,
                                      stationPrinterData.PrinterId,
                                      stationPrinterData.PrinterTypeId);
        }

        #endregion ToEntity: StationData

        #region ToEntity:StationType

        /// <summary>
        /// Converts the station type data to entity.
        /// </summary>
        /// <param name="stationTypeData">The station type data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertStationTypeDataToEntity operation
        /// </summary>
        public static IStationType ConvertStationTypeDataToEntity(StationTypeData stationTypeData)
        {
            return stationTypeData == null
                       ? null
                       : new StationType(stationTypeData.StationTypeId, stationTypeData.StationTypeCategoryId,
                                         stationTypeData.Text, stationTypeData.DisplayOrder,
                                         stationTypeData.LegacyFacilityOrigin, stationTypeData.LegacyImported,
                                         stationTypeData.AllowAssignPPM, stationTypeData.AllowAssignNotes);
        }

        /// <summary>
        /// Converts the station type datas to entity.
        /// </summary>
        /// <param name="stationTypeDatas">The station type datas.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertStationTypeDatasToEntity operation
        /// </summary>
        public static IList<IStationType> ConvertStationTypeDatasToEntity(IList<StationTypeData> stationTypeDatas)
        {
            return stationTypeDatas.Select(ConvertStationTypeDataToEntity).ToList();
        }

        #endregion

        #region ToEntity: DefectData

        /// <summary>
        /// Converts the defect data to entity.
        /// </summary>
        /// <param name="defectData">The defect data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertDefectDataToEntity operation
        /// </summary>
        public static Defect ConvertDefectDataToEntity(DefectData defectData)
        {
            if (defectData == null)
            {
                return null;
            }
            var defect = new Defect(defectData.Raised,
                defectData.ReportingDepartment,
                defectData.DeliveryPointId,
                defectData.ReporterUserName,
                defectData.ReporterUserPosition,
                defectData.DefectStatusId,
                defectData.DefectSeverityId,
                defectData.DefectClassificationId,
                defectData.ItemName,
                defectData.ContainerInstanceId,
                defectData.TurnaroundId,
                defectData.GeneralFaultCount,
                defectData.OtherDetails,
                defectData.Received,
                defectData.ImmediateAction,
                defectData.ImmediateActionUserId,
                defectData.ImmediateActionDate,
                defectData.LongTermAction,
                defectData.LongTermActionUserId,
                defectData.LongTermActionDate,
                defectData.SignedForTrustUserName,
                defectData.SignedForSynergyUserId,
                defectData.Reviewed,
                defectData.ReviewUserId,
                defectData.Reviewed,
                defectData.DefectResponsibilityId,
                defectData.CreatedUserId,
                null,
                null,
                null,
                defectData.ExternalId,
                0,
                defectData.ReviewInformation)
            {
                ReviewInformation = string.Empty,
                IncidentDate = defectData.IncidentDate
            };
            return defect;
        }

        #endregion ToEntity: DefectData

        #region ToEntity: FacilityNoteData

        /// <summary>
        /// Converts the facility note data to entity.
        /// </summary>
        /// <param name="facilityNoteData">The facility note data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertFacilityNoteDataToEntity operation
        /// </summary>
        public static IFacilityNote ConvertFacilityNoteDataToEntity(FacilityNoteData facilityNoteData)
        {
            if (facilityNoteData == null)
            {
                return null;
            }
            return new FacilityNote(facilityNoteData.FacilityNoteId, facilityNoteData.ArchiveduserId,
                                    facilityNoteData.CreatedUserId, facilityNoteData.FacilityId, facilityNoteData.Text,
                                    facilityNoteData.Created, facilityNoteData.Archived,
                                    facilityNoteData.LegacyFacilityOrigin, facilityNoteData.LegacyImported);
        }

        /// <summary>
        /// Converts the facility notes data to entity.
        /// </summary>
        /// <param name="facilityNoteData">The facility note datas.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertFacilityNotesDataToEntity operation
        /// </summary>
        public static IList<IFacilityNote> ConvertFacilityNotesDataToEntity(IList<FacilityNoteData> facilityNoteData)
        {
            return facilityNoteData.Select(ConvertFacilityNoteDataToEntity).ToList();
        }

        #endregion ToEntity: FacilityNoteData

        #region ToEntity: ServiceRequirementData

        /// <summary>
        /// Converts the service requirement data to entity.
        /// </summary>
        /// <param name="serviceRequirementData">The service requirement data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertServiceRequirementDataToEnty operation
        /// </summary>
        public static IServiceRequirement ConvertServiceRequirementDataToEnty(
            ServiceRequirementData serviceRequirementData)
        {
            if (serviceRequirementData == null)
            {
                return null;
            }
            return new ServiceRequirement(serviceRequirementData.ServiceRequirementId,
                                          serviceRequirementData.ArchivedUserId, serviceRequirementData.CreatedUserId,
                                          serviceRequirementData.ExpiryCalculationTypeId,
                                          serviceRequirementData.ServiceRequirementDefinitionId,
                                          serviceRequirementData.Text, serviceRequirementData.Revision,
                                          serviceRequirementData.TurnaroundMinutes, serviceRequirementData.Margin,
                                          serviceRequirementData.MarginAppliesToReprocessing,
                                          serviceRequirementData.MarginAppliesToSingleUse,
                                          serviceRequirementData.MarginAppliesToOther,
                                          serviceRequirementData.GraceMinutes, serviceRequirementData.Effective,
                                          serviceRequirementData.Created, serviceRequirementData.Archived,
                                          serviceRequirementData.LegacyId, serviceRequirementData.LegacyFacilityOrigin,
                                          serviceRequirementData.LegacyImported,
                                          serviceRequirementData.IsFastTrack);
        }

        /// <summary>
        /// Converts the service requirements data to entity.
        /// </summary>
        /// <param name="serviceRequirementDatas">The service requirement datas.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertServiceRequirementsDataToEntity operation
        /// </summary>
        public static IList<IServiceRequirement> ConvertServiceRequirementsDataToEntity(
            IList<ServiceRequirementData> serviceRequirementDatas)
        {
            return serviceRequirementDatas.Select(ConvertServiceRequirementDataToEnty).ToList();
        }

        #endregion ToEntity: ServiceRequirementData

        #region ToEntity: DeliveryPointData

        /// <summary>
        /// Converts the delivery point data to entity.
        /// </summary>
        /// <param name="deliveryPointData">The delivery point data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertDeliveryPointDataToEntity operation
        /// </summary>
        public static IDeliveryPoint ConvertDeliveryPointDataToEntity(DeliveryPointData deliveryPointData)
        {
            if (deliveryPointData == null)
            {
                return null;
            }
            return new DeliveryPoint(deliveryPointData.DeliveryPointId, deliveryPointData.AddressId,
                                     deliveryPointData.ArchivedUserId, deliveryPointData.CustomerDefinitionId,
                                     deliveryPointData.DeliveryTypeId, deliveryPointData.DirectorateId,
                                     deliveryPointData.Text, deliveryPointData.Archived, deliveryPointData.StockLocation,
                                     deliveryPointData.RequiresProof, deliveryPointData.LegacyId,
                                     deliveryPointData.LegacyFacilityOrigin, deliveryPointData.LegacyImported,null, deliveryPointData.RestrictedForBatchTag, deliveryPointData.CreatePhysicalDeliveryNote);
        }

        /// <summary>
        /// Converts the delivery points data to entity.
        /// </summary>
        /// <param name="deliveryPointDatas">The delivery point datas.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertDeliveryPointsDataToEntity operation
        /// </summary>
        public static IList<IDeliveryPoint> ConvertDeliveryPointsDataToEntity(
            IList<DeliveryPointData> deliveryPointDatas)
        {
            return deliveryPointDatas.Select(ConvertDeliveryPointDataToEntity).ToList();
        }

        #endregion ToEntity: DeliveryPointData

        #region ToEntity: CustomerData

        /// <summary>
        /// Converts the customer data to entity.
        /// </summary>
        /// <param name="customerData">The customer data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertCustomerDataToEntity operation
        /// </summary>
        public static ICustomer ConvertCustomerDataToEntity(CustomerData customerData)
        {
            if (customerData == null)
            {
                return null;
            }
            return new Customer(customerData.CustomerId, customerData.AddressId, customerData.CreatedUserId,
                                customerData.CustomerDefinitionId, customerData.CustomerGroupId,
                                customerData.CustomerStatusId, customerData.FacilityId, customerData.Text,
                                customerData.Created, customerData.Revision, customerData.GS1Code,
                                customerData.IndependentQualityAssuranceCheck, customerData.TrayListFooter,
                                customerData.DeliveryNoteFooter, customerData.LegacyId,
                                customerData.LegacyFacilityOrigin, customerData.LegacyImported, customerData.Alias, customerData.DebtorId, customerData.PrintTrayListFrontSheet,
                                customerData.QALabelProductCodeId,
                                customerData.Linear1dBarcodeId,
                                customerData.Datamatrix2dBarcodeId, null,customerData.Notes, customerData.CreatePhysicalDeliveryNote);
        }

        #endregion ToEntity: CustomerData

        #region ToEntity: FacilityData

        /// <summary>
        /// Converts the facility data to entity.
        /// </summary>
        /// <param name="facilityData">The facility data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertFacilityDataToEntity operation
        /// </summary>
        public static IFacility ConvertFacilityDataToEntity(FacilityData facilityData)
        {
            if (facilityData == null)
            {
                return null;
            }
            var facility = new Facility(facilityData.FacilityId, 
                                        facilityData.AddressId, 
                                        facilityData.ArchivedUserId,
                                        facilityData.Text, 
                                        facilityData.EmailAddress, 
                                        facilityData.Archived,
                                        facilityData.UTCOffset, 
                                        facilityData.DLSOffset,
                                        facilityData.SubjectText, 
                                        facilityData.BodyText,
                                        facilityData.IndependentQualityAssuranceCheck,
                                        facilityData.WashRelease, 
                                        facilityData.LegacyFacilityOrigin,
                                        facilityData.LegacyImported, 
                                        facilityData.PrintSecondaryLabel,
                                        facilityData.ItemAliasEnabled,
                                        facilityData.BiologicalIndicatorEnabled, 
                                        facilityData.OwnerId,
                                        facilityData.FacilityCatalogueEnabled, 
                                        facilityData.TenancyCatalogueEnabled,
                                        facilityData.GlobalCatalogueEnabled, 
                                        facilityData.ProcessingModeId, 
                                        facilityData.ModifiedByUserId, 
                                        facilityData.ModifiedDate, 
                                        facilityData.IsFDAEnabled,
                                        facilityData.IsPerformancePauseEnabled,
                                        facilityData.ClockingConfigurationTypeId,
                                        facilityData.PrintSingleSecondaryLabel,
                                        facilityData.MatchReferenceWeights,
                                        facilityData.PreWashToleranceKg,
                                        facilityData.PostWashToleranceKg,
                                        (int)facilityData.DelayedBiTestType,
                                        facilityData.ScanAllIdentifiedItemsMarksAsPacked
                                        );
            facility.ExpiryDays = facilityData.ExpiryDays;

            return facility;

        }

        /// <summary>
        /// Converts the facility datas to entity.
        /// </summary>
        /// <param name="facilityDatas">The facility datas.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertFacilityDatasToEntity operation
        /// </summary>
        public static IList<IFacility> ConvertFacilityDatasToEntity(IList<FacilityData> facilityDatas)
        {
            return facilityDatas.Select(ConvertFacilityDataToEntity).ToList();
        }

        #endregion ToEntity: FacilityData

        #region ToEntity:FacilityLocation

        /// <summary>
        /// Converts the facility location data to entity.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>

        ///// <summary>
        ///// Converts the facility location data to entity.
        ///// </summary>
        ///// <param name="facilityLocationData">The facility location data.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>

        #endregion

        #region ToEntity:ContanierInstance

        /// <summary>
        /// Converts the container instance data to entity.
        /// </summary>
        /// <param name="instanceData">The instance data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertContainerInstanceDataToEntity operation
        /// </summary>
        public static IContainerInstance ConvertContainerInstanceDataToEntity(ContainerInstanceData instanceData)
        {
            if (instanceData == null)
            {
                return null;
            }
            return new ContainerInstance(instanceData.ContainerInstanceId,
                                         instanceData.ArchivedUserId, instanceData.ContainerMasterDefinitionId,
                                         instanceData.CreatedUserId, instanceData.DeliveryPointId,
                                         instanceData.ServiceRequirementDefinitionId, instanceData.FacilityId,
                                         instanceData.ExternalId, instanceData.Created, instanceData.Archived,
                                         instanceData.TurnaroundCount, instanceData.LegacyId,
                                         instanceData.LegacyExternalId, instanceData.LegacyIdReplaced,
                                         instanceData.LegacyFacilityOrigin, instanceData.LegacyImported,
                                         instanceData.Text, instanceData.Giai, instanceData.AlternateExternalId,
                                         instanceData.GS1ProductCode,
                                         instanceData.QuarantineEventTypeId,
                                         instanceData.QuarantineReasonId,
                                         instanceData.QALabelProductCodeId,
                                         instanceData.Linear1dBarcodeId,
                                         instanceData.Datamatrix2dBarcodeId,
                                         instanceData.TurnaroundWarningCount,
                                         instanceData.CurrentProcessEventId,
                                         instanceData.CurrentLocationId,
                                         instanceData.ModifiedById,
                                         instanceData.ModifiedByDate,
                                         instanceData.IsIdentifiable,
                                         instanceData.WeighingRequired,
                                         instanceData.AdditionalInfo);
        }

        #endregion

        #region ToEntity:MissingItem

        /// <summary>
        /// Converts the missing item data to entity.
        /// </summary>
        /// <param name="missingItemData">The missing item data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertMissingItemDataToEntity operation
        /// </summary>
        public static IMissingItem ConvertMissingItemDataToEntity(MissingItemData missingItemData)
        {
            if (missingItemData == null)
            {
                return null;
            }
            return new MissingItem(missingItemData.MissingItemId, missingItemData.ArchivedUserId,
                                   missingItemData.ContainerInstanceId, missingItemData.CreatedUserId,
                                   missingItemData.MissingItemReasonId, missingItemData.ItemInstanceId,
                                   missingItemData.ItemMasterDefinitionId, missingItemData.Quantity,
                                   missingItemData.Created, missingItemData.Archived, missingItemData.LegacyId,
                                   missingItemData.LegacyFacilityOrigin, missingItemData.LegacyImported,
                                   missingItemData.Trackable, missingItemData.TurnaroundId);
        }

        #endregion

        #region ToEntity:MissingItems

        /// <summary>
        /// Converts the missing items data to entity.
        /// </summary>
        /// <param name="missingItemDatas">The missing item datas.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertMissingItemsDataToEntity operation
        /// </summary>
        public static IList<IMissingItem> ConvertMissingItemsDataToEntity(IList<MissingItemData> missingItemDatas)
        {
            return missingItemDatas.Select(ConvertMissingItemDataToEntity).ToList();
        }

        #endregion

        #region ToEntity:Location

        /// <summary>
        /// Converts the location data to entity.
        /// </summary>
        ///// <summary>
        ///// Converts the locations data to entity.
        ///// </summary>
        ///// <param name="locationsData">The locations data.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>

        #endregion

        #region ToEntity:Address

        /// <summary>
        /// Converts the address data to entity.
        /// </summary>
        /// <param name="addressData">The address data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertAddressDataToEntity operation
        /// </summary>
        public static IAddress ConvertAddressDataToEntity(AddressData addressData)
        {
            if (addressData == null)
            {
                return null;
            }
            return new Address(addressData.AddressId, addressData.Address1, addressData.Address2, addressData.Address3,
                               addressData.City,
                               addressData.Postcode, addressData.ContactEmail, addressData.Telephone,
                               addressData.LegacyFacilityOrigin, addressData.LegacyImported);
        }

        /// <summary>
        /// Converts the addresses data to entity.
        /// </summary>
        /// <param name="addresses">The addresses.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertAddressesDataToEntity operation
        /// </summary>
        public static IList<IAddress> ConvertAddressesDataToEntity(IList<AddressData> addresses)
        {
            return addresses.Select(ConvertAddressDataToEntity).ToList();
        }

        #endregion

        #region ToEntity:LocationWorkingHour

        /// <summary>
        /// Converts the location working hour to entity.
        /// </summary>
        ///// <summary>
        ///// Converts the location working hours to entity.
        ///// </summary>
        ///// <param name="ContractedHoursData">The location working hours data.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>

        /// <summary>
        /// Converts the location working hourses to entity.
        /// </summary>
        /// <param name="locationWorkingHourses">The location working hourses.</param>
        /// <returns></returns>
        /// <remarks></remarks>

        #endregion

        #region ToEntity: ContainerMasterData

        /// <summary>
        /// Converts the container master data to entity.
        /// </summary>
        /// <param name="containerMasterData">The container master data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertContainerMasterDataToEntity operation
        /// </summary>
        public static IContainerMaster ConvertContainerMasterDataToEntity(ContainerMasterData containerMasterData)
        {
            if (containerMasterData == null)
            {
                return null;
            }
            return new ContainerMaster(containerMasterData.ContainerMasterId, containerMasterData.ChargableBatchCycleId,
                                       containerMasterData.CategoryId, containerMasterData.ComplexityId,
                                       containerMasterData.ContainerMasterDefinitionId,
                                       containerMasterData.CreatedUserId, containerMasterData.ItemStatusId,
                                       containerMasterData.ItemTypeId, containerMasterData.MachineTypeId,
                                       containerMasterData.SpecialityId, containerMasterData.ExternalId,
                                       containerMasterData.Text, containerMasterData.Revision,
                                       containerMasterData.Created, containerMasterData.IPOH,
                                       containerMasterData.ManufacturersReference, containerMasterData.NumberOfLabels,
                                       containerMasterData.IndependentQualityAssuranceCheck,
                                       containerMasterData.TrackIndividualInstruments, containerMasterData.LegacyId,
                                       containerMasterData.LegacyCustomerId, containerMasterData.LegacyFacilityOrigin,
                                       containerMasterData.LegacyImported, containerMasterData.PrinterTypeId,
                                       containerMasterData.Gtin, containerMasterData.ArchivedUserId,
                                       containerMasterData.Archived, containerMasterData.PinRequestReasonId,
                                       containerMasterData.BiologicalIndicatorEnabled,
                                       containerMasterData.LabourLevelId,
                                       containerMasterData.LastChangeAffectingWeightTime);
        }

        #endregion ToEntity: ContainerMasterData

        #region ToEntity: ItemMasterData

        /// <summary>
        /// Converts the item master data to entity.
        /// </summary>
        /// <param name="itemMasterData">The item master data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertItemMasterDataToEntity operation
        /// </summary>
        public static IItemMaster ConvertItemMasterDataToEntity(ItemMasterData itemMasterData)
        {
            if (itemMasterData == null)
            {
                return null;
            }
            return new ItemMaster(itemMasterData.ItemMasterId, itemMasterData.BatchCycleId, itemMasterData.CategoryId,
                                  itemMasterData.ComplexityId, itemMasterData.CreatedUserId,
                                  itemMasterData.ItemMasterDefinitionId, itemMasterData.ItemStatusId,
                                  itemMasterData.ItemTypeId, itemMasterData.SpecialityId, itemMasterData.ExternalId,
                                  itemMasterData.Text, itemMasterData.Revision, itemMasterData.Created,
                                  itemMasterData.ManufacturersReference, itemMasterData.ComponentPartCount,
                                  itemMasterData.Trackable, itemMasterData.IndependentQualityAssuranceCheck,
                                  itemMasterData.LegacyId, itemMasterData.LegacyFacilityOrigin,
                                  itemMasterData.LegacyImported, itemMasterData.FinanceId, itemMasterData.PinRequestReasonId,
                                  itemMasterData.BiologicalIndicatorEnabled, itemMasterData.LabourLevelId, itemMasterData.ManufacturerId);
        }

        #endregion ToEntity: ItemMasterData

        #region ToEntity: ContainerContentData

        /// <summary>
        /// Converts the container contents data to entity.
        /// </summary>
        /// <param name="containerContentData">The container contents data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertContainerContentDataToEntity operation
        /// </summary>
        public static IContainerContent ConvertContainerContentDataToEntity(ContainerContentData containerContentData)
        {
            if (containerContentData == null)
            {
                return null;
            }
            return new ContainerContent(containerContentData.ContainerContentId,
                                        containerContentData.ContainerContentNoteId,
                                        containerContentData.ContainerMasterId,
                                        containerContentData.ItemMasterDefinitionId, containerContentData.Quantity,
                                        containerContentData.Position, containerContentData.ComponentListPrint,
                                        containerContentData.LegacyId, containerContentData.LegacyCustomerId,
                                        containerContentData.LegacyFacilityOrigin, containerContentData.LegacyImported);
        }

        /// <summary>
        /// Converts the container contents datas to entity.
        /// </summary>
        /// <param name="containerContentData">The container contents datas.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertContainerContentDatasToEntity operation
        /// </summary>
        public static IList<IContainerContent> ConvertContainerContentDatasToEntity(
            IList<ContainerContentData> containerContentData)
        {
            return containerContentData.Select(ConvertContainerContentDataToEntity).ToList();
        }

        #endregion ToEntity: ContainerContentData

        #region ToEntity: WarningData

        /// <summary>
        /// Converts the warning data to entity.
        /// </summary>
        /// <param name="warningData">The warning data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertWarningDataToEntity operation
        /// </summary>
        public static IWarning ConvertWarningDataToEntity(WarningData warningData)
        {
            if (warningData == null)
            {
                return null;
            }
            return new Warning(warningData.WarningId, warningData.ContainerMasterId, warningData.ItemMasterId,
                               warningData.Text, warningData.MaximumTurnarounds, warningData.MaximumDays,
                               warningData.TurnaroundLeadIn, warningData.WarningOnly, warningData.Created,
                               warningData.LegacyFacilityOrigin, warningData.LegacyImported, warningData.Name, warningData.LeadInDays, warningData.CreatedUserId);
        }

        /// <summary>
        /// Converts the warning datas to entity.
        /// </summary>
        /// <param name="warningDatas">The warning datas.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertWarningDatasToEntity operation
        /// </summary>
        public static IList<IWarning> ConvertWarningDatasToEntity(IList<WarningData> warningDatas)
        {
            return warningDatas.Select(ConvertWarningDataToEntity).ToList();
        }

        #endregion ToEntity: WarningData

        #region ToEntity: ContainerMasterNoteData

        /// <summary>
        /// Converts the item notes data to entity.
        /// </summary>
        /// <param name="containerMasterNoteData">The item notes data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertContainerMasterNoteDataToEntity operation
        /// </summary>
        public static IContainerMasterNote ConvertContainerMasterNoteDataToEntity(
            ContainerMasterNoteData containerMasterNoteData)
        {
            if (containerMasterNoteData == null)
            {
                return null;
            }
            return new ContainerMasterNote(containerMasterNoteData.ContainerMasterNoteId,
                                           containerMasterNoteData.ContainerMasterNoteTypeId,
                                           containerMasterNoteData.ContainerMasterId, containerMasterNoteData.Text,
                                           containerMasterNoteData.LegacyId,
                                           containerMasterNoteData.LegacyFacilityOrigin,
                                           containerMasterNoteData.LegacyImported, containerMasterNoteData.ItemMasterId);
        }

        /// <summary>
        /// Converts the item notes datas to entity.
        /// </summary>
        /// <param name="containerMasterNoteDatas">The item notes datas.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertContainerMasterNoteDatasToEntity operation
        /// </summary>
        public static IList<IContainerMasterNote> ConvertContainerMasterNoteDatasToEntity(
            IList<ContainerMasterNoteData> containerMasterNoteDatas)
        {
            return containerMasterNoteDatas.Select(ConvertContainerMasterNoteDataToEntity).ToList();
        }

        #endregion ToEntity: ContainerMasterNoteData

        #region ToEntity: PrinterData

        /// <summary>
        /// Converts the printer data to entity.
        /// </summary>
        /// <param name="printerData">The printer data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertPrinterDataToEntity operation
        /// </summary>
        public static IPrinter ConvertPrinterDataToEntity(PrinterData printerData)
        {
            if (printerData == null)
            {
                return null;
            }
            return new Printer(printerData.PrinterId, printerData.ArchivedUserId, printerData.FacilityId,
                               printerData.PrinterTypeId, printerData.Text, printerData.Archived,
                               printerData.LegacyFacilityOrigin, printerData.LegacyImported);
        }

        /// <summary>
        /// Converts the printer datas to entity.
        /// </summary>
        /// <param name="printerDatas">The printer datas.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertPrinterDatasToEntity operation
        /// </summary>
        public static IList<IPrinter> ConvertPrinterDatasToEntity(IList<PrinterData> printerDatas)
        {
            return printerDatas.Select(ConvertPrinterDataToEntity).ToList();
        }

        #endregion ToEntity: PrinterData

        #region ToEntity: UserData

        /// <summary>
        /// Converts the user data to entity.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserDataToEntity operation
        /// </summary>
        public static IUser ConvertUserDataToEntity(UserData userData)
        {
            if (userData == null)
            {
                return null;
            }
            return new User(userData.UserId, userData.ArchivedUserId, userData.CreatedUserId, userData.UserCategoryId,
                            userData.FirstName, userData.Surname, userData.Password, userData.ExternalId,
                            userData.UserName, userData.EmailAddress, userData.Created, userData.Archived,
                            userData.IsApproved, userData.IsExpired, userData.IsLockedOut, userData.IsOnline,
                            userData.LastActivity, userData.LastLockout, userData.LastLogin, userData.LastPasswordChange,
                            userData.PasswordQuestion, userData.IndependentQualityAssuranceCheck, userData.ProviderName,
                            userData.Comment, userData.LegacyId, userData.LegacyFacilityOrigin, userData.LegacyImported,
                            userData.SystemId, userData.Position, userData.Title, userData.Telephone, userData.IsProtected, userData.CustomerGroupId,
                            userData.Pin, userData.PinAttempts, userData.LastPinChange, userData.IsPinExpired, userData.TenancyId,userData.DateTimeFormatId,userData.TimeZoneId,
                            userData.CurrentClockedInStationId, userData.CurrentClockedInLocationId, userData.CultureId, userData.EmployeeId, userData.PutAwayImmediateSubmit,
                            userData.UserPasswordHistoryId, userData.IsSoftLockedOut, userData.SoftLockOutDate, userData.PasswordAttempts, userData.UserAccountTypeId);
        }

        /// <summary>
        /// Converts the user printer data to entity.
        /// </summary>
        /// <param name="userPrinterData">The user printer data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserPrinterDataToEntity operation
        /// </summary>
        public static IUserPrinter ConvertUserPrinterDataToEntity(UserPrinterData userPrinterData)
        {
            if (userPrinterData == null)
            {
                return null;
            }
            return new UserPrinter(userPrinterData.UserPrinterId, userPrinterData.UserId, userPrinterData.PrinterId,
                                   userPrinterData.LegacyFacilityOrigin, userPrinterData.LegacyImported);
        }

        /// <summary>
        /// Converts the user printer datas to entity.
        /// </summary>
        /// <param name="userPrinterDatas">The user printer datas.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserPrinterDatasToEntity operation
        /// </summary>
        public static IList<IUserPrinter> ConvertUserPrinterDatasToEntity(IList<UserPrinterData> userPrinterDatas)
        {
            return userPrinterDatas.Select(ConvertUserPrinterDataToEntity).ToList();
        }

        /// <summary>
        /// Converts the user facility data to entity.
        /// </summary>
        /// <param name="userFacilityData">The user facility data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserFacilityDataToEntity operation
        /// </summary>
        public static IUserFacility ConvertUserFacilityDataToEntity(UserFacilityData userFacilityData)
        {
            if (userFacilityData == null)
            {
                return null;
            }
            return new UserFacility(userFacilityData.UserFacilityId, userFacilityData.FacilityId,
                                    userFacilityData.UserId, userFacilityData.Selected, userFacilityData.Primary,
                                    userFacilityData.LegacyFacilityOrigin, userFacilityData.LegacyImported);
        }

        /// <summary>
        /// Converts the user facility datas to entity.
        /// </summary>
        /// <param name="userFacilityDatas">The user facility datas.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserFacilityDatasToEntity operation
        /// </summary>
        public static IList<IUserFacility> ConvertUserFacilityDatasToEntity(IList<UserFacilityData> userFacilityDatas)
        {
            return userFacilityDatas.Select(ConvertUserFacilityDataToEntity).ToList();
        }

        /// <summary>
        /// Converts the user item complexitys data to entity.
        /// </summary>
        /// <param name="userComplexityData">The user item complexity data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserComplexityDataToEntity operation
        /// </summary>
        public static IUserComplexity ConvertUserComplexityDataToEntity(UserComplexityData userComplexityData)
        {
            if (userComplexityData == null)
            {
                return null;
            }
            return new UserComplexity(userComplexityData.UserComplexitySpeciailityId, userComplexityData.UserId,
                                      userComplexityData.SpecialityId, userComplexityData.ComplexityId,
                                      userComplexityData.LegacyFacilityOrigin, userComplexityData.LegacyImported);
        }

        /// <summary>
        /// Converts the user item complexity datas to entity.
        /// </summary>
        /// <param name="userComplexityData">The user item complexity datas.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserComplexityDatasToEntity operation
        /// </summary>
        public static IList<IUserComplexity> ConvertUserComplexityDatasToEntity(
            IList<UserComplexityData> userComplexityData)
        {
            return userComplexityData.Select(ConvertUserComplexityDataToEntity).ToList();
        }

        #endregion ToEntity: UserData

        #region ToEntity: RoleData

        /// <summary>
        /// Converts the role data to entity.
        /// </summary>
        /// <param name="roleData">The role data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertRoleDataToEntity operation
        /// </summary>
        public static IRole ConvertRoleDataToEntity(RoleData roleData)
        {
            if (roleData == null)
            {
                return null;
            }
            return new Role(roleData.RoleId, roleData.ArchivedUserId, roleData.Text, roleData.Archived,
                            roleData.LegacyFacilityOrigin, roleData.LegacyImported);
        }

        /// <summary>
        /// Converts the role permissions data to entity.
        /// </summary>
        /// <param name="RolePermissionData">The role permissions data.</param>
        /// <returns></returns>
        /// <remarks></remarks>

        /// <summary>
        /// Converts the role permissions datas to entity.
        /// </summary>
        /// <param name="RolePermissionDatas">The role permissions datas.</param>
        /// <returns></returns>
        /// <remarks></remarks>

        #endregion ToEntity: RoleData

        #region ToEntity: LocationItemCostData

        ///// <summary>
        ///// Converts the location item cost to entity.
        ///// </summary>
        ///// <param name="locationItemCostData">The location item cost data.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>

        ///// <summary>
        ///// Converts the location item costs to entity.
        ///// </summary>
        ///// <param name="locationItemCostDatas">The location item cost datas.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>

        #endregion ToEntity: LocationItemCostData

        #region ToEntity:ItemType

        /// <summary>
        /// Converts the item type to entity.
        /// </summary>
        /// <param name="itemTypeData">The item type data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertItemTypeToEntity operation
        /// </summary>
        public static IItemType ConvertItemTypeToEntity(ItemTypeData itemTypeData)
        {
            if (itemTypeData == null)
            {
                return null;
            }
            return new ItemType(itemTypeData.ItemTypeId, itemTypeData.ArchivedUserId, itemTypeData.LabelTypeId,
                                itemTypeData.ParentItemTypeId, itemTypeData.Text, itemTypeData.Archived,
                                itemTypeData.ItemTypeFeatures, itemTypeData.Trackable, itemTypeData.OwnWorkflow,
                                itemTypeData.AllowFinancialSetup, itemTypeData.LegacyId,
                                itemTypeData.LegacyFacilityOrigin, itemTypeData.LegacyImported,
                                itemTypeData.IsNonSterileProduct, itemTypeData.IsComponent);
        }

        /// <summary>
        /// Converts the item types to entity.
        /// </summary>
        /// <param name="itemTypeDatas">The item type datas.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertItemTypesToEntity operation
        /// </summary>
        public static IList<IItemType> ConvertItemTypesToEntity(IList<ItemTypeData> itemTypeDatas)
        {
            return itemTypeDatas.Select(ConvertItemTypeToEntity).ToList();
        }

        #endregion

        #region ToEntity:FacilityItemType

        /// <summary>
        /// Converts the facility item type to entity.
        /// </summary>
        /// <param name="facilityItemTypeData">The facility item type data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertFacilityItemTypeToEntity operation
        /// </summary>
        public static IFacilityItemType ConvertFacilityItemTypeToEntity(FacilityItemTypeData facilityItemTypeData)
        {
            if (facilityItemTypeData == null)
            {
                return null;
            }
            return new FacilityItemType(facilityItemTypeData.FacilityItemTypeId, facilityItemTypeData.FacilityId,
                                        facilityItemTypeData.ItemTypeId, facilityItemTypeData.LegacyFacilityOrigin,
                                        facilityItemTypeData.LegacyImported);
        }

        /// <summary>
        /// Converts the facility item types to entity.
        /// </summary>
        /// <param name="facilityItemTypeDatas">The facility item type datas.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertFacilityItemTypesToEntity operation
        /// </summary>
        public static IList<IFacilityItemType> ConvertFacilityItemTypesToEntity(
            IList<FacilityItemTypeData> facilityItemTypeDatas)
        {
            return facilityItemTypeDatas.Select(ConvertFacilityItemTypeToEntity).ToList();
        }

        #endregion

        #region ToEntity:FacilityNextEventText

        /// <summary>
        /// Converts the facility next event text data to entity.
        /// </summary>
        /// <param name="facilityNextEventTextData">The facility next event text data.</param>
        /// <returns></returns>
        /// <remarks></remarks>

        ///// <summary>
        ///// Converts the facility next event text datas to entity.
        ///// </summary>
        ///// <param name="facilityNextEventTextDatas">The facility next event text datas.</param>
        ///// <returns></returns>
        ///// <remarks></remarks>

        #endregion

        #region ToEntity:User

        /// <summary>
        /// Converts the user data to enty.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserDataToEnty operation
        /// </summary>
        public static IUser ConvertUserDataToEnty(UserData userData)
        {
            return userData == null
                       ? null
                       : new User(userData.UserId, userData.ArchivedUserId, userData.CreatedUserId,
                                  userData.UserCategoryId, userData.FirstName, userData.Surname, userData.Password,
                                  userData.ExternalId, userData.UserName, userData.EmailAddress, userData.Created,
                                  userData.Archived, userData.IsApproved, userData.IsExpired, userData.IsLockedOut,
                                  userData.IsOnline, userData.LastActivity, userData.LastLockout, userData.LastLogin,
                                  userData.LastPasswordChange, userData.PasswordQuestion,
                                  userData.IndependentQualityAssuranceCheck, userData.ProviderName, userData.Comment,
                                  userData.LegacyId, userData.LegacyFacilityOrigin, userData.LegacyImported, userData.SystemId, userData.Position, userData.Title, userData.Telephone, userData.IsProtected, userData.CustomerGroupId,
                                  userData.Pin, userData.PinAttempts, userData.LastPinChange, userData.IsPinExpired, userData.TenancyId, userData.DateTimeFormatId, userData.TimeZoneId,
                                  userData.CurrentClockedInStationId,userData.CurrentClockedInLocationId, userData.CultureId, userData.EmployeeId, userData.PutAwayImmediateSubmit,
                                  userData.UserPasswordHistoryId, userData.IsSoftLockedOut, userData.SoftLockOutDate, userData.PasswordAttempts, userData.UserAccountTypeId);
        }

        /// <summary>
        /// Converts the user datas to entity.
        /// </summary>
        /// <param name="userDatas">The user datas.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserDatasToEntity operation
        /// </summary>
        public static IList<IUser> ConvertUserDatasToEntity(IList<UserData> userDatas)
        {
            return userDatas.Select(ConvertUserDataToEnty).ToList();
        }

        #endregion

        #region ToEntity:ChangeControlNote

        /// <summary>
        /// Converts the change controlnote to entity.
        /// </summary>
        /// <param name="changeControlNoteData">The change controlnote data.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertChangeControlNoteToEntity operation
        /// </summary>
        public static IChangeControlNote ConvertChangeControlNoteToEntity(ChangeControlNoteData changeControlNoteData)
        {
            return changeControlNoteData == null
                       ? null
                       : new ChangeControlNote(changeControlNoteData.ChangeControlNoteId,
                                               changeControlNoteData.CreatedUserId,
                                               changeControlNoteData.ExternalId,
                                               changeControlNoteData.ItemExternalId,
                                               changeControlNoteData.ItemName,
                                               changeControlNoteData.HasSpecificationSheet,
                                               changeControlNoteData.HasInstructions,
                                               changeControlNoteData.Request,
                                               changeControlNoteData.Reason,
                                               changeControlNoteData.EstimatedUsage,
                                               changeControlNoteData.RequestedBy,
                                               changeControlNoteData.Created,
                                               changeControlNoteData.RequestAction,
                                               changeControlNoteData.CustomerDefinitionId
                                               );
        }
        #endregion
    }
}
