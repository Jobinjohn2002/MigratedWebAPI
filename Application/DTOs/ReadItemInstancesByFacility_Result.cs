using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class ReadItemInstancesByFacility_Result
    {
        /// <summary>
        /// Gets or sets ItemInstanceId
        /// </summary>
        public int ItemInstanceId { get; set; }
        /// <summary>
        /// Gets or sets ItemInstanceIdValue
        /// </summary>
        public string ItemInstanceIdValue { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets ContainerName
        /// </summary>
        public string ContainerName { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public Nullable<long> ExternalId { get; set; }
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets LastEvent
        /// </summary>
        public string LastEvent { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterExternalId
        /// </summary>
        public string ItemMasterExternalId { get; set; }
        /// <summary>
        /// Gets or sets RowNumber
        /// </summary>
        public Nullable<int> RowNumber { get; set; }
        /// <summary>
        /// Gets or sets TotalItems
        /// </summary>
        public Nullable<int> TotalItems { get; set; }
    }
}
