using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// MLDDuplicateInstancesModel
    /// </summary>
    public class MLDDuplicateInstancesModel
    {
        /// <summary>
        /// Gets or sets IsCurrentlyAtSPD
        /// </summary>
        public bool IsCurrentlyAtSPD { get; set; }

        /// <summary>
        /// Gets or sets HasBeenToCustomer
        /// </summary>
        public bool HasBeenToCustomer { get; set; }

        /// <summary>
        /// Gets or sets LoanStatusId
        /// </summary>
        public short LoanStatusId { get; set; }

        /// <summary>
        /// Gets or sets LoanKitExternalId
        /// </summary>
        public string LoanKitExternalId { get; set; }

        /// <summary>
        /// Gets or sets BatchId
        /// </summary>
        public int BatchId { get; set; }

        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }

        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public int ContainerInstanceId { get; set; }

        /// <summary>
        /// Gets or sets ContainerInstanceExternalId
        /// </summary>
        public string ContainerInstanceExternalId { get; set; }

        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }

        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public int ItemTypeId { get; set; }

        /// <summary>
        /// Gets or sets EarliestProcedureDate
        /// </summary>
        public DateTime EarliestProcedureDate { get; set; }

        /// <summary>
        /// Gets or sets MinimumReprocessingTime
        /// </summary>
        public string MinimumReprocessingTime { get; set; }

        public int? MinimumReprocessingTimeParsed
        {
            get
            {
                if (string.IsNullOrEmpty(MinimumReprocessingTime)) return null;
                if (!int.TryParse(MinimumReprocessingTime, out var parsedVal)) return null;
                return parsedVal;
            }
        }
    }
}