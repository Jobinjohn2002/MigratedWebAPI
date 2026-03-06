using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// SCSearchCustomerDefectData
    /// </summary>
    public class SCSearchCustomerDefectData
    {
        public SCSearchCustomerDefectData()
        {
        }

        public SCSearchCustomerDefectData(ISCSearchCustomerDefect defect)
        {
            DefectId = defect.DefectId;
            ExternalId = defect.ExternalId;
            TurnaroundId = defect.TurnaroundId;
            TurnaroundExternalId = defect.TurnaroundExternalId;
            Raised = defect.Raised;
            Status = defect.Status;
            DeliveryPoint = defect.DeliveryPoint;
            CreatedUser = defect.CreatedUser;
            ResponseInformation = defect.ResponseInformation;
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
