using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    using SynergyApplicationFrameworkApi.Application.DTOs.Interfaces.Operative;
    /// <summary>
    /// InstanceTurnaroundEnquiryResponse
    /// </summary>
    public class InstanceTurnaroundEnquiryResponse
    {
        /// <summary>
        /// Gets or sets ItemExternalInstanceId
        /// </summary>
        public string ItemExternalInstanceId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets Found
        /// </summary>
        public bool Found { get; set; }

        /// <summary>
        /// Failed operation
        /// </summary>
        public static InstanceTurnaroundEnquiryResponse Failed(string itemExternalInstanceId)
        {
            return new InstanceTurnaroundEnquiryResponse
                       {
                           Found = false,
                           ItemExternalInstanceId = itemExternalInstanceId
                       };
        }

        /// <summary>
        /// Success operation
        /// </summary>
        public static InstanceTurnaroundEnquiryResponse Success(string itemExternalInstanceId, int turnaroundId)
        {
            return new InstanceTurnaroundEnquiryResponse
                       {
                           Found = true,
                           ItemExternalInstanceId = itemExternalInstanceId,
                           TurnaroundId = turnaroundId
                       };
        }
    }
}