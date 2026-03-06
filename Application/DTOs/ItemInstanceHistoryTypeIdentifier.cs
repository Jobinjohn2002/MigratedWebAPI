using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum ItemInstanceHistoryTypeIdentifier : short
    {
        [EnumMember]
        Created = 1,
        [EnumMember]
        Archived = 2,
        [EnumMember]
        Unarchived = 3,
        [EnumMember]
        Associated = 4,
        [EnumMember]
        Disassociated = 5,
        [EnumMember]
        Audited = 6
    }
}