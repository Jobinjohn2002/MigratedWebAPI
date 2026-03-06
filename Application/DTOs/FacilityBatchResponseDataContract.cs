using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FacilityBatchResponseDataContract
    /// </summary>
    public class FacilityBatchResponseDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets Batches
        /// </summary>
        public List<FacilityBatchDataContract> Batches { get; set; }
    }
}