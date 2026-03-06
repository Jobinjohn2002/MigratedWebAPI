using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum DeliveryPointTypeIdentifier
    {
        [EnumMember]
        Theatre = 0,
        [EnumMember]
        Ward = 1,
        [EnumMember]
        Clinic = 2,
        [EnumMember]
        Store = 3,
        [EnumMember]
        Hospital = 4,
        [EnumMember]
        HealthCentre = 5,
        [EnumMember]
        Surgery = 6,
        [EnumMember]
        Archived = 7
    }
}
