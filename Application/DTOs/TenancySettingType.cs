using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    public enum TenancySettingType
    {
        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        Unknown = 0,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        String = 1,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        Bool = 2,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        Int = 3,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember]
        Decimal = 4,
    }
}
