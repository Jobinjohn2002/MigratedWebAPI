using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum ScanType : short
    {
        [EnumMember]
        ContainerInstance = 1,
        
        [EnumMember]
        ItemInstance = 2,

        [EnumMember]
        Turnaround = 3,

        [EnumMember]
        Station = 4,

        [EnumMember]
        DeliveryNote = 5,

        [EnumMember]
        Trolley = 6,

        [EnumMember]
        Enquire = 7,

        [EnumMember]
        Location = 8,

        [EnumMember]
        Order = 9,

    }
}
