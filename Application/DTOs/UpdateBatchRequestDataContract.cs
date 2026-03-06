using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UpdateBatchRequestDataContract
    /// </summary>
    public class UpdateBatchRequestDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets BatchId
        /// </summary>
        public int BatchId { get; set; }
        /// <summary>
        /// Gets or sets BatchStatusId
        /// </summary>
        public int BatchStatusId { get; set; }
    }
}