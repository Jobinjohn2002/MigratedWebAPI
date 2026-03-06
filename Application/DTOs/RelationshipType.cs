using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Indicates the type of relationship
    /// </summary>
    public enum RelationshipType
    {
        /// <summary>
        /// Unknown, this is the default, but also should never be seen.
        /// </summary>
        [EnumMember] Unknown = 0,

        /// <summary>
        /// The destination is a primary facility you are an alternate processing facility for.
        /// </summary>
        [EnumMember] PrimaryFacility = 1,

        /// <summary>
        /// The destination is an alternate processing facility and you are the primary facility.
        /// </summary>
        [EnumMember] AlternateFacility = 2,

        /// <summary>
        /// The destination is an alternate processing facility for one of your primary facilities, you are also an alternate processing facility.
        /// </summary>
        [EnumMember] ProxyFacility = 3
    }
}
