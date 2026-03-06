using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class admapp_ReadOmniSearchBatchDetail_Result
    {
        /// <summary>
        /// Gets or sets BatchId
        /// </summary>
        public int BatchId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets CycleTypeName
        /// </summary>
        public string CycleTypeName { get; set; }
        public System.DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets IsArchived
        /// </summary>
        public int IsArchived { get; set; }
    }
}
