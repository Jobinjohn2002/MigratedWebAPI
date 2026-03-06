using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustomerDefectStatusIdentifier
    /// </summary>
    /// <remarks></remarks>
    public enum CustomerDefectStatusIdentifier:byte
    {
        /// <summary>
        /// CustomerDefectCreated
        /// </summary>
        [EnumMember]
        CustomerDefectCreated = 1,

        /// <summary>
        /// CustomerDefectRaised
        /// </summary>
        [EnumMember]
        CustomerDefectRaised = 2,

        /// <summary>
        /// CustomerRespondedDirectly
        /// </summary>
        [EnumMember]
        CustomerRespondedDirectly = 3,

        /// <summary>
        /// CustomerRespondedIndirectly
        /// </summary>
        [EnumMember]
        CustomerRespondedIndirectly = 4,

        /// <summary>
        /// CustomerRespondedLate
        /// </summary>
        [EnumMember]
        CustomerRespondedLate = 5,

        /// <summary>
        /// CustomerResponseRequested
        /// </summary>
        [EnumMember]
        CustomerResponseRequested = 6,

        /// <summary>
        /// CustomerResponded
        /// </summary>
        [EnumMember]
        CustomerResponded = 7,

        /// <summary>
        /// Closed
        /// </summary>
        [EnumMember]
        Closed = 8,
        /// <summary>
        /// ReOpen
        /// </summary>
        [EnumMember]
        ReOpen = 10,

        /// <summary>
        /// Void
        /// </summary>
        [EnumMember]
        Void = 11,

        /// <summary>
        /// ResponseSaved
        /// </summary>
        [EnumMember]
        ResponseSaved = 12,

        /// <summary>
        /// TurnaroundRemoved
        /// </summary>
        [EnumMember]
        TurnaroundRemoved = 13,
    }
}
