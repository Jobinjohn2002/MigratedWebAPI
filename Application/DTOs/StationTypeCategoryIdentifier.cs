using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum  StationTypeCategoryIdentifier
    {
        [EnumMember]
        Root = 1,
        [EnumMember]
        Operative = 2,
        [EnumMember]
        CleanRoom = 3,
        [EnumMember]
        Decontamination = 4,
        [EnumMember]
        Dispatch = 5,
        [EnumMember]
        Admin = 6,
        [EnumMember]
        Mobile = 8,

        [EnumMember]
        Endoscopy = 50
    }
}
