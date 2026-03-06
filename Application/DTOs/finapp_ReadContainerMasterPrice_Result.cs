using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class finapp_ReadContainerMasterPrice_Result
    {
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets PriceCategory
        /// </summary>
        public string PriceCategory { get; set; }
        /// <summary>
        /// Gets or sets ManualPriceCategoryDefinitionId
        /// </summary>
        public Nullable<int> ManualPriceCategoryDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ManualReprocessingPrice
        /// </summary>
        public Nullable<decimal> ManualReprocessingPrice { get; set; }
        /// <summary>
        /// Gets or sets ReprocessingPrice
        /// </summary>
        public decimal ReprocessingPrice { get; set; }
        /// <summary>
        /// Gets or sets ReprocessingIndexation
        /// </summary>
        public Nullable<decimal> ReprocessingIndexation { get; set; }
        /// <summary>
        /// Gets or sets ManualSingleUseItemPrice
        /// </summary>
        public Nullable<decimal> ManualSingleUseItemPrice { get; set; }
        /// <summary>
        /// Gets or sets SingleUseItemPrice
        /// </summary>
        public decimal SingleUseItemPrice { get; set; }
        /// <summary>
        /// Gets or sets SingleUseIndexation
        /// </summary>
        public Nullable<decimal> SingleUseIndexation { get; set; }
    }
}
