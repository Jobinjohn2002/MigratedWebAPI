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
    public enum ComplexityTypeIdentifier
    {
        [EnumMember]
        [Description("Level 1")]
        Level1 = 1,

        [EnumMember]
        [Description("Level 2")]
        Level2 = 2,

        [EnumMember]
        [Description("Level 3")]
        Level3 = 3,

        [EnumMember]
        [Description("Level 4")]
        Level4 = 4,

        [EnumMember]
        [Description("Level 5")]
        Level5 = 5,
    }
}
