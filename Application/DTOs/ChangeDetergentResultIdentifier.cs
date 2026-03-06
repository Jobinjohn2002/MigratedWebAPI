using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum ChangeDetergentResultIdentifier
    {
        [EnumMember]
        Success = 0,
        [EnumMember]
        UnknownFailure = 1,
        [EnumMember]
        AerRunningFailure = 2,
        [EnumMember]
        MachineGroupAerRunningFailure = 3
    }
}