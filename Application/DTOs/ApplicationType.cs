using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum ApplicationType
    {
        [EnumMember]
        Admin = 1,
        [EnumMember]
        SAF = 2,
        [EnumMember]
        Finance = 3,
        [EnumMember]
        Operative = 4
    }
}
