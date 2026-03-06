using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class PriceCategoryGroupData 
	{
        /// <summary>
        /// Gets or sets ItemTypes
        /// </summary>
        public List<ItemTypeData> ItemTypes { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeIds
        /// </summary>
        public List<short> ItemTypeIds { get; set; }
	}
}
		