using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// This Enum class only contains the printer type which is selectable.
    /// </summary>
    /// <remarks></remarks>
    public enum CustomerDefectReasonTypeIdentifier : byte
    {
        [EnumMember]
        MissingInstrument=13,

        [EnumMember]
        WrongItemonTray=6,

        [EnumMember]
        DamagedItemRequiringRepair=9,

        [EnumMember]
        UnacceptableCondition=2,

        [EnumMember]
        Quarantine = 8,
    }
}
