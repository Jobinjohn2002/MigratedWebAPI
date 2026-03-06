using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public sealed partial class BatchSterilisationTestReportData
    {
        public BatchSterilisationTestReportData()
        {
        }
        /// <summary>
        /// Gets or sets BatchCycleType
        /// </summary>
        public string BatchCycleType { get; set; }
        /// <summary>
        /// Gets or sets CycleNumber
        /// </summary>
        public string CycleNumber { get; set; }
        /// <summary>
        /// Gets or sets BatchStatusText
        /// </summary>
        public string BatchStatusText { get; set; }

        /// <summary>
        /// To identify the batch is test batch or production batch
        /// </summary>
        /// <summary>
        /// Gets or sets IsChargeable
        /// </summary>
        public bool IsChargeable { get; set; }

        /// <summary>
        /// To identify the batch is archived or not.
        /// </summary>
        /// <summary>
        /// Gets or sets IsBatchArchived
        /// </summary>
        public bool IsBatchArchived { get; set; }

        /// <summary>
        /// To identify the Batch Released By for a batch.
        /// </summary>
        /// <summary>
        /// Gets or sets BatchReleasedBy
        /// </summary>
        public string BatchReleasedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets BITestPerformed
        /// </summary>
        public bool BITestPerformed { get; set; }
	}
}
		