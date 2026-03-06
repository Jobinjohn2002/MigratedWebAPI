using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum ClockingEventTypeIdentifier
    {
        [EnumMember]
        ClockIn = 1,
        [EnumMember]
        ClockOut = 2,
        [EnumMember]
        ToggleState = 3,
    }
}
