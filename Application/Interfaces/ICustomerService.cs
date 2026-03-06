using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// ICustomerService
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Reads all customers pertaining to the given facility
        /// </summary>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        IList<CustomerData> ReadCustomersByFacility(int facilityId);

        #region CustomerGroup
        CustomerGroupData GetCustomerGroupUsingId(int customerGroupId);
        List<CustomerData> ReadCustomersByCustomerGroup(int customerGroupId,short facilityId);

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="vendorId"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        IList<CustomerData> GetContractCustomerByFacility(int facilityId, int vendorId, int customerDefinitionId);

        /// <summary>
        /// Read facility assigned item types by facility
        /// </summary>
        /// <param name="facilityId">The facility Id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<CustomerItemTypeData> ReadCustomerItemTypes(int customerDefinitionId);
        bool UpdateCustomerDeliveryPointTrolleySetting(CustomerData customerData, bool enable);
    }
}

