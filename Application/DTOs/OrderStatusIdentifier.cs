using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum OrderStatusIdentifier
    {
        [EnumMember]
        Unknown = 0,
        [EnumMember]
        New = 1,
        [EnumMember]
        InProcess = 2,
        [EnumMember]
        Delivered = 3,
        [EnumMember]
        Archived = 4,
        [EnumMember]
        Cancelled = 5,
        [EnumMember]
        OnHold = 6,
        [EnumMember]
        ReadyForDispatch = 7,
        [EnumMember]
        Dispatched = 8,
        [EnumMember]
        UnmatchedDeliveryPoint = 9
    }
}
