using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ReassignBatchRequestDataContract
    /// </summary>
    public class ReassignBatchRequestDataContract : CreateBatchRequestDataContract
    {
        /// <summary>
        /// Gets or sets BatchId
        /// </summary>
        public int BatchId { get; set; }
        /// <summary>
        /// Gets or sets IsFailBatch
        /// </summary>
        public bool IsFailBatch { get; set; }
        /// <summary>
        /// Gets or sets StationTypeId
        /// </summary>
        public int StationTypeId { get; set; }
        /// <summary>
        /// Gets or sets IsApplyingEvent
        /// </summary>
        public bool IsApplyingEvent { get; set; }
    }
}