using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class CustomerDefectContract 
	{
        /// <summary>
        /// Gets or sets ClassificationName
        /// </summary>
        public string ClassificationName { get; set; }
        /// <summary>
        /// Gets or sets DefectType
        /// </summary>
        public string DefectType { get; set; }
        /// <summary>
        /// Gets or sets DefectTypeName
        /// </summary>
        public string DefectTypeName { get; set; }
	}
}
		