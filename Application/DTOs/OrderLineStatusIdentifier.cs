using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum OrderLineStatusIdentifier
    {
        [EnumMember]
        Ordered	= 1,

        [EnumMember]
        Picked	= 2,

        [EnumMember]
        InsufficientStock = 3,

        [EnumMember]
        DamagedStock = 4,

        [EnumMember]
        WetPackaging = 5,

        [EnumMember]
        TurnaroundExpired = 6,

        [EnumMember]
        StockStillInProcess = 7,

        [EnumMember]
        NotPickedInTime = 8,

        [EnumMember]
        Cancelled = 9,

        [EnumMember]
        NotAtLocation = 10,

        [EnumMember]
        Delivered = 11,

        [EnumMember]
        CancelledByPartDispatch = 12,
    }
}
