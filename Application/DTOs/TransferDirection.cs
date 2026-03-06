using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Indicates direction of the transfer rule
    /// </summary>
    public enum TransferDirection
    {
        /// <summary>
        /// Outbound - being sent from the owning facility to a secondary processing facility.
        /// </summary>
        [EnumMember] Outbound = 1,

        /// <summary>
        /// Inbound - being sent back to the owning facility from a secondary processing facility.
        /// </summary>
        [EnumMember] Return = 2
    }
}
