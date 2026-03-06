using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class RoleData 
	{
        public RoleData()
        {
        }
        /// <summary>
        /// Gets or sets Permissions
        /// </summary>
        public IEnumerable<PermissionData> Permissions { get; set; }
    }
}
		