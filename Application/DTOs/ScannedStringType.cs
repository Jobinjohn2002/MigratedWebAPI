using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Indicates the type of string that was scanned.
    /// </summary>
    public enum ScannedStringType
    {
        /// <summary>
        /// The scanned string was not recognised / is invalid.
        /// </summary>
        [EnumMember]
        Invalid = 0,

        /// <summary>
        /// The scanned string is an External Turnaround Id
        /// </summary>
        [EnumMember]
        TurnaroundExternalId,

        /// <summary>
        /// The scanned string is an order number (ORD-XXXXXXX)
        /// </summary>
        [EnumMember]
        OrderNumber
    }
}
