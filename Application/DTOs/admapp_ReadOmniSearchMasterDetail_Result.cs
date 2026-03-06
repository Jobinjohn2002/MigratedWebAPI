using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class admapp_ReadOmniSearchMasterDetail_Result
    {
        /// <summary>
        /// Gets or sets MasterUId
        /// </summary>
        public int MasterUId { get; set; }
        /// <summary>
        /// Gets or sets MasterSubtype
        /// </summary>
        public int MasterSubtype { get; set; }
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
        /// Gets or sets LegacyInternalId
        /// </summary>
        public int LegacyInternalId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets NumberOfInstance
        /// </summary>
        public Nullable<int> NumberOfInstance { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets IsArchived
        /// </summary>
        public int IsArchived { get; set; }
    }
}
