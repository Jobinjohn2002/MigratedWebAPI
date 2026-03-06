using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum MachineEventTypeIdentifier
    {
        [EnumMember]
        UnAvailable = 1,
        [EnumMember]
        Available = 2,
    }
}