using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IVendorService
    /// </summary>
    public interface IVendorService
    {
        /// <summary>
        /// To retrieve All Vendors
        /// </summary>
        /// <returns></returns>
        IList<VendorData> ReadAllVendors();

        /// <summary>
        /// To retrieve Vendors by facility.
        /// </summary>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        IList<VendorData> ReadVendorsByFacility(short facilityId);

        /// <summary>
        /// Get Vendor by vendorId.
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        VendorData ReadVendorById(int vendorId);

        /// <summary>
        /// Updates the Vendor
        /// </summary>
        /// <param name="vendorData">The vendor data.</param>        
        /// <returns></returns>
        /// <remarks></remarks>
        int UpdateVendor(VendorData vendorData, short facilityId);

        /// <summary>
        /// Gets the vendor contact by vendor id.
        /// </summary>
        /// <param name="vendorId">The vendor id.</param>
        /// <returns></returns>
        List<ContactData> GetVendorContactByVendorId(int vendorId);

        /// <summary>
        /// Get ALL Vendor Activities.
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        IList<VendorActivityData> GetVendorActivities(int? vendorId);

        /// <summary>
        /// Get only the MaintenanceActivities limited by Configured lists
        /// </summary>
        /// <param name="facilityId">The Id of the Facility</param>
        /// <returns></returns>
        IList<VendorActivityData> GetConfiguredVendorActivities(int facilityId, int vendorId);

        /// <summary>
        /// Get Vendor Contract Activities
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        IList<VendorActivityData> GetVendorAssignedActivities(int? vendorId);
        IList<VendorActivityData> RemoveMaintenanceActivityForVendorAndContracts(VendorRemoveContractsData request);

        /// <summary>
        /// Get Vendor Contract By VendorId.
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        IList<VendorContractData> GetVendorContractByVendorId(int vendorId);

        /// <summary>
        /// Update Vendor Contract.
        /// </summary>
        /// <param name="vendorContractData"></param>
        OperationResponseContract UpdateVendorContract(VendorContractData vendorContractData);

        /// <summary>
        /// Gets the contract vendor maintenace by contract id.
        /// </summary>
        /// <param name="contractId">The contract id.</param>
        /// <returns></returns>
        List<ContractVendorMaintenanceData> GetContractVendorMaintenaceByContractId(int contractId);
        List<ContractVendorMaintenanceData> GetContractVendorMaintenaceByVendorId(int vendorId);

        /// <summary>
        /// Gets the vendor and customer details by container master definition id.
        /// </summary>
        /// <param name="definitionId">The definition id.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        IList<VendorContractData> GetVendorAndCustomerDetailsByContainerMasterDefinitionId(int definitionId, int facilityId);

        /// <summary>
        /// Gets the customer list by facility id.
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        IList<KeyValuePair<int, string>> GetCustomerListByFacilityId(int facilityId);

        /// <summary>
        /// Gets the maintenance activities by customer id.
        /// </summary>
        /// <param name="customerId">The customer id.</param>
        /// <returns></returns>
        IList<GenericKeyValueData> GetMaintenanceActivitiesByCustomerDefinitionId(int customerDefinitionId);

        /// <summary>
        /// Gets the maintenance activities by vendor id.
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        IList<GenericKeyValueData> GetMaintenanceActivitiesByVendorId(int vendorId, int customerDefinitionId, int? containerMasterId);

        /// <summary>
        /// Gets the vendors by customer idand maintenance activity.
        /// </summary>
        /// <param name="customerId">The customer id.</param>
        /// <param name="maintenanceActivityId">The maintenance activity id.</param>
        /// <returns></returns>
        IList<GenericKeyValueData> GetVendorsByCustomerDefinitionIdandMaintenanceActivity(int customerDefinitionId, int maintenanceActivityId, int containerMasterId, bool isContainerMaster);

        /// <summary>
        /// Saves the maintenance rule.
        /// </summary>
        /// <param name="maintenanceRuleData">The maintenance rule data.</param>
        /// <returns></returns>
        int SaveMaintenanceRule(PlannedMaintenanceRuleData maintenanceRuleData);

        /// <summary>
        /// Gets the planned maintenance rules by item definition id.
        /// </summary>
        /// <param name="defintionId"></param>
        /// <param name="isContainerMaster"></param>
        /// <param name="facilityId"></param>
        /// <param name="userCultureData"></param>
        /// <returns></returns>
        List<PlannedMaintenanceRuleData> GetPlannedMaintenanceRulesByItemDefinitionId(int defintionId, bool isContainerMaster, int facilityId, UserCultureData userCultureData);

        /// <summary>
        /// Gets the planned maintenance rule by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        PlannedMaintenanceRuleData GetPlannedMaintenanceRuleById(int id);

        /// <summary>
        /// Validate Vendor.
        /// </summary>
        /// <param name="vendorData"></param>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        OperationResponseContract ValidateVendor(VendorData vendorData, short facilityId);

        /// <summary>
        /// Archives the planned maintenance rule.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>        
        OperationResponseContract ArchivePlannedMaintenanceRule(int id, bool isContainerMaster, int? containerMasterDefinitionId = null);

        /// <summary>
        /// Gets the drop down list data.
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="customerDefinitionId">The customer definition id.</param>
        /// <param name="activityId">The activity id.</param>
        /// <returns></returns>
        MaintenanceRulesDropDownList GetDropDownListData(int facilityId, int? customerDefinitionId, int? activityId, int? containerMasterId, bool isContainerMaster);

        /// <summary>
        /// Gets the customer list by facility id.
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        IList<KeyValuePair<int, string>> GetMaintenanceRulesCustomerByFacilityId(int facilityId);

        /// <summary>
        /// Gets the vendors by customer id.
        /// </summary>
        /// <param name="customerDefinitionId">The Customer Id.</param>
        /// <returns></returns>
        IList<KeyValuePair<int, string>> GetVendorsByCustomerDefinitionId(int customerDefinitionId);

        /// <summary>
        /// Get Vendor Activity And Contract Cost By VendorId And Customer
        /// </summary>
        /// <param name="vendorId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<VendorActivityData> GetVendorActivityAndContractCostByVendorIdAndCustomer(int vendorId, int id);
        List<PlannedMaintenanceDataContract> GetPlannedMaintenanceRulesForInstance(int instanceId, int? turnaroundId, UserCultureData userCultureData);
    }
}
