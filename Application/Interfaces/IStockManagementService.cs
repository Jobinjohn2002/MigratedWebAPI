using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IStockManagementService
    /// </summary>
    public interface IStockManagementService
    {
        /// <summary>
        /// Reading all Stock Transaction Types
        /// </summary>
        /// <returns></returns>
        List<StockTransactionTypeData> GetStockTransactionTypes();

        /// <summary>
        /// Reading all Stock Locations
        /// </summary>
        /// <param name="facilityId">the FacilityId</param>
        /// <returns></returns>
        List<LocationData> GetLocations(short facilityId);

        /// <summary>
        /// Method to get locations based on item master defnition and stock transaction type
        /// </summary>
        /// <returns></returns>
        List<LocationData> ReadStockLocationByItemMaster(short facilityId, int itemMasterDefinitionId, int stockTransactionTypeId);

        /// <summary>
        /// Reading all Locations by location Tree
        /// </summary>
        /// <param name="facilityId">the location Tree Id</param>
        /// <returns></returns>
        List<LocationData> GetLocationsByLocationTree(int treeId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockTransactionData"></param>
        /// <returns></returns>
        StockTransactionData SaveTransaction(StockTransactionData stockTransactionData);

        /// <summary>
        /// To retrieve  Stock Location by id
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        LocationData GetLocation(int locationId);

        /// <summary>
        /// To retrieve Location items by id
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        List<LocationData> GetLocationItems(int locationId);

        /// <summary>
        /// To retrieve  Stock Location by itemMasterDefinitionId
        /// </summary>
        /// <param name="itemMasterDefinitionId"> itemMasterDefinitionId</param>
        /// <param name="facilityId">facilityId</param>
        /// <returns></returns>
        List<LocationData> GetLocationItemsByItemMaster(int itemMasterDefinitionId, int facilityId);

        /// <summary>
        /// Gets all Locations that either contain at least one of the item or are empty
        /// </summary>
        List<LocationData> GetAvailableLocationsForItemMaster(int itemMasterDefinitionId, int facilityId);

        /// <summary>
        /// To retrieve  Stock Transaction History by Location id
        /// </summary>
        /// <param name="locationId">LocationId</param>
        /// <returns></returns>
        List<LocationData> GetTransactionHistory(int locationId);

        /// <summary>
        /// To retrieve  Stock Transaction History by Item Master Definition  id
        /// </summary>
        /// <param name="itemMasterDefinitionId"></param>
        /// <param name="facilityID"></param>
        /// <returns></returns>
        List<LocationData> GetTransactionHistoryByItemMaster(int itemMasterDefinitionId, int facilityID);

        /// <summary>
        /// To retrieve  Current Stock by Location id
        /// </summary>
        /// <returns></returns>
        int GetCurrentStockByLocation(int locationId);

        /// <summary>
        /// To validate Maximum Capacity Exceeded for the Location
        /// </summary>
        /// <returns></returns>
        bool MaximumCapacityExceeded(int locationId, int quantity);

        /// <summary>
        /// Method to get maximum capacity of location
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        int? GetLocationMaximumCapacity(int locationId);

        /// <summary>
        /// Method to validate the location maximum capacity
        /// </summary>
        /// <param name="transactionQuantity"></param>
        /// <param name="locationId"></param>
        /// <param name="transactionTypeId"></param>
        /// <param name="fromLocationId"></param>
        /// <returns></returns>
        OperationResponseContract ValidateLocationMaximumCapacity(int transactionQuantity, int locationId, byte transactionTypeId, int? fromLocationId);

        /// <summary>
        /// method to validate the removal quantity against the item master and location. This will validate while doing stock out and move stock operations.
        /// </summary>
        /// <returns></returns>
        int ValidateRemovalQuantity(int locationId, int itemmasterdefinitionId, int quantity);

        /// <summary>
        /// Get number of items from a location has stock
        /// </summary>
        /// <returns></returns>
        int CurrentStockItemsCount(int locationId);

        /// <summary>
        /// Creates the Stock Location.
        /// </summary>
        /// <param name="locationData"></param>
        /// <returns></returns>
        int CreateLocation(LocationData locationData);

        /// <summary>
        /// Updates the Stock Location.
        /// </summary>
        /// <param name="locationData">The Stock Location parameter.</param>
        OperationResponseContract UpdateLocation(LocationData locationData);

        /// <summary>
        /// Archive Stock Location
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        OperationResponseContract ArchiveLocation(int locationId, int userId);

        /// <summary>
        /// Reading all Stock Locations and Item Details
        /// </summary>
        /// <param name="facilityId">the FacilityId</param>
        /// <param name="locationId">the LocationId </param>
        /// <param name="itemMasterId">the ItemMasterId</param>
        /// <param name="isLocation"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<LocationData> ReadPagedStockDetails(short facilityId, int locationId, int itemMasterId, bool isLocation, Synergy.Core.Data.DataFilter filter);

        /// <summary>
        /// Print Location Tag
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="locationId"></param>
        /// <returns></returns>
        OperationResponseContract PrintLocationTag(int userId, int locationId, UserCultureData userCultureData, bool localPrintingEnabled = false);

        /// <summary>
        /// Reads item master data for the selected location
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="locationId"></param>
        /// <param name="searchText"></param>        
        /// <param name="dataFilter"></param>
        /// <param name="stockActionTypeId"></param>
        /// <returns></returns>
        IList<LocationData> ReadItemMastersByStockLocation(short facilityId, int locationId, string searchText,
                                                           Synergy.Core.Data.DataFilter dataFilter,
                                                           int? stockActionTypeId);

        /// <summary>
        /// Reads Audit History data for the selected location
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        IList<LocationData> ReadLocationAuditHistory(int locationId);

        /// <summary>
        /// ReadStockLocationSummary
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="isLocation"></param>
        /// <returns></returns>
        List<LocationData> ReadStockLocationSummary(short facilityId, bool isLocation);

        /// <summary>
        /// Print Instrument Stock Report
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="isLocation"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        OperationResponseContract PrintInstrumentStock(short facilityId, bool isLocation, int userId, Synergy.Core.Data.DataFilter filter, UserCultureData userCultureData, bool localPrintingEnabled = false);

        /// <summary>
        /// GetContainerMasterByLocation
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        bool MoveLocationLeaf(int leafId, int destinationleafId, int treeID);

        /// <summary>
        /// Method to get location by leaf Id
        /// </summary>
        /// <param name="leafId"></param>
        /// <returns>Location data</returns>
        LocationData GetLocationByLeafId(int? leafId);

        /// <summary>
        /// Method to get location data either by locationId or leafid
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="leafId"></param>
        /// <returns>Location data</returns>
        LocationData ReadLocationData(int? locationId, int? leafId);

        /// <summary>
        /// Method to get location type data
        /// </summary>
        /// <returns></returns>
        List<LocationTypeData> ReadLocationTypeData();

        /// <summary>
        /// Creates or updates the tree data.
        /// </summary>
        /// <param name="treeData"></param>
        /// <returns></returns>
        int SaveTreeDetails(TreeData treeData, byte rootLocationTypeId, int rootLocationCreatedUserId);

        /// <summary>
        /// Method to get tree details
        /// </summary>
        /// <param name="treeId"></param>
        /// <returns></returns>
        TreeData GetTreeDetails(int treeId);

        /// <summary>
        /// Read location trees by facility
        /// </summary>
        /// <param name="facilityId">The facility Id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<TreeData> ReadLocationTreesByFacility(short facilityId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="userCultureData"></param>
        /// <returns></returns>
        OperationResponseContract ValidateArchivelocation(int locationId, UserCultureData userCultureData);

        /// <summary>
        /// Reading all Stock Locations and Item Details
        /// </summary>
        /// <param name="facilityId">the FacilityId</param>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<LocationData> ReadPagedStockLocationAndItem(short facilityId, Synergy.Core.Data.DataFilter filter);

        /// <summary>
        /// method to validate the existing TreeCode. This will validate while doing stock out and move stock operations.
        /// </summary>
        /// <param name="treeId"></param>
        /// <param name="treeCode"></param>
        /// <returns></returns>
        bool ValidateExistingTreeCode(int treeId, string treeCode);
    }
}
