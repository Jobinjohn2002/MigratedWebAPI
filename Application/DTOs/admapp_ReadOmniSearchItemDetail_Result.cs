using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class admapp_ReadOmniSearchItemDetail_Result
    {
        /// <summary>
        /// Gets or sets ItemMasterId
        /// </summary>
        public int ItemMasterId { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets SubType
        /// </summary>
        public string SubType { get; set; }
        /// <summary>
        /// Gets or sets BaseType
        /// </summary>
        public string BaseType { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets IsArchived
        /// </summary>
        public int IsArchived { get; set; }
    }
}
