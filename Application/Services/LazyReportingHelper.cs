using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public static class LazyReportingHelper
    {
        /// <summary>
        /// Converts the facility notes to datas.
        /// </summary>
        /// <param name="reportCategories">The report categories.</param>
        /// <summary>
        /// ConvertReportCategoriesToData operation
        /// </summary>
        public static IList<ReportCategoryData> ConvertReportCategoriesToData(IList<ReportCategory> reportCategories)
        {
            return reportCategories.Count() != 0
                       ? reportCategories.Select(reportCategory => new ReportCategoryData(reportCategory)).ToList()
                       : null;
        }

        /// <summary>
        /// Converts the facility notes to datas.
        /// </summary>
        /// <param name="reports">The reports.</param>
        /// <summary>
        /// ConvertReportsToData operation
        /// </summary>
        public static IList<ReportData> ConvertReportsToData(IList<IReport> reports)
        {
            return reports.Count() != 0 ? reports.Select(ConvertReportToData).ToList() : null;
        }

        /// <summary>
        /// ConvertReportToData operation
        /// </summary>
        public static ReportData ConvertReportToData(IReport report)
        {
            if (report == null)
            {
                return null;
            }

            var rpt = (Report)report;

            ReportData reportData = null;
            if (string.IsNullOrEmpty(Synergy.Core.Helpers.SettingHelper.ReportStaticUrl))
            {
                reportData = new ReportData(rpt.ReportId, rpt.ReportCategoryId, rpt.Text, rpt.Description, rpt.URL, rpt.IsLive,
                                      rpt.LegacyFacilityOrigin.GetValueOrDefault(), rpt.LegacyImported.GetValueOrDefault(), rpt.ReportTypeId, rpt.DefaultReportOutputTypeId);
            }
            else
            {
                var splitUrl = rpt.URL.Split('?');
                reportData = new ReportData(rpt.ReportId, rpt.ReportCategoryId, rpt.Text, rpt.Description, string.Format("{0}?{1}", Synergy.Core.Helpers.SettingHelper.ReportStaticUrl, splitUrl[1]), rpt.IsLive,
                                      rpt.LegacyFacilityOrigin.GetValueOrDefault(), rpt.LegacyImported.GetValueOrDefault(), rpt.ReportTypeId, rpt.DefaultReportOutputTypeId);
            }

            reportData.ReportCategoryName = rpt.ReportCategory.Text;

            return reportData;
        }

        /// <summary>
        /// Converts the user reports to data.
        /// </summary>
        /// <param name="reports">The reports.</param>
        /// <summary>
        /// ConvertUserReportsToData operation
        /// </summary>
        public static IList<UserReportData> ConvertUserReportsToData(IList<IUserReport> reports)
        {
            return reports.Count() != 0 ? reports.Select(report => new UserReportData(report)).ToList() : null;
        }

        /// <summary>
        /// Converts the defect to data contract.
        /// </summary>
        /// <param name="genericReport">The generic report.</param>
        /// <summary>
        /// ConvertReportToDataContract operation
        /// </summary>
        public static ReportData ConvertReportToDataContract(IReport genericReport)
        {
            if (genericReport == null)
            {
                return null;
            }
            return new ReportData(genericReport);
        }

        #region User

        /// <summary>
        /// Converts the user facility to user facility data.
        /// </summary>
        /// <param name="userFacility">The user facility.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserFacilityToUserFacilityData operation
        /// </summary>
        public static UserFacilityData ConvertUserFacilityToUserFacilityData(IUserFacility userFacility)
        {
            if (userFacility == null)
            {
                return null;
            }
            return new UserFacilityData(userFacility);
        }

        /// <summary>
        /// Converts the user facility to user facility data.
        /// </summary>
        /// <param name="userFacility">The user facility.</param>
        /// <param name="facilityName">Name of the facility.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserFacilityToUserFacilityData operation
        /// </summary>
        public static UserFacilityData ConvertUserFacilityToUserFacilityData(IUserFacility userFacility,
                                                                             string facilityName)
        {
            if (userFacility == null)
            {
                return null;
            }

            return new UserFacilityData(userFacility);
        }

        /// <summary>
        /// Converts the user to user data.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserToUserData operation
        /// </summary>
        public static UserData ConvertUserToUserData(IUser user)
        {
            if (user == null)
            {
                return null;
            }
            return new UserData(user);
        }

        /// <summary>
        /// Converts the user facility list to user facility data.
        /// </summary>
        /// <param name="userFacilityList">The user facility list.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserFacilityListToUserFacilityData operation
        /// </summary>
        public static IList<UserFacilityData> ConvertUserFacilityListToUserFacilityData(
            IList<IUserFacility> userFacilityList)
        {
            IList<UserFacilityData> userFacilityDatas =
                userFacilityList.Select(ConvertUserFacilityToUserFacilityData).ToList();
            return userFacilityDatas;
        }

        /// <summary>
        /// Converts the user to user data.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="userExtendedProperty">The user extended property.</param>
        /// <param name="UserFacility">The user facilities.</param>
        /// <param name="roles">The roles.</param>
        /// <param name="userPermissionsList">The user permissions list.</param>
        /// <param name="userPrinters">The user printers.</param>
        /// <param name="userItemComplexities"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserToUserData operation
        /// </summary>
        public static UserData ConvertUserToUserData(IUser user, IUserExtendedProperty userExtendedProperty,
                                                     IList<IUserFacility> UserFacility, IList<IRole> roles,
                                                     IList<IUserPrinter> userPrinters,
                                                     IList<IUserComplexity> userItemComplexities)
        {
            if (user == null)
            {
                return null;
            }

            return new UserData(user);
        }

        #endregion User

        #region role

        /// <summary>
        /// Converts the role to role data.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertRoleToRoleData operation
        /// </summary>
        public static RoleData ConvertRoleToRoleData(IRole role)
        {
            if (role == null)
            {
                return null;
            }
            return new RoleData(role);
        }

        /// <summary>
        /// Converts the role list to roles data.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertRoleListToRolesData operation
        /// </summary>
        public static IList<RoleData> ConvertRoleListToRolesData(IList<IRole> roles)
        {
            IList<RoleData> roleDatas =
                roles.Select(ConvertRoleToRoleData).ToList();
            return roleDatas;
        }

        #endregion role

        #region UserPrinter

        /// <summary>
        /// Converts the user printer to data contract.
        /// </summary>
        /// <param name="userPrinter">The user printer.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserPrinterToDataContract operation
        /// </summary>
        public static UserPrinterData ConvertUserPrinterToDataContract(IUserPrinter userPrinter)
        {
            if (userPrinter == null)
            {
                return null;
            }
            return new UserPrinterData(userPrinter);
        }

        /// <summary>
        /// Converts the user printer list to data contract.
        /// </summary>
        /// <param name="userPrinters">The user printers.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserPrinterListToDataContract operation
        /// </summary>
        public static IList<UserPrinterData> ConvertUserPrinterListToDataContract(IList<IUserPrinter> userPrinters)
        {
            return userPrinters.Select(ConvertUserPrinterToDataContract).ToList();
        }

        #endregion UserPrinter

        #region UserItemComplexity

        /// <summary>
        /// Converts the user item complexity to data contract.
        /// </summary>
        /// <param name="userItemComplexity">The user item complexity.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserItemComplexityToDataContract operation
        /// </summary>
        public static UserComplexityData ConvertUserItemComplexityToDataContract(IUserComplexity userItemComplexity)
        {
            if (userItemComplexity == null)
            {
                return null;
            }
            return new UserComplexityData(userItemComplexity);
        }

        /// <summary>
        /// Converts the user item complexity list to data contract.
        /// </summary>
        /// <param name="userItemComplexities">The user item complexities.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ConvertUserItemComplexityListToDataContract operation
        /// </summary>
        public static IList<UserComplexityData> ConvertUserItemComplexityListToDataContract(
            IList<IUserComplexity> userItemComplexities)
        {
            return userItemComplexities.Select(ConvertUserItemComplexityToDataContract).ToList();
        }

        #endregion UserItemComplexity
    }
}