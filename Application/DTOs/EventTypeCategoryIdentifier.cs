using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Enum values that represent autoclave batch status types.
    /// </summary>
    /// <remarks>Dan.maunder, 02/10/2011.</remarks>
    public enum EventTypeCategoryIdentifier
    {
        [EnumMember]
        Normal = 1,
        [EnumMember]
        FailItemEvent = 2,
        [EnumMember]
        FailBatchEvent = 3,
        [EnumMember]
        QuarantineEvent = 4,
    }
}