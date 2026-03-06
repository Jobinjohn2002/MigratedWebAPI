using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum PictureType
    {
        [Description("None")]
        [EnumMember]
        None = 0,
        [Description("Container")]
        [EnumMember]
        ContainerMaster = 1,
        [Description("Item")]
        [EnumMember]
        ItemMaster = 2,
        [Description("Container Instance")]
        [EnumMember]
        ContainerInstance = 3,
        [Description("Item Instance")]
        [EnumMember]
        ItemInstance = 4,
        [Description("Defect")]
        [EnumMember]
        Defect = 5,
        [Description("Batch")]
        [EnumMember]
        Batch = 6
    }
}
