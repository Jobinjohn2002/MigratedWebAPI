using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UserRolesModel
    /// </summary>
    public class UserRolesModel
    {
        public UserRolesModel()
        {
            SelectedRoles = new List<int>();
            Roles = new List<Role>();
        }

        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets SelectedRoles
        /// </summary>
        public List<int> SelectedRoles { get; set; }
        /// <summary>
        /// Gets or sets Roles
        /// </summary>
        public List<Role> Roles { get; set; }
    }
}