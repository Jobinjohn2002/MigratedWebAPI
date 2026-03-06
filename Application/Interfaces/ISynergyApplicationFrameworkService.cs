using System.Collections.Generic;
using FavouriteReportContract = Pathway.Core.Services.DataContracts.FavouriteReportContract;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// ISynergyApplicationFrameworkService
    /// </summary>
    public interface ISynergyApplicationFrameworkService
    {
        int? LoadTrolley(int trolleyUid, int stationId, int userId);
        bool LoadInstanceOntoTrolley(int instanceId, int trolleyTurnaroundId, int userId, int stationId);
        bool RetrospectiveAddToWashBatch(int fromContainerInstance, int toContainerInstance, int stationId, int userId);
        int? MakeTrolleyAvailableForCollection(int trolleyId, int stationId, int userId);
        int? RecordCollection(int trolleyId, int stationId, int userId);
        int? DeliverTrolley(int trolleyId, int stationId, int userId);
        bool DeliverDeliveryNote(int deliveryNoteId, int stationId, int userId);
        bool AddTurnaroundToStoragePoint(int storagePointId, long turnaroundExternalId, int stationId, int userId);
        bool AddTrolleyToStoragePoint(int storagePointId, int trolleyId, int stationId, int userId);
        ConfigurableListDataContract GetCustomisableListValuesForTenancy(int listTypeId, int tenancyId, int? eventTypeId);
        List<KeyValuePair<byte, string>> GetConfiguredDefectResponsibilities(int facilityId);

        #region Reports
        List<FavouriteReportContract> GetAllFavouriteReports(int userId);
        OperationResponseContract DeleteFavouriteReport(int favouriteReportId);
        int CreateFavouriteReport(FavouriteReportContract favouriteReportContract);
        OperationResponseContract EditFavouriteReport(FavouriteReportContract favouriteReportContract);
        List<ReportOutputTypeContract> GetReportOutputTypes(short reportId);
        List<ItemExceptionsDataContract> GetItemExceptionDates(string externalId, int containerInstanceId); 
        List<ItemExceptionsDataContract> GetItemExceptionDatesByTurnaroundId(string externalId, int turnaroundId); 
        List<ReportData> GetAllReportsForUser(int userId);
        OperationResponseContract<int> MarkReportAsFavourite(int userId, short reportId);
        List<UsersSavedReportParameterCollection> GetListOfParametersForFavouriteReport(int userId, int reportId);
        FavouriteReportContract GetFavouriteReport(int favouriteReportId);
        bool CheckArchiveCMAndLKR(int containerInstanceId);

        #endregion
    }
}
