using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
	public sealed partial class FailedBatchData
	{
		public FailedBatchData(IFailedBatch genericObj, int batchId, string failureReason, string batchExternalId)
			: this(genericObj)
		{
			BatchId = batchId;
			FailureReason = failureReason;
            BatchExternalId = batchExternalId;
		}
		/// <summary>
		/// Gets or sets FailureReason
		/// </summary>
		public string FailureReason { get; set; }
        /// <summary>
        /// Gets or sets BatchExternalId
        /// </summary>
        public string BatchExternalId { get; set; }
	}
}
