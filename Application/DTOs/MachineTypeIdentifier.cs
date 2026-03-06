using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    public enum MachineTypeIdentifier
    {
        [EnumMember]
        Autoclave = 1,
        [EnumMember]
        Washer = 2,
        [EnumMember]
        WasherCarriage = 3,
        [EnumMember]
        TrolleyWasher = 4,
        [EnumMember]
        SuperUltrasound = 5,
        [EnumMember]
        SuperUltraSound2 = 6,
        [EnumMember]
        HandWash= 7,
        [EnumMember]
        CarriageWasher = 8,
        [EnumMember]
        Post1997Washer = 12,

        [EnumMember]
        Aer = 50,
        [EnumMember]
        DryingCabinet = 51,
        [EnumMember]
        VacuumPacker = 52
    }
}