using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UserPermissionInfo
    /// </summary>
    public class UserPermissionInfo
    {
        /// <summary>
        /// Gets or sets PermissionId
        /// </summary>
        public int PermissionId { get; set; }
        /// <summary>
        /// Gets or sets Permission
        /// </summary>
        public string Permission { get; set; }
    }
}
