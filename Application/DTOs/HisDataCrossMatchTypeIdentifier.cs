using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum HisDataCrossMatchTypeIdentifier : short
    {
        [EnumMember]
        ContainerMaster = 1,
        [EnumMember]
        Procedure = 2,
        [EnumMember]
        DeliveryPoint = 3,
        [EnumMember]
        Surgeon = 4
    }
}
