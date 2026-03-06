using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum CommunicationTypeIdentifier
    {
        [EnumMember]
        Print = 1,
        [EnumMember]
        PrintLabel = 2,
        [EnumMember]
        Email = 3,
        [EnumMember]
        SMS = 4
    }
}
