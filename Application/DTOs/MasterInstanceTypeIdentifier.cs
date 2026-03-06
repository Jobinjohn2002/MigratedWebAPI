using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    public enum MasterInstanceTypeIdentifier
    {
        [EnumMember]
        None = 0,
        [EnumMember]
        Container = 1,
        [EnumMember]
        Component = 2
    }
}
