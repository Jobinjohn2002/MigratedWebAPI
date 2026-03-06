using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum UserCategory
    {

        [EnumMember]
        All = 0,

        [EnumMember]
        Operative = 1,

        [EnumMember]
        Administration = 2,

        [EnumMember]
        Management = 3,

        [EnumMember]
        Finance = 4,

        [EnumMember]
        IT = 5,

        [EnumMember]
        Customer = 6,

        [EnumMember]
        Quality = 7,

        [EnumMember]
        Commercial = 8,

        [EnumMember]
        Supervisor = 9,

        [EnumMember]
        HR = 10,

        [EnumMember]
        Agency = 11,
    }
}
