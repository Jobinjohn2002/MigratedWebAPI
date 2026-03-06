using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum KnownPrintType
    {
        [EnumMember]
        Normal = 0,
        [EnumMember]
        TurnaroundLabel = 1,
        [EnumMember]
        InstanceLabel = 2,
        [EnumMember]
        TwoDBarcodeInstanceLabel = 3,
        [EnumMember]
        PackListLabel = 4,
        [EnumMember]
        UserTag = 5,
        [EnumMember]
        DeliveryPointTag = 6,
        [EnumMember]
        ExsudexBarcode = 7,
        [EnumMember]
        Report = 8,
        [EnumMember]
        StationLabel = 9,
        [EnumMember]
        CombinedBarcodeInstanceLabel = 10,
    }
}
