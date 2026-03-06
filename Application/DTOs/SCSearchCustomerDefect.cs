using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SCSearchCustomerDefect
    /// </summary>
    public class SCSearchCustomerDefect
    {
        public SCSearchCustomerDefect(int defectId, string externalId, int turnaroundId, long turnaroundExternalId, DateTime raised, string status, string deliveryPoint, string createdUser, string responseInformation)
        {
            DefectId = defectId;
            ExternalId = externalId;
            TurnaroundId = turnaroundId;
            TurnaroundExternalId = turnaroundExternalId;
            Raised = raised;
            Status = status;
            DeliveryPoint = deliveryPoint;
            CreatedUser = createdUser;
            ResponseInformation = responseInformation;
        }
        /// <summary>
        /// Gets or sets DefectId
        /// </summary>
        public int DefectId { get; set; }

        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }

        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public long TurnaroundExternalId { get; set; }

        /// <summary>
        /// Gets or sets Raised
        /// </summary>
        public DateTime Raised { get; set; }

        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public string DeliveryPoint { get; set; }

        /// <summary>
        /// Gets or sets CreatedUser
        /// </summary>
        public string CreatedUser { get; set; }

        /// <summary>
        /// Gets or sets ResponseInformation
        /// </summary>
        public string ResponseInformation { get; set; }
    }
}
