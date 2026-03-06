using SynergyApplicationFrameworkApi.Application.DTOs;
using SynergyApplicationFrameworkApi.Application.Services.DataContracts;
using SynergyApplicationFrameworkApi.Application.DTOs;
using SynergyApplicationFrameworkApi.Application.DTOs.Search;
using SynergyApplicationFrameworkApi.Application.DTOs.TrayBuilder;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Synergy.Core.Data;
using System.ServiceModel;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IItemService
    /// </summary>
    public interface IItemService
    {
        /// <summary>
        /// Registers a turnaround event..
        /// </summary>
        /// <param name="containerInstanceId"></param>
        /// <param name="facilityId"></param>
        /// <param name="stationId"></param>
        /// <param name="userId"></param>
        /// <param name="eventType"></param>
        /// <returns></returns>
        WashStationData RegisterEvent(int containerInstanceId, short facilityId, int stationId, int userId, byte processStationType, int eventType);

        /// <summary>
        /// Creates the 1st revision of a container
        /// </summary>
        /// <param name="item"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        int CreateContainerMaster(ContainerMasterData item, int userId, short facilityId);

        /// <summary>
        /// Creates subsequent revisions of a container
        /// </summary>
        /// <param name="item"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        int UpdateContainerMaster(ContainerMasterData item, int userId, short facilityId);

        /// <summary>
        /// Updates the prices associated with a container
        /// </summary>
        /// <param name="containerMasterId"></param>
        /// <param name="userId"></param>
        /// <param name="manualPriceCategoryDefinitionId"></param>
        /// <param name="manualReprocessingPriceAfterIndexation"></param>
        /// <param name="manualSingleUsePriceAfterIndexation"></param>
        /// <returns></returns>
        int UpdateContainerMasterPrice(int containerMasterId, int userId, int? manualPriceCategoryDefinitionId, decimal? manualReprocessingPriceAfterIndexation, decimal? manualSingleUsePriceAfterIndexation);

        /// <summary>
        /// Creates the price adjustments associated with a container
        /// </summary>
        /// <param name="adjustment"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        int CreateContainerMasterPriceAdjustment(ContainerMasterPriceAdjustmentData adjustment, int userId);

        /// <summary>
        /// Updates the price adjustments associated with a container
        /// </summary>
        /// <param name="adjustment"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        int UpdateContainerMasterPriceAdjustment(ContainerMasterPriceAdjustmentData adjustment, int userId);

        /// <summary>
        /// Creates the 1st revision of an item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        int CreateItemMaster(ItemMasterData item, int userId, short facilityId);

        /// <summary>
        /// Creates subsequent revisions of an item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="userId"></param>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        int UpdateItemMaster(ItemMasterData item, int userId, short facilityId);

        /// <summary>
        /// Updates the price associated with an item
        /// </summary>
        /// <param name="price"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        int UpdateItemMasterPrice(ItemMasterPriceData price, int userId);

        /// <summary>
        /// See event handler
        /// </summary>
        /// <param name="containerMasterDefinitionId"></param>
        /// <returns></returns>
        IList<ContainerMasterPriceAdjustmentData> ReadActivePriceAdjustmentsByContainerMasterDefinition(int containerMasterDefinitionId);

        /// <summary>
        /// To retrieve deliverable containers by customer and search criteria
        /// </summary>
        /// <param name="customerDefinitionId">Customer definition Id</param>
        /// <param name="searchText">Search criteria</param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        IList<ContainerMasterData> ReadDeliverableContainersByCustomerAndSearchText(int customerDefinitionId, string searchText, int skip, int take);

        /// <summary>
        /// Method to archive item master
        /// </summary>
        /// <param name="itemMasterId">item master id</param>
        /// <param name="userId">archived user id</param>
        /// <param name="pinRequestReasonId"></param>
        /// <returns></returns>
        OperationResponseContract ArchiveItemMaster(int itemMasterId, int userId, int? pinRequestReasonId);

        #region UnArchiveItemMaster

        /// <summary>
        /// Unarchive the item master.
        /// </summary>
        /// <param name="itemMasterId">The item master id.</param>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        int UnArchiveItemMaster(int itemMasterId, int userId);

        #endregion

        #region  UnArchiveContainerMaster

        /// <summary>
        /// Unarchive the container master.
        /// </summary>
        /// <param name="itemId">The item id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="pinRequestReasonId"></param>
        /// <returns></returns>
        int UnArchiveContainerMaster(int itemId, int userId, int? pinRequestReasonId);

        #endregion
        /// <summary>
        /// To retrieve containers by delivery point
        /// </summary>
        /// <param name="deliveryPointId">the Id for the delivery point</param>
        /// <param name="filter"></param>
        /// <returns></returns>
        OperationResponseContract<IList<ContainerMasterData>> ReadContainersByDeliveryPoint(int deliveryPointId, DataFilter filter, UserCultureData userCultureData);

        /// <summary>
        /// Read Master by Item Type.
        /// </summary>
        /// <param name="itemTypeId">Item Type Ref</param>
        /// <param name="facilityId"></param>
        /// <param name="filter">filter criteria</param>
        /// <returns></returns>
        OperationResponseContract<IList<MasterData>> ReadByItemType(int itemTypeId, short facilityId, DataFilter filter, UserCultureData userCultureData);

        /// <summary>
        /// Method to check whether container master can be archived or not
        /// </summary>
        /// <param name="containerMasterId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(BasicFaultContract))]
        bool IsContainerMasterArchivable(int containerMasterId);

        /// <summary>
        /// Method to add container contents to containermaster
        /// </summary>
        /// <param name="components"></param>
        /// <param name="containermasterId"></param>
        /// <param name="createdUserId"></param>
        /// <param name="isAdd"></param>
        /// <returns></returns>
        int AddContainerContentsToContainerMaster(IList<ContainerContentData> components, int containermasterId, int createdUserId, bool isAdd);

        /// <summary>
        /// Method to remove container content form ContainerMaster
        /// </summary>
        /// <param name="itemmasterDefinitionId"></param>
        /// <param name="containermasterid"></param>
        /// <param name="createdUserId"></param>
        /// <returns></returns>
        int RemoveContainerContentFromContainerMaster(int itemmasterDefinitionId, int containermasterid, int createdUserId);

        /// <summary>
        /// Method to add container content notes to containermaster
        /// </summary>
        /// <param name="containerContentNoteId"></param>
        /// <param name="containerContentNote"></param>
        /// <param name="containermasterId"></param>
        /// <param name="createdUserId"></param>
        /// <returns></returns>
        int AddContainerContentNoteToContainerMaster(int containerContentNoteId, string containerContentNote, int containermasterId,
                                                      int createdUserId);

        /// <summary>
        /// Method to remove container contentnote form ContainerMaster
        /// </summary>
        /// <param name="containermasterid"></param>
        /// <param name="createdUserId"></param>
        /// <param name="containerContentNoteId"></param>
        /// <returns></returns>
        int RemoveContainerContentNoteFromContainerMaster(int containerContentNoteId, int containermasterid, int createdUserId);

        /// <summary>
        /// Method to remove container contentnote form ContainerMaster
        /// </summary>
        /// <param name="isUp"></param>
        /// <param name="containermasterid"></param>
        /// <param name="createdUserId"></param>
        /// <param name="containerContentIds"></param>
        /// <returns></returns>
        int MoveComponents(List<int> containerContentIds, bool isUp, int containermasterid, int createdUserId);

        /// <summary>
        /// Unarchive the instance.
        /// </summary>
        /// <param name="instanceId">The instance id.</param>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        OperationResponseContract UnArchiveInstance(int instanceId, int userId, int? deliveryPointId, int? serviceRequirementDefinitionId);

        /// <summary>
        /// Method to get deleted item type active item summaray details for a facility
        /// </summary>
        /// <param name="itemtypeIds"></param>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        OperationResponseContract<IList<ItemTypeSummaryDetailData>> GetDeletedItemTypeActiveItemSummaryDetails(List<int> itemtypeIds, int facilityId);

        /// <summary>
        /// To retrieve item master Alias by facility id and container instance id
        /// </summary>
        /// <param name="facilityId">Id for a facility</param>
        /// <param name="containerInstanceId">Id for a Container Instance</param>
        /// <returns></returns>        
        IList<ItemMasterAliasData> ReadAliasByContainerInstance(short facilityId, int containerInstanceId);

        /// <summary>
        /// To retrieve item master Alias by facility id and Item Master Definition id
        /// </summary>
        /// <param name="facilityId">Id for a facility</param>
        /// <param name="itemMasterId">Id for a Item Master Definition</param>
        /// <returns></returns>        
        IList<ItemMasterAliasData> ReadAliasByItemMasterDefinition(short facilityId, int itemMasterDefinitionId);

        /// <summary>
        /// To retrieve item master Alias by facility id and Container Master Definition id
        /// </summary>
        /// <param name="facilityId">Id for a facility</param>
        /// <param name="itemMasterId">Id for a Container Master Definition</param>
        /// <returns></returns>
        IList<ItemMasterAliasData> ReadAliasByContainerMasterDefinition(short facilityId, int containerMasterDefinitionId);

        /// <summary>
        /// Read container instances by the given searchText
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        OperationResponseContract<IList<ContainerInstanceData>> ReadContainerInstanceBySearchText(string searchText, short facilityId, DataFilter filter);

        /// <summary>
        /// Read container Masters by the given searchText
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        OperationResponseContract<IList<ContainerMasterData>> ReadContainerMasterBySearchText(string searchText, short facilityId, DataFilter filter);

        /// <summary>
        /// Updates the Item Master Alias
        /// </summary>
        /// <param name="itemMasterDefinitionId"></param>
        /// <param name="customerDefinitionId"></param>
        /// <param name="deliveryPointId"></param>
        /// <param name="containerInstanceId"></param>
        /// <param name="aliasName"></param>
        /// <returns></returns>
        int UpdateItemMasterAlias(IList<int> itemMasterDefinitionId, IList<int> customerDefinitionId, IList<int> deliveryPointId, int? containerInstanceId, int? containerMasterDefinitionId, string aliasName);

        /// <summary>
        /// Read item master alias for the given criteria
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="filter"></param>
        /// <param name="itemMasterDefinitionId"></param>
        /// <param name="customerDefnitionId"></param>
        /// <param name="customerGroupId"></param>
        /// <returns></returns>
        IList<ItemMasterAliasData> ReadItemMasterAlias(int? itemMasterDefinitionId, int? customerDefnitionId, int? customerGroupId, short facilityId, DataFilter filter);

        /// <summary>
        /// Reads customer data for the given item master
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="itemMasterDefinitionId"></param>
        /// <returns></returns>
        IList<CustomerData> ReadCustomersByItemMasterDefinition(int facilityId, int itemMasterDefinitionId);

        /// <summary>
        /// Reads item master data for the selected customer group or customer definitionId
        /// </summary>
        /// <param name="customerDefnitionId"></param>
        /// <param name="customerGroupId"></param>
        /// <param name="facilityId"></param>
        /// <param name="dataFilter"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        IList<ItemMasterAliasData> ReadItemMastersByCustomer(int? customerDefnitionId, int? customerGroupId, short facilityId, DataFilter dataFilter, string searchText);

        /// <summary>
        /// Inserts or Updates item master alias for the selected parameters
        /// </summary>
        /// <param name="itemMasterDefinitionId"></param>
        /// <param name="customerDefnitionId"></param>
        /// <param name="customerGroupId"></param>
        /// <param name="aliasText"></param>
        /// <param name="createdUserId"></param>
        /// <returns></returns>
        int SaveItemMasterAlias(int itemMasterDefinitionId, int? customerDefnitionId, int? customerGroupId, string aliasText, int createdUserId);

        /// <summary>
        /// Method to get Item Alias data
        /// </summary>
        /// <param name="itemMasterAliasId"></param>
        /// <returns></returns>
        ItemMasterAliasData GetItemAliasDetails(int itemMasterAliasId);

        /// <summary>
        /// Method to delete the item master alias id
        /// </summary>
        /// <param name="itemMasterAliasId"></param>
        /// <param name="deletedUserId"></param>
        /// <returns></returns>
        OperationResponseContract ArchiveItemMasterAlias(int itemMasterAliasId, int deletedUserId);

        /// <summary>
        /// Validate item master alias for the selected parameters
        /// </summary>        
        /// <param name="itemMasterDefinitionId"></param>
        /// <param name="customerDefinitionId"></param>
        /// <param name="customerGroupId"></param>
        /// <param name="itemMasterExternalId"></param>        
        /// <returns></returns>
        int ValidateItemMasterAlias(int? itemMasterDefinitionId, int? customerDefinitionId, int? customerGroupId, string itemMasterExternalId);
        OperationResponseContract<IList<ContainerInstanceData>> SearchContainerInstances(string searchText, short facilityId, int customerDefinitionId, int? deliveryPointId, DataFilter filter);

        /// <summary>
        /// Read Customers By ItemMaster Alias
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="itemMasterDefinitionId"></param>
        /// <param name="itemMasterAliasId"></param>
        /// <param name="customerDefinitionId"></param>
        /// <param name="customerGroupId"></param>
        /// <param name="dataFilter"></param>
        /// <returns></returns>
        IList<ItemMasterAliasData> ReadCustomersByItemMasterAlias(short facilityId, int? customerDefinitionId, int? customerGroupId, int? itemMasterDefinitionId, int itemMasterAliasId, DataFilter dataFilter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemMasterDefinitionId"></param>
        /// <param name="customerGroupId"></param>
        /// <param name="facilityId"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        IList<ItemMasterAliasData> ReadCustomerGroupItemMasterAliases(int itemMasterDefinitionId, int customerGroupId, int facilityId, DataFilter filter);

        /// <summary>
        /// Read the root item types with child items types nested
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<ItemTypeData> ReadNestedItemTypes(int facilityId);

        /// <summary>
        /// Read the root item types for the given facility
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<ItemTypeData> ReadAllBaseItemTypes(int facilityId, bool isComponent);

        /// <summary>
        /// Read the root item types for the given facility and parent Item Type Id
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<ItemTypeData> ReadItemTypes(int facilityId, int parentItemTypeId);

        /// <summary>
        /// Read the root item types for the given facility and parent Item Type Id
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        (List<KeyValuePair<int, string>> DeconTasks, IList<ItemTypeData> ItemTypes) ReadBaseDataForParentItemType(int facilityId, int parentItemTypeId);
        /// <summary>
        /// Reprint a traylist given for a container master
        /// </summary>
        /// <param name="containerMasterId"></param>
        /// <param name="userId"></param>
        /// <param name="facilityId"></param>
        /// <param name="processStationType">Type of process station</param>
        /// <param name="localPrintingEnabled"></param>
        /// <returns></returns>
        OperationResponseContract ReprintTrayListByContainerMaster(int containerMasterId, int userId, UserCultureData userCultureData, bool localPrintingEnabled = false);

        #region
        /// <summary>
        /// method to get item name using definitionId
        /// </summary>
        /// <param name="definitionId"></param>
        /// <param name="masterType"></param>
        /// <returns></returns>
        string GetItemTitle(int definitionId, MasterType masterType);
        #endregion

        /// <summary>
        /// Checking outstanding orders for the Container Master Definition
        /// </summary>
        /// <param name="containerMasterDefinitionId"></param>
        /// <returns></returns>
        bool OutstandingOrdersExists(int containerMasterDefinitionId);

        #region TrayBuilder
        TrayModelData GetTrayModelData(int containerMasterDefinitionID, int userID);
        ItemModelData GetItemModelData(int itemMasterID);
        List<LineItem> GetProductSpecification(int containerMasterID);
        List<LineItem> GetLatestProductSpecification(int containerMasterDefinitionID);
        SaveSpecificationResult SaveProductSpecification(int containerMasterDefinitionID, List<LineItem> specification, short facilityID, bool isChargeable, int userID, string password = null, int? pinRequestReasonID = null);
        bool AddTagsToItem(int itemID, Tag[] tags);
        bool RemoveTagsFromItem(int itemID, Tag[] tags);
        List<FullTag> ListTagsForItem(int itemID);
        List<LineItem> SearchForProducts(string searchString, int facilityID);

        #endregion

        /// <summary>
        /// PrintSingleUseItems
        /// </summary>
        /// <param name="customerDefinitionId"></param>
        /// <param name="userId"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        OperationResponseContract PrintSingleUseItems(int customerDefinitionId, int userId, DataFilter filter, UserCultureData userCultureData, bool localPrintingEnabled = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerDefinitionId"></param>
        /// <param name="searchText"></param>
        /// <param name="userId"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        OperationResponseContract PrintDeliverableItems(int customerDefinitionId, string searchText, int userId, DataFilter filter, UserCultureData userCultureData, bool localPrintingEnabled = false);

        /// <summary>
        /// Get Facilities Customer Id and Customer Names
        /// </summary>
        /// <param name="facilityId">The facility Id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<GenericKeyValueData> ReadCustomersWithDeliveryPoints(short facilityId);

        /// <summary>
        /// Gets all Item Instances for the specified container instance, including their identifiers.
        /// </summary>
        /// <param name="containerInstanceId">The container to obtain item instances for.</param>
        /// <returns>A collection of Item Instances.</returns>
        IList<ItemInstanceData> GetItemInstancesWithIdentifiers(int containerInstanceId);

        /// <summary>
        /// Prints item instance list.
        /// </summary>
        /// <param name="facilityId">The facility in which the items exist</param>
        OperationResponseContract PrintItemInstanceList(int itemMasterDefId, short facilityId, int userId, DataFilter filter, UserCultureData userCultureData, bool localPrintingEnabled = false);
        OperationResponseContract ArchiveItemInstance(int itemInstanceId, int userId);
        OperationResponseContract UnarchiveItemInstance(int itemInstanceId, int userId);
        ContainerInstanceDataContract ReadContainerInstanceByItemInstance(int itemInstanceId);
        ItemInstancesDataContract ReadItemInstancesByFacility(int itemMasterDefinitionId, int facilityId, DataFilter filter);
        string CreateItemInstance(int itemMasterDefinitionId, int identifierType, string identValue, int createdUserId, int ownerId);
        bool ItemInstanceIdentExists(string identifer, int identifierType, int itemMasterDefinitionId);
        OperationResponseContract ChangeItemMasterForItemInstance(int itemInstanceId, int itemMasterDefinitionId, int userId);
        ItemInstanceData GetItemInstance(int itemInstanceId);
        ItemMasterData ReadItemMasterByItemInstance(int itemInstanceId);
        int GetItemInstancesCountByItemMaster(int itemMasterDefinitionId, int facilityId);
        bool HasItemInstanceCatalogueAccess(int itemMasterDefinitionId, int facilityId);

        /// <summary>
        /// Get Container Instance Count for the given containerMasterDefinitionId, facilityId and archivedInstances
        /// </summary>
        /// <param name="containerMasterDefinitionId"></param>
        /// <param name="facilityId"></param>
        /// <param name="archivedInstances"></param>
        /// <returns></returns>        
        int GetContainerInstanceCount(int containerMasterDefinitionId, short facilityId, bool? archivedInstances, UserCultureData userCultureData);

        /// <summary>
        /// Get Active Turnaround Count for the given containerMasterId
        /// </summary>
        /// <param name="containerMasterId"></param>
        /// <param name="facilityId"></param>
        /// <returns></returns>   
        int GetActiveTurnaroundsByContainerMasterCount(int containerMasterId, short facilityId);

        /// <summary>
        /// Update Active Turnarounds for the given containerMasterId
        /// </summary>
        /// <param name="containerMasterId"></param>
        /// <param name="userId"></param>
        /// <param name="facilityId"></param>
        /// <returns></returns>        
        int UpdateActiveTurnaroundsByContainerMaster(int containerMasterId, int userId, short facilityId);

        /// <summary>
        /// Print Batch turnaround Report
        /// </summary>
        /// <returns></returns>
        OperationResponseContract PrintBatchTurnaroundsReport(int batchId, int facilityId, int userId, UserCultureData userCultureData, bool localPrintingEnabled = false);

        /// <summary>
        /// Method to get customer name and customer key based on customer definitionId
        /// </summary>
        /// <param name="customerDefinitionId"></param>
        /// <returns></returns>
        CustomerData GetLatestCustomerNameByDefinition(int customerDefinitionId);
        List<ItemInstanceHistoryData> GetItemInstanceHistory(int itemInstanceId);
        bool IsContainerMasterLinkedToExternalLoanSet(int containerMasterDefinitionId);
        int? GetBlueprintContainerMasterIdByContainerMasterId(int containerMasterId);
        int? GetBlueprintContainerMasterDefinitionIdByContainerMasterDefinitionId(int containerMasterDefinitionId);
        int? GetBlueprintItemMasterIdByItemMasterId(int itemMasterId);
        int? GetBlueprintItemMasterDefinitionIdByContainerMasterDefinitionId(int containerMasterDefinitionId);
    }
}