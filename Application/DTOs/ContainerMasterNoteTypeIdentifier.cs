using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Enum values that represent autoclave batch failure reason types.
    /// </summary>
    /// <remarks>Mark.Gu, 27/02/2012.</remarks>
    public enum ContainerMasterNoteTypeIdentifier
    {
        [EnumMember]
        General = 1,
        [EnumMember]
        Operational = 2,
    }
}