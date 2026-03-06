using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// Omni Search Item Detail
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IOmniSearchUserDetail
    /// </summary>
    public interface IOmniSearchUserDetail
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>The user id.</value>
        /// <remarks></remarks>
        int  UserUid { get; set; }
      
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>Then first name.</value>
        /// <remarks></remarks>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>The surname.</value>
        /// <remarks></remarks>
        string Surname { get; set; }
       
        /// <summary>
        /// Gets or sets the external id.
        /// </summary>
        /// <value>The external id.</value>
        /// <remarks></remarks>
        string ExternalId { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>The email address.</value>
        /// <remarks></remarks>
        string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>The creation date.</value>
        /// <remarks></remarks>
        DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets status of locked out .
        /// </summary>
        /// <value>The status of locked out.</value>
        /// <remarks></remarks>
        bool IsLockedOut { get; set; }

        /// <summary>
        /// Gets or sets the status of expiried.
        /// </summary>
        /// <value>The status of expiried.</value>
        /// <remarks></remarks>
        bool? IsExpired { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        /// <value>The user name.</value>
        /// <remarks></remarks>
        string UserName { get; set; }

        /// <summary>
        /// Gets or sets the Archived .
        /// </summary>
        /// <value>The Archived .</value>
        /// <remarks></remarks>
        DateTime? Archived { get; set; }
    }
}
