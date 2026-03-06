using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [MetadataType(typeof(UserPrinterMetaData))]
    /// <summary>
    /// UserPermissionRights
    /// </summary>
    public class UserPermissionRights
    {
        /// <summary>
        /// Full constructor of UserPermissionRights 
        /// </summary>
        /// <param name="area">Permission Area Identifier</param>
        /// <param name="rights">Permission Rights</param>
        public UserPermissionRights(PermissionAreaIdentifier area, PermissionRightIdentifiers rights)
        {
            Area = area;
            Rights = rights;
        }

        /// <summary>
        /// Gets or sets Area
        /// </summary>
        public PermissionAreaIdentifier Area { get; set; }
        /// <summary>
        /// Gets or sets Rights
        /// </summary>
        public PermissionRightIdentifiers Rights { get; set; }
    }
}