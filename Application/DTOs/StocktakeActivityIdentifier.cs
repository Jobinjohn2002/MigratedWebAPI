using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum StocktakeActivityIdentifier
    {
        [EnumMember]
        ConfirmedPresent = 1,

        [EnumMember]
        Added = 2,

        [EnumMember]
        Missing = 3,
    }
}
