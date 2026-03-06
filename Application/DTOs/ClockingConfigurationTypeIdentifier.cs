using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum ClockingConfigurationTypeIdentifier
    {
        [EnumMember]
        Off = 1,
        [EnumMember]
        Enforced = 2,
        [EnumMember]
        Automatic = 3
    }
}
