using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum CategoryIdentifier
    {
        [EnumMember]
        Temp = 1,
        [EnumMember]
        Instruments = 2,
        [EnumMember]
        Identification = 3,
        [EnumMember]
        ContainersInserts = 4,
        [EnumMember]
        Consumables = 5,
        [EnumMember]
        Wraps = 6,
        [EnumMember]
        Holloware = 7,
        [EnumMember]
        Notes = 8
    }
}