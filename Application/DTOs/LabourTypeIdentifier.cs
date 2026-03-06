using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    public enum LabourTypeIdentifier
    {
        [EnumMember]
        [Description("None")]
        None = 1,

            
        [EnumMember]
        [Description("Light")]
        Light = 2,

        [EnumMember]
        [Description("Medium")]
        Medium = 3,

        [EnumMember]
        [Description("Heavy")]
        Heavy = 4,
    }
}
