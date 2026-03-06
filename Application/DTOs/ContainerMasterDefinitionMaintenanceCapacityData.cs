using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class ContainerMasterDefinitionMaintenanceCapacityData 
	{
        public ContainerMasterDefinitionMaintenanceCapacityData(IContainerMasterDefinitionMaintenanceCapacity genericObj, string modifiedByUserFullName) : this(genericObj)
        {
            ModifiedByUserFullName = modifiedByUserFullName;
        }
        /// <summary>
        /// Gets or sets ModifiedByUserFullName
        /// </summary>
        public string ModifiedByUserFullName { get; set; }
    }
}
		