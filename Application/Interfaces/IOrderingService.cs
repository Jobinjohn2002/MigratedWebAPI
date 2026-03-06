using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IOrderingService
    /// </summary>
    public interface IOrderingService
    {
        OperationResponseContract<List<HisDataCrossMatchRequiredDc>> GetCrossMatchingRequiredByHisOrder(int userId, int facilityId, string hisOrder);
        OperationResponseContract<List<HisDataCrossMatchRequiredDc>> GetCrossMatchingRequired(HisDataCrossMatchingRequiredSearchParameters searchParameters);
        OperationResponseContract<List<HisDataCrossMatchingDataContract>> GetDeliveryPointCrossMatching(HisDataCrossMatchingSearchParameters searchParameters);
        OperationResponseContract<List<HisDataCrossMatchingDataContract>> GetContainerMasterCrossMatching(HisDataCrossMatchingSearchParameters searchParameters, UserCultureData userCultureData);
        OperationResponseContract<HisOrderDataContract> GetHisOrder(int hisOrderId);
        OperationResponseContract<List<HisDataCrossMatchRequiredDc>> GetHisOrderMatchingIssues(int userID, int facilityID, string orderRef, HisDataCrossMatchTypeIdentifier? crossMatchType = null);
        OperationResponseContract<List<ContainerMasterInfo>> GetCrossMatchingContainerMastersForCustomer(int customerDefinitionId, string searchText, short numberOfResults);
        OperationResponseContract SaveCrossMatching(HisDataCrossMatchingDataContract hisCrossMatchingData, string hisOrderRef);

    }
}
