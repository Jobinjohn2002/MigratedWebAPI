using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// HISOrderCancellationRequest
    /// </summary>
    public class HISOrderCancellationRequest
    {
        /// <summary>
        /// The Synergy CustomerDefinitionId that this order is for.
        /// </summary>
        [Required]
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }

        /// <summary>
        /// Your reference number for the order, e.g. your internal system reference number to link to this record.
        /// </summary>
        [Required]
        [MaxLength(HISOrderRequest.MAX_YOUR_REFERENCE_LENGTH)]
        /// <summary>
        /// Gets or sets YourReference
        /// </summary>
        public string YourReference { get; set; }

        /// <summary>
        /// Your unique code to identify this individual communications message
        /// </summary>
        [Required]
        [MaxLength(HISOrderRequest.MAX_YOUR_MESSAGE_REFERENCE_LENGTH)]
        /// <summary>
        /// Gets or sets YourMessageReference
        /// </summary>
        public string YourMessageReference { get; set; }
    }
}
