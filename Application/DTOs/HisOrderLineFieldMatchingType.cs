using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum HisOrderLineFieldMatchingType : short
    {
        [EnumMember]
        None = 0,
        [EnumMember]
        ProductNumber = 1,
        [EnumMember]
        ContainerMasterExternalID = 2,
        [EnumMember]
        Name = 3,
        [EnumMember]
        ManufacturersReference = 4
    }
}