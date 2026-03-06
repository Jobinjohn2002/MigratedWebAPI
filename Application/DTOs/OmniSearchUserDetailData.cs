using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// OmniSearchUserDetailData
    /// </summary>
    public class OmniSearchUserDetailData
    {
        public OmniSearchUserDetailData()
        { }

        public OmniSearchUserDetailData(int userId,
                                      string firstName,
                                      string surname,
                                      string externalId,
                                      string emailAddress,
                                      DateTime creationDate,
                                      bool isLockedOut,
                                      bool? isExpired)
        {
            UserUid = userId;
            FirstName = firstName;
            Surname = surname;
            ExternalId = externalId;
            EmailAddress = emailAddress;
            CreationDate = creationDate;
            IsLockedOut = isLockedOut;
            IsExpired = isExpired;
        }

        public OmniSearchUserDetailData(int userId,
                                   string firstName,
                                   string surname,
                                   string externalId,
                                   string emailAddress,
                                   DateTime creationDate,
                                   bool isLockedOut,
                                   bool? isExpired, string userName)
            : this(userId, firstName, surname, externalId, emailAddress, creationDate, isLockedOut, isExpired)
        {
            UserName = userName;

        }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>The user id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets UserUid
        /// </summary>
        public int UserUid { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>Then first name.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>The surname.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the external id.
        /// </summary>
        /// <value>The external id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>The email address.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets EmailAddress
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>The creation date.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CreationDate
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets status of locked out .
        /// </summary>
        /// <value>The status of locked out.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets IsLockedOut
        /// </summary>
        public bool IsLockedOut { get; set; }

        /// <summary>
        /// Gets or sets the status of expiried.
        /// </summary>
        /// <value>The status of expiried.</value>
        /// <remarks></remarks>
        public bool? IsExpired { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        /// <value>The user name.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets UserName
        /// </summary>
        public string UserName { get; set; }
         /// Gets or sets the Archived .
         /// </summary>
         /// <value>The Archived .</value>
         /// <remarks></remarks>
         public DateTime? Archived { get; set; }
    }
}
