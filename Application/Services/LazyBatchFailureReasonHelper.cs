using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyBatchFailureReasonHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(BatchFailureReason concreteBatchFailureReason,
                                     BatchFailureReason genericBatchFailureReason)
        {
            concreteBatchFailureReason.BatchFailureReasonId = genericBatchFailureReason.BatchFailureReasonId;
            concreteBatchFailureReason.Text = genericBatchFailureReason.Text;
            concreteBatchFailureReason.LegacyFacilityOrigin = genericBatchFailureReason.LegacyFacilityOrigin;
            concreteBatchFailureReason.LegacyImported = genericBatchFailureReason.LegacyImported;
        }
    }
}