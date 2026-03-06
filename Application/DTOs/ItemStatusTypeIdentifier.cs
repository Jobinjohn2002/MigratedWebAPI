using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public enum ItemStatusTypeIdentifier
    {
        [EnumMember]
        Active = 1,
        [EnumMember]
        Retired = 2,
        [EnumMember]
        Draft = 3,
        [EnumMember]
        Archived = 4,
        [EnumMember]
        Unarchive = 5
    }
}