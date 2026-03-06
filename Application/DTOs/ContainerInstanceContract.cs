using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class ContainerInstanceContract 
	{
        /// <summary>
        /// Gets or sets CreatedUserName
        /// </summary>
        public string CreatedUserName { get; set; }
        /// <summary>
        /// Gets or sets ArchivedUserName
        /// </summary>
        public string ArchivedUserName { get; set; }
	}
}
		