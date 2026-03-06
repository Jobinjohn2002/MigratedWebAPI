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
    public enum PrinterTypeIdentifier
    {
        [EnumMember]
        Default = 1,
        [EnumMember]
        Intermec = 2,
        [EnumMember]
        PTouch = 3,
    }
}