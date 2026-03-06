using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Indicates to the Permission Checking filter how the permissions will be evaluated
    /// </summary>
    public enum PermissionCheck
    {
        /// <summary>
        /// All permissions specified must be granted to the user, e.g. there are 5 different locks requiring 5 keys to open it
        /// </summary>
        RequireAll = 0,
        /// <summary>
        /// Any one of the permissions specified must be granted to the user, e.g. there is one lock, but multiple keys can open it
        /// </summary>
        RequireAny = 1
    }
}
