using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Flags]
    public enum ChangePasswordResult
    {
        [EnumMember]
        Unknown = 0,
        [EnumMember]
        FailedOnCurrentPasswordRequired = 1,
        [EnumMember]
        FailedOnNewPasswordRequired = 2,
        [EnumMember]
        FailedOnConfirmNewPasswordRequired = 4,
        [EnumMember]
        FailedOnCurrentPasswordInvalid = 8,
        [EnumMember]
        FailedOnNewPasswordMatch = 16,
        [EnumMember]
        FailedOnNewPasswordMatchesCurrent = 32,
        [EnumMember]
        FailedOnNewPasswordComplexity = 64,
        [EnumMember]
        FailedOnNewPasswordReuse = 128,
        [EnumMember]
        FailedOnNewPasswordBreached = 256,
        [EnumMember]
        Success = 512,
        [EnumMember]
        SuccessWithPreviouslyBreachedPassword = 1024,
        [EnumMember]
        DeniedPreviouslyBreachedPassword = 2048

    }
}
