using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{

    [Serializable]
    public enum AuditResultTypeIdentifier
    {
        [EnumMember]
        CompletedWithoutExceptions = 1,
        [EnumMember]
        CompletedWithExceptions = 2,
        [EnumMember]
        Cancelled = 3,
        ManualFail = 4

    }
}
