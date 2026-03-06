using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Linq.Expressions;
using SynergyApplicationFrameworkApi.Framework.Encryption;
using SynergyApplicationFrameworkApi.Framework;
using SynergyApplicationFrameworkApi.Entities;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class UserExtentions
    {
        /// <summary>
        /// FullName operation
        /// </summary>
        public static string FullName(this User? user)
        {
            return user == null
                ? string.Empty
                : string.Format("{0} {1}", user.FirstName, user.Surname).Trim();
        }

        /// <summary>
        /// HasPinExpired operation
        /// </summary>
        public static bool HasPinExpired(this User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return (DateTime.UtcNow.Date - user.LastPinChange.Date).TotalDays > 30;
        }

        /// <summary>
        /// HasLoggedInRecently operation
        /// </summary>
        public static bool HasLoggedInRecently(this User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.LastLogin <= new DateTime(1990, 1, 1) ||
                   (DateTime.UtcNow.Date - user.LastLogin.Date).TotalDays < 60;
        }

        /// <summary>
        /// IsArchived operation
        /// </summary>
        public static bool IsArchived(this User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.Archived != null;
        }

        /// <summary>
        /// IsAccessDenied operation
        /// </summary>
        public static bool IsAccessDenied(this User user, int passwordChangeExpiryMinutes)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.IsArchived() || user.IsLockedOut || HasPasswordExpiredBeyondChangePeriod(user, passwordChangeExpiryMinutes);
        }

        /// <summary>
        /// HasMinimumPermission operation
        /// </summary>
        public static bool HasMinimumPermission(this User user)
        {
            var permissions = new[] { KnownPermission.AdminAdministrator, KnownPermission.AdminUser, KnownPermission.SynergyCustomerAdministrator, KnownPermission.SynergyCustomerUser };
            if (user.HasAnyPermission(permissions))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// HasPasswordExpired operation
        /// </summary>
        public static bool HasPasswordExpired(this User user, int maxDays, bool isEnforced)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.IsExpired || ((isEnforced || user.HasAnyExternalPermission()) && Math.Abs((DateTime.UtcNow - user.LastPasswordChange).TotalDays) >= maxDays);
        }

        /// <summary>
        /// HasTooManyIncorrectAttempts operation
        /// </summary>
        public static bool HasTooManyIncorrectAttempts(this User user, int maxAttempts)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.PasswordAttempts >= maxAttempts;
        }

        /// <summary>
        /// HasPasswordExpiredBeyondChangePeriod operation
        /// </summary>
        public static bool HasPasswordExpiredBeyondChangePeriod(this User user, int passwordChangeExpiryMinutes)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.IsExpired && (DateTime.UtcNow - user.LastPasswordChange).TotalMinutes > passwordChangeExpiryMinutes;
        }

        /// <summary>
        /// ChangePassword operation
        /// </summary>
        public static ChangePasswordResult ChangePassword(this User user, string currentPassword, string newPassword, string confirmNewPassword, int previousPasswordsToCheck, int maxPasswordAttempts, bool isEnforced, int maxBreachLimit, int breachPolicy, IPathwayRepository repository, out bool recordLoginAudit)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            var result = ValidateChangePasswordParameters(user, currentPassword, newPassword, confirmNewPassword, previousPasswordsToCheck, maxPasswordAttempts, isEnforced, maxBreachLimit, breachPolicy, repository, out recordLoginAudit);

            if (result != ChangePasswordResult.Success)
            {
                return result;
            }

            user.ResetPasswordAttempts(repository);
            user.CreateNewPasswordHistory(newPassword, repository);

            var now = DateTime.UtcNow;
            user.LastPasswordChange = now;
            user.LastLogin = now;
            user.IsExpired = false;
            repository.Save(user);
            repository.CommitChanges();

            result = ChangePasswordResult.Success;
            recordLoginAudit = true;

            return result;
        }

        private static ChangePasswordResult ValidateChangePasswordParameters(User user, string currentPassword, string newPassword, string confirmNewPassword, int passwordsToCheck, int maxPasswordAttempts, bool isEnforced, int maxBreachLimit, int breachPolicy, IPathwayRepository repository, out bool recordLoginAudit)
        {
            var result = ChangePasswordResult.Success;
            recordLoginAudit = false;

            if (string.IsNullOrEmpty(currentPassword))
            {
                result |= ChangePasswordResult.FailedOnCurrentPasswordRequired;
            }

            if (string.IsNullOrEmpty(newPassword))
            {
                result |= ChangePasswordResult.FailedOnNewPasswordRequired;
            }

            if (string.IsNullOrEmpty(confirmNewPassword))
            {
                result |= ChangePasswordResult.FailedOnConfirmNewPasswordRequired;
            }

            if (result != ChangePasswordResult.Success)
            {
                return result;
            }

            if (!user.ValidatePassword(currentPassword, repository))
            {
                user.UpdatePasswordAttempts(maxPasswordAttempts, repository);
                result |= ChangePasswordResult.FailedOnCurrentPasswordInvalid;
            }

            if (newPassword != confirmNewPassword)
            {
                result |= ChangePasswordResult.FailedOnNewPasswordMatch;
            }

            if (result != ChangePasswordResult.Success)
            {
                return result;
            }

            if (user.IsPreviousPassword(newPassword, passwordsToCheck, isEnforced, repository))
            {
                result |= ChangePasswordResult.FailedOnNewPasswordReuse;
            }

            if (!PasswordManager.MeetsMinumumComplexity(newPassword))
            {
                result |= ChangePasswordResult.FailedOnNewPasswordComplexity;
            }

            if (user.IsBreachedPassword(newPassword, maxBreachLimit, breachPolicy > 0))
            {
                recordLoginAudit = true;
                if (breachPolicy == 1)
                {
                    result |= ChangePasswordResult.FailedOnNewPasswordBreached;
                }
            }

            return result;
        }

        /// <summary>
        /// IsPreviousPassword operation
        /// </summary>
        public static bool IsPreviousPassword(this User user, string input, int passwordsToCheck, bool isEnforced, IPathwayRepository repository)
        {
            if (isEnforced || user.HasAnyExternalPermission())
            {
                var ninetyDaysAgo = DateTime.UtcNow.AddDays(-90);
                Expression<Func<UserPasswordHistory, bool>> expr = uph => uph.UserId == user.UserId;
                Expression<Func<UserPasswordHistory, bool>> expr1 = uph => uph.UserId == user.UserId && uph.CreatedDate >= ninetyDaysAgo;
                var userPasswordHistory = repository.Where(expr).OrderByDescending(uph => uph.CreatedDate).Take(passwordsToCheck + 1).Select(uph => new { uph.Password, uph.Salt, uph.Iterations }).Union(repository.Where(expr1).OrderByDescending(uph => uph.CreatedDate).Select(uph => new { uph.Password, uph.Salt, uph.Iterations })).ToList();

                foreach (var uph in userPasswordHistory)
                {
                    var rfc = Encryption.Encrypt(input, uph.Salt, uph.Iterations);
                    if (uph.Password == Convert.ToBase64String(rfc.Hash))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// IsBreachedPassword operation
        /// </summary>
        public static bool IsBreachedPassword(this User user, string input, int maxBreachLimit, bool isEnforced)
        {
            if (!isEnforced)
                return false;

            var breachoccurrances = Task.Run(() => PasswordManager.GetBreachCountAsync(input)).Result;

            return breachoccurrances > maxBreachLimit;
        }
        /// <summary>
        /// CreateNewPasswordHistory operation
        /// </summary>
        public static void CreateNewPasswordHistory(this User user, string input, IPathwayRepository repository)
        {
            var now = DateTime.UtcNow;

            var rfc2898 = Encryption.Encrypt(input);
            var uph = new UserPasswordHistory
            {
                CreatedDate = now,
                Iterations = rfc2898.Iterations,
                Password = Convert.ToBase64String(rfc2898.Hash),
                Salt = Convert.ToBase64String(rfc2898.Salt),
                UserId = user.UserId
            };

            repository.Save(uph);
            repository.CommitChanges();

            user.UserPasswordHistoryId = uph.UserPasswordHistoryId;
            user.Password = null;

            repository.Save(user);
            repository.CommitChanges();
        }

        /// <summary>
        /// ValidatePassword operation
        /// </summary>
        public static bool ValidatePassword(this User user, string input, IPathwayRepository repository)
        {
            var result = false;

            if (user.Password != null)
            {
                if (user.Password == input.LegacyEncrypt())
                {
                    user.CreateNewPasswordHistory(input, repository);
                    result = true;
                }
            }
            else
            {
                Expression<Func<UserPasswordHistory, bool>> expr = uph => uph.UserPasswordHistoryId == user.UserPasswordHistoryId.Value;

                var userPasswordHistory = repository.Where(expr).SingleOrDefault();
                if (userPasswordHistory != null)
                {
                    var encryptedPassword = Convert.ToBase64String(Encryption.Encrypt(input, userPasswordHistory.Salt, userPasswordHistory.Iterations).Hash);

                    if (userPasswordHistory.Password == encryptedPassword)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// UpdatePasswordAttempts operation
        /// </summary>
        public static void UpdatePasswordAttempts(this User user, int maxAttempts, IPathwayRepository repository)
        {
            user.PasswordAttempts++;

            if (user.PasswordAttempts >= maxAttempts && user.HasAnyExternalPermission())
            {
                user.IsSoftLockedOut = true;
                user.SoftLockOutDate = DateTime.UtcNow;
            }

            repository.Save(user);
            repository.CommitChanges();
        }

        /// <summary>
        /// ResetPasswordAttempts operation
        /// </summary>
        public static void ResetPasswordAttempts(this User user, IPathwayRepository repository)
        {
            user.PasswordAttempts = 0;
            user.IsSoftLockedOut = false;
            user.SoftLockOutDate = null;

            repository.Save(user);
            repository.CommitChanges();
        }

        /// <summary>
        /// ConvertToPrincipal operation
        /// </summary>
        public static IPrincipal ConvertToPrincipal(this User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var identity = new GenericIdentity(user.UserName, "Synergy");

            var roles = user.UserRoles.Select(ur => ur.Role.Text).Distinct().ToArray();

            var principal = new GenericPrincipal(identity, roles);

            return principal;
        }

        /// <summary>
        /// SoftLockOutPreventLogin operation
        /// </summary>
        public static bool SoftLockOutPreventLogin(this User user, int softLockOutMins)
        {
            if (user == null)
            {
                return false;
            }

            if (user.IsSoftLockedOut && user.SoftLockOutDate == null)
            {
                user.SoftLockOutDate = DateTime.UtcNow;
            }

            return user.IsSoftLockedOut && (DateTime.UtcNow - user.SoftLockOutDate.Value).TotalMinutes <= softLockOutMins;
        }

        /// <summary>
        /// Added GetPermissionList as GetPermissions links to out-of-date enum, this method pulls text values from the DB
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <summary>
        /// GetPermissionList operation
        /// </summary>
        public static IList<String> GetPermissionList(this User user)
        {
            var userPermissions = user.UserRoles
                .SelectMany(ur => ur.Role.RolePermissions)
                .Select(rp => rp.Permission.Text)
                .Distinct()
                .ToList();

            return userPermissions;
        }

        /// <summary>
        /// GetPermissions operation
        /// </summary>
        public static IList<KnownPermission> GetPermissions(this User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var userPermissions = user.UserRoles
                .SelectMany(ur => ur.Role.RolePermissions)
                .Select(rp => rp.PermissionId)
                .Distinct()
                .ToList()
                .ConvertAll(p => (KnownPermission)p);

            return userPermissions;
        }

        /// <summary>
        /// IsNewUser operation
        /// </summary>
        public static bool IsNewUser(this User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.Created.AddDays(7).Date > DateTime.UtcNow.Date;
        }

        #region General Permission Checking

        /// <summary>
        /// HasPermission operation
        /// </summary>
        public static bool HasPermission(this User user, params int[] permission)
        {
            return HasPermission(user, permission?.Select(p => (KnownPermission)p).ToArray());
        }

        /// <summary>
        /// HasPermission operation
        /// </summary>
        public static bool HasPermission(this User user, params KnownPermission[] permission)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (permission == null || permission.Length == 0)
            {
                return true;
            }

            var userPermissions = user.GetPermissions();

            if (userPermissions.Contains(KnownPermission.Administrator))
            {
                return true;
            }

            var auth =
                from up in userPermissions
                join rp in permission on up equals rp
                select up;

            return auth.Count() == permission.Count();
        }

        /// <summary>
        /// HasAnyPermission operation
        /// </summary>
        public static bool HasAnyPermission(this User user, params int[] permission)
        {
            return HasAnyPermission(user, permission?.Select(p => (KnownPermission)p).ToArray());
        }

        /// <summary>
        /// HasAnyPermission operation
        /// </summary>
        public static bool HasAnyPermission(this User user, params KnownPermission[] permission)
        {
            if (user == null)
            {
                return false;
            }

            if (permission == null || permission.Length == 0)
            {
                return true;
            }

            var userPermissions = user.GetPermissions();

            if (userPermissions.Contains(KnownPermission.Administrator))
            {
                return true;
            }

            var auth =
                from up in userPermissions
                join rp in permission on up equals rp
                select up;

            return auth.Any();
        }

        /// <summary>
        /// IsSystemAdministrator operation
        /// </summary>
        public static bool IsSystemAdministrator(this User? user)
        {
            return user?.HasPermission(KnownPermission.Administrator) ?? false;
        }

        /// <summary>
        /// HasAnyExternalPermission operation
        /// </summary>
        public static bool HasAnyExternalPermission(this User user)
        {
            KnownPermission[] permissions = { KnownPermission.AdminUser, KnownPermission.FinanceUser };

            return user.HasAnyPermission(permissions);
        }

        #endregion

        #region "Customer" Permission Checking

        /// <summary>
        /// HasCustomerPermission operation
        /// </summary>
        public static bool HasCustomerPermission(this User user, params int[] permission)
        {
            return HasCustomerPermission(user, permission?.Select(p => (KnownPermission)p).ToArray());
        }

        /// <summary>
        /// HasCustomerPermission operation
        /// </summary>
        public static bool HasCustomerPermission(this User user, params KnownPermission[] permission)
        {
            if (user.HasPermission(KnownPermission.SynergyCustomerAdministrator))
            {
                return true;
            }

            return user.HasPermission(KnownPermission.SynergyCustomerUser) && user.HasPermission(permission);
        }

        /// <summary>
        /// HasAnyCustomerPermission operation
        /// </summary>
        public static bool HasAnyCustomerPermission(this User user, params int[] permission)
        {
            return HasAnyCustomerPermission(user, permission?.Select(p => (KnownPermission)p).ToArray());
        }

        /// <summary>
        /// HasAnyCustomerPermission operation
        /// </summary>
        public static bool HasAnyCustomerPermission(this User user, params KnownPermission[] permission)
        {
            if (user == null)
            {
                return false;
            }

            if (permission == null || permission.Length == 0)
            {
                return true;
            }

            var userPermissions = user.GetPermissions();

            if (userPermissions.Contains(KnownPermission.Administrator) || userPermissions.Contains(KnownPermission.SynergyCustomerAdministrator))
            {
                return true;
            }

            if (!userPermissions.Contains(KnownPermission.SynergyCustomerUser))
            {
                return false;
            }

            var auth =
                from up in userPermissions
                join rp in permission on up equals rp
                select up;

            return auth.Any();
        }

        #endregion

        #region "SynergyTrak" Permission Checking

        /// <summary>
        /// HasSynergyTrakPermission operation
        /// </summary>
        public static bool HasSynergyTrakPermission(this User user, params int[] permission)
        {
            return HasSynergyTrakPermission(user, permission?.Select(p => (KnownPermission)p).ToArray());
        }

        /// <summary>
        /// HasSynergyTrakPermission operation
        /// </summary>
        public static bool HasSynergyTrakPermission(this User user, params KnownPermission[] permission)
        {
            if (user.HasPermission(KnownPermission.OperativeAdministrator))
            {
                return true;
            }

            if (!user.HasPermission(KnownPermission.OperativeUser))
            {
                return false;
            }

            return user.HasPermission(permission);
        }

        /// <summary>
        /// HasAnySynergyTrakPermission operation
        /// </summary>
        public static bool HasAnySynergyTrakPermission(this User user, params int[] permission)
        {
            return HasAnySynergyTrakPermission(user, permission == null ? null : permission.Select(p => (KnownPermission)p).ToArray());
        }

        /// <summary>
        /// HasAnySynergyTrakPermission operation
        /// </summary>
        public static bool HasAnySynergyTrakPermission(this User user, params KnownPermission[] permission)
        {
            if (user == null)
                return false;

            if (permission == null || permission.Length == 0)
                return true;

            var userPermissions = user.GetPermissions();

            if (userPermissions.Contains(KnownPermission.Administrator) || userPermissions.Contains(KnownPermission.OperativeAdministrator))
            {
                return true;
            }

            if (!userPermissions.Contains(KnownPermission.OperativeUser))
            {
                return false;
            }

            var auth =
                from up in userPermissions
                join rp in permission on up equals rp
                select up;

            return auth.Any();
        }

        #endregion

        #region "Administration" Permission Checking

        /// <summary>
        /// HasAdministrationPermission operation
        /// </summary>
        public static bool HasAdministrationPermission(this User user, params int[] permission)
        {
            return HasAdministrationPermission(user, permission?.Select(p => (KnownPermission)p).ToArray());
        }

        /// <summary>
        /// HasAdministrationPermission operation
        /// </summary>
        public static bool HasAdministrationPermission(this User user, params KnownPermission[] permission)
        {
            if (user.HasPermission(KnownPermission.AdminAdministrator))
            {
                return true;
            }

            if (!user.HasPermission(KnownPermission.AdminUser))
            {
                return false;
            }

            return user.HasPermission(permission);
        }

        /// <summary>
        /// HasAnyAdministrationPermission operation
        /// </summary>
        public static bool HasAnyAdministrationPermission(this User user, params int[] permission)
        {
            return HasAnyAdministrationPermission(user, permission == null ? null : permission.Select(p => (KnownPermission)p).ToArray());
        }

        /// <summary>
        /// HasAnyAdministrationPermission operation
        /// </summary>
        public static bool HasAnyAdministrationPermission(this User user, params KnownPermission[] permission)
        {
            if (user == null)
                return false;

            if (permission == null || permission.Length == 0)
                return true;

            var userPermissions = user.GetPermissions();

            if (userPermissions.Contains(KnownPermission.Administrator) || userPermissions.Contains(KnownPermission.AdminAdministrator))
            {
                return true;
            }

            if (!userPermissions.Contains(KnownPermission.AdminUser))
            {
                return false;
            }

            var auth =
                from up in userPermissions
                join rp in permission on up equals rp
                select up;

            return auth.Any();
        }

        #endregion

        #region Reporting Checks

        /// <summary>
        /// HasReportingPermission operation
        /// </summary>
        public static bool HasReportingPermission(this User user)
        {
            return HasAnyPermission(user,
                KnownPermission.ReadReport,
                KnownPermission.ReportingUser,
                KnownPermission.ReportingAdministrator,
                KnownPermission.SynergyCustomerAdministrator,
                KnownPermission.AdminAdministrator);
        }

        #endregion

        #region DateTime Extensions

        /// <summary>
        /// GetShortDateTimeFormat operation
        /// </summary>
        public static string GetShortDateTimeFormat(this User user)
        {
            return user.DateTimeFormat.ShortDateFormat.Text + " " + user.DateTimeFormat.ShortTimeFormat.Text;
        }

        /// <summary>
        /// GetLongDateTimeFormat operation
        /// </summary>
        public static string GetLongDateTimeFormat(this User user)
        {
            return user.DateTimeFormat.LongDateFormat.Text + " " + user.DateTimeFormat.LongTimeFormat.Text;
        }

        /// <summary>
        /// GetShortDateFormat operation
        /// </summary>
        public static string GetShortDateFormat(this User user)
        {
            return user.DateTimeFormat.ShortDateFormat.Text;
        }

        /// <summary>
        /// GetLongDateFormat operation
        /// </summary>
        public static string GetLongDateFormat(this User user)
        {
            return user.DateTimeFormat.LongDateFormat.Text;
        }

        /// <summary>
        /// GetShortTimeFormat operation
        /// </summary>
        public static string GetShortTimeFormat(this User user)
        {
            return user.DateTimeFormat.ShortTimeFormat.Text;
        }

        /// <summary>
        /// GetLongTimeFormat operation
        /// </summary>
        public static string GetLongTimeFormat(this User user)
        {
            return user.DateTimeFormat.LongTimeFormat.Text;
        }

        /// <summary>
        /// GetShortBootstrapDateTimeFormat operation
        /// </summary>
        public static string GetShortBootstrapDateTimeFormat(this User user)
        {
            return GetShortDateFormat(user) + " " + StringConstants.BootstrapTimeFormat;
        }

        /// <summary>
        /// GetLongBootstrapDateTimeFormat operation
        /// </summary>
        public static string GetLongBootstrapDateTimeFormat(this User user)
        {
            return GetLongDateFormat(user) + " " + StringConstants.BootstrapTimeFormat;
        }

        /// <summary>
        /// GetTimeDifference operation
        /// </summary>
        public static int GetTimeDifference(this User user)
        {
            var now = DateTimeOffset.UtcNow;
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(user.TimeZone.Text);
            var result = timeZoneInfo.GetUtcOffset(now);

            return result.Hours;
        }

        #endregion
    }
}