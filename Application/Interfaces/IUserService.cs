using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SynergyApplicationFrameworkApi.Application.Services.DataContracts;
using SynergyApplicationFrameworkApi.Application.DTOs;
using SynergyApplicationFrameworkApi.Application.DTOs;
using SynergyApplicationFrameworkApi.Application.Models;
using SynergyApplicationFrameworkApi.Application.Contracts;
using SynergyApplicationFrameworkApi.Application.Entities;
using SynergyApplicationFrameworkApi.Application.ValueObjects;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// User Service contract
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IUserService
    /// </summary>
    public interface IUserService
    {
        bool SaveCatalogueEditors(int userId, bool IsGlobalEditor, bool IsTenancyEditor, int tenancyId, bool IsFacilityEditor, int facilityId);
        IList<LookupData> ReadCatalogueEditors(int userId, int facilityId, int tenancyId);

        /// <summary>
        /// Reads the user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        UserData ReadUser(int userId);

        /// <summary>
        /// Reads a user by their username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="encryptedPassword"></param>
        /// <returns></returns>
        OperationResponseContract<UserData> Login(string username, string encryptedPassword, string encryptedNewPassword, string encryptedNewPin, string browserAgent);

        /// <summary>
        /// Archives the user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="archiveUserId">The archive user id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        OperationResponseContract ArchiveUser(int userId, int archiveUserId);

        /// <summary>
        /// UnArchives the user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="archiveUserId">The archive user id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        OperationResponseContract UnArchiveUser(int userId, int archiveUserId);

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="newPassword">The new password.</param>
        /// <param name="isTemporary">if set to <c>true</c> [is temporary].</param>
        /// <returns></returns>
        /// <remarks></remarks>
        OperationResponseContract ResetPassword(int userId, string newPassword, bool isTemporary);

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="currentPassword">The current password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <param name="isTemporary">if set to <c>true</c> [is temporary].</param>
        /// <returns></returns>
        /// <remarks></remarks>
        Pathway.DataContracts.AuthenticationContracts.ChangePasswordDataContract ChangePassword(int userId, string currentPassword, string newPassword, bool isTemporary);

        /// <summary>
        /// Unlocks the user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        OperationResponseContract UnlockUser(int userId);

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="userFacilitie">The user facilitie.</param>
        /// <param name="roles">The roles.</param>
        /// <param name="printers">The printers.</param>
        /// <param name="userItemComplexities">The user item complexities.</param>
        /// <param name="operatorId">The operator id.</param>
        /// <param name="deliveryPoints"></param>
        /// <param name="userReports"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        UserData CreateUser(UserData user, IList<UserFacilityData> userFacilitie, short[] roles, IList<UserPrinterData> printers, IList<UserComplexityData> userItemComplexities, int operatorId, List<int> deliveryPoints, List<int> userReports);

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="userFacilitie">The user facilitie.</param>
        /// <param name="roles">The roles.</param>
        /// <param name="printers">The printers.</param>
        /// <param name="userItemComplexities">The user item complexities.</param>
        /// <param name="operatorId">The operator id.</param>
        /// <param name="deliveryPoints"></param>
        /// <param name="userReports"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        OperationResponseContract UpdateUser(UserData user, IList<UserFacilityData> userFacilitie, short[] roles, IList<UserPrinterData> printers, IList<UserComplexityData> userItemComplexities, int operatorId, List<int> deliveryPoints, List<int> userReports, int currentFacilityId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cultureId"></param>
        /// <returns></returns>
        OperationResponseContract UpdateUserCulture(int userId, int cultureId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deliveryPoints"></param>
        /// <returns></returns>
        OperationResponseContract UpdateUserDeliveryPoints(int userId, List<int> deliveryPoints);
        /// <summary>
        /// Reads the user roles.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<RoleData> ReadUserRoles(int userId);

        /// <summary>
        /// Reads the user reports.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<UserReportData> ReadUserReports(int userId);

        /// <summary>
        /// Reads the role.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        RoleData ReadRole(short roleId);

        /// <summary>
        /// Creates the role.
        /// </summary>
        /// <param name="roleData">The role data.</param>
        /// <param name="rolePermissions">The role permissions.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        RoleData CreateRole(RoleData roleData, IList<RolePermissionData> rolePermissions);

        /// <summary>
        /// Updates the role.
        /// </summary>
        /// <param name="roleData">The role data.</param>
        /// <param name="rolePermissions">The role permissions.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        OperationResponseContract UpdateRole(RoleData roleData, IList<RolePermissionData> rolePermissions);

        /// <summary>
        /// Archives the role.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        /// <param name="archiveUserId">The archive user id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        OperationResponseContract ArchiveRole(short roleId, int archiveUserId);

        /// <summary>
        /// Reads all roles.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<RoleData> ReadAllRoles();

        /// <summary>
        /// Reads all permissions.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        IList<PermissionData> ReadAllPermissions();
        OperationResponseContract<UserData> ReadUserByExternalId(string externalId);

        /// <summary>
        /// Reads the user by user id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        OperationResponseContract<UserData> ReadUserByUserId(int userId);

        /// <summary>
        /// To change user's PIN
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pin"></param>
        OperationResponseContract ChangePin(int userId, string pin);

        /// <summary>
        /// Validates user pin id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pin"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        OperationResponseContract ValidatePin(int userId, string pin);

        /// <summary>
        /// Validate user pin password.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pin"></param>
        /// <returns></returns>
        OperationResponseContract ValidatePinPassword(int userId, string pin);

        /// <summary>
        /// Resets the pin.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="newPin">The new pin.</param>
        /// <param name="isTemporary">if set to <c>true</c> [is temporary].</param>
        /// <returns></returns>
        /// <remarks></remarks>
        OperationResponseContract ResetPin(int userId, int newPin, bool isTemporary);

        /// <summary>
        /// To get the current pin
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        string GetCurrentPin(int userId);

        /// <summary>
        /// Method to get only user name using user Id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        string GetUserName(int userId);

        /// <summary>
        /// Read Email Address.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="customerId"></param>
        /// <param name="deliveryPointId"></param>
        /// <returns></returns>
        EmailAddressData ReadEmailAddress(int userId, int customerId, int deliveryPointId);

        /// <summary>
        /// Reads a user by their username, password and IsFDAEnabled state of the application
        /// </summary>
        /// <param name="username"></param>
        /// <param name="encryptedPassword"></param>
        /// <param name="encryptedNewPassword"></param>
        /// <param name="encryptedNewPin"></param>
        /// <param name="appType">Enum containing the application type</param>
        /// <param name="browserAgent">String containing the browser agent</param>
        /// <returns></returns>
        OperationResponseContract<UserData> LoginWithFDAEnabledCheck(string username, string encryptedPassword, string encryptedNewPassword, string encryptedNewPin, ApplicationType appType, string browserAgent, string ipAddress);
        OperationResponseContract<UserData> AutoLogin(int userId);
        bool HasCatalogueAccess(int userId, short selectedFacilityId);
        List<RoleData> GetUserRoleExcludeList(int userId);
        bool DoesUserHavePermission(int userId, int permissionId);

        #region Feedback Methods
        bool PostFeedback(int userID, string sentiment, string feedback, string url);
        bool PostFeedbackComment(int feedbackID, int userID, string body);
        int UpvoteFeedback(int userID, int feedbackID);
        List<UserFeedback> GetFeedback(int userID, Tag[] tags, FeedbackFetchHint hint);
        List<Tag> ListAllFeedbackTags();
        bool AddTagsToFeedback(int feedbackID, Tag[] tags);
        bool RemoveTagsFromFeedback(int feedbackID, Tag[] tags);
        List<FullTag> ListTagsForFeedback(int feedbackID);
        List<Comment> GetAllCommentsForFeedback(int feedbackID);

        #endregion
        List<CultureData> GetAllCultures();

        #region Timezone Methods

        /// <summary>
        /// Fetches all synergy date time format from format table
        /// </summary>
        /// <returns></returns>
        IList<GenericKeyValueData> GetSynergyDateTimeFormats();

        /// <summary>
        /// Fetches all synergy time zones
        /// </summary>
        /// <returns></returns>
        IDictionary<short, string> GetSynergyTimeZones();

        /// <summary>
        /// Fetches all date time format settings using facilityId
        /// </summary>
        /// <returns></returns>
        DateTimeFormatData ReadTenancyDateTimeFormatData(int facilityId);

        #endregion
        void FinanceHmacAudit(int? uid, string result);
        void FailedPermissionsLoginAudit(int? uid, string userName, ApplicationType appType);
        string GetSignalRJWTTokenForUser(SignalRJWTData data);
        List<UserProductionManagerFilterDataContract> GetAllProductionManagerFilterForUserAndFacility(int userId, short facilityId);
        int SaveProductionManagerFilter(Pathway.DataContracts.UserProductionManagerFilterDataContract newFilterDC);
        int DeleteProductionManagerFilter(int userProductionManagerFilterId);
        int ChangeOrderOfUserProductionManagerFilter(int userProductionManagerFilter, int newOrderNumber);

    }
}