using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum EntityType
    {
        [EnumMember]
        DeliveryPoint,

        [EnumMember]
        Customer,

        [EnumMember]
        CustomerDefects,

        [EnumMember]
        FastTrack,

        [EnumMember]
        OverdueItem,

        [EnumMember]
        Facility,

        [EnumMember]
        Station,

        [EnumMember]
        Item,

        [EnumMember]
        Container,

        [EnumMember]
        Instance,

        [EnumMember]
        Turnarounds,

        [EnumMember]
        Defects,

        [EnumMember]
        User,

        [EnumMember]
        Production
    }
}
