using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class AuthenticationResultHelper
    {
        public static readonly AccountAuthenticationResult[] InvalidAccountFlags = { AccountAuthenticationResult.AccessDenied, AccountAuthenticationResult.Invalid };
    }
}
