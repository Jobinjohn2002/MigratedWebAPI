using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum GroupTurnaroundsBy
    {
        [EnumMember]
        Null = 0,
        [EnumMember]
        BaseType = 1,
        [EnumMember]
        ServiceRequirement = 2,
    }
}
