using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum AerStatus
    {
        [EnumMember]
        Ready,

        [EnumMember]
        Loading,

        [EnumMember]
        Washing,

        [EnumMember]
        WashComplete,

        [EnumMember]
        OutOfService,

        [EnumMember]
        RunningDisinfectionCycle,

        [EnumMember]
        RunningTestCycle
    }
}
