using System.Collections.Generic;
using FavouriteReportContract = Pathway.Core.Services.DataContracts.FavouriteReportContract;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IReportingService
    /// </summary>
    public interface IReportingService
    {
        /// <summary>
        /// Reads all report categories.
        /// </summary>
        IList<ReportCategoryData> ReadAllReportCategories();

        /// <summary>
        /// Reads all reports.
        /// </summary>
        IList<ReportData> ReadAllReports(int userId);

        /// <summary>
        /// Reads the report.
        /// </summary>
        /// <param name="reportId">The report id.</param>
        IReport ReadReport(short reportId);

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="newPassword">The new password.</param>
        /// <param name="isTemporary">if set to <c>true</c> [is temporary].</param>
        OperationResponseContract ResetPassword(int userId, string newPassword, bool isTemporary);

        /// <summary>
        /// Reads the reports by parent report category id.
        /// </summary>
        /// <param name="parentReportCategoryId">The parent report category id.</param>
        IList<ReportData> ReadReportsByParentReportCategorId(int parentReportCategoryId);
        List<ReportData> GetAllReportsForUser(int userId);
        List<FavouriteReportContract> GetAllFavouriteReports(int userId);
        OperationResponseContract DeleteFavouriteReport(int favouriteReportId);
        int CreateFavouriteReport(FavouriteReportContract favouriteReportContract);
        OperationResponseContract EditFavouriteReport(FavouriteReportContract favouriteReportContract);
        List<ReportOutputTypeContract> GetReportOutputTypes(short reportId);
        OperationResponseContract<int> MarkReportAsFavourite(int userId, short reportId);
        List<UsersSavedReportParameterCollection> GetFavouriteReportParameters(int userId, int reportId);
        FavouriteReportContract GetFavouriteReport(int favouriteReportId);
    }
}