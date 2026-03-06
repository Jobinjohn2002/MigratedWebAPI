using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    public enum DefectResponsibilityIdentifier
    {
        [EnumMember]
        AwaitingResponsibility = 1,
        [EnumMember]
        Synergy = 2,
        [EnumMember]
        Trust = 3,
        [EnumMember]
        Joint = 4,
        [EnumMember]
        Repairs = 5,
        [EnumMember]
        InsufficientInformation = 6,
        [EnumMember]
        Void = 7,
        [EnumMember]
        Customer = 8,
    }
}