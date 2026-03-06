using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// User permission data contract.
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    /// <summary>
    /// UserPermissionRightsContract
    /// </summary>
    public class UserPermissionRightsContract
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserPermissionRightsContract"/> class.
        /// </summary>
        /// <param name="genericUserPermissionRights">The generic user permission rights.</param>
        /// <remarks></remarks>
        public UserPermissionRightsContract(IUserPermissionRights genericUserPermissionRights)
        {
        }

        #region IPrinter Members

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>The area.</value>
        /// <remarks></remarks>

        /// <summary>
        /// Gets or sets the rights.
        /// </summary>
        /// <value>The rights.</value>
        /// <remarks></remarks>

        #endregion
    }
}