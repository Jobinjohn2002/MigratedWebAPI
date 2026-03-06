using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// OrderTemplateLineData
    /// </summary>
    public class OrderTemplateLineData
    {
        /// <summary>
        /// Gets or sets OrderTemplateLineId
        /// </summary>
        public int OrderTemplateLineId { get; set; }
        /// <summary>
        /// Gets or sets OrderTemplateId
        /// </summary>
        public int OrderTemplateId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionId
        /// </summary>
        public int ContainerMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        public int? DefaultStockLocation { get; set; }
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }
    }
}
