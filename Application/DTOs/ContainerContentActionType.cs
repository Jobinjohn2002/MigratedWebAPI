using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Enum values that represent actions performed on container components.
    /// </summary>
    /// <remarks>Mark.Gu, 27/02/2012.</remarks>
    public enum ContainerContentActionType
    {
        [EnumMember]
        AddComponent,
        
        [EnumMember]
        RemoveComponent,

        [EnumMember]
        UpdateComponent,
        
        [EnumMember]
        AddNote,

        [EnumMember]
        RemoveNote,

        [EnumMember]
        UpdateNote,

        [EnumMember]
        MoveUp,
        
        [EnumMember]
        MoveDown,

    }
}
