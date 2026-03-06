using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class PriceCategoryData 
	{
        /// <summary>
        /// Gets or sets PriceCategoryBatchCycleList
        /// </summary>
        public List<PriceCategoryBatchCycleData> PriceCategoryBatchCycleList { get; set; }
        /// <summary>
        /// Gets or sets PriceCategoryGroupId
        /// </summary>
        public int PriceCategoryGroupId { get; set; }
        /// <summary>
        /// Gets or sets CompoundIndexation
        /// </summary>
        public decimal CompoundIndexation { get; set; }
	}
}
		