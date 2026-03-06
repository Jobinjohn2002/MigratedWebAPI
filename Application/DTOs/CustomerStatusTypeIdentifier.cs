using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Customer status types enum
    /// </summary>
    /// <remarks></remarks>
    public enum CustomerStatusTypeIdentifier
    {
        [EnumMember]
        Active = 1,
        [EnumMember]
        Stop = 2,
        [EnumMember]
        Retired = 3,
        [EnumMember]
        Archived = 4,
        [EnumMember]
        RetiredOnStop = 5
    }
}