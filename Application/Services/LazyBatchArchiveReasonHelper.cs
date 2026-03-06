using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyBatchArchiveReasonHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(BatchArchiveReason concreteBatchArchiveReason,
                                     BatchArchiveReason genericBatchArchiveReason)
        {
            concreteBatchArchiveReason.BatchArchiveReasonId = genericBatchArchiveReason.BatchArchiveReasonId;
            concreteBatchArchiveReason.Text = genericBatchArchiveReason.Text;
            concreteBatchArchiveReason.LegacyFacilityOrigin = genericBatchArchiveReason.LegacyFacilityOrigin;
            concreteBatchArchiveReason.LegacyImported = genericBatchArchiveReason.LegacyImported;
        }
    }
}