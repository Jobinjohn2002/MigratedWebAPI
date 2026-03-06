using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum ReportCategoryIdentifier
    {
        [EnumMember]
        Dev = 1,
        [EnumMember]
        Operations = 2,
        [EnumMember]
        SynergyCustomer = 3,
        [EnumMember]
        Production = 4,
        [EnumMember]
        Finance = 5,
        [EnumMember]
        Exceptions = 6,
        [EnumMember]
        Quality = 7,
        [EnumMember]
        Setup = 8,
    }
}