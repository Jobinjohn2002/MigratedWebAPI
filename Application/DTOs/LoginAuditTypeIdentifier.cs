using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum LoginAuditTypeIdentifier
    {
        [EnumMember]
        AccessDenied = 0,

        [EnumMember]
        PasswordExpired = 1,

        [EnumMember]
        Success = 2,

        [EnumMember]
        PinExpired = 3,

        [EnumMember]
        NoFacilities = 4,

        [EnumMember]
        IncorrectUsernamePassword = 5,

        [EnumMember]
        TooManyAttempts = 6,

        [EnumMember]
        InsufficientComplexity = 7,

        [EnumMember]
        StrictPolicyOldPasswordReused = 8,

        [EnumMember]
        SuccessWithPreviouslyBreachedPassword = 9,

        [EnumMember]
        DeniedPreviouslyBreachedPassword = 10,

        [EnumMember]
        PasswordResetExpired = 11
    }
}
