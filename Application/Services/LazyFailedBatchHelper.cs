using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyFailedBatchHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(FailedBatch concreteFailedBatch, FailedBatch genericFailedBatch)
        {
            concreteFailedBatch.FailedBatchId = genericFailedBatch.FailedBatchId;
            concreteFailedBatch.BatchId = genericFailedBatch.BatchId;
            concreteFailedBatch.CreatedUserId = genericFailedBatch.CreatedUserId;
            concreteFailedBatch.FailureTypeId = genericFailedBatch.FailureTypeId;
            concreteFailedBatch.Created = genericFailedBatch.Created;
        }
    }
}