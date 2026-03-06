using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum FormatTypeIdentifier
    {
        [EnumMember]
        LongDateFormat=2,
        [EnumMember]
        LongTimeFormat=4,
        [EnumMember]
        ShortDateFormat=1,
        [EnumMember]
        ShortTimeFormat=3,
        
    }
}
