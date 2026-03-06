using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    public enum ItemSubtypeIdentifier
    {
        [EnumMember]
        Unknown = 0,
        [EnumMember]
        ContainerMaster = 1,
        [EnumMember]
        ItemMaster = 2,
    }
}
