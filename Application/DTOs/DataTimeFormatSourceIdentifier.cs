using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum DateTimeFormatSourceIdentifier
    {
        [EnumMember]
        User = 1,
        [EnumMember]
        Facility = 2,
        [EnumMember]
        Station = 3
    }
}
