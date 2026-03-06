using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum BatchStatusIdentifier
    {
        [EnumMember]
        [Description("In Progress")]
        InProgress = 1,

        [EnumMember]
        [Description("Passed")]
        Passed = 2,

        [EnumMember]
        [Description("Failed")]
        Failed = 3,

        [EnumMember]
        [Description("Archived")]
        Archived = 4,

        [EnumMember]
        [Description("Cancel")]
        Cancel = 0
    }
}
