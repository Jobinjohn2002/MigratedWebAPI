using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// User interface
    /// </summary>
    /// <summary>
    /// IUser
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>The user id.</value>
        int UserId { get; set; }

        /// <summary>
        /// Gets or sets the archived user id.
        /// </summary>
        /// <value>The archived user id.</value>
        int? ArchivedUserId { get; set; }

        /// <summary>
        /// Gets or sets the created user id.
        /// </summary>
        /// <value>The created user id.</value>
        int CreatedUserId { get; set; }

        /// <summary>
        /// Gets or sets the user category id.
        /// </summary>
        /// <value>The user category id.</value>
        byte UserCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>The surname.</value>
        string Surname { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        string Password { get; set; }

        /// <summary>
        /// Gets or sets the external id.
        /// </summary>
        /// <value>The external id.</value>
        string ExternalId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        string UserName { get; set; }
        
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>The email address.</value>
        string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>The created.</value>
        DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the archived.
        /// </summary>
        /// <value>The archived.</value>
        DateTime? Archived { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is approved.
        /// </summary>
        /// <value><c>true</c> if this instance is approved; otherwise, <c>false</c>.</value>
        bool IsApproved { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is expired.
        /// </summary>
        /// <value><c>true</c> if this instance is expired; otherwise, <c>false</c>.</value>
        bool IsExpired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is locked out.
        /// </summary>
        /// <value><c>true</c> if this instance is locked out; otherwise, <c>false</c>.</value>
        bool IsLockedOut { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is online.
        /// </summary>
        /// <value><c>true</c> if this instance is online; otherwise, <c>false</c>.</value>
        bool IsOnline { get; set; }
        
        /// <summary>
        /// Gets or sets the last activity.
        /// </summary>
        /// <value>The last activity.</value>
        DateTime LastActivity { get; set; }

        /// <summary>
        /// Gets or sets the last lockout.
        /// </summary>
        /// <value>The last lockout.</value>
        DateTime LastLockout { get; set; }

        /// <summary>
        /// Gets or sets the last login.
        /// </summary>
        /// <value>The last login.</value>
        DateTime LastLogin { get; set; }

        /// <summary>
        /// Gets or sets the last password changed.
        /// </summary>
        /// <value>The last password changed.</value>
        DateTime LastPasswordChange { get; set; }

        /// <summary>
        /// Gets or sets the password question.
        /// </summary>
        /// <value>The password question.</value>
        string PasswordQuestion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [independent quality assurance check].
        /// </summary>
        /// <value><c>true</c> if [independent quality assurance check]; otherwise, <c>false</c>.</value>
        bool IndependentQualityAssuranceCheck { get; set; }

        /// <summary>
        /// Gets or sets the name of the provider.
        /// </summary>
        /// <value>The name of the provider.</value>
        string ProviderName { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>The comment.</value>
        string Comment { get; set; }

        /// <summary>
        /// Gets or sets the legacy id.
        /// </summary>
        /// <value>The legacy id.</value>
        int? LegacyId { get; set; }

        /// <summary>
        /// Gets or sets the legacy facility origin.
        /// </summary>
        /// <value>The legacy facility origin.</value>
        int? LegacyFacilityOrigin { get; set; }

        /// <summary>
        /// Gets or sets the legacy imported.
        /// </summary>
        /// <value>The legacy imported.</value>
        DateTime? LegacyImported { get; set; }

        /// <summary>
        /// System Id used for reporting services
        /// </summary>
        Guid SystemId { get; set; }

        /// <summary>
        /// Gets or sets the Position.
        /// </summary>
        /// <value>The Position.</value>
        string Position { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        /// <value>The Title.</value>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the Telephone.
        /// </summary>
        /// <value>The Telephone.</value>
        string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the Is Protected.
        /// </summary>
        /// <value>Is Protected.</value>
        bool? IsProtected { get; set; }

        /// <summary>
        /// User CustomerGroupId
        /// </summary>
        /// <value>Is Protected.</value>
        int? CustomerGroupId { get; set; }  

        /// <summary>
        /// Gets or sets a value indicating whether this instance is expired.
        /// </summary>
        /// <value><c>true</c> if this instance is expired; otherwise, <c>false</c>.</value>
        bool? IsPinExpired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this pin is expired.
        /// </summary>
        /// <value><c>true</c> if this pin is expired; otherwise, <c>false</c>.</value>
        string Pin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this pinattempts is expired.
        /// </summary>
        /// <value><c>true</c> if this instance is pinattempts; otherwise, <c>false</c>.</value>
        int PinAttempts { get; set; }

        DateTime LastPinChange { get; set; }

        /// <summary>
        /// gets or sets primary facility id for the validated user
        /// </summary>
        int PrimaryFacilityId { get; set; }

        int TenancyId { get; set; }

        int DateTimeFormatId { get; set; }

        short TimeZoneId { get; set; }

        int? CurrentClockedInStationId { get; set; }

        int? CurrentClockedInLocationId { get; set; }

        int? CultureId { get; set; }

        string EmployeeId {get; set; }

        bool PutAwayImmediateSubmit { get; set; }
        
        int? UserPasswordHistoryId { get; set;}

        bool IsSoftLockedOut { get; set; }

        DateTime? SoftLockOutDate { get; set; }

        short PasswordAttempts { get; set; }

        int UserAccountTypeId { get; set; }
    }
}