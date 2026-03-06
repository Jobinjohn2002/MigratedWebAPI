using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyBatchHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Batch concreteBatch, Batch genericBatch)
        {
            concreteBatch.BatchId = genericBatch.BatchId;
            concreteBatch.ArchivedUserId = genericBatch.ArchivedUserId;
            concreteBatch.BatchArchiveReasonId = genericBatch.BatchArchiveReasonId;
            concreteBatch.CreatedUserId = genericBatch.CreatedUserId;
            concreteBatch.BatchCycleId = genericBatch.BatchCycleId;
            concreteBatch.BatchFailureReasonId = genericBatch.BatchFailureReasonId;
            concreteBatch.FailedUserId = genericBatch.FailedUserId;
            concreteBatch.MachineId = genericBatch.MachineId;
            concreteBatch.ExternalId = genericBatch.ExternalId;
            concreteBatch.Created = genericBatch.Created;
            concreteBatch.Started = genericBatch.Started;
            concreteBatch.Failed = genericBatch.Failed;
            concreteBatch.Archived = genericBatch.Archived;
            concreteBatch.LegacyId = genericBatch.LegacyId;
            concreteBatch.LegacyFacilityOrigin = genericBatch.LegacyFacilityOrigin;
            concreteBatch.LegacyImported = genericBatch.LegacyImported;
            concreteBatch.BatchStatusId = genericBatch.BatchStatusId;
            concreteBatch.BatchReleasedUserId = genericBatch.BatchReleasedUserId;
        }
    }
}