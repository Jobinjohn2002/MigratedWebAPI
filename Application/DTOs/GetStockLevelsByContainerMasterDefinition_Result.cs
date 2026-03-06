using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class GetStockLevelsByContainerMasterDefinition_Result
    {
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionId
        /// </summary>
        public int ContainerMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets LocationId
        /// </summary>
        public int LocationId { get; set; }
        /// <summary>
        /// Gets or sets LocationText
        /// </summary>
        public string LocationText { get; set; }
        /// <summary>
        /// Gets or sets LocationCode
        /// </summary>
        public string LocationCode { get; set; }
        /// <summary>
        /// Gets or sets LocationExternalId
        /// </summary>
        public string LocationExternalId { get; set; }
        /// <summary>
        /// Gets or sets Count
        /// </summary>
        public Nullable<int> Count { get; set; }
    }
}
