using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum PulseTypeIdentifier : byte
    {
        [EnumMember]
        Positive = 1,
        [EnumMember]
        Negative = 0,
    }
}
