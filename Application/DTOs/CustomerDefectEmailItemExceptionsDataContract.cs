using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustomerDefectEmailItemExceptionsDataContract
    /// </summary>
    public class CustomerDefectEmailItemExceptionsDataContract
    {
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets BaseItemTypeName
        /// </summary>
        public string BaseItemTypeName { get; set; }
        /// <summary>
        /// Gets or sets ChildItemTypeName
        /// </summary>
        public string ChildItemTypeName { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets ReasonName
        /// </summary>
        public string ReasonName { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptionQuantity
        /// </summary>
        public int ItemExceptionQuantity { get; set; }
    }
}