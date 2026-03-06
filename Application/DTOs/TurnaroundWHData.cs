using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class TurnaroundWHData 
	{
        /// <summary>
        /// Gets or sets TurnaroundCount
        /// </summary>
        public int TurnaroundCount { get; set; }
        /// <summary>
        /// Gets or sets DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }
        /// <summary>
        /// Gets or sets Priority
        /// </summary>
        public TurnaroundPriority Priority { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }

        public TurnaroundWHData()
        {
        }
	}
}
		