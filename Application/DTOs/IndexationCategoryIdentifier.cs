using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum IndexationCategoryIdentifier
    {
        [EnumMember]
        Null = 0,
        [EnumMember]
        Reprocessing = 1,
        [EnumMember]
        SingleUse = 2,
        [EnumMember]
        Other = 3,
        [EnumMember]
        ChangeControlNote = 4,
        [EnumMember]
        BarcodeReprint = 5,
        [EnumMember]
        Handwash = 6,
    }
}
