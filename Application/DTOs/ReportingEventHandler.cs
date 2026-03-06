using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Administration service event handler
    /// </summary>
    /// <summary>
    /// ReportingEventHandler
    /// </summary>
    public class ReportingEventHandler : EventHandlerBase, IReportingEventHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdministrationEventHandler"/> class.
        /// </summary>
        /// <param name="operativeWorkUnit">The operative work unit.</param>
        /// <remarks></remarks>
        internal ReportingEventHandler(IUnitOfWork operativeWorkUnit) : base(operativeWorkUnit)
        {

        }

        #region IReportingEventHandler Members

        /// <summary>
        /// Reads the report categories.
        /// </summary>
        /// <summary>
        /// ReadAllReportCategories operation
        /// </summary>
        public IList<ReportCategory> ReadAllReportCategories()
        {
            var reportCategoryDataAdapter = DataAdapterFactory.GetReportCategoryDataAdapter(OperativeWorkUnit);
            return reportCategoryDataAdapter.GetAllReportCategory().ToList();
        }

        /// <summary>
        /// Reads all live reports that a user can have access to via Tenancy or Facility level access.
        /// </summary>
        /// <summary>
        /// ReadAllReports operation
        /// </summary>
        public IList<IReport> ReadAllReports(int userId)
        {
            var reportDataAdapter = DataAdapterFactory.GetReportDataAdapter(OperativeWorkUnit);
            return reportDataAdapter.GetAllLiveReports(userId).ToList();
        }

        /// <summary>
        /// Reads the reports by user uid.
        /// </summary>
        /// <param name="userId">The user uid.</param>
        /// <summary>
        /// ReadReportsByUserId operation
        /// </summary>
        public IList<IUserReport> ReadReportsByUserId(int userId)
        {
            var reportDataAdapter = DataAdapterFactory.GetUserReportDataAdapter(OperativeWorkUnit);
            return reportDataAdapter.GetAllReportsByUserId(userId).ToList();
        }

        /// <summary>
        /// Reads the report.
        /// </summary>
        /// <param name="reportIndexid">The report index id.</param>
        /// <summary>
        /// ReadReport operation
        /// </summary>
        public IReport ReadReport(short reportIndexid)
        {
            var reportDataAdapter = DataAdapterFactory.GetReportDataAdapter(OperativeWorkUnit);
            return reportDataAdapter.GetReport(reportIndexid);
        }

        /// <summary>
        /// Validate User Credentials
        /// </summary>
        /// <param name="userName">User Name</param>
        /// <param name="password">Password</param>
        /// <returns>UserAuthenticationState</returns>
        /// <summary>
        /// ValidateUserCredentials operation
        /// </summary>
        public UserAuthenticationState ValidateUserCredentials(string userName, string password)
        {
            var userDataAdapter = DataAdapterFactory.GetUserDataAdapter(OperativeWorkUnit);
            var exceptedUser = userDataAdapter.GetUserByName(userName);
            if (exceptedUser == null)
            {
                return UserAuthenticationState.UserDoesnotExist;
            }

            if (!exceptedUser.Password.Equals(password))
            {
                return UserAuthenticationState.PasswordError;
            }

            if (exceptedUser.IsLockedOut)
            {
                return UserAuthenticationState.LockedOut;
            }

            return UserAuthenticationState.Successful;
        }

        /// <summary>
        /// ReadUserByName operation
        /// </summary>
        public IUser ReadUserByName(string userName)
        {
            var userDataAdapter = DataAdapterFactory.GetUserDataAdapter(OperativeWorkUnit);
            var user = userDataAdapter.GetUserByName(userName);
            return user;
        }

        /// <summary>
        /// ResetPassword operation
        /// </summary>
        public bool ResetPassword(int userId, string newPassword, bool isTemporary)
        {
            var utilityEventHandler = EventHandlerFactory.GetUtilityEventHandler(OperativeWorkUnit);
            var userDataAdapter = DataAdapterFactory.GetUserDataAdapter(OperativeWorkUnit);

            var user = utilityEventHandler.ValidateUser(userId);
            user.Password = newPassword;
            user.LastPasswordChange = DateTime.UtcNow;

            if (isTemporary)
            {
                user.IsExpired = true;
            }

            using (var transaction = new TransactionScope())
            {
                userDataAdapter.UpdateUser(user);
                transaction.Complete();
            }

            return true;
        }

        /// <summary>
        /// ResetPin operation
        /// </summary>
        public bool ResetPin(int userId, int newPin, bool isTemporary)
        {
            var utilityEventHandler = EventHandlerFactory.GetUtilityEventHandler(OperativeWorkUnit);
            var userDataAdapter = DataAdapterFactory.GetUserDataAdapter(OperativeWorkUnit);

            var user = utilityEventHandler.ValidateUser(userId);
            user.Pin = newPin.ToString();
            user.LastPinChange = DateTime.UtcNow;

            if (isTemporary)
            {
                user.IsExpired = true;
            }

            {
                userDataAdapter.UpdateUser(user);
                transaction.Complete();
            }

            return true;
        }

        /// <summary>
        /// Reads the reports by parent report category id.
        /// </summary>
        /// <param name="parentReportCategoryId">The parent report category id.</param>
        /// <summary>
        /// ReadReportsByParentReportCategorId operation
        /// </summary>
        public IList<IReport> ReadReportsByParentReportCategorId(int parentReportCategoryId)
        {
            var reportDataAdapter = DataAdapterFactory.GetReportDataAdapter(OperativeWorkUnit);
            return reportDataAdapter.GetReportsByParentReportCategory(parentReportCategoryId).ToList();
        }

        /// <summary>
        /// Reads the reports by report category id and user Id
        /// </summary>
        /// <param name="reportCategoryId">The report category id.</param>
        /// <param name="userId">user Id</param>
        /// <summary>
        /// ReadReportsByReportCategoryIdAndUserId operation
        /// </summary>
        public IList<IReport> ReadReportsByReportCategoryIdAndUserId(int reportCategoryId, int userId)
        {
            var reportDataAdapter = DataAdapterFactory.GetReportDataAdapter(OperativeWorkUnit);
            var reportList = reportDataAdapter.GetAllReportsByReportCategoryId(reportCategoryId).ToList();
            var userListReport = ReadReportsByUserId(userId);

            var reportListByUser = from report in reportList
                                   join ul in userListReport on report.ReportId equals ul.ReportId
                                   orderby report.Text
                                   select report;

            return reportListByUser.ToList();
        }

        #endregion

        private void UpdateFavouriteReportsForChange(int id, UpdateReportParameterType idType, int? userId = null)
        {
            {
                using (var context = new OperativeModelContainer())
                {
                    context.FavouriteReports_InvalidateFavouriteReportsForId
                    (
                        userId,
                        (int)idType,
                        id.ToString()
                    );
                }

                transaction.Complete();
            }
        }

        private enum UpdateReportParameterType
        {
            DeliveryPoint = 0,
            Customer = 1,
            Facility = 2
        }

        /// <summary>
        /// UpdateFavouriteReportsForFacilityUserPermissionRemoved operation
        /// </summary>
        public void UpdateFavouriteReportsForFacilityUserPermissionRemoved(int facilityId, int userId)
        {
            UpdateFavouriteReportsForChange(facilityId, UpdateReportParameterType.Facility, userId);
        }

        /// <summary>
        /// UpdateFavouriteReportsForDeliveryPointPortalUserPermissionRemoved operation
        /// </summary>
        public void UpdateFavouriteReportsForDeliveryPointPortalUserPermissionRemoved(int deliveryPointId, int userId)
        {
            UpdateFavouriteReportsForChange(deliveryPointId, UpdateReportParameterType.DeliveryPoint, userId);
        }

        /// <summary>
        /// UpdateFavouriteReportsForCustomerPortalUserPermissionRemoved operation
        /// </summary>
        public void UpdateFavouriteReportsForCustomerPortalUserPermissionRemoved(int customerDefinitionId, int userId)
        {
            UpdateFavouriteReportsForChange(customerDefinitionId, UpdateReportParameterType.Customer, userId);
        }

        /// <summary>
        /// UpdateFavouriteReportsForFacilityArchive operation
        /// </summary>
        public void UpdateFavouriteReportsForFacilityArchive(int facilityId)
        {
            UpdateFavouriteReportsForChange(facilityId, UpdateReportParameterType.Facility);
        }

        /// <summary>
        /// UpdateFavouriteReportsForDeliveryPointArchive operation
        /// </summary>
        public void UpdateFavouriteReportsForDeliveryPointArchive(int deliveryPointId)
        {
            UpdateFavouriteReportsForChange(deliveryPointId, UpdateReportParameterType.DeliveryPoint);
        }

        /// <summary>
        /// UpdateFavouriteReportsForCustomerArchive operation
        /// </summary>
        public void UpdateFavouriteReportsForCustomerArchive(int customerId)
        {
            UpdateFavouriteReportsForChange(customerId, UpdateReportParameterType.Customer);
        }
    }
}