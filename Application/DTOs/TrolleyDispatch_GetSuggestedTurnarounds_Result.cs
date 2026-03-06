using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class TrolleyDispatch_GetSuggestedTurnarounds_Result
    {
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterName
        /// </summary>
        public string ContainerMasterName { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public long TurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementName
        /// </summary>
        public string ServiceRequirementName { get; set; }
        /// <summary>
        /// Gets or sets IsFastTrack
        /// </summary>
        public Nullable<bool> IsFastTrack { get; set; }
        public Nullable<System.DateTime> Expiry { get; set; }
        /// <summary>
        /// Gets or sets BatchExternalID
        /// </summary>
        public string BatchExternalID { get; set; }
        public Nullable<System.DateTime> BatchPassedDateTime { get; set; }
        /// <summary>
        /// Gets or sets IsSupplementary
        /// </summary>
        public bool IsSupplementary { get; set; }
        /// <summary>
        /// Gets or sets IsTray
        /// </summary>
        public bool IsTray { get; set; }
        /// <summary>
        /// Gets or sets IsExtra
        /// </summary>
        public bool IsExtra { get; set; }
    }
}
