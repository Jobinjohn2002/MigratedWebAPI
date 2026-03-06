using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyUserHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(User concreteUser, User genericUser)
        {
            concreteUser.UserId = genericUser.UserId;
            concreteUser.ArchivedUserId = genericUser.ArchivedUserId;
            concreteUser.CreatedUserId = genericUser.CreatedUserId;
            concreteUser.UserCategoryId = genericUser.UserCategoryId;
            concreteUser.FirstName = genericUser.FirstName;
            concreteUser.Surname = genericUser.Surname;
            concreteUser.Password = genericUser.Password;
            concreteUser.ExternalId = genericUser.ExternalId;
            concreteUser.UserName = genericUser.UserName;
            concreteUser.EmailAddress = genericUser.EmailAddress;
            concreteUser.Created = genericUser.Created;
            concreteUser.Archived = genericUser.Archived;
            concreteUser.IsApproved = genericUser.IsApproved;
            concreteUser.IsExpired = genericUser.IsExpired;
            concreteUser.IsLockedOut = genericUser.IsLockedOut;
            concreteUser.IsOnline = genericUser.IsOnline;
            concreteUser.LastActivity = genericUser.LastActivity;
            concreteUser.LastLockout = genericUser.LastLockout;
            concreteUser.LastLogin = genericUser.LastLogin;
            concreteUser.LastPasswordChange = genericUser.LastPasswordChange;
            concreteUser.PasswordQuestion = genericUser.PasswordQuestion;
            concreteUser.IndependentQualityAssuranceCheck = genericUser.IndependentQualityAssuranceCheck;
            concreteUser.ProviderName = genericUser.ProviderName;
            concreteUser.Comment = genericUser.Comment;
            concreteUser.LegacyId = genericUser.LegacyId;
            concreteUser.LegacyFacilityOrigin = genericUser.LegacyFacilityOrigin;
            concreteUser.LegacyImported = genericUser.LegacyImported;
            concreteUser.Position = genericUser.Position;
            concreteUser.Title = genericUser.Title;
            concreteUser.Telephone = genericUser.Telephone;
            concreteUser.IsProtected = genericUser.IsProtected;
            concreteUser.CustomerGroupId = genericUser.CustomerGroupId;
            concreteUser.SystemId = genericUser.SystemId;
            concreteUser.Pin = genericUser.Pin;
            concreteUser.LastPinChange = genericUser.LastPinChange;
            concreteUser.PinAttempts = genericUser.PinAttempts;
            concreteUser.IsPinExpired = genericUser.IsPinExpired;
            concreteUser.TenancyId = genericUser.TenancyId;
            concreteUser.DateTimeFormatId = genericUser.DateTimeFormatId;
            concreteUser.TimeZoneId = genericUser.TimeZoneId;
            concreteUser.CultureId = genericUser.CultureId;
            concreteUser.EmployeeId = genericUser.EmployeeId;
            concreteUser.PutAwayImmediateSubmit = genericUser.PutAwayImmediateSubmit;
            concreteUser.IsSoftLockedOut = genericUser.IsSoftLockedOut;
            concreteUser.SoftLockOutDate = genericUser.SoftLockOutDate;
            concreteUser.PasswordAttempts = genericUser.PasswordAttempts;
            concreteUser.UserAccountTypeId = genericUser.UserAccountTypeId;
        }
    }
}