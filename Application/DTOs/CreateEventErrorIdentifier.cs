using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Enum values that represent autoclave batch status types.
    /// </summary>
    /// <remarks>Dan.maunder, 02/10/2011.</remarks>
    public enum CreateEventErrorIdentifier
    {
        [EnumMember]
        Unknow = 0,
        [EnumMember]
        InvalidFacility = 1,
        [EnumMember]
        CustomerOnStop = 2,
        [EnumMember]
        CustomerArchived = 3,
        [EnumMember]
        HasWarnings = 4,
        [EnumMember]
        IndependentQA = 5,
        [EnumMember]
        InvalidNextEvent = 6,
        [EnumMember]
        PackingIndependentQA = 16, 
    }
}