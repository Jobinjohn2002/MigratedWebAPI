using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// Reporting event handler
    /// </summary>
    /// <summary>
    /// IReportingEventHandler
    /// </summary>
    public interface IReportingEventHandler
    {
        /// <summary>
        /// load all facility notes from specific facility
        /// </summary>
        /// <returns>List of Facility Notes</returns>
        IList<ReportCategory> ReadAllReportCategories();

        /// <summary>
        /// Reads all reports.
        /// </summary>
        IList<IReport> ReadAllReports(int userId);

        /// <summary>
        /// Reads the reports by user uid.
        /// </summary>
        /// <param name="userId">The user uid.</param>
        IList<IUserReport> ReadReportsByUserId(int userId);

        /// <summary>
        /// Reads the report.
        /// </summary>
        /// <param name="reportId">The report Id.</param>
        IReport ReadReport(short reportId);

        /// <summary>
        /// Validate User Credentials
        /// </summary>
        /// <param name="userName">User Name</param>
        /// <param name="password">Password</param>
        /// <returns>UserAuthenticationState</returns>
        UserAuthenticationState ValidateUserCredentials(string userName, string password);

        /// <summary>
        /// Reads the name of the user by.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        IUser ReadUserByName(string userName);

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="newPassword">The new password.</param>
        /// <param name="isTemporary">if set to <c>true</c> [is temporary].</param>
        bool ResetPassword(int userId, string newPassword, bool isTemporary);

        /// <summary>
        /// Reads the reports by parent report category id.
        /// </summary>
        /// <param name="parentReportCategoryId">parent report category id</param>
        /// <returns>Reports</returns>
        IList<IReport> ReadReportsByParentReportCategorId(int parentReportCategoryId);

        /// <summary>
        /// Resets the pin.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="newPin">The new pin.</param>
        /// <param name="isTemporary">if set to <c>true</c> [is temporary].</param>
        bool ResetPin(int userId, int newPin, bool isTemporary);

        /// <summary>
        /// Reads the reports by report category id and user Id
        /// </summary>
        /// <param name="reportCategoryId">The report category id.</param>
        /// <param name="userId">user Id</param>
        IList<IReport> ReadReportsByReportCategoryIdAndUserId(int reportCategoryId, int userId);

        void UpdateFavouriteReportsForFacilityUserPermissionRemoved(int facilityId, int userId);

        void UpdateFavouriteReportsForDeliveryPointPortalUserPermissionRemoved(int deliveryPointId, int userId);

        void UpdateFavouriteReportsForCustomerPortalUserPermissionRemoved(int customerDefinitionId, int userId);

        void UpdateFavouriteReportsForFacilityArchive(int facilityId);

        void UpdateFavouriteReportsForDeliveryPointArchive(int deliveryPointId);

        void UpdateFavouriteReportsForCustomerArchive(int customerId);
    }
}