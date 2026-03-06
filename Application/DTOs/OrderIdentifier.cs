using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum OrderIdentifier
    {
        [EnumMember]
        StatusNew = 1,

        [EnumMember]
        Picked = 2,

        [EnumMember]
        Delivered = 3,

        [EnumMember]
        Cancelled = 5,

        [EnumMember]
        ReadyForDispatch = 7,

        [EnumMember]
        Dispatched = 8,
    }
}
