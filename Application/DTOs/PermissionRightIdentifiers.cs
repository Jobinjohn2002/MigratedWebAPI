using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Available rights for permission areas and assigned rights
    /// </summary>
    /// <remarks>
    /// The enum can work as a bitmask as it has the Flags.  
    /// To combine and examine the bitmask check the example provided.
    /// </remarks>
    /// <example>
    /// <code>
    /// // assigning the read and update rights to a bitmask variable
    ///var rights = PermissionRights.Read | PermissionRights.Update;

    ///             // checking for the update right in code
    ///             if((rights & PermissionRights.Update) == PermissionRights.Update) {
    ///                // has update rights
    ///                ...
    ///             }
    ///            else {
    ///                // does not have update rights
    ///               ...
    ///             }
    /// </code>
    /// </example>
    [Flags]
    public enum PermissionRightIdentifiers
    {
        [EnumMember]
        None = 0x0,

        [EnumMember]
        Create = 0x1,

        [EnumMember]
        Read = 0x2,

        [EnumMember]
        Update = 0x4,

        [EnumMember]
        Delete = 0x8
    }
}