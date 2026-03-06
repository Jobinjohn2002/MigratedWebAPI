using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class TrolleyDispatch_GetTrolleySummary_Result
    {
        /// <summary>
        /// Gets or sets TrolleyName
        /// </summary>
        public string TrolleyName { get; set; }
        /// <summary>
        /// Gets or sets TrolleyInstancePrimaryId
        /// </summary>
        public string TrolleyInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets TrolleyInstanceId
        /// </summary>
        public int TrolleyInstanceId { get; set; }
        /// <summary>
        /// Gets or sets TrolleyTurnaroundExternalID
        /// </summary>
        public Nullable<long> TrolleyTurnaroundExternalID { get; set; }
        /// <summary>
        /// Gets or sets LastEventTypeId
        /// </summary>
        public Nullable<short> LastEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public Nullable<int> CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public Nullable<int> TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets HasTurnaroundEnded
        /// </summary>
        public Nullable<bool> HasTurnaroundEnded { get; set; }
        /// <summary>
        /// Gets or sets NextEvent
        /// </summary>
        public string NextEvent { get; set; }
        /// <summary>
        /// Gets or sets TrolleyContainerMasterId
        /// </summary>
        public int TrolleyContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public int ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets OwnerFacilityId
        /// </summary>
        public int OwnerFacilityId { get; set; }
        /// <summary>
        /// Gets or sets ProcessingFacilityId
        /// </summary>
        public Nullable<int> ProcessingFacilityId { get; set; }
        /// <summary>
        /// Gets or sets IsOwner
        /// </summary>
        public bool IsOwner { get; set; }
        /// <summary>
        /// Gets or sets CanProcessForMFPCustomer
        /// </summary>
        public bool CanProcessForMFPCustomer { get; set; }
        /// <summary>
        /// Gets or sets CanProcessForAnyCustomerFacility
        /// </summary>
        public bool CanProcessForAnyCustomerFacility { get; set; }
    }
}
