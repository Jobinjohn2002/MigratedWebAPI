using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// MasterIdTypeIdentifier enum
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    public enum MasterIdTypeIdentifier
    {
        [EnumMember]
        Guid = 1,
        [EnumMember]
        LegacyId = 2
    }
}