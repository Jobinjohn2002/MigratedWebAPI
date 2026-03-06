using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    using SynergyApplicationFrameworkApi.Application.DTOs.Interfaces.Operative;
    /// <summary>
    /// TurnaroundEnquiryResponse
    /// </summary>
    public class TurnaroundEnquiryResponse
    {
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public long ExternalId { get; set; }
        /// <summary>
        /// Gets or sets Exists
        /// </summary>
        public bool Exists { get; set; }

        /// <summary>
        /// Failed operation
        /// </summary>
        public static TurnaroundEnquiryResponse Failed(long externalId)
        {
            return new TurnaroundEnquiryResponse { Exists = false, ExternalId = externalId };
        }

        /// <summary>
        /// Success operation
        /// </summary>
        public static TurnaroundEnquiryResponse Success(int turnaroundId, long externalId)
        {
            return new TurnaroundEnquiryResponse { Exists = true, TurnaroundId = turnaroundId, ExternalId = externalId };
        }
    }
}
