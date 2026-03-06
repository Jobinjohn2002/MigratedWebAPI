using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum CultureIdentifier
    {
        [EnumMember]
        English = 1,
        [EnumMember]
        American = 2,
        [EnumMember]
        Italian = 3,
        [EnumMember]
        Dutch = 4,
        [EnumMember]
        Chinese= 5,
        [EnumMember]
        TestLanguage = 6,
    }
}
