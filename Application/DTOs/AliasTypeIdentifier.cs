using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum AliasTypeIdentifier
    {
        [EnumMember]
        CustomerGroup = 1,
        [EnumMember]
        Customer = 2,
        [EnumMember]
        ItemMaster = 3,
    }
}
