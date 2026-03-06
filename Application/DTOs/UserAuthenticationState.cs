using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum UserAuthenticationState
    {
        [EnumMember]
        Successful = 0,
        [EnumMember]
        UserDoesnotExist = -1,
        [EnumMember]
        PasswordError = -2,
        [EnumMember]
        LockedOut = -3,
        [EnumMember]
        TooManyFailedPasswordAttempts = -4,
    }
}