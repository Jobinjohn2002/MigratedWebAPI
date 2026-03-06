using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum DateTimeFormatIdentifier
    {
        [EnumMember]
        ShorDate = 1,
        [EnumMember]
        Shorttime = 2,
        [EnumMember]
        LongDate = 3,
        [EnumMember]
        LongTime = 4,
        [EnumMember]
        ShortDatetime = 5,
        [EnumMember]
        LongDateTime = 6
    }
}
