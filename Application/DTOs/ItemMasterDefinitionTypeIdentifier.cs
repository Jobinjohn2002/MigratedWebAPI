using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum ItemMasterDefinitionTypeIdentifier
    {
        [EnumMember]
        [Description("Reprocessing")]
        Reprocessing = 1,

        [EnumMember]
        [Description("Blueprint")]
        Blueprint = 2,
    }
}
