using SynergyApplicationFrameworkApi.Application.DTOs.Interfaces.Operative;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class LazyFinanceHelper
    {
        #region ToContract:Customer

        /// <summary>
        /// ConvertCustomerToContract operation
        /// </summary>
        public static CustomerData ConvertCustomerToContract(ICustomer customer)
        {
            return customer == null ? null : new CustomerData(customer);
        }

        /// <summary>
        /// ConvertCustomersToContract operation
        /// </summary>
        public static IList<CustomerData> ConvertCustomersToContract(IList<ICustomer> customers)
        {
            if (customers == null)
            {
                return null;
            }
            return customers.Select(ConvertCustomerToContract).ToList();
        }

        #endregion

        #region ToContract:Location

        #endregion

        #region ToContract:Address

        /// <summary>
        /// ConvertAddressToContract operation
        /// </summary>
        public static AddressData ConvertAddressToContract(IAddress address)
        {
            return new AddressData(address);
        }

        #endregion

        #region ToContract:Facility

        /// <summary>
        /// ConvertFacilityToContract operation
        /// </summary>
        public static FacilityData ConvertFacilityToContract(IFacility facility)
        {
            return new FacilityData(facility);
        }

        #endregion

        #region ToContgract:CustomerGroup

        /// <summary>
        /// ConvertCustomerGroupToContract operation
        /// </summary>
        public static CustomerGroupData ConvertCustomerGroupToContract(ICustomerGroup customerGroup)
        {
            return new CustomerGroupData(customerGroup);
        }

        #endregion

        #region ToContract:LocationWorkingHour

        #endregion

        #region ToContract:ContractedHours

        /// <summary>
        /// ConvertContractedHoursToContract operation
        /// </summary>
        public static ContractedHoursData ConvertContractedHoursToContract(IContractedHours locationWorkingHour)
        {
            return new ContractedHoursData(locationWorkingHour);
        }

        /// <summary>
        /// ConvertContractedHoursToContract operation
        /// </summary>
        public static IList<ContractedHoursData> ConvertContractedHoursToContract(IList<IContractedHours> locationWorkingHours)
        {
            return locationWorkingHours.Select(ConvertContractedHoursToContract).ToList();
        }

        #endregion

        #region ToContract:CustomerBarcodeReprintCost

        #endregion

        #region ToContract:ServiceRequirement

        /// <summary>
        /// ConvertServiceRequirementToContract operation
        /// </summary>
        public static ServiceRequirementData ConvertServiceRequirementToContract(IServiceRequirement serviceRequirement)
        {
            var its = ((ServiceRequirement)serviceRequirement).ItemTypes;
            var itsArray = new short[its.Count];
            int index = 0;
            foreach (var i in its)
            {
                itsArray[index] = i.ItemTypeId;
                index++;
            }

            var requirement = serviceRequirement as ServiceRequirement;

            var serviceRequirementData = new ServiceRequirementData(serviceRequirement);

            if (requirement != null && requirement.ItemTypes != null)
            {
                serviceRequirementData.ItemTypeList = ConvertItemTypesToContract(requirement.ItemTypes.ToList()).ToList();
            }

            return serviceRequirementData;
        }

        /// <summary>
        /// ConvertServiceRequirementsToContract operation
        /// </summary>
        public static IList<ServiceRequirementData> ConvertServiceRequirementsToContract(
            IList<IServiceRequirement> serviceRequirements)
        {
            return serviceRequirements.Select(ConvertServiceRequirementToContract).ToList();
        }

        #endregion

        #region ToContract:ExpiryCalculationType

        /// <summary>
        /// ConvertExpiryCalculationTypeToContract operation
        /// </summary>
        public static ExpiryCalculationTypeData ConvertExpiryCalculationTypeToContract(IExpiryCalculationType expiryCalculationType)
        {
            return new ExpiryCalculationTypeData(expiryCalculationType);
        }

        /// <summary>
        /// ConvertExpiryCalculationTypeListToContract operation
        /// </summary>
        public static IList<ExpiryCalculationTypeData> ConvertExpiryCalculationTypeListToContract(IList<ExpiryCalculationType> expiryCalculationTypes)
        {
            return expiryCalculationTypes.Select(ConvertExpiryCalculationTypeToContract).ToList();
        }

        #endregion

        #region ToContract:CustomerCharge

        #endregion

        #region ToContract:ItemMaster

        /// <summary>
        /// ConvertItemMasterToContract operation
        /// </summary>
        public static ItemMasterData ConvertItemMasterToContract(IItemMaster itemMaster)
        {
            return new ItemMasterData(itemMaster);
        }

        /// <summary>
        /// ConvertItemMastersToContract operation
        /// </summary>
        public static IList<ItemMasterData> ConvertItemMastersToContract(IList<IItemMaster> itemMasters)
        {
            return itemMasters.Select(ConvertItemMasterToContract).ToList();
        }

        #endregion

        #region ToContract:ContainerMaster

        /// <summary>
        /// ConvertContainerMasterToContract operation
        /// </summary>
        public static ContainerMasterData ConvertContainerMasterToContract(IContainerMaster containerMaster)
        {
            return new ContainerMasterData(containerMaster);
        }

        /// <summary>
        /// ConvertContainerMastersToContract operation
        /// </summary>
        public static IList<ContainerMasterData> ConvertContainerMastersToContract(
            IList<IContainerMaster> containerMasters)
        {
            return containerMasters.Select(ConvertContainerMasterToContract).ToList();
        }

        #endregion

        #region ToContract:ItemInstance

        /// <summary>
        /// ConvertItemInstanceToContract operation
        /// </summary>
        public static ItemInstanceData ConvertItemInstanceToContract(IItemInstance itemInstance)
        {
            return new ItemInstanceData(itemInstance);
        }

        /// <summary>
        /// ConvertItemInsancesToContract operation
        /// </summary>
        public static IList<ItemInstanceData> ConvertItemInsancesToContract(IList<IItemInstance> itemInstances)
        {
            return itemInstances.Select(ConvertItemInstanceToContract).ToList();
        }

        #endregion

        #region ToContract:ItemType
        /// <summary>
        /// ConvertItemTypeToContract operation
        /// </summary>
        public static ItemTypeData ConvertItemTypeToContract(IItemType itemType)
        {
            return new ItemTypeData(itemType);
        }

        /// <summary>
        /// ConvertItemTypesToContract operation
        /// </summary>
        public static IList<ItemTypeData> ConvertItemTypesToContract(IList<IItemType> itemTypes)
        {
            return itemTypes.Select(ConvertItemTypeToContract).ToList();
        }

        /// <summary>
        /// ConvertItemTypesToContract operation
        /// </summary>
        public static IList<ItemTypeData> ConvertItemTypesToContract(IList<ItemType> itemTypes)
        {
            return itemTypes.Select(i => ConvertItemTypeToContract(i as IItemType)).ToList();
        }

        #endregion

        #region ToContract:ContainerInstance

        /// <summary>
        /// ConvertContainerInstanceToContract operation
        /// </summary>
        public static ContainerInstanceData ConvertContainerInstanceToContract(ContainerInstance containerInstance)
        {
            return new ContainerInstanceData(containerInstance) { PrimaryId = containerInstance.PrimaryId };
        }

        /// <summary>
        /// ConvertContainerInstancesToContract operation
        /// </summary>
        public static IList<ContainerInstanceData> ConvertContainerInstancesToContract(IList<ContainerInstance> containerInstances)
        {
            return containerInstances.Select(ConvertContainerInstanceToContract).ToList();
        }

        #endregion

        #region ToContract:DeliveryPoint

        /// <summary>
        /// ConvertDeliveryPointToContract operation
        /// </summary>
        public static DeliveryPointData ConvertDeliveryPointToContract(IDeliveryPoint deliveryPoint)
        {
            return new DeliveryPointData(deliveryPoint);
        }

        /// <summary>
        /// ConvertDeliveryPointsToContract operation
        /// </summary>
        public static IList<DeliveryPointData> ConvertDeliveryPointsToContract(IList<IDeliveryPoint> deliveryPoints)
        {
            return deliveryPoints.Select(ConvertDeliveryPointToContract).ToList();
        }

        #endregion

        #region ToContract:LabourBand

        /// <summary>
        /// ConvertLabourBandToContract operation
        /// </summary>
        public static LabourBandData ConvertLabourBandToContract(ILabourBand labourBand)
        {
            return new LabourBandData(labourBand);
        }

        /// <summary>
        /// ConvertLabourBandsToContract operation
        /// </summary>
        public static IList<LabourBandData> ConvertLabourBandsToContract(IList<ILabourBand> labourBands)
        {
            return labourBands.Select(ConvertLabourBandToContract).ToList();
        }

        #endregion

        #region ToContract: CustomerTrayChangeCost

        #endregion

        #region ToContract:CustomerPriceRise

        #endregion

        #region ToContract:Directorate

        /// <summary>
        /// ConvertDirectorateToContract operation
        /// </summary>
        public static DirectorateData ConvertDirectorateToContract(IDirectorate directorate)
        {
            return new DirectorateData(directorate);
        }

        /// <summary>
        /// ConvertDirectorateListToContract operation
        /// </summary>
        public static IList<DirectorateData> ConvertDirectorateListToContract(IList<Directorate> directorates)
        {
            return directorates.Select(ConvertDirectorateToContract).ToList();
        }

        #endregion

        #region ToContract:CostingModelType

        /// <summary>
        /// ConvertCostingModelTypeToContract operation
        /// </summary>
        public static CostingModelTypeData ConvertCostingModelTypeToContract(ICostingModelType costingModelType)
        {
            return new CostingModelTypeData(costingModelType);
        }

        /// <summary>
        /// ConvertCostingModelTypeListToContract operation
        /// </summary>
        public static IList<CostingModelTypeData> ConvertCostingModelTypeListToContract(IList<CostingModelType> costingModelTypes)
        {
            return costingModelTypes.Select(ConvertCostingModelTypeToContract).ToList();
        }

        #endregion

        #region ToContract:CostingModel

        /// <summary>
        /// ConvertCostingModelToContract operation
        /// </summary>
        public static CostingModelData ConvertCostingModelToContract(ICostingModel costingModel)
        {
            return new CostingModelData(costingModel);
        }

        /// <summary>
        /// ConvertCostingModelListToContract operation
        /// </summary>
        public static IList<CostingModelData> ConvertCostingModelListToContract(IList<ICostingModel> costingModels)
        {
            return costingModels.Select(ConvertCostingModelToContract).ToList();
        }

        #endregion

        #region ToContract:ChargeList

        /// <summary>
        /// ConvertChargeListToContract operation
        /// </summary>
        public static ChargeListData ConvertChargeListToContract(IChargeList chargeList)
        {
            return new ChargeListData(chargeList);
        }

        /// <summary>
        /// ConvertChargeListListToContract operation
        /// </summary>
        public static IList<ChargeListData> ConvertChargeListListToContract(IList<IChargeList> chargeLists)
        {
            return chargeLists.Select(ConvertChargeListToContract).ToList();
        }

        #endregion

        #region ToContract:ChargeListSummary

        /// <summary>
        /// ConvertChargeListSummaryToContract operation
        /// </summary>
        public static ChargeListSummaryData ConvertChargeListSummaryToContract(IChargeListSummary chargeListSummary)
        {
            return new ChargeListSummaryData(chargeListSummary);
        }

        /// <summary>
        /// ConvertChargeListSummaryListToContract operation
        /// </summary>
        public static IList<ChargeListSummaryData> ConvertChargeListSummaryListToContract(IList<IChargeListSummary> chargeListSummarys)
        {
            return chargeListSummarys.Select(ConvertChargeListSummaryToContract).ToList();
        }

        #endregion

        #region ToContract:CustomerIndexationSummary

        /// <summary>
        /// ConvertCustomerIndexationSummaryToContract operation
        /// </summary>
        public static CustomerIndexationSummaryData ConvertCustomerIndexationSummaryToContract(ICustomerIndexationSummary customerIndexationSummary)
        {
            return new CustomerIndexationSummaryData(customerIndexationSummary);
        }

        /// <summary>
        /// ConvertCustomerIndexationSummaryListToContract operation
        /// </summary>
        public static IList<CustomerIndexationSummaryData> ConvertCustomerIndexationSummaryListToContract(IList<ICustomerIndexationSummary> customerIndexationSummarys)
        {
            return customerIndexationSummarys.Select(ConvertCustomerIndexationSummaryToContract).ToList();
        }

        #endregion

        #region ToContract:CustomerIndexationDetailSummary

        /// <summary>
        /// ConvertCustomerIndexationDetailSummaryToContract operation
        /// </summary>
        public static CustomerIndexationDetailSummaryData ConvertCustomerIndexationDetailSummaryToContract(ICustomerIndexationDetailSummary customerIndexationDetailSummary)
        {
            return new CustomerIndexationDetailSummaryData(customerIndexationDetailSummary);
        }

        /// <summary>
        /// ConvertCustomerIndexationDetailSummaryListToContract operation
        /// </summary>
        public static IList<CustomerIndexationDetailSummaryData> ConvertCustomerIndexationDetailSummaryListToContract(IList<ICustomerIndexationDetailSummary> customerIndexationDetailSummarys)
        {
            return customerIndexationDetailSummarys.Select(ConvertCustomerIndexationDetailSummaryToContract).ToList();
        }

        #endregion

        #region ToContract:SingleUseItemSummary

        /// <summary>
        /// ConvertSingleUseItemSummaryToContract operation
        /// </summary>
        public static SingleUseItemSummaryData ConvertSingleUseItemSummaryToContract(ISingleUseItemSummary singleUseItemSummary)
        {
            return new SingleUseItemSummaryData(singleUseItemSummary);
        }

        /// <summary>
        /// ConvertSingleUseItemSummaryListToContract operation
        /// </summary>
        public static IList<SingleUseItemSummaryData> ConvertSingleUseItemSummaryListToContract(IList<ISingleUseItemSummary> singleUseItemSummarys)
        {
            return singleUseItemSummarys.Select(ConvertSingleUseItemSummaryToContract).ToList();
        }

        #endregion

        #region ToContract:SingleUseItemByContainerMasterSummary

        /// <summary>
        /// ConvertSingleUseItemByContainerMasterSummaryToContract operation
        /// </summary>
        public static SingleUseItemByContainerMasterSummaryData ConvertSingleUseItemByContainerMasterSummaryToContract(ISingleUseItemByContainerMasterSummary singleUseItemByContainerMasterSummary)
        {
            return new SingleUseItemByContainerMasterSummaryData(singleUseItemByContainerMasterSummary);
        }

        /// <summary>
        /// ConvertSingleUseItemByContainerMasterSummaryListToContract operation
        /// </summary>
        public static IList<SingleUseItemByContainerMasterSummaryData> ConvertSingleUseItemByContainerMasterSummaryListToContract(IList<ISingleUseItemByContainerMasterSummary> singleUseItemByContainerMasterSummarys)
        {
            return singleUseItemByContainerMasterSummarys.Select(ConvertSingleUseItemByContainerMasterSummaryToContract).ToList();
        }

        #endregion

        #region ToContract:CustomerItemsSummary

        /// <summary>
        /// ConvertCustomerItemsSummaryToContract operation
        /// </summary>
        public static CustomerItemsSummaryData ConvertCustomerItemsSummaryToContract(ICustomerItemsSummary customerItemsSummary)
        {
            return new CustomerItemsSummaryData(customerItemsSummary);
        }

        /// <summary>
        /// ConvertCustomerItemsSummaryListToContract operation
        /// </summary>
        public static IList<CustomerItemsSummaryData> ConvertCustomerItemsSummaryListToContract(IList<ICustomerItemsSummary> customerItemsSummarys)
        {
            return customerItemsSummarys.Select(ConvertCustomerItemsSummaryToContract).ToList();
        }

        #endregion

        #region ToContract:ContainerMasterPriceAdjustment

        /// <summary>
        /// ConvertContainerMasterPriceAdjustmentToContract operation
        /// </summary>
        public static ContainerMasterPriceAdjustmentData ConvertContainerMasterPriceAdjustmentToContract(IContainerMasterPriceAdjustment containerMasterPriceAdjustment)
        {
            return new ContainerMasterPriceAdjustmentData(containerMasterPriceAdjustment);
        }

        /// <summary>
        /// ConvertContainerMasterPriceAdjustmentListToContract operation
        /// </summary>
        public static IList<ContainerMasterPriceAdjustmentData> ConvertContainerMasterPriceAdjustmentListToContract(IList<IContainerMasterPriceAdjustment> containerMasterPriceAdjustments)
        {
            return containerMasterPriceAdjustments.Select(ConvertContainerMasterPriceAdjustmentToContract).ToList();
        }

        #endregion

        #region ToContract:ContainerMasterPriceAdjustmentType

        /// <summary>
        /// ConvertContainerMasterPriceAdjustmentTypeToContract operation
        /// </summary>
        public static ContainerMasterPriceAdjustmentTypeData ConvertContainerMasterPriceAdjustmentTypeToContract(IContainerMasterPriceAdjustmentType containerMasterPriceAdjustmentType)
        {
            return new ContainerMasterPriceAdjustmentTypeData(containerMasterPriceAdjustmentType);
        }

        /// <summary>
        /// ConvertContainerMasterPriceAdjustmentTypeListToContract operation
        /// </summary>
        public static IList<ContainerMasterPriceAdjustmentTypeData> ConvertContainerMasterPriceAdjustmentTypeListToContract(IList<ContainerMasterPriceAdjustmentType> containerMasterPriceAdjustmentTypes)
        {
            return containerMasterPriceAdjustmentTypes.Select(ConvertContainerMasterPriceAdjustmentTypeToContract).ToList();
        }

        #endregion

        #region ToContract:ChargeListCategory

        /// <summary>
        /// ConvertChargeListCategoryToContract operation
        /// </summary>
        public static ChargeListCategoryData ConvertChargeListCategoryToContract(IChargeListCategory chargeListCategory)
        {
            return new ChargeListCategoryData(chargeListCategory);
        }

        /// <summary>
        /// ConvertChargeListCategoryListToContract operation
        /// </summary>
        public static IList<ChargeListCategoryData> ConvertChargeListCategoryListToContract(IList<ChargeListCategory> chargeListCategorys)
        {
            return chargeListCategorys.Select(ConvertChargeListCategoryToContract).ToList();
        }

        #endregion

        #region ToContract:PriceCategoryGroup

        /// <summary>
        /// ConvertPriceCategoryGroupsToContract operation
        /// </summary>
        public static PriceCategoryGroupData ConvertPriceCategoryGroupsToContract(IPriceCategoryGroup priceCategoryGroup)
        {
            var priceCategory = priceCategoryGroup as PriceCategoryGroup;

            var priceCategoryGroupData = new PriceCategoryGroupData(priceCategoryGroup);

            if (priceCategory != null && priceCategory.PriceCategoryGroupItemType != null)
            {
                priceCategoryGroupData.ItemTypes = ConvertItemTypesToContract(priceCategory.PriceCategoryGroupItemType.Select(i => i.ItemType).ToList()).ToList();
            }

            return priceCategoryGroupData;
        }

        /// <summary>
        /// ConvertPriceCategoryGroupsListToContract operation
        /// </summary>
        public static IList<PriceCategoryGroupData> ConvertPriceCategoryGroupsListToContract(IList<IPriceCategoryGroup> priceCategoryGroups)
        {
            return priceCategoryGroups.Select(ConvertPriceCategoryGroupsToContract).ToList();
        }

        #endregion

        #region ToContract:PriceCategoryGroupItemType

        /// <summary>
        /// ConvertPriceCategoryGroupItemTypeToContract operation
        /// </summary>
        public static PriceCategoryGroupItemTypeData ConvertPriceCategoryGroupItemTypeToContract(PriceCategoryGroupItemType priceCategoryGroupItemType)
        {
            return new PriceCategoryGroupItemTypeData(priceCategoryGroupItemType);
        }

        /// <summary>
        /// ConvertPriceCategoryGroupItemTypeListToContract operation
        /// </summary>
        public static IList<PriceCategoryGroupItemTypeData> ConvertPriceCategoryGroupItemTypeListToContract(IList<PriceCategoryGroupItemType> priceCategoryGroupItemTypes)
        {
            return priceCategoryGroupItemTypes.Select(ConvertPriceCategoryGroupItemTypeToContract).ToList();
        }

        #endregion

        #region ToContract:PriceCategory

        /// <summary>
        /// ConvertPriceCategoryToContract operation
        /// </summary>
        public static PriceCategoryData ConvertPriceCategoryToContract(IPriceCategory priceCategory)
        {
            var category = priceCategory as PriceCategory;

            var priceCategoryData = new PriceCategoryData(priceCategory);

            if (category != null)
            {
                if (category.PriceCategoryBatchCycle != null)
                {
                    priceCategoryData.PriceCategoryBatchCycleList = ConvertPriceCategoryBatchCycleListToContract(category.PriceCategoryBatchCycle.Where(x=>x.BatchCycle.IsChargeable).ToList()).ToList();
                }

                priceCategoryData.PriceCategoryGroupId = category.PriceCategoryDefinition.PriceCategoryGroupId;
            }

            return priceCategoryData;
        }

        /// <summary>
        /// ConvertPriceCategoryListToContract operation
        /// </summary>
        public static IList<PriceCategoryData> ConvertPriceCategoryListToContract(IList<IPriceCategory> priceCategorys)
        {
            return priceCategorys.Select(ConvertPriceCategoryToContract).ToList();
        }

        #endregion

        #region ToContract:PriceCategoryBatchCycle

        /// <summary>
        /// ConvertPriceCategoryBatchCycleToContract operation
        /// </summary>
        public static PriceCategoryBatchCycleData ConvertPriceCategoryBatchCycleToContract(PriceCategoryBatchCycle priceCategoryBatchCycle)
        {
            return new PriceCategoryBatchCycleData(
                priceCategoryBatchCycle.PriceCategoryBatchCycleId, 
                priceCategoryBatchCycle.BatchCycleId, 
                priceCategoryBatchCycle.BatchCycle.Text, 
                priceCategoryBatchCycle.PriceCategoryId, 
                priceCategoryBatchCycle.Charge, 
                priceCategoryBatchCycle.LegacyId, 
                priceCategoryBatchCycle.LegacyFacilityOrigin,
                priceCategoryBatchCycle.LegacyImported
            );
        }

        /// <summary>
        /// ConvertPriceCategoryBatchCycleListToContract operation
        /// </summary>
        public static IList<PriceCategoryBatchCycleData> ConvertPriceCategoryBatchCycleListToContract(IList<PriceCategoryBatchCycle> priceCategoryBatchCycles)
        {
            return priceCategoryBatchCycles.Select(ConvertPriceCategoryBatchCycleToContract).ToList();
        }

        #endregion

        #region ToContract:Indexation

        /// <summary>
        /// ConvertIndexationToContract operation
        /// </summary>
        public static IndexationData ConvertIndexationToContract(IIndexation indexation)
        {
            var index = indexation as Indexation;

            var indexationData = new IndexationData(indexation);

            indexationData.TypeName = index.IndexationType != null ? index.IndexationType.Text : "";

            return indexationData;
        }

        /// <summary>
        /// ConvertIndexationListToContract operation
        /// </summary>
        public static IList<IndexationData> ConvertIndexationListToContract(IList<IIndexation> indexations)
        {
            return indexations.Select(ConvertIndexationToContract).ToList();
        }

        #endregion

        #region ToContract:Invoice

        /// <summary>
        /// ConvertInvoiceToContract operation
        /// </summary>
        public static InvoiceData ConvertInvoiceToContract(IInvoice invoice)
        {
            var invoiceref = invoice as Invoice;

            var invoiceData = new InvoiceData(invoice);
            invoiceData.Name = invoiceref.Name;
            invoiceData.InvoiceId = invoiceref.InvoiceId;
            invoiceData.InvoiceStatus = invoiceref.InvoiceStatus;
            invoiceData.FacilityName = invoiceref.FacilityName;
            invoiceData.Value = invoiceref.Value;
            invoiceData.InvoiceStatusId = invoiceref.InvoiceStatusId;
            invoiceData.From = invoiceref.From;
            invoiceData.To = invoiceref.To;
            invoiceData.ExternalId = invoiceref.ExternalId;
            invoiceData.DebtorId = invoiceref.DebtorId;
            invoiceData.CustomerId = invoiceref.CustomerId;

            return invoiceData;
        }

        /// <summary>
        /// ConvertInvoiceSummaryToContract operation
        /// </summary>
        public static InvoiceSummaryData ConvertInvoiceSummaryToContract(IInvoiceSummary invoiceSummary)
        {
            return new InvoiceSummaryData(invoiceSummary.CurrentCustomerInvoiceCount, invoiceSummary.CurrentCustomerGroupInvoiceCount, invoiceSummary.CurrentDirectorateInvoiceCount
            );
        }

        /// <summary>
        /// ConvertInvoiceListToContract operation
        /// </summary>
        public static IList<InvoiceData> ConvertInvoiceListToContract(IList<IInvoice> invoices)
        {
            return invoices.Select(ConvertInvoiceToContract).ToList();
        }

        /// <summary>
        /// ConvertInvoiceStatusToContract operation
        /// </summary>
        public static InvoiceStatusData ConvertInvoiceStatusToContract(IInvoiceStatus invoiceStatus)
        {
            return new InvoiceStatusData(invoiceStatus);
        }

        /// <summary>
        /// ConvertInvoiceStatusListToContact operation
        /// </summary>
        public static IList<InvoiceStatusData> ConvertInvoiceStatusListToContact(IList<InvoiceStatus> invoiceStatusList)
        {
            return invoiceStatusList.Select(ConvertInvoiceStatusToContract).ToList();
        }

        /// <summary>
        /// ConvertInvoicePeriodToContract operation
        /// </summary>
        public static InvoicePeriodData ConvertInvoicePeriodToContract(IInvoicePeriod invoicePeriod)
        {
            return new InvoicePeriodData(invoicePeriod);
        }

        /// <summary>
        /// ConvertInvoicePeriodListToContact operation
        /// </summary>
        public static IList<InvoicePeriodData> ConvertInvoicePeriodListToContact(IList<InvoicePeriod> invoicePeriodList)
        {
            return invoicePeriodList.Select(ConvertInvoicePeriodToContract).ToList();
        }

        #endregion

        #region ToContract:IndexationType

        /// <summary>
        /// ConvertIndexationTypeToContract operation
        /// </summary>
        public static IndexationTypeData ConvertIndexationTypeToContract(IIndexationType indexationType)
        {
            return new IndexationTypeData(indexationType);
        }

        /// <summary>
        /// ConvertIndexationTypeListToContract operation
        /// </summary>
        public static IList<IndexationTypeData> ConvertIndexationTypeListToContract(IList<IndexationType> indexationTypes)
        {
            return indexationTypes.Select(ConvertIndexationTypeToContract).ToList();
        }

        #endregion

        #region ToContract:CustomerCostingModel

        #endregion

        #region ToContractUser

        /// <summary>
        /// ConvertRoleToContract operation
        /// </summary>
        public static RoleData ConvertRoleToContract(IRole role)
        {
            return new RoleData(role);
        }

        /// <summary>
        /// ConvertRolesToContract operation
        /// </summary>
        public static IList<RoleData> ConvertRolesToContract(IList<IRole> roles)
        {
            return roles.Select(ConvertRoleToContract).ToList();
        }

        /// <summary>
        /// ConvertUserToContract operation
        /// </summary>
        public static UserData ConvertUserToContract(IUser user)
        {
            return new UserData(user);
        }

        /// <summary>
        /// ConvertUserRoleDataToContract operation
        /// </summary>
        public static UserRoleData ConvertUserRoleDataToContract(IUserRole userRole)
        {
            return new UserRoleData(userRole);
        }

        /// <summary>
        /// ConvertRolePermissionDataToContract operation
        /// </summary>
        public static RolePermissionData ConvertRolePermissionDataToContract(IRolePermission rolePermission)
        {
            return new RolePermissionData(rolePermission) { Text = ((Pathway.Data.Models.Operative.RolePermission)(rolePermission)).Permission.Text };
        }

        /// <summary>
        /// ConvertRolePermissionsDataToContract operation
        /// </summary>
        public static IList<RolePermissionData> ConvertRolePermissionsDataToContract(IList<IRolePermission> rolePermissions)
        {
            return rolePermissions.Select(ConvertRolePermissionDataToContract).ToList();
        }

        /// <summary>
        /// ConvertUserRolesDataToContract operation
        /// </summary>
        public static IList<UserRoleData> ConvertUserRolesDataToContract(IList<IUserRole> userRoles)
        {
            return userRoles.Select(ConvertUserRoleDataToContract).ToList();
        }

        #endregion

        #region ToEntity:CustomerData

        /// <summary>
        /// ConvertCustomerDataToEntity operation
        /// </summary>
        public static ICustomer ConvertCustomerDataToEntity(IUnitOfWork unitOfWork, CustomerData customerData)
        {
            if (customerData == null)
            {
                return null;
            }
            return CustomerFactory.CreateEntity(unitOfWork,
                                customerData.CustomerId,
                                customerData.AddressId,
                                customerData.CreatedUserId,
                                customerData.CustomerDefinitionId,
                                customerData.CustomerGroupId,
                                customerData.CustomerStatusId,
                                customerData.FacilityId,
                                customerData.Text,
                                customerData.Created,
                                customerData.Revision,
                                customerData.GS1Code,
                                customerData.IndependentQualityAssuranceCheck,
                                customerData.TrayListFooter,
                                customerData.DeliveryNoteFooter,
                                customerData.LegacyId,
                                customerData.LegacyFacilityOrigin,
                                customerData.LegacyImported,
                                customerData.Alias,
                                customerData.DebtorId,
                                customerData.PrintTrayListFrontSheet,
                                customerData.QALabelProductCodeId,
                                customerData.Linear1dBarcodeId,
                                customerData.Datamatrix2dBarcodeId, null,
                                customerData.Notes,
                                customerData.CreatePhysicalDeliveryNote
                                );
        }

        #endregion ToEntity: CustomerData

        #region ToEntity:Location

        #endregion

        #region ToEntity:Address

        /// <summary>
        /// ConvertAddressDataToEntity operation
        /// </summary>
        public static Address ConvertAddressDataToEntity(IUnitOfWork unitOfWork, AddressData addressData)
        {
            if (addressData == null)
            {
                return null;
            }
            return AddressFactory.CreateEntity(unitOfWork, addressData.AddressId,
                               addressData.Address1, addressData.Address2, addressData.Address3, addressData.City,
                               addressData.Postcode, addressData.ContactEmail, addressData.Telephone,
                               addressData.LegacyFacilityOrigin, addressData.LegacyImported);
        }

        /// <summary>
        /// ConvertAddressesDataToEntity operation
        /// </summary>
        public static IList<Address> ConvertAddressesDataToEntity(IUnitOfWork unitOfWork, IList<AddressData> addresses)
        {
            return addresses.Select(a => ConvertAddressDataToEntity(unitOfWork, a)).ToList();
        }

        #endregion

        #region ToEntity:ContractedHour

        /// <summary>
        /// ConvertContractedHourToEntity operation
        /// </summary>
        public static ContractedHours ConvertContractedHourToEntity(IUnitOfWork unitOfWork, ContractedHoursData contractedHourData)
        {
            if (contractedHourData == null)
            {
                return null;
            }
            return ContractedHoursFactory.CreateEntity(unitOfWork, contractedHourData.ContractedHoursId,
                                            contractedHourData.CustomerId,
                                            contractedHourData.DayOfWeek,
                                            contractedHourData.Opening,
                                            contractedHourData.Closing,
                                            contractedHourData.Closed,
                                            contractedHourData.LegacyFacilityOrigin,
                                            contractedHourData.LegacyImported);
        }

        /// <summary>
        /// ConvertContractedHoursToEntity operation
        /// </summary>
        public static IList<ContractedHours> ConvertContractedHoursToEntity(IUnitOfWork unitOfWork, IList<ContractedHoursData> contractedHoursData)
        {
            return contractedHoursData.Select(a => ConvertContractedHourToEntity(unitOfWork, a)).ToList();
        }

        #endregion

        #region ToEntity: ServiceRequirementData

        /// <summary>
        /// ConvertServiceRequirementDataToEnty operation
        /// </summary>
        public static ServiceRequirement ConvertServiceRequirementDataToEnty(IUnitOfWork unitOfWork, ServiceRequirementData serviceRequirementData)
        {
            if (serviceRequirementData == null)
            {
                return null;
            }
            var serviceRequirement = ServiceRequirementFactory.CreateEntity(unitOfWork, serviceRequirementData.ServiceRequirementId,
                                                            serviceRequirementData.ArchivedUserId,
                                                            serviceRequirementData.CreatedUserId,
                                                            serviceRequirementData.ExpiryCalculationTypeId,
                                                            serviceRequirementData.ServiceRequirementDefinitionId,
                                                            serviceRequirementData.Text,
                                                            serviceRequirementData.Revision,
                                                            serviceRequirementData.TurnaroundMinutes,
                                                            serviceRequirementData.Margin,
                                                            serviceRequirementData.MarginAppliesToReprocessing,
                                                            serviceRequirementData.MarginAppliesToSingleUse,
                                                            serviceRequirementData.MarginAppliesToOther,
                                                            serviceRequirementData.GraceMinutes,
                                                            serviceRequirementData.Effective,
                                                            serviceRequirementData.Created,
                                                            serviceRequirementData.Archived,
                                                            serviceRequirementData.LegacyId,
                                                            serviceRequirementData.LegacyFacilityOrigin,
                                                            serviceRequirementData.LegacyImported,
                                                            serviceRequirementData.IsFastTrack);

            var itemTypes = serviceRequirementData.ItemTypes;
            if (itemTypes != null)
            {
                foreach (var itemType in itemTypes)
                {
                    serviceRequirement.ItemTypes.Add(new ItemType(itemType));
                }
            }
            return serviceRequirement;
        }

        /// <summary>
        /// ConvertServiceRequirementsDataToEntity operation
        /// </summary>
        public static IList<ServiceRequirement> ConvertServiceRequirementsDataToEntity(IUnitOfWork unitOfWork, IList<ServiceRequirementData> serviceRequirementDatas)
        {
            return serviceRequirementDatas.Select(a => ConvertServiceRequirementDataToEnty(unitOfWork, a)).ToList();
        }

        #endregion ToEntity: ServiceRequirementData

        #region ToEntity: LabourBandData

        /// <summary>
        /// ConvertLabourBandDataToEntity operation
        /// </summary>
        public static LabourBand ConvertLabourBandDataToEntity(IUnitOfWork unitOfWork, LabourBandData labourBandData)
        {
            if (labourBandData == null)
            {
                return null;
            }
            var labourBand = LabourBandFactory.CreateEntity(unitOfWork, labourBandData.LabourBandId,
                                            labourBandData.Text,
                                            labourBandData.Cost,
                                            labourBandData.MaximumComponents,
                                            labourBandData.Created,
                                            labourBandData.CreatedUserId,
                                            labourBandData.Archived,
                                            labourBandData.ArchivedUserId,
                                            labourBandData.CustomerId,
                                            labourBandData.LegacyInternalId);
            var itemTypes = labourBandData.GetItemTypes();
            if (itemTypes != null)
            {
                foreach (var itemType in itemTypes)
                {
                    labourBand.ItemTypes.Add(new ItemType(itemType));
                }
            }
            return labourBand;
        }

        /// <summary>
        /// ConvertLabourBandsDataToEntity operation
        /// </summary>
        public static IList<LabourBand> ConvertLabourBandsDataToEntity(IUnitOfWork unitOfWork, IList<LabourBandData> labourBandDatas)
        {
            return labourBandDatas.Select(a => ConvertLabourBandDataToEntity(unitOfWork, a)).ToList();
        }

        #endregion ToEntity: LabourBandData

        #region ToEntity: CustomerCostingModelData

        #endregion ToEntity: CustomerCostingModelData

        #region ToEntity: BarcodeReprintCostsData

        #endregion ToEntity: BarcodeReprintCostsData

        #region ToEntity: CustomerTrayChangeCostData

        #endregion ToEntity: CustomerTrayChangeCostData

        #region ToEntity:CustomerCharge

        #endregion CustomerCharge

        #region ToEntity:CustomerChargeReoccurring

        #endregion CustomerCharge

        #region ToEntity:CustomerGroup

        /// <summary>
        /// ConvertCustomerGroupToEntity operation
        /// </summary>
        public static CustomerGroup ConvertCustomerGroupToEntity(IUnitOfWork unitOfWork, CustomerGroupData customerGroup)
        {
            if (customerGroup == null)
            {
                return null;
            }
            return CustomerGroupFactory.CreateEntity(unitOfWork, customerGroup.CustomerGroupId,
                                     customerGroup.AddressId,
                                     customerGroup.ArchivedUserId,
                                     customerGroup.CreatedUserId,
                                     customerGroup.Text,
                                     customerGroup.Created,
                                     customerGroup.Archived,
                                     customerGroup.LegacyFacilityOrigin,
                                     customerGroup.LegacyImported,
                                     customerGroup.TenancyId);
        }

        #endregion

        #region ToEntity:Customer

        /// <summary>
        /// ConvertCustomerToEntity operation
        /// </summary>
        public static ICustomer ConvertCustomerToEntity(IUnitOfWork unitOfWork, CustomerData customer)
        {
            if (customer == null)
            {
                return null;
            }
            return CustomerFactory.CreateEntity(unitOfWork,
                                customer.CustomerId,
                                customer.AddressId,
                                customer.CreatedUserId,
                                customer.CustomerDefinitionId,
                                customer.CustomerGroupId,
                                customer.CustomerStatusId,
                                customer.FacilityId,
                                customer.Text,
                                customer.Created,
                                customer.Revision,
                                customer.GS1Code,
                                customer.IndependentQualityAssuranceCheck,
                                customer.TrayListFooter,
                                customer.DeliveryNoteFooter,
                                customer.LegacyId,
                                customer.LegacyFacilityOrigin,
                                customer.LegacyImported,
                                customer.Alias,
                                customer.DebtorId, customer.PrintTrayListFrontSheet,
                                customer.QALabelProductCodeId,
                                customer.Linear1dBarcodeId,
                                customer.Datamatrix2dBarcodeId, null, customer.Notes,
                                customer.CreatePhysicalDeliveryNote);
        }

        /// <summary>
        /// ConvertCustomersToEntity operation
        /// </summary>
        public static IList<ICustomer> ConvertCustomersToEntity(IUnitOfWork unitOfWork, IList<CustomerData> customers)
        {
            if (customers == null)
                return null;
            return customers.Select(a => ConvertCustomerToEntity(unitOfWork, a)).ToList();
        }

        #endregion

        #region ToEntity:CustomerPriceRise

        #endregion

        #region Directorate

        /// <summary>
        /// ConvertDirectorateToEntity operation
        /// </summary>
        public static Directorate ConvertDirectorateToEntity(IUnitOfWork unitOfWork, DirectorateData directorate)
        {
            if (directorate == null)
            {
                return null;
            }
            return DirectorateFactory.CreateEntity(unitOfWork,
                                directorate.DirectorateId,
                                directorate.AddressId,
                                directorate.CustomerDefinitionId,
                                directorate.Text,
                                directorate.LegacyId,
                                directorate.LegacyFacilityOrigin,
                                directorate.LegacyImported,
                                directorate.Archived,
                                directorate.ArchivedUserId);
        }

        #endregion

        #region ToEntity:PriceCategoryGroup

        /// <summary>
        /// ConvertPriceCategoryGroupToEntity operation
        /// </summary>
        public static PriceCategoryGroup ConvertPriceCategoryGroupToEntity(IUnitOfWork unitOfWork, PriceCategoryGroupData priceCategoryGroup)
        {
            if (priceCategoryGroup == null)
            {
                return null;
            }
            return PriceCategoryGroupFactory.CreateEntity(unitOfWork, priceCategoryGroup.PriceCategoryGroupId,
                priceCategoryGroup.ArchivedUserId,
                priceCategoryGroup.CreatedUserId,
                priceCategoryGroup.CustomerDefinitionId,
                priceCategoryGroup.Text,
                priceCategoryGroup.Created,
                priceCategoryGroup.Archived,
                priceCategoryGroup.LegacyId,
                priceCategoryGroup.LegacyFacilityOrigin,
                priceCategoryGroup.LegacyImported
                );
        }

        #endregion

        #region ToEntity:PriceCategory

        /// <summary>
        /// ConvertPriceCategoryToEntity operation
        /// </summary>
        public static PriceCategory ConvertPriceCategoryToEntity(IUnitOfWork unitOfWork, PriceCategoryData priceCategory)
        {
            if (priceCategory == null)
            {
                return null;
            }
            return PriceCategoryFactory.CreateEntity(unitOfWork, priceCategory.PriceCategoryId,
                priceCategory.ArchivedUserId,
                priceCategory.CreatedUserId,
                priceCategory.PriceCategoryDefinitionId,
                priceCategory.ExternalId,
                priceCategory.Text,
                priceCategory.MaximumComponents,
                priceCategory.Created,
                priceCategory.Archived,
                priceCategory.LegacyId,
                priceCategory.LegacyFacilityOrigin,
                priceCategory.LegacyImported
                );
        }

        #endregion

        #region ToEntity:UserItemAudit

        /// <summary>
        /// ConvertUserItemAuditToEntity operation
        /// </summary>
        public static UserItemAudit ConvertUserItemAuditToEntity(IUnitOfWork unitOfWork, UserItemAuditData userItemAudit)
        {
            if (userItemAudit == null)
            {
                return null;
            }
            return UserItemAuditFactory.CreateEntity(unitOfWork,
                userItemAudit.UserItemAuditId,
                userItemAudit.UserId,
                userItemAudit.UserItemAuditTypeId,
                userItemAudit.RelatedId,
                userItemAudit.Created,
                userItemAudit.Processed
                );
        }

        #endregion

        #region ToEntity:ItemType

        /// <summary>
        /// ConvertItemTypeToEntity operation
        /// </summary>
        public static ItemType ConvertItemTypeToEntity(ItemTypeData itemType)
        {
            if (itemType == null)
            {
                return null;
            }
            return new ItemType(itemType.ItemTypeId);
        }

        /// <summary>
        /// ConvertItemTypesToEntity operation
        /// </summary>
        public static IList<ItemType> ConvertItemTypesToEntity(IList<ItemTypeData> itemTypes)
        {
            if (itemTypes == null)
                return null;
            return itemTypes.Select(ConvertItemTypeToEntity).ToList();
        }

        #endregion

        #region ToEntity:PriceCategoryBatchCycle

        /// <summary>
        /// ConvertPriceCategoryBatchCycleToEntity operation
        /// </summary>
        public static PriceCategoryBatchCycle ConvertPriceCategoryBatchCycleToEntity(IUnitOfWork unitOfWork, PriceCategoryBatchCycleData priceCategoryBatchCycle)
        {
            if (priceCategoryBatchCycle == null)
            {
                return null;
            }
            return PriceCategoryBatchCycleFactory.CreateEntity(unitOfWork, priceCategoryBatchCycle.PriceCategoryBatchCycleId,
                priceCategoryBatchCycle.BatchCycleId,
                priceCategoryBatchCycle.PriceCategoryId,
                priceCategoryBatchCycle.Charge,
                priceCategoryBatchCycle.LegacyId,
                priceCategoryBatchCycle.LegacyFacilityOrigin,
                priceCategoryBatchCycle.LegacyImported);
        }

        /// <summary>
        /// ConvertPriceCategoryBatchCyclesToEntity operation
        /// </summary>
        public static IList<PriceCategoryBatchCycle> ConvertPriceCategoryBatchCyclesToEntity(IUnitOfWork unitOfWork, IList<PriceCategoryBatchCycleData> priceCategoryBatchCycles)
        {
            if (priceCategoryBatchCycles == null)
                return null;
            return priceCategoryBatchCycles.Select(a => ConvertPriceCategoryBatchCycleToEntity(unitOfWork, a)).ToList();
        }

        #endregion

        #region ToEntity:ChargeList

        /// <summary>
        /// ConvertChargeListToEntity operation
        /// </summary>
        public static ChargeList ConvertChargeListToEntity(IUnitOfWork unitOfWork, ChargeListData chargeList)
        {
            if (chargeList == null)
            {
                return null;
            }
            return ChargeListFactory.CreateEntity(unitOfWork,
                chargeList.ChargeListId,
                chargeList.ArchivedUserId,
                chargeList.ChargeListCategoryId,
                chargeList.CreatedUserId,
                chargeList.CustomerDefinitionId,
                chargeList.Charge,
                chargeList.Created,
                chargeList.Text,
                chargeList.Archived,
                chargeList.LegacyFacilityOrigin,
                chargeList.LegacyImported
                );
        }
        #endregion

        #region ToEntity:Indexation

        /// <summary>
        /// ConvertIndexationToEntity operation
        /// </summary>
        public static Indexation ConvertIndexationToEntity(IUnitOfWork unitOfWork, IndexationData indexation)
        {
            if (indexation == null)
            {
                return null;
            }
            return IndexationFactory.CreateEntity(unitOfWork,
                indexation.IndexationId,
                indexation.ArchivedUserId,
                indexation.CreatedUserId,
                indexation.CustomerDefinitionId,
                indexation.IndexationCategoryId,
                indexation.IndexationTypeId,
                indexation.Amount,
                indexation.AppliesFrom,
                indexation.Created,
                indexation.Archived,
                indexation.LegacyId,
                indexation.LegacyFacilityOrigin,
                indexation.LegacyImported,
                indexation.Text
                );
        }
        #endregion

        #region ToEntity:ContainerMasterPriceAdjustment

        /// <summary>
        /// ConvertContainerMasterPriceAdjustmentToEntity operation
        /// </summary>
        public static ContainerMasterPriceAdjustment ConvertContainerMasterPriceAdjustmentToEntity(IUnitOfWork unitOfWork, ContainerMasterPriceAdjustmentData containerMasterPriceAdjustment)
        {
            if (containerMasterPriceAdjustment == null)
            {
                return null;
            }
            return ContainerMasterPriceAdjustmentFactory.CreateEntity(unitOfWork,
                    containerMasterPriceAdjustment.ContainerMasterPriceAdjustmentId,
                    containerMasterPriceAdjustment.ContainerMasterId,
                    containerMasterPriceAdjustment.Text,
                    containerMasterPriceAdjustment.Adjustment,
                    containerMasterPriceAdjustment.ApplyServiceRequirementFactor,
                    containerMasterPriceAdjustment.LegacyId,
                    containerMasterPriceAdjustment.LegacyFacilityOrigin,
                    containerMasterPriceAdjustment.LegacyImported,
                    containerMasterPriceAdjustment.ContainerMasterPriceAdjustmentTypeId,
                    containerMasterPriceAdjustment.Archived,
                    containerMasterPriceAdjustment.ArchivedUserId
                );
        }
        #endregion
    }
}