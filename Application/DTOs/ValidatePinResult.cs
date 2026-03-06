using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    public enum ValidatePinResult
    {
        [EnumMember]
        [Description("User not found.")]
        NoUserFound,
        [EnumMember]
        [Description("Password entered incorrectly.")]
        IncorrectPin,
        [EnumMember]
        [Description("Your user account has been locked because you failed to enter a correct password after 3 attempts.")]
        Lockout,
        [EnumMember]
        [Description("Successfully validated Password.")]
        CorrectPin

    }
}
