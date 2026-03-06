using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OrderLineManagementRequest
    /// </summary>
    public class OrderLineManagementRequest : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets OrderId
        /// </summary>
        public int OrderId { get; set; }
        public DateTime? OrderModifiedDate { get; set; }
        /// <summary>
        /// Gets or sets ScanDetail
        /// </summary>
        public ScanDetails ScanDetail { get; set; }
    }
}